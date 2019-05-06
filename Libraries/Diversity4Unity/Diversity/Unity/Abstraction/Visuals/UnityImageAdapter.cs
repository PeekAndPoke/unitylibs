using De.Kjg.Diversity.Impl.Abstraction.Visuals;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Abstraction.Visuals
{
    public class UnityImageAdapter : BaseImageAdapter
    {
        public UnityImageAdapter(object wrapped) : base(wrapped)
        {
        }

        protected Texture2D Texture
        {
            get { return (Texture2D) GetWrapped(); }
        }

        public override float Width
        {
            get { return Texture.width; }
        }

        public override float Height
        {
            get { return Texture.height; }
        }
    }
}
