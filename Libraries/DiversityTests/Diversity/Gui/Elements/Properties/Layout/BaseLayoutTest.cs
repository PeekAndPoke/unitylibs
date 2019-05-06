using System;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout;
using NUnit.Framework;

namespace De.Kjg.Diversity.Gui.Elements.Properties.Layout
{
    [TestFixture]
    class BaseLayoutTest
    {
        /// <summary>
        /// Test the constructor and default values
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            var guiElement = new Spacer(100, 100);
            var layout = new BaseLayout(guiElement);

            // check that the guiElement was set
            Assert.That(layout.GetGuiElement(), Is.EqualTo(guiElement));

            // check for default values
            Assert.That(layout.HorizontalAlign, Is.EqualTo(HorizontalAlign.None));
            Assert.That(layout.VerticalAlign, Is.EqualTo(VerticalAlign.None));
            Assert.That(layout.Visible, Is.EqualTo(true));
        }

        /// <summary>
        /// Test the default value of all properties
        /// </summary>
        [Test]
        public void PropertyDefaultsTests() 
        {
            var guiElement = new Spacer(100, 100);
            var layout = new BaseLayout(guiElement);

            // check width properties default values
            Assert.That(layout.HasManualWidth,          Is.EqualTo(false));
            Assert.That(layout.HasPercentualWidth,      Is.EqualTo(false));
            Assert.That(layout.ManualWidth,             Is.EqualTo(0));
            Assert.That(layout.PercentualWidth,         Is.EqualTo(0));
            Assert.That(layout.MinWidth,                Is.EqualTo(0));
            Assert.That(layout.MaxWidth,                Is.EqualTo(Single.MaxValue));

            // check height properties default values
            Assert.That(layout.HasManualHeight,         Is.EqualTo(false));
            Assert.That(layout.HasPercentualHeight,     Is.EqualTo(false));
            Assert.That(layout.ManualHeight,            Is.EqualTo(0));
            Assert.That(layout.PercentualHeight,        Is.EqualTo(0));
            Assert.That(layout.MinHeight,               Is.EqualTo(0));
            Assert.That(layout.MaxHeight,               Is.EqualTo(Single.MaxValue));

            // check padding
            Assert.That(layout.PaddingTop,              Is.EqualTo(0));
            Assert.That(layout.PaddingRight,            Is.EqualTo(0));
            Assert.That(layout.PaddingBottom,           Is.EqualTo(0));
            Assert.That(layout.PaddingLeft,             Is.EqualTo(0));
        }

        [Test]
        public void SetXTest()
        {
            var layout = new BaseLayout(null);

            layout.X = 100;

            Assert.That(layout.X, Is.EqualTo(100));
        }

        [Test]
        public void SetYTest()
        {
            var layout = new BaseLayout(null);

            layout.Y = 100;

            Assert.That(layout.Y, Is.EqualTo(100));
        }

        [Test]
        public void AutomaticalPercentualManualWidthTest()
        {
            var layout = new BaseLayout(null);

            layout.SetWidth(100);
            Assert.That(layout.GetWidth(), Is.EqualTo(100));
            Assert.That(layout.HasManualWidth, Is.EqualTo(true));
            Assert.That(layout.HasPercentualWidth, Is.EqualTo(false));

            layout.SetPercentualWidth(100);
            Assert.That(layout.GetPercentualWidth(), Is.EqualTo(100));
            Assert.That(layout.HasManualWidth, Is.EqualTo(false));
            Assert.That(layout.HasPercentualWidth, Is.EqualTo(true));

            layout.UseAutomaticalWidth();
            Assert.That(layout.HasManualWidth, Is.EqualTo(false));
            Assert.That(layout.HasPercentualWidth, Is.EqualTo(false));
        }

        [Test]
        public void SetPaddingTest()
        {
            var layout = new BaseLayout(null);

            layout.SetPadding(10, 20, 30, 40);

            Assert.That(layout.PaddingTop, Is.EqualTo(10));
            Assert.That(layout.PaddingRight, Is.EqualTo(20));
            Assert.That(layout.PaddingBottom, Is.EqualTo(30));
            Assert.That(layout.PaddingLeft, Is.EqualTo(40));
        }

