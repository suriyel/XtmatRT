using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Automation;

namespace XtmatRT
{
    public class MethodStep
    {
        public Guid Id { set; get; }

        public MethodInfo MethodInfo { set; get; }

        public ControlType Type { set; get; }

        public MethodStep()
        {
            Id = Guid.NewGuid();
            ;
        }

        public object Clone()
        {
            return new MethodStep()
                {
                    Id = this.Id,
                    MethodInfo = this.MethodInfo,
                    Type = this.Type
                };
        }
    }
}
