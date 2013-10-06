using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace XtmatRT
{
    internal class CondictionScript
    {
        public Guid Id { set; get; }

        public CondictionType Type { set; get; }

        public string Paremter { set; get; }
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
