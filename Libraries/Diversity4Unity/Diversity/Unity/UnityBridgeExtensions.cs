using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Unity.Abstraction.Visuals;
using UnityEngine;

namespace De.Kjg.Diversity.Unity
{
    /// <summary>
    /// Bridge To and From Unity3D
    /// 
    /// This is used to decouple the gui framework from Unity3D
    /// </summary>
    public static class UnityBridgeExtensions
    {
        private static Rect _tempRect;
        private static Point _tempPoint;
        private static Vector2 _tempVector2;
        private static Color _tempColor;

        /// <summary>
        /// Extension method for UnityEngine.GUISkin which converts it to an instance of SkinAdapter
        /// </summary>
        /// <param name="guiSkin"></param>
        /// <returns></returns>
        public static ISkin ToSkin(this GUISkin guiSkin)
        {
            return new UnitySkinAdapter(guiSkin);
        }

        /// <summary>
        /// Extension method for SkinAdapter which converts it to an instance of UnityEngine.GUISkin
        /// </summary>
        /// <param name="skin"></param>
        /// <returns></returns>
        public static GUISkin ToGuiSkin(this ISkin skin)
        {
            return (GUISkin) skin.GetWrapped();
        }

        /// <summary>
        /// Extension method for UnityEngine.GUIStyle which converts it to an instance of StyleAdapter
        /// </summary>
        /// <param name="guiStyle"></param>
        /// <returns></returns>
        public static IStyle ToStyle(this GUIStyle guiStyle)
        {
            return new UnityStyleAdapter(guiStyle);
        }

        /// <summary>
        /// Extension method for StyleAdapter which converts it to an instance of UnityEngine.GUIStyle
        /// </summary>
        /// <param name="styleAdapter"></param>
        /// <returns></returns>
        public static GUIStyle ToGuiStyle(this IStyle styleAdapter)
        {
            return (GUIStyle) styleAdapter.GetWrapped();
        }

        /// <summary>
        /// Extension method for UnityEngine.Texture2D which converts it to an instance of StyleAdapter
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public static IImage ToImage(this Texture2D texture)
        {
            return new UnityImageAdapter(texture);
        }

        /// <summary>
        /// Extension method for ImageAdapter which converts it to an instance of UnityEngine.Texture2D
        /// </summary>
        /// <param name="abstractImage"></param>
        /// <returns></returns>
        public static Texture2D ToTexture2D(this IImage abstractImage)
        {
            return (Texture2D)abstractImage.GetWrapped();
        }


        public static Rect ToRect(this IRectangle rectangle)
        {
            _tempRect.x = rectangle.X;
            _tempRect.y = rectangle.Y;
            _tempRect.width = rectangle.Width;
            _tempRect.height = rectangle.Height;
            
            return _tempRect;
        }

        public static IPoint ToPoint(this Vector2 vector2)
        {
            _tempPoint.X = vector2.x;
            _tempPoint.Y = vector2.y;
            return _tempPoint;
        }

        public static Vector2 ToVector2(this IPoint point)
        {
            _tempVector2.x = point.X;
            _tempVector2.y = point.Y;
            
            return _tempVector2;
        }

        public static Color ToColor(this IRgbaColor color)
        {
            _tempColor.r = color.R;
            _tempColor.g = color.G;
            _tempColor.b = color.B;
            _tempColor.a = color.A;
            
            return _tempColor;
        } 

    }
}