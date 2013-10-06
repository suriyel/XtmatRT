using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;

namespace XtmatRT
{
    internal class CaseScript<T> where T:UIItem
    {
        public Guid Id { set; get; }
        public List<ControlScript> ControlScripts { set; get; }

    }
}
