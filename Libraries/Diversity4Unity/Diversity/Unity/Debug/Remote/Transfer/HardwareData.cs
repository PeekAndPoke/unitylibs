using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.Diversity.Impl.Abstraction.Data;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Transfer
{
    public struct HardwareData
    {
        public readonly Point MousePosition;
        public readonly Point DisplaySize;
        public readonly bool LeftMouseButton;
        public readonly bool MiddleMouseButton;
        public readonly bool RightMouseButton;

        public HardwareData(Point mousePosition, Point displaySize, bool leftMouseButton, bool middleMouseButton, bool rightMouseButton)
        {
            MousePosition = mousePosition;
            DisplaySize = displaySize;
            LeftMouseButton = leftMouseButton;
            MiddleMouseButton = middleMouseButton;
            RightMouseButton = rightMouseButton;
        }
    }
}
