using System;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Data;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Layout;

namespace De.Kjg.Diversity.Impl.UXs.Guis.Layout
{
    public class BaseLayout : ILayout
    {
        /// <summary>
        /// The GuiElement that own the layout
        /// </summary>
        protected IGuiElement GuiElement;
        /// <summary>
        /// Data structure to store the calculated data
        /// </summary>
        protected ProcessingData ProcessingData = new ProcessingData();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="guiElement"></param>
        public BaseLayout(IGuiElement guiElement)
        {
            GuiElement = guiElement;
            HorizontalAlign = HorizontalAlign.None;
            VerticalAlign = VerticalAlign.None;
            Visible = true;
        }

        #region Properties

        /// <summary>
        /// True if the GuiElement is visible
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// X-Position
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Y-Position
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// Horizontal align
        /// </summary>
        public HorizontalAlign HorizontalAlign { get; set; }
        /// <summary>
        /// Vertical Align
        /// </summary>
        public VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// Is true when the GuiElement has a width set with SetWidth()
        /// </summary>
        public bool HasManualWidth { get; protected set; }
        /// <summary>
        /// Is ture when the GuiElement has a percentual width set with SetPercentualWidth()
        /// </summary>
        public bool HasPercentualWidth { get; protected set; }
        /// <summary>
        /// Value of manually set width
        /// </summary>
        public float ManualWidth { get; protected set; }
        /// <summary>
        /// Value of percentual width (0 .. 1)
        /// </summary>
        public float PercentualWidth { get; protected set; }
        /// <summary>
        /// The minimal width of the GuiElement
        /// </summary>
        public float MinWidth = 0;
        /// <summary>
        /// The maximal width of the GuiElement
        /// </summary>
        public float MaxWidth = Single.MaxValue;

        /// <summary>
        /// Is true when the GuiElement has a height set with SetHeight()
        /// </summary>
        public bool HasManualHeight { get; protected set; }
        /// <summary>
        /// Is ture when the GuiElement has a percentual height set with SetPercentualHeight()
        /// </summary>
        public bool HasPercentualHeight { get; protected set; }
        /// <summary>
        /// Value of manually set height
        /// </summary>
        public float ManualHeight { get; protected set; }
        /// <summary>
        /// Value of percentual height (0 .. 1)
        /// </summary>
        public float PercentualHeight { get; protected set; }
        /// <summary>
        /// The minimal height of the GuiElement
        /// </summary>
        public float MinHeight = 0;
        /// <summary>
        /// The maximal height of the GuiElement
        /// </summary>
        public float MaxHeight = Single.MaxValue;

        /// <summary>
        /// Resets manual and percentual width. 
        /// 
        /// After calling this method the width of the GuiElement will be determined automatically.
        /// </summary>
        public void UseAutomaticalWidth()
        {
            HasManualWidth = false;
            HasPercentualWidth = false;
        }
        /// <summary>
        /// Returns the manual width.
        /// </summary>
        /// <returns></returns>
        public float GetWidth()
        {
            return ManualWidth;
        }
        /// <summary>
        /// Set the manual width. Resets percentual width.
        /// </summary>
        /// <param name="width"></param>
        public void SetWidth(float width)
        {
            ManualWidth = width;
            HasManualWidth = true;
            HasPercentualWidth = false;
        }
        /// <summary>
        /// Get the percentual width (0 .. 1)
        /// </summary>
        /// <returns></returns>
        public float GetPercentualWidth()
        {
            return PercentualWidth;
        }
        /// <summary>
        /// Set percentual width. Resets manual width.
        /// </summary>
        /// <returns></returns>
        public void SetPercentualWidth(float percent)
        {
            PercentualWidth = percent;
            HasManualWidth = false;
            HasPercentualWidth = true;
        }
        /// <summary>
        /// Get the minimal width
        /// </summary>
        /// <returns></returns>
        public float GetMinWidth()
        {
            return MinWidth;
        }
        /// <summary>
        /// Set the minimal width
        /// </summary>
        /// <param name="minWidth"></param>
        public void SetMinWidth(float minWidth)
        {
            MinWidth = minWidth;
        }
        /// <summary>
        /// Get the maximal width
        /// </summary>
        /// <returns></returns>
        public float GetMaxWidth()
        {
            return MaxWidth;
        }
        /// <summary>
        /// Set the maximal width
        /// </summary>
        /// <param name="maxWidth"></param>
        public void SetMaxWidth(float maxWidth)
        {
            MaxWidth = maxWidth;
        }

