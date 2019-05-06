using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.Utils;
using De.Kjg.Diversity.Unity.Debug.Remote.Transfer;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Server
{
    class DebugServerMonoBehaviour : MonoBehaviour
    {
        protected List<string> ReceivedChunks = new List<string>();
        protected List<RemoteRenderCommand> RemoteCommands = new List<RemoteRenderCommand>();

        protected GUISkin ServerSkin;
        protected DebugServerRenderer ServerRenderer;
        protected DebugServerHardware ServerHardware;

        protected bool ReceivedCommands;

        public void StartServer(int port, bool useNat)
        {
            Network.InitializeServer(10, port, useNat);
            ServerHardware = new DebugServerHardware();
        }

        public void SetServerGuiSkin(GUISkin guiSkin)
        {
            ServerSkin = guiSkin;
            ServerRenderer = new DebugServerRenderer(ServerSkin.ToSkin());
        }

        public void OnGUI()
        {
            if (GetNumConnections() > 0)
            {
                if (ServerHardware == null)
                {
                    ServerHardware = new DebugServerHardware();
                }
                if (ServerRenderer == null)
                {
                    ServerRenderer = new DebugServerRenderer(ServerSkin.ToSkin());
                }

                ServerHardware.CollectData();

                if (ServerRenderer != null)
                {
                    ServerRenderer.RenderCommands(RemoteCommands);

                    if (ReceivedCommands)
                    {
                        ReceivedCommands = false;

                        SendHardwareData();
                        ServerHardware.Reset();
                    }
                }
            }
        }

        public int GetNumConnections()
        {
            return Network.connections.Length;
        }
            
        [RPC]
        public void RpcRenderDataStart()
        {
            ReceivedChunks.Clear();
        }

        [RPC]
        public void RpcRenderData(string chunk)
        {
            ReceivedChunks.Add(chunk);
        }

        [RPC]
        public void RpcRenderDataEnd()
        {
            ParseReceivedCommands();

            ReceivedCommands = true;
        }
        
        [RPC]
        public void RpcHardwareData(string data)
        {
            // nothing to do here - receiving code is on the client side
        }

        [RPC]
        public void RpcPing(string param)
        {
            UnityEngine.Debug.Log(param);
        }

        protected void ParseReceivedCommands()
        {
            var combined = StringUtil.Join(ReceivedChunks, "");

            var bFormatter = new XmlSerializer(typeof(List<RemoteRenderCommand>), new[]
                {
                    typeof(RemoteRenderCommand),
                    typeof(Rectangle),
                    typeof(Point),
                    typeof(RgbaColor)
                });


            using (var reader = new StringReader(combined))
            {
                RemoteCommands = (List<RemoteRenderCommand>)bFormatter.Deserialize(reader);
            }
        }

        protected void SendHardwareData()
        {
            var bFormatter = new XmlSerializer(typeof(HardwareData), new[]
                {
                    typeof(Point)
                });

            string str;

            using (var writer = new StringWriter())
            {
                bFormatter.Serialize(writer, ServerHardware.GetCollectedData());
                str = writer.ToString();
            }

            networkView.RPC("RpcHardwareData", RPCMode.Others, str);
        }
    }
}
