using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XtmatRT
{
    internal class CondictionScript:ICloneable
    {
        public Guid Id { set; get; }

        public CondictionType Type { set; get; }

        public string Paremter { set; get; }

        public CondictionScript()
        {
            Id = Guid.NewGuid();
        }

        public object Clone()
        {
            return new CondictionScript()
                {
                    Id = this.Id,
                    Type = this.Type,
                    Paremter = this.Paremter
                };
        }
    }
    public enum CondictionType
    {
        All,
        AutomationID,
        ClassName,
        ControlType,
        FrameWorkId,
        NativeProperty,
        Text,
        Index
    }
}
