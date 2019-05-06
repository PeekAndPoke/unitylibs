using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Interfaces.Abstraction.Renderers
{
    public interface IRenderer
    {
        #region Flow

        void Begin();

        void Finish();

        #endregion

        #region Styles

        /// <summary>
        /// Set a gui StyleAdapter by name
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="style">the StyleAdapter</param>
        /// <returns></returns>
        void SetStyle(string name, IStyle style);

        #endregion

        #region Basic Elements

        void RenderButton(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style);

        void RenderImage(string uniqueId, IRectangle drawingGeometry, string caption, IImage image);

        bool RenderImageToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, IImage image, IStyle style);

        void RenderLabel(string uniqueId, IRectangle drawingGeometry, string text, IStyle style, bool hasDropShadow,
                         IRgbaColor dropShadowRgbaColor, float dropShadowOffsetX, float dropShadowOffsetY);

        void RenderSpacer(string uniqueId, IRectangle drawingGeometry);

        bool RenderToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, string caption, IStyle style);

        void RenderBox(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style);

        void RenderTexture(string uniqueId, IRectangle drawingGeometry, IImage texture);

        #endregion

        #region Grouping Elements

        IPoint BeginScrollView(string uniqueId, IRectangle drawingGeometry, IPoint scrollPosition, IRectangle contentRect);
        
        void EndScrollView();

        void BeginGroup(string uniqueId, IRectangle drawingGeometry);

        void EndGroup();

        #endregion

        #region Input Elements

        float RenderHorizontalScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, float min,
                                        float max, IStyle style);

        float RenderHSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max);

        string RenderPasswordField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, char charMask, IStyle style);

        string RenderTextArea(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style);

        string RenderTextField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style);

        float RenderVScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, float min, float max,
                               IStyle style);

        float RenderVSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max);

        #endregion

    }
}
