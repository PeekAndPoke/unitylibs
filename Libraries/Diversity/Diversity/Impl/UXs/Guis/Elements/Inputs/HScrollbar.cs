using System;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete implementation of a generic scroll bar
    /// </summary>
    public class HScrollbar : GenericHScrollbar<HScrollbar>
    {
        public HScrollbar(int width, int height, float value, float min = 0, float max = 100)
            : base(width, height, value, min, max)
        {
        }
    }

    /// <summary>
    /// Generic implementation of a horizontal scroll bar
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericHScrollbar<TElementType> : GenericAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        protected float Min = 0;
        protected float Max = 100;
        protected float Value = 0;
        protected float Size = 1;

        public GenericHScrollbar(int width, int height, float value, float min = 0, float max = 100)
        {
            SetWidth(width);
            SetHeight(height);
            Value = value;
            Min = min;
            Max = max;
        }

        public TElementType SetValue(float value)
        {
            Value = value;
            return AsElementType();
        }

        public TElementType SetSize(float size)
        {
            Size = size;
            return AsElementType();
        }

        public override string GetContent()
        {
            return Value.ToString();
        }

        public override TElementType SetContent(string content)
        {
            try
            {
                Value = Convert.ToSingle(content);
            }
            catch (Exception)
            {
                Value = 0;
            }
            return AsElementType();
        }

        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            var newValue = renderer.RenderHorizontalScrollbar(
                UniqueId,
                Enabled,
                drawingGeometry,
                Value,
                Size,
                Min,
                Max,
                GetStyle()
            );

            if (newValue != Value)
            {
                Value = newValue;
                DispatchChange();
            }
        }
    }
}
