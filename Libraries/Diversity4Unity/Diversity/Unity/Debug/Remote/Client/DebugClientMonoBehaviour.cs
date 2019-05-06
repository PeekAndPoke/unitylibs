using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.Utils;
using De.Kjg.Diversity.Unity.Debug.Remote.Transfer;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Client
{
    class DebugClientMonoBehaviour : MonoBehaviour
    {
        protected List<RemoteRenderCommand> RemoteCommands = new List<RemoteRenderCommand>();

        private GuiStage _remoteStage = new GuiStage();
        private readonly DebugClientHardware _debugHardware = new DebugClientHardware();
        private readonly DebugClientRenderer _debugRenderer = new DebugClientRenderer();

        private int _a;

        public void ConnectToServer(string ip, int port)
        {
            if (!IsConnected())
            {
                Network.Connect(ip, port);
            }
        }

        public void DisconnectFromServer()
        {
            if (IsConnected())
            {
                Network.Disconnect();
            }
        }

        public bool IsConnected()
        {
            return Network.peerType == NetworkPeerType.Client;
        }

        public void SetRemoteStage(GuiStage stage)
        {
            _remoteStage = stage;
        }

        private DateTime _last = DateTime.Now;

        public void OnGUI()
        {
            if (IsConnected())
            {
                if (_a++ % 1000 == 0)
                {
                    networkView.RPC("RpcPing", RPCMode.Others, "Ping " + _a);
                }

                // TODO: The next line is neccessary to see the overlays on the element under the mouse,
                //       because we need to call DebugWindow.Draw on every OnGUI() which is not done in Remote-Mode.
                //       -> that is not very nice because it eats performance. There is a better solution.
                _remoteStage.Render(_debugRenderer);

                if ((DateTime.Now - _last).TotalMilliseconds > 66)
                {
                    _last = DateTime.Now;
                    Render();
                }
            }
        }


        public void Render()
        {
            // Layout
            _remoteStage.CalculateLayout(_debugHardware);
            _remoteStage.ProcessInteraction(_debugHardware);

            // Render and Record Commands
            _debugRenderer.Begin();
            _remoteStage.Render(_debugRenderer);
            _debugRenderer.Finish();

            // Send commands to Server
            RenderRemote(_debugRenderer.GetRecordedCOmmands());
        }


        public void RenderRemote(List<RemoteRenderCommand> renderCommands)
        {
            if (IsConnected())
            {
                // UnityEngine.Debug.Log("/////////////////////////////////////////////////////////////////////////////////////\n/////////////////////////////////////////////////////////////////////////////////////");

                var bFormatter = new XmlSerializer(typeof(List<RemoteRenderCommand>), new[]
                {
                    typeof(RemoteRenderCommand),
                    typeof(Rectangle),
                    typeof(Point),
                    typeof(RgbaColor)
                });

                string str;

                using (var writer = new StringWriter())
                {
                    bFormatter.Serialize(writer, renderCommands);
                    str = writer.ToString();
                }

                var chunks = StringUtil.ToChunks(str, 4095);

                // UnityEngine.Debug.Log("sending commands: " + renderCommands.Count);
                // UnityEngine.Debug.Log("in num chunks " + chunks.Count());

                networkView.RPC("RpcRenderDataStart", RPCMode.Others);
                foreach (var chunk in chunks)
                {
                    networkView.RPC("RpcRenderData", RPCMode.Others, chunk);
                }
                networkView.RPC("RpcRenderDataEnd", RPCMode.Others);
            }
        }
            
        [RPC]
        public void RpcRenderDataStart()
        {
        }

        [RPC]
        public void RpcRenderData(string chunk)
        {
        }

        [RPC]
        public void RpcRenderDataEnd()
        {
        }

        [RPC]
        public void RpcHardwareData(string data)
        {
            var bFormatter = new XmlSerializer(typeof(HardwareData), new[]
                {
                    typeof(Point)
                });

            HardwareData hardwareData;

            using (var reader = new StringReader(data))
            {
                hardwareData = (HardwareData)bFormatter.Deserialize(reader);
            }

            _debugHardware.SetHardwareData(hardwareData);
        }

        [RPC]
        public void RpcPing(string param)
        {
        }
    }
}
