using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.Kjg.Diversity.Impl.UXs;
using De.Kjg.Diversity.Interfaces.Abstraction.Hardware;
using De.Kjg.Diversity.Interfaces.Abstraction.Renderers;
using De.Kjg.Diversity.Interfaces.UXs.Guis;
using De.Kjg.Diversity.Interfaces.UXs.Scenes;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.UXs
{
    public class UxUnity3D : Ux
    {
        public UxUnity3D(IGuiStage guiStage, IRenderer renderer, IHardware hardware, IScene scene) : base(guiStage, renderer, hardware, scene)
        {
        }

        public override void Update()
        {
            
        }

        public override void UpdateGui()
        {
            if (Event.current.type == EventType.Layout)
            {
                GuiStage.CalculateLayout(Hardware);
                GuiStage.ProcessInteraction(Hardware);
            }
            else
            {
                GuiStage.Render(Renderer);
            }
        }
    }
}
