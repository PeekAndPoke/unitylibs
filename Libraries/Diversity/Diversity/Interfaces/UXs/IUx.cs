using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;

namespace De.Kjg.Diversity.Interfaces.UXs
{
    public interface IUx
    {
        IGuiStage GetGuiStage();
        IRenderer GetRenderer();
        IHardware GetHardware();
        IScene GetScene();

        void Update();
        void UpdateGui();
    }
}
