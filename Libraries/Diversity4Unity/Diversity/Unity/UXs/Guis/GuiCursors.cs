using UnityEngine;

namespace De.Kjg.Diversity.Unity.Gui
{
    /// <summary>
    /// Gui corsors.
    /// </summary>
    [System.Serializable]
    public class GuiCursors
    {
        public Texture2D CursorAdd;
        public Texture2D CursorCanGrab;
        public Texture2D CursorCross;
        public Texture2D CursorCrossHairs;
        public Texture2D CursorDefault;
        public Texture2D CursorDefaultMirrored;
        public Texture2D CursorDragClick;
        public Texture2D CursorGrabbed;
        public Texture2D CursorResizeHorizontal;
        public Texture2D CursorResizeVertical;
        public Texture2D CursorResizeDiagonalTopLeftBottomRight;
        public Texture2D CursorResizeDiagonalTopRightBottomLeft;

        private static GuiCursors _instance;

        protected GuiCursors()
        {
            // this is for unity3d-editor because it even instantiates objects with a protected constructor
            _instance = this;
        }

        public static GuiCursors Instance
        {
            get { return _instance ?? (_instance = new GuiCursors()); }
        }

        public static void None()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        public static void Add()
        {
            Cursor.SetCursor(Instance.CursorAdd, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void CanGrab()
        {
            Cursor.SetCursor(Instance.CursorCanGrab, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void Cross()
        {
            Cursor.SetCursor(Instance.CursorCross, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void CrossHairs()
        {
            Cursor.SetCursor(Instance.CursorCrossHairs, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void Default()
        {
            Cursor.SetCursor(Instance.CursorDefault, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void DefaultMirrord()
        {
            Cursor.SetCursor(Instance.CursorDefaultMirrored, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void DragClick()
        {
            Cursor.SetCursor(Instance.CursorDragClick, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void Grabbed()
        {
            Cursor.SetCursor(Instance.CursorGrabbed, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void ResizeHorizontal()
        {
            Cursor.SetCursor(Instance.CursorResizeHorizontal, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void ResizeVertical()
        {
            Cursor.SetCursor(Instance.CursorResizeVertical, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void ResizeDiagonalTopLeftBottomRight()
        {
            Cursor.SetCursor(Instance.CursorResizeDiagonalTopLeftBottomRight, new Vector2(0, 0), CursorMode.Auto);
        }

        public static void ResizeDiagonalTopRightBottomLeft()
        {
            Cursor.SetCursor(Instance.CursorResizeDiagonalTopRightBottomLeft, new Vector2(0, 0), CursorMode.Auto);
        }
    }
}
