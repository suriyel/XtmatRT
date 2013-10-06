using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    internal class ControlScript
    {
        public Guid Id { set; get; }

        public int Index { set; get; }

        public string BaseControlCondictionScrID { set; get; }

        public CondictionScript CreatCondiction { set; get; }

        public List<MethodScript> CaseScript { set; get; }
    }
}
