using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De.Kjg.Diversity.Interfaces.I18n
{
    public interface II18NDataHolder
    {
        object GetData(string id);
        void SetData(string id, object data);
        II18NDataHolder ResolvePath(List<string> path, bool createHolders);
    }
}
