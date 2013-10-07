using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace XtmatRT.CaseSteps
{
    public class ButtonEx
    {
        [CommonMethodAtr(typeof(Button))]
        public void Click(Button button, ButtonParam param)
        {
            button.Click();
        }
    }
}
