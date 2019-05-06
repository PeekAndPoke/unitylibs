using System;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Elements.Inputs
{
    /// <summary>
    /// Concrete implementation of a password field
    /// </summary>
    public class PasswordField : GenericPasswordField<PasswordField>
    {
        public PasswordField(int width, int height) : base(width, height)
        {
        }
    }

    /// <summary>
    /// Generic implementation of a password field
    /// </summary>
    /// <typeparam name="TElementType"></typeparam>
    public class GenericPasswordField<TElementType> : GenericAbstractInputElement<TElementType> where TElementType : IGuiInputElement
    {
        protected Char CharMask = '*';

        public GenericPasswordField(int width, int height)
        {
            SetWidth(width);
            SetHeight(height);
        }

        public TElementType SetCharMask(Char mask)
        {
            CharMask = mask;
            return AsElementType();
        }

        public override void Draw(IRenderer renderer)
        {
            var drawingGeometry = GetLayoutProcessingData().DrawingGeometry;

            var newContent = renderer.RenderPasswordField(
                UniqueId,
                Enabled,
                drawingGeometry,
                Content,
                CharMask,
                GetStyle()
            );

            if (newContent != Content)
            {
                Content = newContent;
                DispatchChange();
            }
        }
    }
}
