﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;

namespace XtmatRT
{
    internal class CaseScript:ICloneable  
    {
        public Guid Id { set; get; }
        public List<ControlScript> ControlScripts { set; get; }

        public CaseScript()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new CaseScript()
                {
                    Id = this.Id,
                    ControlScripts = this.ControlScripts.Select(c => c.Clone() as ControlScript).ToList()
                };
        }
    }
}
