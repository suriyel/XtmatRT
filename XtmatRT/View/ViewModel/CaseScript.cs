using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;

namespace XtmatRT
{
    internal class CaseScriptVM:ICloneable
    {
        public Guid Id { set; get; }

        public List<ControlScriptVM> ControlScripts { set; get; }

        public CondictionScriptVM ParentContainer { set; get; }

        public List<CondictionScriptVM> BaseCondictions { set; get; }

        public CaseScriptVM()
        {
            Id = Guid.NewGuid();
            ControlScripts = new List<ControlScriptVM>();
            BaseCondictions = new List<CondictionScriptVM>();
        }

        public object Clone()
        {
            return new CaseScriptVM()
                {
                    Id = this.Id,
                    BaseCondictions = BaseCondictions.Select(bc => bc.Clone() as CondictionScriptVM).ToList(),
                    ControlScripts = this.ControlScripts.Select(cs => cs.Clone() as ControlScriptVM).ToList()
                };
        }
    }
}
