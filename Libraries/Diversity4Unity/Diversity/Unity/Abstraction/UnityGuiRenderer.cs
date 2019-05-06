using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Abstraction
{
    /// <summary>
    /// Renderer implementation which renders all ui elements to the 2D-Gui-Layer of Unity3D
    /// </summary>
    public class UnityGuiRenderer : AbstractBaseRenderer
    {
        protected GUISkin GuiSkin;
        protected int ZIndex = 100;

        /// <summary>
        /// Used for temporary assignments to avoid "new Rectangle()"
        /// </summary>
        protected Rectangle TempRect = new Rectangle();

        public UnityGuiRenderer(ISkin skin) : base(skin)
        {
            if (skin == null || skin.ToGuiSkin() == null)
            {
                GuiSkin = new GUISkin();
            }
            else
            {
                GuiSkin = skin.ToGuiSkin();
            }
        }

        public void SetZIndex(int zIndex)
        {
            ZIndex = zIndex;
        }

        #region Flow

        public override void Begin()
        {
            GUI.depth = ZIndex;
        }

        public override void Finish()
        {
        }

        #endregion

        /// <summary>
        /// Get a gui StyleAdapter by name.
        /// 
        /// 1. looks in styles added by SetStyle()
        /// 2. looks in the SkinAdapter
        /// 3. if not found returns null
        /// </summary>
        /// <param name="name">the StyleAdapter name</param>
        /// <returns>The StyleAdapter if found or null</returns>
        protected IStyle GetStyleByName(string name)
        {
            // first look into the custom styles
            IStyle style;
            if (CustomStyles.TryGetValue(name, out style))
            {
                return style;
            }

            return GuiSkin.FindStyle(name).ToStyle();
        }

        #region Basic Elements

        public override void RenderButton(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
            GUI.Button(
                drawingGeometry.ToRect(),
                caption,
                (style ?? GetStyleByName("button")).ToGuiStyle()
            );
        }

        public override void RenderImage(string uniqueId, IRectangle drawingGeometry, string caption, IImage image)
        {
            GUI.Label(
                drawingGeometry.ToRect(),
                image.ToTexture2D()
            );
        }

        public override bool RenderImageToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, IImage image, IStyle style)
        {
            return GUI.Toggle(
                drawingGeometry.ToRect(),
                isDown,
                image.ToTexture2D(),
                (style ?? GetStyleByName("button")).ToGuiStyle()
            );
        }

        public override void RenderLabel(string uniqueId, IRectangle drawingGeometry, string text, IStyle style, bool hasDropShadow,
                                         IRgbaColor dropShadowRgbaColor, float dropShadowOffsetX, float dropShadowOffsetY)
        {
            var styleToUse = (style ?? GetStyleByName("label")).ToGuiStyle();

            if (hasDropShadow)
            {
                var oldColor = GUI.color;
                GUI.color = dropShadowRgbaColor.ToColor();

                TempRect.Set(
                    drawingGeometry.X + dropShadowOffsetX,
                    drawingGeometry.Y + dropShadowOffsetY,
                    drawingGeometry.Width,
                    drawingGeometry.Height
                    );

                GUI.Label(
                    TempRect.ToRect(),
                    text,
                    styleToUse
                );
                GUI.color = oldColor;
            }

            GUI.Label(
                drawingGeometry.ToRect(),
                text,
                styleToUse
            );            
        }

        public override void RenderSpacer(string uniqueId, IRectangle drawingGeometry)
        {
            // nothing to do here
        }

        public override bool RenderToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, string caption, IStyle style)
        {
            return GUI.Toggle(
                drawingGeometry.ToRect(),
                isDown,
                caption,
                (style ?? GetStyleByName("Button")).ToGuiStyle()
            );
        }

        public override void RenderBox(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
            GUI.Box(
                drawingGeometry.ToRect(), 
                caption, 
                (style ?? GetStyleByName("Box")).ToGuiStyle()
            );                                                       
        }

        public override void RenderTexture(string uniqueId, IRectangle drawingGeometry, IImage texture)
        {
            GUI.DrawTexture(drawingGeometry.ToRect(), texture.ToTexture2D());
        }

        #endregion

        #region Grouping Elements

        public override IPoint BeginScrollView(string uniqueId, IRectangle drawingGeometry, IPoint scrollPosition, IRectangle contentRect)
        {
            return GUI.BeginScrollView(
                drawingGeometry.ToRect(),
                scrollPosition.ToVector2(),
                contentRect.ToRect()
            ).ToPoint();
        }

        public override void EndScrollView()
        {
            GUI.EndScrollView();
        }

        public override void BeginGroup(string uniqueId, IRectangle drawingGeometry)
        {
            GUI.BeginGroup(drawingGeometry.ToRect());
        }
        
        public override void EndGroup()
        {
            GUI.EndGroup();
        }

        #endregion

        #region Input Elements

        public override float RenderHorizontalScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, 
                                                        float size, float min, float max, IStyle style)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.HorizontalScrollbar(
                drawingGeometry.ToRect(),
                value,
                size,
                min,
                max,
                (style ?? GetStyleByName("horizontalscrollbar")).ToGuiStyle()
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        public override float RenderHSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.HorizontalSlider(
                drawingGeometry.ToRect(),
                value,
                min,
                max
                // TODO: StyleAdapter
                //                GuiStyle ?? GetStyleByName("verticalslider"),
                //                GuiStyle ?? GetStyleByName("verticalsliderthumb")
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }


        public override string RenderPasswordField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, char charMask, IStyle style)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.PasswordField(
                drawingGeometry.ToRect(),
                content,
                charMask,
                (style ?? GetStyleByName("textfield")).ToGuiStyle()
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        public override string RenderTextArea(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.TextArea(
                drawingGeometry.ToRect(),
                content,
                (style ?? GetStyleByName("textarea")).ToGuiStyle()
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        public override string RenderTextField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.TextField(
                drawingGeometry.ToRect(),
                content,
                (style ?? GetStyleByName("textfield")).ToGuiStyle()
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        public override float RenderVScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, float min, 
                                              float max, IStyle style)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.VerticalScrollbar(
                drawingGeometry.ToRect(),
                value,
                size,
                min,
                max,
                (style ?? GetStyleByName("verticalscrollbar")).ToGuiStyle()
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        public override float RenderVSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            var oldEnabled = GUI.enabled;
            GUI.enabled = enabled;

            var newValue = GUI.VerticalSlider(
                drawingGeometry.ToRect(),
                value,
                min,
                max
                            // TODO: StyleAdapter
                            //                GuiStyle ?? GetStyleByName("verticalslider"),
                            //                GuiStyle ?? GetStyleByName("verticalsliderthumb")
            );

            GUI.enabled = oldEnabled;

            return newValue;
        }

        #endregion
    }
}
