using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Mocks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using XtmatRT;

namespace Test
{
    [TestFixture]
    public class GetAllControlsTest
    {

        private Process m_Process;
        private Application m_Application;

        [Test]
        public void GetAllControlsSimpleTest()
        {
            m_Process = Process.Start(@"D:\code\演示程序\RunClient.exe");
            m_Application = Application.Attach(m_Process);

            var window = m_Application.GetWindows()[0];
            var element = window.GetElement(SearchCriteria.ByAutomationId("textBox_IP"));
            CondictionScript baseC = null;
            var controls = new List<ControlScript>();
            ControlsAnalyse.GetControlScript(element, window, out baseC, out controls);
            Assert.AreEqual(controls[8].CreatCondiction.Pairs[0].Type,CondictionType.AutomationID);
            Assert.AreEqual(controls[8].CreatCondiction.Pairs[0].Paremter, "SmallIncrement");
            m_Process.Kill();
        }
    }
}
