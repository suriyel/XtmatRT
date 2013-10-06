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

        public CaseScriptVM()
        {
            Id = Guid.NewGuid();
            ControlScripts = new List<ControlScriptVM>();
        }

        public object Clone()
        {
            return new CaseScriptVM()
                {
                    Id = this.Id,
                    ControlScripts = this.ControlScripts.Select(cs => cs.Clone() as ControlScriptVM).ToList()
                };
        }
    }
}
