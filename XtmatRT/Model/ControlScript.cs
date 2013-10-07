using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    public class ControlScript:ICloneable
    {
        public Guid Id { set; get; }

        public int Index { set; get; }

        public Guid BaseControlCondictionScrID { set; get; }

        public CondictionScript CreatCondiction { set; get; }

        public List<MethodScript> MethodScripts { set; get; }

        public ControlScript()
        {
            Id = Guid.NewGuid();
            MethodScripts = new List<MethodScript>();
        }

        public object Clone()
        {
            return new ControlScript()
                {
                    Id = this.Id,
                    Index = this.Index,
                    BaseControlCondictionScrID = this.BaseControlCondictionScrID,
                    CreatCondiction = this.CreatCondiction.Clone() as CondictionScript,
                    MethodScripts = this.MethodScripts.Select(cs => cs.Clone() as MethodScript).ToList()
                };
        }
    }
}