        [Test]
        public void PaddingSetterTest()
        {
            var layout = new BaseLayout(null);

            layout.Padding = 10;

            Assert.That(layout.PaddingTop, Is.EqualTo(10));
            Assert.That(layout.PaddingRight, Is.EqualTo(10));
            Assert.That(layout.PaddingBottom, Is.EqualTo(10));
            Assert.That(layout.PaddingLeft, Is.EqualTo(10));
        }

        [Test]
        public void SetGetterTest()
        {
            var layout = new BaseLayout(null);

            layout.SetPadding(10, 20, 30, 40);

            // the getter only returns Layout.PaddingTop
            Assert.That(layout.Padding, Is.EqualTo(10));
        }

        [Test]
        public void GetCalculatedContentWidthTest()
        {
            var layout = new BaseLayout(null);
            layout.SetWidth(100);

            // the base layout does not calculate its contents width.
            Assert.That(layout.GetCalculatedContentWidth(), Is.EqualTo(0));
        }

        [Test]
        public void GetCalculatedWidthWithManualWidthTest()
        {
            var layout = new BaseLayout(null);
            layout.SetWidth(100);
            layout.Padding = 10;

            Assert.That(layout.GetCalculatedWidth(), Is.EqualTo(120));
        }

        [Test]
        public void GetCalculatedWidthWithoutManualWidthTest()
        {
            var layout = new BaseLayout(null);
            layout.Padding = 10;

            // since the base layout does not calculate its contents width we will only get the padding summed
            Assert.That(layout.GetCalculatedWidth(), Is.EqualTo(20));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthAutomaticWidthTest()
        {
            var layout = new BaseLayout(null);

            Assert.That(layout.GetCalculatedOrPercentualContentWidth(100, 10, 20), Is.EqualTo(0));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthWithManualWidthTest()
        {
            var layout = new BaseLayout(null);
            layout.SetWidth(100);

            Assert.That(layout.GetCalculatedOrPercentualContentWidth(100, 10, 20), Is.EqualTo(100));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthWithPercentualWidthTest()
        {
            var layout = new BaseLayout(null);
            layout.SetPercentualWidth(0.5f);

            // we expect (130 - 10 + 20) * 0.5
            Assert.That(layout.GetCalculatedOrPercentualContentWidth(130, 10, 20), Is.EqualTo(50));
        }

        [Test]
        public void GetCalculatedContentHeightTest()
        {
            var layout = new BaseLayout(null);
            layout.SetHeight(100);

            // the base layout does not calculate its contents height.
            Assert.That(layout.GetCalculatedContentHeight(), Is.EqualTo(0));
        }

        [Test]
        public void GetCalculatedWidthWithManualHeightTest()
        {
            var layout = new BaseLayout(null);
            layout.SetHeight(100);
            layout.Padding = 10;

            Assert.That(layout.GetCalculatedHeight(), Is.EqualTo(120));
        }

        [Test]
        public void GetCalculatedWidthWithoutManualHeightTest()
        {
            var layout = new BaseLayout(null);
            layout.Padding = 10;

            // since the base layout does not calculate its contents width we will only get the padding summed
            Assert.That(layout.GetCalculatedHeight(), Is.EqualTo(20));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthAutomaticHeightTest()
        {
            var layout = new BaseLayout(null);

            Assert.That(layout.GetCalculatedOrPercentualContentHeight(100, 10, 20), Is.EqualTo(0));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthWithManualHeightTest()
        {
            var layout = new BaseLayout(null);
            layout.SetHeight(100);

            Assert.That(layout.GetCalculatedOrPercentualContentHeight(100, 10, 20), Is.EqualTo(100));
        }

        [Test]
        public void GetCalculatedOrPercentualContentWidthWithPercentualHeightTest()
        {
            var layout = new BaseLayout(null);
            layout.SetPercentualHeight(0.5f);

            // we expect (130 - 10 + 20) * 0.5
            Assert.That(layout.GetCalculatedOrPercentualContentHeight(130, 10, 20), Is.EqualTo(50));
        }

    }
}
