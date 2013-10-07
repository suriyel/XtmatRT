using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using XtmatRT;


namespace Test
{
   [TestFixture]
    public class AnalyseTest
   {
       private Process m_Process;
       private Application m_Application;

       [Test]
       public void AnalyseSimpleT()
       {
           m_Process = Process.Start(@"D:\code\演示程序\RunClient.exe");
           m_Application = Application.Attach(m_Process);

           var window = m_Application.GetWindows()[0];
           var element = window.GetElement(SearchCriteria.ByAutomationId("textBox_IP"));
           var result = BaseWindowFinder.GetBaseCondiction(element, window);

           Assert.AreEqual(result.Pairs.Count,0);
           m_Process.Kill();
       }

       [Test]
       public void AnalyseNoFindT()
       {
           m_Process = Process.Start(@"D:\code\演示程序\RunClient.exe");
           var notepad= Process.Start("Notepad.exe");
           m_Application = Application.Attach(m_Process);

           var window = m_Application.GetWindows()[0];
           var element = Application.Attach(notepad).GetWindows()[0].AutomationElement;
           var result = BaseWindowFinder.GetBaseCondiction(element, window);

           Assert.AreEqual(result,null);
           m_Process.Kill();
           notepad.Kill();
       }

       [Test]
       public void AnalyseMuliWindow()
       {
           m_Process = Process.Start(@"F:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe");
           m_Application = Application.Attach(m_Process);

           var window = m_Application.GetWindow(SearchCriteria.ByAutomationId("VisualStudioMainWindow"),
                                                InitializeOption.NoCache);
           var element = window.GetElement(SearchCriteria.ByAutomationId("GetStarted_ItemsGroupList"));
           var result = BaseWindowFinder.GetBaseCondiction(element, window);
           Assert.AreEqual(result.Pairs.Count, 0);
           m_Process.Kill();
       }
   }
}
