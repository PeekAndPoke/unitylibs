using De.Kjg.Diversity.Unity.Modules;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Server
{
    public class DebugServerModule : IUnityModule
    {
        protected GUISkin GuiSkin;
        protected int Port = 39999;

        public DebugServerModule(GUISkin guiSkin)
        {
            GuiSkin = guiSkin;
        }

        public void Initialize(GameObject gameObject)
        {
            var networkView = gameObject.AddComponent<NetworkView>();
            networkView.stateSynchronization = NetworkStateSynchronization.Off;

            var behaviour = gameObject.AddComponent<DebugServerMonoBehaviour>();

            behaviour.SetServerGuiSkin(GuiSkin);
            behaviour.StartServer(Port, false);
        }
    }
}
