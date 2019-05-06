using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Data;

namespace De.Kjg.Diversity.Interfaces.UXs.Guis.Layout
{
    /// <summary>
    /// Interface definition for layouts
    /// 
    /// Layouts are used to calculate the size and position of gui elements. Each element needs a layout applied to it. 
    /// </summary>
    public interface ILayout
    {
        /// <summary>
        /// True if the element is visible
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// The x position
        /// </summary>
        float X { get; set; }
        /// <summary>
        /// The y position
        /// </summary>
        float Y { get; set; }

        /// <summary>
        /// The horizontal align
        /// </summary>
        HorizontalAlign HorizontalAlign { get; set; }
        /// <summary>
        /// The vertical align
        /// </summary>
        VerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// True if a manual width was set
        /// </summary>
        bool HasManualWidth { get; }
        /// <summary>
        /// Returns true if a percentual width was set
        /// </summary>
        bool HasPercentualWidth { get; }
        /// <summary>
        /// Get the manually set width
        /// </summary>
        float ManualWidth { get; }
        /// <summary>
        /// Get the percentual width
        /// </summary>
        float PercentualWidth { get; }
       
        /// <summary>
        /// True if a manual height is set
        /// </summary>
        bool HasManualHeight { get; }
        /// <summary>
        /// True if a percentual height is set
        /// </summary>
        bool HasPercentualHeight { get; }
        /// <summary>
        /// Get the manually set height
        /// </summary>
        float ManualHeight { get; }
        /// <summary>
        /// Get the percentual height
        /// </summary>
        float PercentualHeight { get; }

        /// <summary>
        /// Get and set all four paddings
        /// </summary>
        float Padding { get; set; }
        /// <summary>
        /// Top padding
        /// </summary>
        float PaddingTop { get; set; }
        /// <summary>
        /// Right padding
        /// </summary>
        float PaddingRight { get; set; }
        /// <summary>
        /// Bottom padding
        /// </summary>
        float PaddingBottom { get; set; }
        /// <summary>
        /// Left padding
        /// </summary>
        float PaddingLeft { get; set; }

        /// <summary>
        /// Set padding
        /// </summary>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <param name="left"></param>
        void SetPadding(float top, float right, float bottom, float left);

        /// <summary>
        /// Reset manual and percentual height and use automatically calculated height
        /// </summary>
        void UseAutomaticalWidth();
        /// <summary>
        /// Get the manually set width
        /// </summary>
        /// <returns></returns>
        float GetWidth();
        /// <summary>
        /// Manually set the width
        /// </summary>
        /// <param name="width"></param>
        void SetWidth(float width);
        /// <summary>
        /// Get percentual width
        /// </summary>
        /// <returns></returns>
        float GetPercentualWidth();
        /// <summary>
        /// Set percentual width
        /// </summary>
        /// <param name="percent"></param>
        void SetPercentualWidth(float percent);
        /// <summary>
        /// Get minimal width
        /// </summary>
        /// <returns></returns>
        float GetMinWidth();
        /// <summary>
        /// Set minimum width
        /// </summary>
        /// <param name="minWidth"></param>
        void SetMinWidth(float minWidth);
        /// <summary>
        /// Get maximum width
        /// </summary>
        /// <returns></returns>
        float GetMaxWidth();
        /// <summary>
        /// Set maximum width
        /// </summary>
        /// <param name="maxWidth"></param>
        void SetMaxWidth(float maxWidth);

        /// <summary>
        /// Reset manual and percentual height and use automatically calculated height
        /// </summary>
        void UseAutomaticalHeight();
        /// <summary>
        /// Get the manually set height
        /// </summary>
        /// <returns></returns>
        float GetHeight();
        /// <summary>
        /// Manually set the height
        /// </summary>
        /// <param name="height"></param>
        void SetHeight(float height);
        /// <summary>
        /// Get the percentual height
        /// </summary>
        /// <returns></returns>
        float GetPercentualHeight();
        /// <summary>
        /// Set the percentual height
        /// </summary>
        /// <param name="percent"></param>
        void SetPercentualHeight(float percent);
        /// <summary>
        /// Get the minimum height
        /// </summary>
        /// <returns></returns>
        float GetMinHeight();
        /// <summary>
        /// Set the minimum height
        /// </summary>
        /// <param name="minHeight"></param>
        void SetMinHeight(float minHeight);
        /// <summary>
        /// Get the maximum height
        /// </summary>
        /// <returns></returns>
        float GetMaxHeight();
        /// <summary>
        /// Set the maximum height
        /// </summary>
        /// <param name="maxHeight"></param>
        void SetMaxHeight(float maxHeight);

        /// <summary>
        /// Calculates the resulting width of the gui element based on all settings 
        /// </summary>
        /// <returns></returns>
        float GetCalculatedWidth();
        /// <summary>
        /// Calculates the resulting height of the gui element based on all settings
        /// </summary>
        /// <returns></returns>
        float GetCalculatedHeight();

        /// <summary>
        /// Calculates the width of the content of the element without padding.
        /// </summary>
        /// <returns></returns>
        float GetCalculatedContentWidth();
        /// <summary>
        /// Calculates the content width, depending on whether percentual width is defined or not.
        /// </summary>
        /// <param name="parentWidth"></param>
        /// <param name="parentPaddingLeft"></param>
        /// <param name="parentPaddingRight"></param>
        /// <returns></returns>
        float GetCalculatedOrPercentualContentWidth(float parentWidth, float parentPaddingLeft, float parentPaddingRight);
        /// <summary>
        /// Calculate the height of the content of the element without padding. 
        /// </summary>
        /// <returns></returns>
        float GetCalculatedContentHeight();
        /// <summary>
        /// Calculates the content height, depending on whether percentual height is defined or not.
        /// </summary>
        /// <param name="parentHeight"></param>
        /// <param name="parentPaddingTop"></param>
        /// <param name="parentPaddingBottom"></param>
        /// <returns></returns>
        float GetCalculatedOrPercentualContentHeight(float parentHeight, float parentPaddingTop, float parentPaddingBottom);

        /// <summary>
        /// Get the processing data.
        /// 
        /// The processing data is used to store drawing geometry, absolute geometry, ...
        /// </summary>
        /// <returns></returns>
        ProcessingData GetProcessingData();
    }
}
