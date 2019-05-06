using System;
using De.Kjg.Diversity.Impl.Abstraction.Data;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout.Data
{
    /// <summary>
    /// ProcessingData is used to store data that is calculated while layout and that is then used to draw items und to do
    /// input processing.
    /// </summary>
    public class ProcessingData
    {
        /// <summary>
        /// The drawing geometry is used to really draw the gui element.
        /// This geometry is most likely relative to the parent gui element.
        /// </summary>
        public Rectangle DrawingGeometry = new Rectangle(0, 0, 0, 0);
        /// <summary>
        /// The absolute drawing geometry used for input processing.
        /// This geometry is in absolute coordinates.
        /// </summary>
        public Rectangle AbsoluteGeometry = new Rectangle(0, 0, 0, 0);
        /// <summary>
        /// The clipping rectangle in absolute coordinates.
        /// Needed for input processing to prevent input on elements the are not visible, f.e. if they are in a scrollview 
        /// but scrolled out of view.
        /// </summary>
        public Rectangle ClipRect = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
        /// <summary>
        /// True if the mouse was over the item on the last turn
        /// </summary>
        public bool MouseWasOver = false;
        /// <summary>
        /// Timestamp of the last click on the, used to detect doubleClick
        /// </summary>
        public DateTime LastClickTimestamp = DateTime.Now;

        /// <summary>
        /// Set the drawing geometry
        /// <see cref="DrawingGeometry"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetDrawingGeometry(float x, float y, float width, float height)
        {
            DrawingGeometry.Set(x, y ,width, height);
        }

        /// <summary>
        /// Set only the drawing dimension (width and height)
        /// <see cref="DrawingGeometry"/>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetDrawingDimension(float width, float height)
        {
            DrawingGeometry.SetDimension(width, height);
        }

        /// <summary>
        /// Set only the drawing position (x and y) 
        /// <see cref="DrawingGeometry"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetDrawingPosition(float x, float y)
        {
            DrawingGeometry.SetPosition(x, y);
        }

        /// <summary>
        /// Set the absolute geometry
        /// <see cref="AbsoluteGeometry"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetAbsoluteGeometry(float x, float y, float width, float height)
        {
            AbsoluteGeometry.Set(x, y, width, height);
        }

        /// <summary>
        /// Set the clipping rect
        /// <see cref="ClipRect"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetClipRect(float x, float y, float width, float height)
        {
            ClipRect.Set(x, y, width, height);
        }
    }
}
