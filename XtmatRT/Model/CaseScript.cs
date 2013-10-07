using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;

namespace XtmatRT
{
    public class CaseScript:ICloneable  
    {
        public Guid Id { set; get; }

        public CondictionScript ParentContainer { set; get; }

        public List<CondictionScript> BaseCondictions { set; get; }

        public List<ControlScript> ControlScripts { set; get; }

        public CaseScript()
        {
            Id = Guid.NewGuid();
            BaseCondictions = new List<CondictionScript>();
            ControlScripts = new List<ControlScript>();
        }

        public object Clone()
        {
            return new CaseScript()
                {
                    Id = this.Id,
                    ParentContainer=this.ParentContainer.Clone() as CondictionScript,
                    BaseCondictions = this.BaseCondictions.Select(bc => bc.Clone() as CondictionScript).ToList(),
                    ControlScripts = this.ControlScripts.Select(c => c.Clone() as ControlScript).ToList()
                };
        }
    }
}
