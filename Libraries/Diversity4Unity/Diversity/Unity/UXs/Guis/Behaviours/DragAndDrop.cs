using System.Collections.Generic;
using De.Kjg.Diversity.Impl.UXs.Guis;
using De.Kjg.Diversity.Impl.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Behaviours;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg;
using De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg.Interfaces;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.Gui.Behaviours
{
    /// <summary>
    /// Drop and drop behaviour.
    /// 
    /// It can be configured to behave in different ways by setting different stratagies.
    /// <see cref="SetDragAndDropStrategy"/>
    /// <see cref="SetHighlightingStrategy"/>
    /// </summary>
    public class DragAndDrop : AbstractBehaviour
    {
        protected GuiStage GuiStage;

        protected static Texture2D DropTargetTexture;

        protected IDragAndDropStrategy DragAndDropStrategy = new DefaultDragAndDropStrategy();
        protected IHighlightingStrategy HighlightingStrategy = new DefaultHighlightingStrategy();

        protected List<IGuiElement> PossibleDropTargets; 

        public DragAndDrop SetDragAndDropStrategy(IDragAndDropStrategy strategy)
        {
            DragAndDropStrategy = strategy;
            return this;
        }

        public DragAndDrop SetHighlightingStrategy(IHighlightingStrategy strategy)
        {
            HighlightingStrategy = strategy;
            return this;
        } 

        public override void Initialize()
        {
            if (!(GuiElement is IDraggable))
            {
                // throw new ArgumentException("The GuiElement has to implement IDraggable!");
            }

            GuiStage = GuiElement.GetStage();

            DragAndDropStrategy.Initialize(GuiElement);

            PossibleDropTargets = DragAndDropStrategy.FindPossibleDropTargets(GuiElement.GetStage());

            HighlightingStrategy.Highlight(PossibleDropTargets);

            DragAndDropStrategy.Grab();

//            UnityEngine.Debug.Log("start drag and drop - targets: " + PossibleDropTargets.Count);
        }

        public override bool Process()
        {
            if (!Input.GetMouseButton(0))
            {
                HighlightingStrategy.Restore();

                DragAndDropStrategy.HandleMouseUp(PossibleDropTargets);

                return false;
            }

            DragAndDropStrategy.Move();

            return true;
        }

        public override void Destroy()
        {
        }
    }
}
