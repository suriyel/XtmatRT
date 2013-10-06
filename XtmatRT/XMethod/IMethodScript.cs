using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XtmatRT
{
    internal abstract class IMethodScript:ICloneable
    {
        protected Guid Id { set; get; }

        protected MethodInfo MethodInfo { set; get; }

        protected object Parameter { set; get; }

        protected IMethodScript()
        {
            Id = Guid.NewGuid();
        }

        public abstract object Clone();
    }
}
