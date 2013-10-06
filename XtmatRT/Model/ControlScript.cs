using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    internal class ControlScript:ICloneable
    {
        public Guid Id { set; get; }

        public int Index { set; get; }

        public string BaseControlCondictionScrID { set; get; }

        public CondictionScript CreatCondiction { set; get; }

        public List<MethodScript> CaseScript { set; get; }

        public ControlScript()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new ControlScript()
                {
                    Id = this.Id,
                    Index = this.Index,
                    BaseControlCondictionScrID = this.BaseControlCondictionScrID,
                    CreatCondiction = this.CreatCondiction.Clone() as CondictionScript,
                    CaseScript = this.CaseScript.Select(cs => cs.Clone() as MethodScript).ToList()
                };
        }
    }
}
