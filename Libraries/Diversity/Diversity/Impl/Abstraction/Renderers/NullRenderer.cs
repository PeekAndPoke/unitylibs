using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Impl.Abstraction.Renderers
{
    /// <summary>
    /// Renderer implementation that does not render anything.
    /// 
    /// Can be used for unit-test f.e.
    /// </summary>
    public class NullRenderer : AbstractBaseRenderer
    {
        public NullRenderer() : base(null)
        {
        }

        public override void RenderButton(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
        }

        public override void RenderImage(string uniqueId, IRectangle drawingGeometry, string caption, IImage image)
        {
        }

        public override bool RenderImageToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, IImage image, IStyle style)
        {
            return false;
        }

        public override void RenderLabel(string uniqueId, IRectangle drawingGeometry, string text, IStyle style, bool hasDropShadow, 
                                         IRgbaColor dropShadowRgbaColor, float dropShadowOffsetX, float dropShadowOffsetY)
        {
        }

        public override void RenderSpacer(string uniqueId, IRectangle drawingGeometry)
        {
        }

        public override bool RenderToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, string caption, IStyle style)
        {
            return false;
        }

        public override void RenderBox(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
        }

        public override void RenderTexture(string uniqueId, IRectangle drawingGeometry, IImage testure)
        {
        }


        public override IPoint BeginScrollView(string uniqueId, IRectangle drawingGeometry, IPoint scrollPosition, IRectangle contentRect)
        {
            return new Point();
        }

        public override void EndScrollView()
        {
        }

        public override void BeginGroup(string uniqueId, IRectangle drawingGeometry)
        {
        }

        public override void EndGroup()
        {
        }

        public override float RenderHorizontalScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, 
                                                        float min, float max, IStyle style)
        {
            return 0;
        }

        public override float RenderHSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            return 0;
        }

        public override string RenderPasswordField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, char charMask, IStyle style)
        {
            return "";
        }

        public override string RenderTextArea(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            return "";
        }

        public override string RenderTextField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            return "";
        }

        public override float RenderVScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, float min, 
                                               float max, IStyle style)
        {
            return 0;
        }

        public override float RenderVSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            return 0;
        }
    }
}
