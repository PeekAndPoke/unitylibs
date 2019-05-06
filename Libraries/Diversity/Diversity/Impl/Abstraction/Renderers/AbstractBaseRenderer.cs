using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Impl.Abstraction.Renderers
{
    public abstract class AbstractBaseRenderer : IRenderer
    {
        /// <summary>
        /// The Skin used by the renderer
        /// </summary>
        protected ISkin Skin;
        /// <summary>
        /// Additional styles
        /// </summary>
        protected Dictionary<string, IStyle> CustomStyles = new Dictionary<string, IStyle>();

        protected AbstractBaseRenderer(ISkin skin)
        {
            Skin = skin;
        }

        #region Flow

        public virtual void Begin()
        {
        }

        public virtual void Finish()
        {
        }

        #endregion

        #region Styles

        /// <summary>
        /// Set a gui StyleAdapter by name
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="style">the Style</param>
        /// <returns></returns>
        public void SetStyle(string name, IStyle style)
        {
            CustomStyles.Add(name, style);
        }

        #endregion

        public abstract void RenderButton(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style);

        public abstract void RenderImage(string uniqueId, IRectangle drawingGeometry, string caption, IImage image);

        public abstract bool RenderImageToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, IImage image, IStyle style);

        public abstract void RenderLabel(string uniqueId, IRectangle drawingGeometry, string text, IStyle style, bool hasDropShadow,
                                         IRgbaColor dropShadowRgbaColor, float dropShadowOffsetX, float dropShadowOffsetY);

        public abstract void RenderSpacer(string uniqueId, IRectangle drawingGeometry);

        public abstract bool RenderToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, string caption, IStyle style);

        public abstract void RenderBox(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style);

        public abstract void RenderTexture(string uniqueId, IRectangle drawingGeometry, IImage testure);

        public abstract IPoint BeginScrollView(string uniqueId, IRectangle drawingGeometry, IPoint scrollPosition, IRectangle contentRect);
        
        public abstract void EndScrollView();

        public abstract void BeginGroup(string uniqueId, IRectangle drawingGeometry);

        public abstract void EndGroup();

        public abstract float RenderHorizontalScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size,
                                                        float min, float max, IStyle style);

        public abstract float RenderHSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max);

        public abstract string RenderPasswordField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content,
                                                   char charMask, IStyle style);

        public abstract string RenderTextArea(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style);

        public abstract string RenderTextField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style);

        public abstract float RenderVScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size,
                                               float min, float max, IStyle style);

        public abstract float RenderVSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max);
    }
}
