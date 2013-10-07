using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestStack.White.UIItems;

namespace XtmatRT
{
    internal static class CommonMethodHelper
    {
        public static List<MethodStep> GetAllCommonMethodInfoFromConfig()
        {
            var steps = new List<MethodStep>();
            var paths = ConfigInstance.MethodDlls;
            foreach (var path in paths)
            {
                steps.AddRange(GetCommonSteps(path));
            }

            return steps;
        }

        private static IEnumerable<MethodStep> GetCommonSteps(string path)
        {
            var result = new List<MethodStep>();
            var asm= Assembly.LoadFrom(path);
            foreach (var type in asm.GetTypes())
            {
                foreach (var methodInfo in type.GetMethods())
                {
                    MethodStep step = null;
                    if (GetMethodStep(methodInfo, out step))
                    {
                        result.Add(step);
                    }
                }
            }
            return result;
        }

        private static bool GetMethodStep(MethodInfo methodInfo, out MethodStep step)
        {
            step = null;
            if (methodInfo.IsDefined(typeof (CommonMethodAtr), false))
            {
                if(IsParamterValid(methodInfo))
                {
                    step = new MethodStep()
                        {
                            MethodInfo=methodInfo,
                            Type = (methodInfo.GetCustomAttributes(typeof(CommonMethodAtr), false)[0] as CommonMethodAtr).Type
                        };
                    return true;
                }
            }
            return false;
        }

        private static bool IsParamterValid(MethodInfo methodInfo)
        {
            if (methodInfo.GetParameters().Count() != 2)
            {
                return false;
            }
            var uiItem = methodInfo.GetParameters()[0].GetType();
            if(uiItem.IsAssignableFrom(typeof(IUIItem)))
            {
                return true;
            }
            return false;
        }
    }
}
