using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    internal class MethodScriptVM:ICloneable
    {
        public Guid Id { set; get; }

        public MethodScript Method { set; get; }

        public int Index { set; get; }

        public MethodScriptVM()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new MethodScriptVM()
                {
                    Id = this.Id,
                    Method = this.Method.Clone() as MethodScript,
                    Index = this.Index
                };
        }
    }
}
