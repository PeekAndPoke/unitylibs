using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Unity.Modules;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Client
{
    public class DebugClientModule : IUnityModule
    {
        private static DebugClientModule _instance;

        protected string Ip = "127.0.0.1";
        protected int Port = 39999;
        protected bool AutoConnect = true;

        protected NetworkView NetworkView;
        private DebugClientMonoBehaviour _rpcBehaviour;

        private GuiStage _remoteStage = new GuiStage();

        protected DebugClientModule()
        {
        }

        public static DebugClientModule Instance
        {
            get { return _instance ?? (_instance = new DebugClientModule()); }
        } 

        public void AddChild(IGuiElement guiElement)
        {
            _remoteStage.AddChild(guiElement);
        }

        public void RemoveChild(IGuiElement guiElement)
        {
            _remoteStage.RemoveChild(guiElement);
        }

        public void Initialize(GameObject gameObject)
        {
            NetworkView = gameObject.AddComponent<NetworkView>();
            NetworkView.stateSynchronization = NetworkStateSynchronization.Off;

            _rpcBehaviour = gameObject.AddComponent<DebugClientMonoBehaviour>();
            _rpcBehaviour.SetRemoteStage(_remoteStage);

            if (AutoConnect)
            {
                Connect();
            }
        }

        public DebugClientModule SetConnection(string ip, int port, bool autoConnect)
        {
            Ip = ip;
            Port = port;
            AutoConnect = autoConnect;
            return this;
        }

        public DebugClientModule Connect()
        {
            _rpcBehaviour.ConnectToServer(Ip, Port);
            return this;
        }

        public DebugClientModule Disconnect()
        {
            _rpcBehaviour.DisconnectFromServer();
            return this;
        }

        public bool IsConnected()
        {
            return _rpcBehaviour.IsConnected();
        }
    }
}
