using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.Abstraction.Hardware;
using De.Kjg.Diversity.Impl.Abstraction.Renderers;
using De.Kjg.Diversity.Impl.Abstraction.Visuals;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.Abstraction.Visuals;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using NSubstitute;
using NUnit.Framework;

namespace De.Kjg.Diversity.Gui._Acceptance
{
    [TestFixture]
    class BasicElementsAcceptanceTest
    {
        [Test]
        public void ButtonAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer
            
            TestAcceptanceFor(renderer, new Button(100, 200, "TEXT").SetX(50).SetY(75));

            renderer.Received(1).RenderButton(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(), 
                Arg.Any<string>(), 
                Arg.Any<IStyle>()
            );
        }

        [Test]
        public void ImageAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            var image = new BaseImageAdapter(null);

            TestAcceptanceFor(renderer, new Image(100, 200, image).SetX(50).SetY(75));

            renderer.Received(1).RenderImage(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(),
                Arg.Any<string>(),
                Arg.Any<IImage>()
            );
        }

        [Test]
        public void ImageButtonAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            TestAcceptanceFor(renderer, new ImageButton(100, 200, null).SetX(50).SetY(75));

            renderer.Received(1).RenderButton(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(),
                Arg.Is(""),
                Arg.Any<IStyle>()
            );
        }

        [Test]
        public void ImageToggleButtonAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            TestAcceptanceFor(renderer, new ImageToggleButton(100, 200, null).SetX(50).SetY(75));

            renderer.Received(1).RenderImageToggleButton(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(),
                Arg.Any<bool>(),
                Arg.Any<IImage>(),
                Arg.Any<IStyle>()
            );
        }

        [Test]
        public void LabelAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            TestAcceptanceFor(renderer, new Label(100, 200, "TEXT").SetX(50).SetY(75));

            renderer.Received(1).RenderLabel(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(), 
                Arg.Any<string>(),
                Arg.Any<IStyle>(), 
                Arg.Any<bool>(), 
                Arg.Any<RgbaColor>(),
                Arg.Any<float>(),
                Arg.Any<float>()
            );
        }

        [Test]
        public void SpacerAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            TestAcceptanceFor(renderer, new Spacer(100, 200).SetX(50).SetY(75));

            renderer.Received(1).RenderSpacer(
                Arg.Any<string>(), 
                Arg.Any<Rectangle>()
                );
        }

        [Test]
        public void ToggleButtonAcceptanceTest()
        {
            var renderer = Substitute.For<NullRenderer>();  // mock the renderer

            TestAcceptanceFor(renderer, new ToggleButton(100, 200, "TEXT").SetX(50).SetY(75));

            renderer.Received(1).RenderToggleButton(
                Arg.Any<string>(),
                Arg.Any<Rectangle>(),
                Arg.Any<bool>(),
                Arg.Any<string>(),
                Arg.Any<IStyle>()
            );
        }


        protected void TestAcceptanceFor(IRenderer renderer, IGuiElement guiElement)
        {
            var hardware = new NullHardware(1024, 768);
            var stage = new GuiStage();

            stage.AddChild(guiElement);

            // Layout and Render
            stage.CalculateLayout(hardware);
            stage.ProcessInteraction(hardware);
            stage.Render(renderer);

            var processingData = guiElement.GetLayoutProcessingData();

            // drawing geometry
            Assert.AreEqual(processingData.DrawingGeometry.X, 50);
            Assert.AreEqual(processingData.DrawingGeometry.Y, 75);
            Assert.AreEqual(processingData.DrawingGeometry.Width, 100);
            Assert.AreEqual(processingData.DrawingGeometry.Height, 200);
            // absolute geometry
            Assert.AreEqual(processingData.AbsoluteGeometry.X, 50);
            Assert.AreEqual(processingData.AbsoluteGeometry.Y, 75);
            Assert.AreEqual(processingData.AbsoluteGeometry.Width, 100);
            Assert.AreEqual(processingData.AbsoluteGeometry.Height, 200);
            // clip rect
            Assert.AreEqual(processingData.ClipRect.X, 50);
            Assert.AreEqual(processingData.ClipRect.Y, 75);
            Assert.AreEqual(processingData.ClipRect.Width, 100);
            Assert.AreEqual(processingData.AbsoluteGeometry.Height, 200);
        }
    }
}
