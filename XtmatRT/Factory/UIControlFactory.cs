using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace XtmatRT
{
    public static class UIControlFactory<C, T>
        where C : UIItemContainer
        where T : UIItem
    {
        private static Dictionary<CondictionType, Func<C, object, T>> CondictionScripts = new Dictionary<CondictionType, Func<C, object, T>>()
            {
                {CondictionType.All,(c,p)=>c.Get<T>(SearchCriteria.All)},
                {CondictionType.AutomationID,(c,p)=>c.Get<T>(SearchCriteria.ByAutomationId(p.ToString()))},
                {CondictionType.ClassName,(c,p)=>c.Get<T>(SearchCriteria.ByClassName(p.ToString()))},
                {CondictionType.ControlType,(c,p)=>c.Get<T>(SearchCriteria.ByControlType((ControlType)p))},
                {CondictionType.FrameWorkId,(c,p)=>c.Get<T>(SearchCriteria.ByFramework(p.ToString()))},
                {CondictionType.Index,(c,p)=>c.Get<T>(SearchCriteria.Indexed(int.Parse(p.ToString())))},
                {CondictionType.NativeProperty,(c,p)=>
                    {
                        var autoProperty = (Tuple<AutomationProperty, object>) p;
                       return c.Get<T>(SearchCriteria.ByNativeProperty(autoProperty.Item1, autoProperty.Item2));
                    }},
                {CondictionType.Text,(c,p)=>c.Get<T>(SearchCriteria.ByText(p.ToString()))},
            };

        public static T GetControl(C container, CondictionScript script)
        {
            try
            {
                for (int i = 0; i < script.Pairs.Count; i++)
                {
                    var tempContainer = CondictionScripts[script.Pairs[i].Type](container, script.Pairs[i].Paremter);
                    container = tempContainer as C;
                    if (container == null && i != script.Pairs.Count - 1)
                    {
                        return null;
                    }
                }
                return container as T;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
    }
}