        /// <summary>
        /// Reset manual and percentual height. 
        /// 
        /// After calling this method the height of the GuiElement will be determined automatically.
        /// </summary>
        public void UseAutomaticalHeight()
        {
            HasManualHeight = false;
            HasPercentualHeight = false;
        }
        /// <summary>
        /// Get the manual height
        /// </summary>
        /// <returns></returns>
        public float GetHeight()
        {
            return ManualHeight;
        }
        /// <summary>
        /// Set the manual height. Resets the percentual height.
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(float height)
        {
            ManualHeight = height;
            HasManualHeight = true;
            HasPercentualHeight = false;
        }
        /// <summary>
        /// Get the percentual height.
        /// </summary>
        /// <returns></returns>
        public float GetPercentualHeight()
        {
            return PercentualHeight;
        }
        /// <summary>
        /// Set the percentual height. Resets the manual height.
        /// </summary>
        /// <param name="percent"></param>
        public void SetPercentualHeight(float percent)
        {
            PercentualHeight = percent;
            HasManualHeight = false;
            HasPercentualHeight = true;
        }
        /// <summary>
        /// Get the minimal height.
        /// </summary>
        /// <returns></returns>
        public float GetMinHeight()
        {
            return MinHeight;
        }
        /// <summary>
        /// Set the minimal height.
        /// </summary>
        /// <param name="minHeight"></param>
        public void SetMinHeight(float minHeight)
        {
            MinHeight = minHeight;
        }
        /// <summary>
        /// Get the maximal height.
        /// </summary>
        /// <returns></returns>
        public float GetMaxHeight()
        {
            return MaxHeight;
        }
        /// <summary>
        /// Set the maximal height.
        /// </summary>
        /// <param name="maxHeight"></param>
        public void SetMaxHeight(float maxHeight)
        {
            MaxHeight = maxHeight;
        }
        /// <summary>
        /// The Padding
        /// 
        /// The getter only returns the value of PaddingTop.
        /// The setter sets the given value to PaddingTop, PaddingRight, PaddingBottom und PaddingLeft.
        /// </summary>
        public float Padding
        {
            get { return PaddingTop; }
            set
            {
                PaddingTop = value;
                PaddingRight = value;
                PaddingBottom = value;
                PaddingLeft = value;
            }
        }
        /// <summary>
        /// The Padding above
        /// </summary>
        public float PaddingTop { get; set; }
        /// <summary>
        /// The Padding on the right side
        /// </summary>
        public float PaddingRight { get; set; }
        /// <summary>
        /// The Padding below
        /// </summary>
        public float PaddingBottom { get; set; }
        /// <summary>
        /// The Padding on the Left side
        /// </summary>
        public float PaddingLeft { get; set; }
        /// <summary>
        /// Set the padding
        /// </summary>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        public void SetPadding(float top, float right, float bottom, float left)
        {
            PaddingTop = top;
            PaddingRight = right;
            PaddingBottom = bottom;
            PaddingLeft = left;
        }

        #endregion

        #region Calculation

