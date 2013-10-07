using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Automation;


namespace XtmatRT
{
    public class CondictionScript : ICloneable
    {
        public Guid Id { set; get; }

        public List<CondictionPair> Pairs { set; get; }

        public int ControlTypeID { set; get; }

        public CondictionScript()
        {
            Id = Guid.NewGuid();
            Pairs=new List<CondictionPair>();
        }

        public object Clone()
        {
            return new CondictionScript()
                {
                    Id = this.Id,
                    Pairs=this.Pairs.Select(p=>p.Clone() as CondictionPair).ToList(),
                    ControlTypeID = this.ControlTypeID
                };
        }
    }

    public class CondictionPair:ICloneable
    {
        public CondictionType Type { set; get; }

        public object Paremter { set; get; }


        public object Clone()
        {
            return new CondictionPair()
                {
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
