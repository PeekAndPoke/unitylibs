using System.Collections.Generic;
using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Data;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;

namespace De.Kjg.Diversity.Unity.Debug.Remote.Client
{
    class DebugClientRenderer : IRenderer 
    {
        private readonly List<RemoteRenderCommand> _recorder = new List<RemoteRenderCommand>(); 

        #region Flow

        public void Begin()
        {
            _recorder.Clear();
        }

        public void Finish()
        {
        }

        public List<RemoteRenderCommand> GetRecordedCOmmands()
        {
            return _recorder;
        }

        protected void Record(string methodName, params object[] parameters)
        {
            _recorder.Add(new RemoteRenderCommand(methodName, parameters));
        }

        /// <summary>
        /// floats are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(float para)
        {
            return para;
        }

        /// <summary>
        /// Strings are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(string para)
        {
            return para;
        }

        /// <summary>
        /// Bools are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(bool para)
        {
            return para;
        }

        /// <summary>
        /// Points are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(IPoint para)
        {
            return para;
        }

        /// <summary>
        /// Rectangles are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(IRectangle para)
        {
            return para;
        }

        /// <summary>
        /// RgbaColors are supported
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(IRgbaColor para)
        {
            return para;
        }

        /// <summary>
        /// Styles not supported yet
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        protected object PrepareParam(IStyle para)
        {
            return null;
        }

        #endregion

        public void SetStyle(string name, IStyle style)
        {
            // not supported
        }

        public void RenderButton(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
            Record(
                "RenderButton",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry),
                PrepareParam(caption), 
                PrepareParam(style)
            );
        }

        public void RenderImage(string uniqueId, IRectangle drawingGeometry, string caption, IImage image)
        {
            // TODO: implement for images
            RenderSpacer(uniqueId, drawingGeometry);
        }

        public bool RenderImageToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, IImage image, IStyle style)
        {
            // TODO: implement for ImageToggleButtons
            return RenderToggleButton(uniqueId, drawingGeometry, isDown, "XXX", style);
        }

        public void RenderLabel(string uniqueId, IRectangle drawingGeometry, string text, IStyle style, bool hasDropShadow, 
                                IRgbaColor dropShadowRgbaColor, float dropShadowOffsetX, float dropShadowOffsetY)
        {
            Record(
                "RenderLabel",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry),
                PrepareParam(text),
                PrepareParam(style),
                PrepareParam(hasDropShadow),
                PrepareParam(dropShadowRgbaColor),
                PrepareParam(dropShadowOffsetX),
                PrepareParam(dropShadowOffsetY)
            );
        }

        public void RenderSpacer(string uniqueId, IRectangle drawingGeometry)
        {
            Record(
                "RenderSpacer",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry)
            );
        }

        public bool RenderToggleButton(string uniqueId, IRectangle drawingGeometry, bool isDown, string caption, IStyle style)
        {
            Record(
                "RenderToggleButton",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry),
                PrepareParam(isDown),
                PrepareParam(caption),
                PrepareParam(style)
            );

            return false;
        }

        public void RenderBox(string uniqueId, IRectangle drawingGeometry, string caption, IStyle style)
        {
            Record(
                "RenderBox",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry),
                PrepareParam(caption),
                PrepareParam(style)
            );
        }

        public void RenderTexture(string uniqueId, IRectangle drawingGeometry, IImage texture)
        {
            // TODO: implement for Texture
            RenderSpacer(uniqueId, drawingGeometry);
        }

        public IPoint BeginScrollView(string uniqueId, IRectangle drawingGeometry, IPoint scrollPosition, IRectangle contentRect)
        {
            Record(
                "BeginScrollView",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry),
                PrepareParam(scrollPosition),
                PrepareParam(contentRect)
            );

            return new Point();
        }

        public void EndScrollView()
        {
            Record(
                "EndScrollView"
                );
        }

        public void BeginGroup(string uniqueId, IRectangle drawingGeometry)
        {
            Record(               
                "BeginGroup",
                PrepareParam(uniqueId),
                PrepareParam(drawingGeometry)
            );
        }

        public void EndGroup()
        {
            Record(
                "EndGroup"
                );
        }

        public float RenderHorizontalScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, 
                                               float min, float max, IStyle style)
        {
            Record(
                "RenderHorizontalScrollbar",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(value),
                PrepareParam(size),
                PrepareParam(min),
                PrepareParam(max),
                PrepareParam(style)
            );

            return 0;
        }

        public float RenderHSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            Record(
                "RenderHSlider",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(value),
                PrepareParam(min),
                PrepareParam(max)
            );

            return 0;
        }

        public string RenderPasswordField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, char charMask, IStyle style)
        {
            Record(
                "RenderPasswordField",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(content),
                PrepareParam(charMask),
                PrepareParam(style)
            );

            return "";
        }

        public string RenderTextArea(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            Record(
                "RenderTextArea",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(content),
                PrepareParam(style)
            );

            return "";
        }

        public string RenderTextField(string uniqueId, bool enabled, IRectangle drawingGeometry, string content, IStyle style)
        {
            Record(
                "RenderTextField",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(content),
                PrepareParam(style)
            );

            return "";
        }

        public float RenderVScrollbar(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float size, 
                                      float min, float max, IStyle style)
        {
            Record(
                "RenderVScrollbar",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(value),
                PrepareParam(size),
                PrepareParam(min),
                PrepareParam(max),
                PrepareParam(style)
            );

            return 0;
        }

        public float RenderVSlider(string uniqueId, bool enabled, IRectangle drawingGeometry, float value, float min, float max)
        {
            Record(
                "RenderVSlider",
                PrepareParam(uniqueId),
                PrepareParam(enabled),
                PrepareParam(drawingGeometry),
                PrepareParam(value),
                PrepareParam(min),
                PrepareParam(max)
            );

            return 0;
        }
    }
}