        /// <summary>
        /// Calculates the width of the GuiElement and returns the result.
        /// 
        /// The width is PaddingLeft + MinWidth leq inner width leq MaxWidth + PaddingRight.
        /// The inner width is either
        ///    the manual width, if a manual width is set
        /// or
        ///    the calculated width of the content
        /// </summary>
        /// <returns></returns>
        public float GetCalculatedWidth()
        {
            return 
                PaddingLeft + 
                Math.Max(MinWidth, Math.Min(HasManualWidth ? ManualWidth : GetCalculatedContentWidth(), MaxWidth)) +
                PaddingRight
            ;
        }

        /// <summary>
        /// Return the calculated width of the content. 
        /// 
        /// F.e. the sum of all child element widths in a Horizontal Layout.
        /// </summary>
        /// <returns>Zero by default</returns>
        public virtual float GetCalculatedContentWidth()
        {
            return 0;
        }

        /// <summary>
        /// Get the calculated or the percentual width.
        /// 
        /// THe method is called by container layouts to calculate the dimensions of a child element.
        /// 
        /// If a manual width is set, it will be used.
        /// If a percentual width is set, it will be be calculated according the given parent width.
        /// If none of the two is set, the result of GetCalculatedContentWidth() will be used.
        /// </summary>
        /// <param name="parentWidth"></param>
        /// <param name="parentPaddingLeft"></param>
        /// <param name="parentPaddingRight"></param>
        /// <returns></returns>
        public virtual float GetCalculatedOrPercentualContentWidth(float parentWidth, float parentPaddingLeft, float parentPaddingRight)
        {
            if (HasManualWidth)
            {
                return ManualWidth;
            }

            if (HasPercentualWidth)
            {
                return (parentWidth - (parentPaddingLeft + parentPaddingRight)) * PercentualWidth;
            }

            return GetCalculatedContentWidth();
        }

        /// <summary>
        /// Calculates the height of the GuiElement and returns the result.
        /// 
        /// The width is PaddingTop + MinHeight leq inner height leq MaxHeight + PaddingBottom.
        /// The inner height is either
        ///    the manual height, if a manual height is set
        /// or
        ///    the calculated height of the content
        /// </summary>
        /// <returns></returns>
        public float GetCalculatedHeight()
        {
            return 
                PaddingTop + 
                Math.Max(MinHeight, Math.Min(HasManualHeight ? ManualHeight : GetCalculatedContentHeight(), MaxHeight)) + 
                PaddingBottom
            ;
        }

        /// <summary>
        /// Return the calculated height of the content. 
        /// 
        /// F.e. the sum of all child element heights in a vertical Layout.
        /// </summary>
        /// <returns>Zero by default</returns>
        public virtual float GetCalculatedContentHeight()
        {
            return 0;
        }

        /// <summary>
        /// Get the calculated or the percentual content height.
        /// 
        /// THe method is called by container layouts to calculate the dimensions of a child element.
        /// 
        /// If a manual height is set, it will be used.
        /// If a percentual height is set, it will be be calculated according the given parent height.
        /// If none of the two is set, the result of GetCalculatedContentHeight() will be used.
        /// </summary>
        /// <param name="parentHeight"></param>
        /// <param name="parentPaddingTop"></param>
        /// <param name="parentPaddingBottom"></param>
        /// <returns></returns>
        public virtual float GetCalculatedOrPercentualContentHeight(float parentHeight, float parentPaddingTop, float parentPaddingBottom)
        {
            if (HasManualHeight)
            {
                return ManualHeight;
            }

            if (HasPercentualHeight)
            {
                return (parentHeight - (parentPaddingTop + parentPaddingBottom)) * PercentualHeight;
            }

            return GetCalculatedContentHeight();
        }

        #endregion

        /// <summary>
        /// Get the processing data
        /// </summary>
        /// <returns></returns>
        public ProcessingData GetProcessingData()
        {
            return ProcessingData;
        }

        /// <summary>
        /// Get the gui element
        /// </summary>
        /// <returns></returns>
        public IGuiElement GetGuiElement()
        {
            return GuiElement;
        }
    }
}
