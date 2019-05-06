using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Container;
using De.Kjg.Diversity.Impl.UXs.Guis.Layout.Container;
using De.Kjg.Diversity.Impl.UXs.Guis.Processors;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.I18n;
using De.Kjg.Diversity.Interfaces.UXs.Guis;

namespace De.Kjg.Diversity.Impl.UXs.Guis
{
    /// <summary>
    /// The stage is the gui element where all other elements live inside of.
    /// 
    /// It is a container.
    /// It holds the gui skins and styles.
    /// It holds i18n data.
    /// It provides a debug window for gui elements.
    /// </summary>
    public class GuiStage : GenericAbstractGuiContainer<GuiStage>, IGuiStage
    {
        // TODO: move current and previous mouse position into seperate class

        /// <summary>
        /// Allways contains the current mouse position (is update by Draw())
        /// </summary>
        public static Point MousePosition = new Point(-1, -1);
        /// <summary>
        /// container previous mouse position
        /// </summary>
        public static Point PreviousMousePosition = new Point(-1, -1);

        /// <summary>
        /// The input processor
        /// </summary>
        private readonly MouseInputProcessor _mouseInputProcessor = new MouseInputProcessor();
        public MouseInputProcessor MouseInputProcessor { get { return _mouseInputProcessor; } }

        /// <summary>
        /// The behaviour registry
        /// </summary>
        private readonly BehaviourProcessor _behaviourProcessor = new BehaviourProcessor();
        public BehaviourProcessor BehaviourProcessor { get { return _behaviourProcessor; } }

        /// <summary>
        /// I18n data
        /// </summary>
        protected II18N I18N;

        // TODO: remove pseudo-singleton from gui stage

        /// <summary>
        /// The stage instance
        /// </summary>
        private static GuiStage _instance;
        /// <summary>
        /// Get the stage instance
        /// </summary>
        public static GuiStage Instance 
        {
            get { return _instance; }
        }

        /// <summary>
        /// C'tor
        /// </summary>
        public GuiStage()
        {
            _instance = this;
            SetLayout(new GuiStageLayout(this));
            SetMouseEnabled(false);
        }
        /// <summary>
        /// Getter for Layout casting it to GuiStageLayout 
        /// </summary>
        protected GuiStageLayout Layout
        {
            get { return (GuiStageLayout) GetLayout(); }
        }

        /// <summary>
        /// Set i18n data
        /// </summary>
        /// <param name="i18N">the i18n data</param>
        public void SetI18N(II18N i18N)
        {
            I18N = i18N;
        }

        /// <summary>
        /// Get the i18n data
        /// </summary>
        /// <returns></returns>
        public override II18N GetI18N()
        {
            return I18N;
        }

        /// <summary>
        /// Returns this.
        /// </summary>
        /// <returns></returns>
        public override GuiStage GetStage()
        {
            return this;
        }

        public void CalculateLayout(IHardware hardware)
        {
            // the layout needs to know the resolution of the application
            Layout.SetHardware(hardware);

            Layout.Calculate();
        }

        public void ProcessInteraction(IHardware hardware)
        {
            // Update Gui Mouse Position
            PreviousMousePosition.X = MousePosition.X;
            PreviousMousePosition.Y = MousePosition.Y;

            MousePosition.X = hardware.GetMousePosition().X;
            MousePosition.Y = hardware.GetApplicationDisplaySize().Y - hardware.GetMousePosition().Y;

            ProcessMouseInputs(hardware);

            BehaviourProcessor.Process();
        }

        /// <summary>
        /// Calls this on each OnGUI-cycle to draw all gui elements and handle inputs and clicks.
        /// </summary>
        public void Render(IRenderer renderer)
        {
            // draw needs to be called on every events, because unity handles inputs with multiple different events
            renderer.Begin();
            Draw(renderer);
            renderer.Finish();
        }

        /// <summary>
        /// Draw the stage and all its children.
        /// 
        /// The method is made protected to force a call to Update()
        /// </summary>
        /// <param name="renderer"></param>
        protected new void Draw(IRenderer renderer)
        {
            base.Draw(renderer);
        }

        /// <summary>
        /// Process mouse inputs
        /// </summary>
        protected void ProcessMouseInputs(IHardware hardware)
        {
            _mouseInputProcessor.ProcessInputs(this, hardware);
        }
    }
}
