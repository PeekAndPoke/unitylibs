﻿using System;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete implementation of a vertical slider
    /// </summary>
    public class VSlider : GenericVSlider<VSlider>
    {
        public VSlider(int width, int height, float value, float min = 0, float max = 100)
            : base(width, height, value, min, max)
        {
        }
    }

    /// <summary>
    /// Generic implementation of a vertical slider
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericVSlider<TElementType> : GenericAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        protected float Min = 0;
        protected float Max = 100;
        protected float Value = 0;

        public GenericVSlider(int width, int height, float value, float min = 0, float max = 100)
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

            var newValue = renderer.RenderVSlider(
                UniqueId,
                Enabled,
                drawingGeometry,
                Value,
                Min,
                Max
                // TODO: StyleAdapter
                //                GuiStyle ?? GetStyleByName("verticalslider"),
                //                GuiStyle ?? GetStyleByName("verticalsliderthumb")
            );

            if (newValue != Value)
            {
                Value = newValue;
                DispatchChange();
            }
        }
    }
}
