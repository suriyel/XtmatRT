using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    internal class ControlScriptVM:ICloneable
    {
        public Guid Id { set; get; }

        public int Index { set; get; }

        public CondictionScriptVM BaseControlCondiction { set; get; }

        public CondictionScriptVM CreatCondiction { set; get; }

        public List<MethodScriptVM> CaseScript { set; get; }

        public ControlScriptVM()
        {
            Id = Guid.NewGuid();
            CaseScript = new List<MethodScriptVM>();
        }

        public object Clone()
        {
            return new ControlScriptVM()
                {
                    Id = this.Id,
                    Index = this.Index,
                    BaseControlCondiction = this.BaseControlCondiction.Clone() as CondictionScriptVM,
                    CreatCondiction = this.CreatCondiction.Clone() as CondictionScriptVM,
                    CaseScript = this.CaseScript.Select(cs => cs.Clone() as MethodScriptVM).ToList()
                };
        }
    }
}
