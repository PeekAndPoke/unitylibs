using De.Kjg.Diversity.Impl.Abstraction.Data;
using De.Kjg.Diversity.Impl.Abstraction.Visuals;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Abstraction.Visuals
{
    public class UnityStyleAdapter : BaseStyleAdapter
    {
        public UnityStyleAdapter(object wrapped) : base(wrapped)
        {
        }

        public GUIStyle GuiStyle
        {
            get { return (GUIStyle) Wrapped; }
        }

        public override Point GetBackgroundImageSize()
        {
            return new Point(
                GuiStyle.normal.background.width,
                GuiStyle.normal.background.height
            );
        }
    }
}
