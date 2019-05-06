using System.Collections.Generic;

namespace De.Kjg.Diversity.Interfaces.MVC.DataBinding
{
    public interface IBindableContainer
    {
        List<IBindable> GetBindableChildren();
    }
}
