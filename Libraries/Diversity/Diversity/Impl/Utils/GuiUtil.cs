using De.Kjg.Diversity.Interfaces.UXs.Guis.Elements;

namespace De.Kjg.Diversity.Impl.Utils
{
    public class GuiUtil
    {
        public static string GetGuiElementPath(IGuiElement element)
        {
            var path = "";
            while (element != null)
            {
                path = element.GetType().Name + (path == "" ? "" : "." + path);
                element = element.GetParent();
            }
            return path;
        }
    }
}
