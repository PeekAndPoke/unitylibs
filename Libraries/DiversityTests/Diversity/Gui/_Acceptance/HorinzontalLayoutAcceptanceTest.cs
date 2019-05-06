using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.Abstraction.Hardware;
using De.Kjg.Diversity.Impl.Abstraction.Renderers;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using NSubstitute;
using NUnit.Framework;

namespace De.Kjg.Diversity.Gui._Acceptance
{
    [TestFixture]
    class HorinzontalLayoutAcceptanceTest
    {
        /// <summary>
        /// We test if the following aspects of the horizontal layout work properly:
        /// - Positioning of the HBox
        /// - Padding of the HBox
        /// - Placing of children inside the HBox
        /// - Spacing between the children inside the HBox
        /// </summary>
        [Test]
        public void HorizontalLayoutTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer
            var hardware = new NullHardware(1024, 768);
            var stage = new GuiStage();

            var hBox = new HBox().SetX(10).SetY(20).SetPadding(10, 20, 30, 40); // makes a size of 60x40 just through padding
            stage.AddChild(hBox);
            stage.CalculateLayout(hardware);

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 60, 40)));

            // add a child
            var spacer1 = new Spacer(200, 100);
            hBox.AddChild(spacer1);     // should increase the size by 200x100                 
            stage.CalculateLayout(hardware);

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 260, 140)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));

            // add another child
            var spacer2 = new Spacer(300, 200);
            hBox.AddChild(spacer2);     // should increase the size by 200x100                 
            stage.CalculateLayout(hardware);

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 560, 240)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));
            // check the absolute position of spacer1
            Assert.That(spacer2.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(250, 30, 300, 200)));

            // check setting the spacing
            hBox.SetSpacing(100);
            stage.CalculateLayout(hardware);

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 660, 240)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));
            // check the absolute position of spacer1
            Assert.That(spacer2.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(350, 30, 300, 200)));
        }


        /// <summary>
        /// We test if the following aspects of the horizontal layout work properly:
        /// - vertical align when NO height was set -> the the children will ALSO be vertical aligned
        /// - vertical align when a height was set -> the children will be vertical aligned
        /// </summary>
        [Test]
        public void VerticalAlignTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer
            var hardware = new NullHardware(1024, 768);
            var stage = new GuiStage();

            var box = new HBox();
            stage.AddChild(box);   // makes a size of 60x40 just through padding
            
            var spacerNone = new Spacer(100, 100).SetVAlign(VerticalAlign.None);
            box.AddChild(spacerNone);
            var spacerTop = new Spacer(100, 100).SetVAlign(VerticalAlign.Top);
            box.AddChild(spacerTop);
            var spacerMiddle = new Spacer(100, 100).SetVAlign(VerticalAlign.Middle);
            box.AddChild(spacerMiddle);
            var spacerBottom = new Spacer(100, 100).SetVAlign(VerticalAlign.Bottom);
            box.AddChild(spacerBottom);

            // we add one child that will free up some height
            box.AddChild(new Spacer(100, 400));

            stage.CalculateLayout(hardware);

            // since we have not set a height on the hBox yet we expect all children to be not vertically aligned
            Assert.That(box.GetLayout().GetCalculatedHeight(), Is.EqualTo(400));
            Assert.That(box.GetLayout().GetCalculatedContentHeight(), Is.EqualTo(400));

            Assert.That(spacerNone.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(0));      // NONE stays on top
            Assert.That(spacerTop.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(0));       // TOP stays on top
            Assert.That(spacerMiddle.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(150));  // MIDDLE 400 / 2 - 100 / 2 
            Assert.That(spacerBottom.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(300));    // BOTTOM 400 - 100

            // new we set a height and then we expect the children to be aligned
            box.SetHeight(800);
            stage.CalculateLayout(hardware);

            Assert.That(box.GetLayout().GetCalculatedHeight(), Is.EqualTo(800));
            Assert.That(box.GetLayout().GetCalculatedContentHeight(), Is.EqualTo(400));

            Assert.That(spacerNone.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(0));      // NONE stays on top
            Assert.That(spacerTop.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(0));       // TOP stays on top
            Assert.That(spacerMiddle.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(350));  // MIDDLE 800 / 2 - 100 / 2
            Assert.That(spacerBottom.GetLayoutProcessingData().AbsoluteGeometry.Top, Is.EqualTo(700));  // BOTTOM (800 - 100)
        }
    }
}
