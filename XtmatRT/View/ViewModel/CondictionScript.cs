﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XtmatRT
{
    internal class CondictionScriptVM:ICloneable
    {
        public Guid Id { set; get; }

        public CondictionType Type { set; get; }

        public string Paremter { set; get; }

        public CondictionScriptVM()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new CondictionScriptVM()
                {
                    Id = this.Id,
                    Type = this.Type,
                    Paremter = this.Paremter
                };
        }
    }
}
