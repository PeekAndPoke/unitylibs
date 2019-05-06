using De.Kjg.Diversity.Impl.UXs.Guis.Elements.Basic;
using De.Kjg.Diversity.Unity.Debug.Interfaces;

namespace De.Kjg.Diversity.Unity.Debug.Panels
{
    class DummyPanel : AbstractDebugPanel<DummyPanel>
    {
        public DummyPanel()
        {
            AddChild(new Label(100, 20, "Dummy"));
        }

        public override string GetName()
        {
            return "Dummy";
        }
    }
}
