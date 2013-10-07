using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace XtmatRT
{
    public static class CondictionFinder
    {
        public static Dictionary<CondictionType, Func<Window, AutomationElement,CondictionScript>> CondictionScripts = new Dictionary
            <CondictionType, Func<Window, AutomationElement, CondictionScript>>()
            {
                {CondictionType.All, (w,element) =>null
                    //{
                    //    if(Get(w, element, SearchCriteria.All))
                    //    {
                    //        var c= new CondictionScript();
                    //        c.Pairs.Add(new CondictionPair()
                    //            {
                    //                Paremter = string.Empty,
                    //                Type = CondictionType.All
                    //            });
                    //        return c;
                    //    }
                    //    return null;
                    //}
                    },
                {
                    CondictionType.AutomationID,
                    (w, element) =>
                        {
                          
                            if(Get(w, element, SearchCriteria.ByAutomationId(element.Current.AutomationId)))
                            {
                                var c = new CondictionScript(){ControlTypeID = element.Current.ControlType.Id};
                                c.Pairs.Add(new CondictionPair() { Paremter = element.Current.AutomationId, Type = CondictionType.AutomationID });
                                return c;
                            }
                            return null;
                        }
                },
                {
                    CondictionType.ClassName,
                    (w, element) =>
                        {
                            if(Get(w, element, SearchCriteria.ByClassName(element.Current.ClassName)))
                            {
                                var c = new CondictionScript() { ControlTypeID = element.Current.ControlType.Id };
                                c.Pairs.Add(new CondictionPair() { Paremter = element.Current.ClassName, Type = CondictionType.ClassName });
                                return c;
                            }
                            return null;
                        }
                },
                {CondictionType.ControlType, (w, element) =>null},
                {CondictionType.FrameWorkId, (w, element) =>
                    {
                        if(Get(w, element, SearchCriteria.ByFramework(element.Current.FrameworkId)))
                        {
                            var c = new CondictionScript() { ControlTypeID = element.Current.ControlType.Id };
                            c.Pairs.Add(new CondictionPair() { Paremter = element.Current.FrameworkId, Type = CondictionType.FrameWorkId });
                            return c;
                        }
                        return null;
                    }},
                {CondictionType.Index, (w, element) =>
                    {
                       if(Get(w, element, SearchCriteria.Indexed(0)))
                       {
                           var c = new CondictionScript() { ControlTypeID = element.Current.ControlType.Id };
                           c.Pairs.Add(new CondictionPair() { Paremter = 0, Type = CondictionType.Index });
                           return c;
                       }
                        return null;
                    }},
                {CondictionType.NativeProperty, (w, element) => null},
                {CondictionType.Text, (w, element) =>
                    {
                       if(Get(w, element, SearchCriteria.ByText(element.Current.Name)))
                       {
                           var c = new CondictionScript() { ControlTypeID = element.Current.ControlType.Id };
                           c.Pairs.Add(new CondictionPair() { Paremter = element.Current.Name, Type = CondictionType.Text });
                           return c;
                       }
                        return null;
                    }},
            };
        private static bool Get(Window window, AutomationElement element, SearchCriteria searchCriteria)
        {

            var result =
                window.Get(searchCriteria.AndControlType(Ulity.AvailableCustomType[element.Current.ControlType.Id],
                                                         WindowsFrameworkExtensions.FromFrameworkId(
                                                             window.AutomationElement.Current.FrameworkId)));
            return result != null && result.AutomationElement == element;
        }
    }
}
