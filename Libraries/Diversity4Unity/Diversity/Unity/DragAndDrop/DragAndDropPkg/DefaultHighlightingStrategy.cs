using System.Collections.Generic;
using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;
using De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg.Interfaces;
using De.Kjg.Diversity.Unity.Gui;
using UnityEngine;

namespace De.Kjg.Diversity.Unity.DragAndDrop.DragAndDropPkg
{
    public class DefaultHighlightingStrategy : IHighlightingStrategy
    {
        private readonly Texture2D _dropTargetTexture;

        /// <summary>
        /// Contains possible Drop targets and a clone of their original GUIStyle
        /// </summary>
        protected readonly Dictionary<IGuiElement, GUIStyle> StyleCache = new Dictionary<IGuiElement, GUIStyle>();

        public DefaultHighlightingStrategy(Texture2D dropTargetTexture = null)
        {
            if (dropTargetTexture != null)
            {
                _dropTargetTexture = dropTargetTexture;
            }
            else
            {
                // create a default highlight texture
                var tex = new Texture2D(2, 2);
                tex.SetPixel(0, 0, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(1, 0, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(0, 1, new Color(1, 0, 0, 0.3f));
                tex.SetPixel(1, 1, new Color(1, 0, 0, 0.3f));
                tex.Apply();
                _dropTargetTexture = tex;
            }
        }

        public void Highlight(IEnumerable<IGuiElement> dropTargets)
        {
            foreach (var element in dropTargets)
            {
                StyleCache.Add(element, element.GetStyle() != null ? new GUIStyle(element.GetStyle().ToGuiStyle()) : null);

                if (element.GetStyle() == null)
                {
                    element.SetStyle(new GUIStyle().ToStyle());
                }

                element.GetStyle().ToGuiStyle().normal.background = _dropTargetTexture;
                element.GetStyle().ToGuiStyle().border = new RectOffset(2, 2, 2, 2);
            }
        }

        public void Restore()
        {
            foreach (var target in StyleCache)
            {
                target.Key.SetStyle(target.Value.ToStyle());
            }
        }
    }
}
