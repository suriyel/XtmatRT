using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XtmatRT
{
    public class MethodScript:ICloneable
    {
        public Guid Id { set; get; }

        public Guid MethodID { set; get; }

        public int Index { set; get; }

        public MethodScript()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new MethodScript()
                {
                    Id = this.Id,
                    MethodID = this.MethodID,
                    Index = this.Index
                };
        }
    }
}
