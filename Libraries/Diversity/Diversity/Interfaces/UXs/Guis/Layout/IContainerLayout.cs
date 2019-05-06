namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Layout
{
    public interface IContainerLayout
    {
        /// <summary>
        /// Calculate the layout of all children.
        /// 
        /// This methods gets the extends of the parent to be able to calculate percentual widths and heights.
        /// </summary>
        /// <param name="x">X position relative to parent</param>
        /// <param name="y">Y position relative to parent</param>
        /// <param name="parentWidth">parents width</param>
        /// <param name="parentHeight">parents height</param>
        /// <param name="absoluteX">absolute x position</param>
        /// <param name="absoluteY">absolute y position</param>
        void CalculateChildLayouts(float x, float y, float parentWidth, float parentHeight, float absoluteX, float absoluteY);
    }
}
