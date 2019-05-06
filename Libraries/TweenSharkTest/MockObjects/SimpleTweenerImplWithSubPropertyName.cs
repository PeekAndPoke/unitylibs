using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TweenSharkTest.MockObjects
{
    class SimpleTweenerImplWithSubPropertyName<TValueType> : SimpleTweenerImpl<TValueType>
    {
        public override string GetSubPropertyName()
        {
            return "_sub";
        }
    }
}
