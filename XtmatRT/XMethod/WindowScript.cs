using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT.XMethod
{
    internal class WindowScript : IMethodScript
    {
        public override object Clone()
        {
            return new WindowScript()
                {
                    Id = this.Id,
                    MethodInfo = this.MethodInfo,
                    Parameter = this.Clone()
                };
        }
    }
}
