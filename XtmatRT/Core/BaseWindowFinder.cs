using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using Logger;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace XtmatRT
{
    public static class BaseWindowFinder
    {
        public static CondictionScript GetBaseCondiction(AutomationElement element,Window rootWindow)
        {
            var walker =
              new System.Windows.Automation.TreeWalker(
                  System.Windows.Automation.Condition.TrueCondition);

            System.Windows.Automation.AutomationElement testparent;
            var baseCondiction = new CondictionScript();
            var paths=new List<AutomationElement>();

            GetPath(element, rootWindow, walker, paths);

            int flag = AnalyseSimpleCondiction(paths, rootWindow, baseCondiction);

            if(flag>0)
            {
                return baseCondiction;
            }
            else if(flag==0)
            {
                return new CondictionScript();
            }
            else
            {
                return null;
            }
        }

        private static int AnalyseSimpleCondiction(List<AutomationElement> paths, Window rootWindow, CondictionScript baseCondiction)
        {
            int index = -1;
            CondictionType type;
            string parameter;
            bool findNext = false;
            var nodeWindow = rootWindow;

            if(paths.Count==0)
            {
                return -1;
            }

            do
            {
                findNext = false;
                for (int i = paths.Count-1; i > index; i--)
                {
                    int flag = CanFindWinodw(paths[i], ref nodeWindow, out type, out parameter);
                    if(flag==0)
                    {
                        return 0;
                    }
                    if (flag > 0)
                    {
                        baseCondiction.Pairs.Add(new CondictionPair() {Type = type, Paremter = parameter});
                        index = i;
                        findNext = true;
                        break;
                    }
                }

                if(!findNext&&index!=paths.Count-1)
                {
                    return -1;
                }

            } while (findNext);

            return 1;
        }

        private static int CanFindWinodw(AutomationElement element, ref Window rootWindow, out CondictionType type, out string parameter)
        {
            type=new CondictionType();
            parameter = string.Empty;

            if (element == rootWindow.AutomationElement)
            {
                return 0;
            }

            try
            {
               var tempWindow= rootWindow.Get<Window>(SearchCriteria.ByAutomationId(element.Current.AutomationId));
                if(tempWindow!=null)
                {
                    type=CondictionType.AutomationID;
                    parameter = element.Current.AutomationId;
                    return 1;
                }
            }
            catch (Exception)
            {
                
            }

            try
            {
                var tempWindow = rootWindow.Get<Window>(SearchCriteria.ByText(element.Current.Name));
                if(tempWindow!=null)
                {
                    type = CondictionType.Text;
                    parameter = element.Current.Name;
                    return 1;
                }
            }
            catch (Exception)
            {
            }
            return -1;
        }

        private static void GetPath(AutomationElement element, Window rootWindow, TreeWalker walker, List<AutomationElement> paths)
        {
            try
            {
               var testparent = element;

                if (testparent != null && (int) testparent.Current.ProcessId > 0)
                {
                    if (testparent != rootWindow.AutomationElement)
                    {
                        if (testparent.Current.ControlType.Equals(ControlType.Window))
                        {
                            paths.Add(testparent);
                        }
                    }
                }

                while (testparent != null && (int) testparent.Current.ProcessId > 0)
                {
                    testparent =
                        walker.GetParent(testparent);
                    if (testparent != null && (int) testparent.Current.ProcessId > 0)
                    {
                        if (testparent != AutomationElement.RootElement)
                        {
                            if (testparent.Current.ControlType.Equals(ControlType.Window))
                            {
                                paths.Add(testparent);
                            }
                        }
                    }
                }
            }
            catch (Exception eNew)
            {
                Log.WriteLog(eNew.Message + eNew.StackTrace, Stage.Erro);
            }
        }
    }

    public static class ControlsAnalyse
    {
        public static AutomationElement GetElementFromPoint()
        {
            AutomationElement element = null;

            // use Windows forms mouse code instead of WPF
            System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;

            // commented 20120618 to switch to UIACOMWrapper
            element =
                System.Windows.Automation.AutomationElement.FromPoint(
                    new System.Windows.Point(mouse.X, mouse.Y));
            //element = 
            //	//(UIANET::System.Windows.Automation.AutomationElement)
            //	UIACOM3.UIACOMHelper.GetAutomationElementFromPoint();

            return element;
        }

        public static bool GetControlScript(AutomationElement curElement, Window rootWindow, out CondictionScript condictionScript, out List<ControlScript> controlScripts)
        {
            controlScripts = new List<ControlScript>();
            condictionScript = BaseWindowFinder.GetBaseCondiction(curElement, rootWindow);
            Window baseWindow;

            if(condictionScript==null)
            {
                return false;
            }
            else if(condictionScript.Pairs.Count==0)
            {
                baseWindow = rootWindow;
            }
            else
            {
                baseWindow = UIControlFactory<Window, Window>.GetControl(rootWindow, condictionScript);
            }
          
            if(baseWindow==null)
            {
                return false;
            }

            if (GetAllControls(controlScripts, condictionScript, baseWindow))
            {
                return true;
            }
            return false;
        }
        private static readonly TreeWalker RawViewWalker = TreeWalker.RawViewWalker;

        private static bool GetAllControls(List<ControlScript> condictionScripts, CondictionScript condictionScript, Window baseWindow)
        {
            var elements = new List<AutomationElement>();
            FindMatchingDescendants(baseWindow.AutomationElement, elements,
                                    int.Parse(ConfigInstance.InstanceDic["MaxDeep"]));

            for (int i = 0; i < elements.Count; i++)
            {
                CondictionScript creatCondiction = null;
                if(IsCanFind(elements[i],baseWindow,out creatCondiction))
                {
                    var cs = new ControlScript
                        {BaseControlCondictionScrID = condictionScript.Id, CreatCondiction = creatCondiction, Index = i};

                    condictionScripts.Add(cs);
                }
            }
            return true;
        }

        

        private static bool IsCanFind(AutomationElement automationElement, Window baseWindow, out CondictionScript creatCondiction)
        {
            creatCondiction =new CondictionScript();
            var allTypes = Enum.GetValues(typeof(CondictionType)).Cast<CondictionType>();
            foreach (var type in allTypes)
            {
                try

                {
                    creatCondiction = CondictionFinder.CondictionScripts[type](baseWindow, automationElement);
                    if (creatCondiction != null)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                 
                }
            }
            return false;
        }

        private static void FindMatchingDescendants(AutomationElement element, List<AutomationElement> elements, int depth)
        {
            if (depth == 0)
            {
                return;
            }
            
            AutomationElement current = RawViewWalker.GetFirstChild(element);
            while (current != null)
            {
                if (Ulity.AvailableCustomType.Keys.Contains(current.Current.ControlType.Id) && !elements.Contains(current))
                {
                    elements.Add(current);
                }
                FindMatchingDescendants(current, elements, depth - 1);

                current = RawViewWalker.GetNextSibling(current);
            }
        }
    }
    
}
