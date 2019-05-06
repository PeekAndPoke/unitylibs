using De.Kjg.Diversity.Impl.Abstraction.Data;

namespace De.Kjg.Diversity.Interfaces.Abstraction.Hardware
{
    public interface IHardware
    {
        /// <summary>
        /// Get the mouse position
        /// </summary>
        /// <returns></returns>
        Point GetMousePosition();

        /// <summary>
        /// True if the left mouse button is down
        /// </summary>
        /// <returns></returns>
        bool GetLeftMouseButton();

        /// <summary>
        /// True if the middle mouse button is down
        /// </summary>
        /// <returns></returns>
        bool GetMiddleMouseButton();

        /// <summary>
        /// True if the right mouse button is down
        /// </summary>
        /// <returns></returns>
        bool GetRightMouseButton();

        /// <summary>
        /// Get the dimension of the applications 
        /// </summary>
        /// <returns></returns>
        Point GetApplicationDisplaySize();
    }
}
