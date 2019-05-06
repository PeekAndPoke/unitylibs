using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Unity.Debug.Remote.Transfer;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Client
{
    class DebugClientHardware : IHardware
    {
        protected HardwareData HardwareData;

        public void SetHardwareData(HardwareData hardwareData)
        {
            HardwareData = hardwareData;
        }

        /// <summary>
        /// Get the mouse position
        /// </summary>
        /// <returns></returns>
        public Point GetMousePosition()
        {
            return HardwareData.MousePosition;
        }

        /// <summary>
        /// True if the left mouse button is down
        /// </summary>
        /// <returns></returns>
        public bool GetLeftMouseButton()
        {
            return HardwareData.LeftMouseButton;
        }

        /// <summary>
        /// True if the middle mouse button is down
        /// </summary>
        /// <returns></returns>
        public bool GetMiddleMouseButton()
        {
            return HardwareData.MiddleMouseButton;
        }

        /// <summary>
        /// True if the right mouse button is down
        /// </summary>
        /// <returns></returns>
        public bool GetRightMouseButton()
        {
            return HardwareData.RightMouseButton;
        }

        /// <summary>
        /// Get the dimension of the applications 
        /// </summary>
        /// <returns></returns>
        public Point GetApplicationDisplaySize()
        {
            return HardwareData.DisplaySize;
        }

    }
}
