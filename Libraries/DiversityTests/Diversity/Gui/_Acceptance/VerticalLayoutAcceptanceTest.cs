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
    class VerticalLayoutAcceptanceTest
    {
        /// <summary>
        /// We test if the following aspects of the vertical layout work properly:
        /// - Positioning of the VBox
        /// - Padding of the VBox
        /// - Placing of children inside the VBox
        /// - Spacing between the children inside the VBox
        /// </summary>
        [Test]
        public void VerticalLayoutTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer
            var hardware = new NullHardware(1024, 768);
            var stage = new GuiStage();

            var hBox = new VBox().SetX(10).SetY(20).SetPadding(10, 20, 30, 40); // makes a size of 60x40 just through padding
            stage.AddChild(hBox);   
            stage.CalculateLayout(hardware);     // layout

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 60, 40)));

            // add a child
            var spacer1 = new Spacer(200, 100);
            hBox.AddChild(spacer1);     // should increase the size by 200x100                 
            stage.CalculateLayout(hardware);     // layout

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 260, 140)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));

            // add another child
            var spacer2 = new Spacer(300, 200);
            hBox.AddChild(spacer2);     // should increase the size by 200x100                 
            stage.CalculateLayout(hardware);     // layout

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 360, 340)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));
            // check the absolute position of spacer1
            Assert.That(spacer2.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 130, 300, 200)));

            // check setting the spacing
            hBox.SetSpacing(100);
            stage.CalculateLayout(hardware);     // layout

            Assert.That(hBox.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(10, 20, 360, 440)));
            // check the absolute position of spacer1
            Assert.That(spacer1.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 30, 200, 100)));
            // check the absolute position of spacer1
            Assert.That(spacer2.GetLayoutProcessingData().AbsoluteGeometry, Is.EqualTo(new Rectangle(50, 230, 300, 200)));
        }


        /// <summary>
        /// We test if the following aspects of the vertical layout work properly:
        /// - horizontal align when NO height was set -> the the children will ALSO be horizontal aligned
        /// - horizontal align when a height was set -> the children will be horizontal aligned
        /// </summary>
        [Test]
        public void HorizontalAlignTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer
            var hardware = new NullHardware(1024, 768);
            var stage = new GuiStage();

            var box = new VBox();
            stage.AddChild(box);   // makes a size of 60x40 just through padding
            
            var spacerNone = new Spacer(100, 100).SetHAlign(HorizontalAlign.None);
            box.AddChild(spacerNone);
            var spacerLeft = new Spacer(100, 100).SetHAlign(HorizontalAlign.Left);
            box.AddChild(spacerLeft);
            var spacerCenter = new Spacer(100, 100).SetHAlign(HorizontalAlign.Center);
            box.AddChild(spacerCenter);
            var spacerRight = new Spacer(100, 100).SetHAlign(HorizontalAlign.Right);
            box.AddChild(spacerRight);

            // we add one child that will free up some width
            box.AddChild(new Spacer(400, 100));

            stage.CalculateLayout(hardware);     // layout

            // since we have not set a height on the hBox yet we expect all children to be not vertically aligned
            Assert.That(box.GetLayout().GetCalculatedWidth(), Is.EqualTo(400));
            Assert.That(box.GetLayout().GetCalculatedContentWidth(), Is.EqualTo(400));

            Assert.That(spacerNone.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(0));         // NONE stays on top
            Assert.That(spacerLeft.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(0));         // TOP stays on top
            Assert.That(spacerCenter.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(150));     // MIDDLE 400 / 2 - 100 / 2 
            Assert.That(spacerRight.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(300));      // BOTTOM 400 - 100

            // new we set a height and then we expect the children to be aligned
            box.SetWidth(800);
            stage.CalculateLayout(hardware);     // layout

            Assert.That(box.GetLayout().GetCalculatedWidth(), Is.EqualTo(800));
            Assert.That(box.GetLayout().GetCalculatedContentWidth(), Is.EqualTo(400));

            Assert.That(spacerNone.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(0));         // NONE stays on top
            Assert.That(spacerLeft.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(0));         // TOP stays on top
            Assert.That(spacerCenter.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(350));     // MIDDLE 800 / 2 - 100 / 2
            Assert.That(spacerRight.GetLayoutProcessingData().AbsoluteGeometry.Left, Is.EqualTo(700));      // BOTTOM (800 - 100)
        }
    }
}
