using De.Kjg.Diversity.Unity.Abstraction;
using De.Kjg.Diversity.Unity.Debug.Remote.Transfer;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Server
{
    class DebugServerHardware : UnityHardware
    {
        protected bool LeftMouseButtonCollected;
        protected bool MiddleMouseButtonCollected;
        protected bool RightMouseButtonCollected;

        public void CollectData()
        {
            LeftMouseButtonCollected = LeftMouseButtonCollected || base.GetLeftMouseButton();
            MiddleMouseButtonCollected = MiddleMouseButtonCollected || base.GetMiddleMouseButton();
            RightMouseButtonCollected = RightMouseButtonCollected || base.GetRightMouseButton();
        }

        public HardwareData GetCollectedData()
        {
            return new HardwareData(
                GetMousePosition(),
                GetApplicationDisplaySize(),
                LeftMouseButtonCollected,
                MiddleMouseButtonCollected,
                RightMouseButtonCollected
            );
        }

        public void Reset()
        {
            LeftMouseButtonCollected = false;
            MiddleMouseButtonCollected = false;
            RightMouseButtonCollected = false;
        }
    }
}
