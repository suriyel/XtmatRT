using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace XtmatRT
{
    [AttributeUsage(AttributeTargets.Method,Inherited = false)]
    public sealed class CommonMethodAtr:Attribute
    {
        private static Dictionary<Type, int> ControlTypeDic = Ulity.AvailableControlType.ToDictionary(r => r.Value,
                                                                                                       r => r.Key); 
        public ControlType Type { set; get; }

        public CommonMethodAtr(Type type)
        {
            Type = ControlType.LookupById(ControlTypeDic[type]);
        }
    }
}
