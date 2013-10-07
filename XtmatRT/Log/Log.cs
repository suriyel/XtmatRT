using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;

namespace XtmatRT
{
    internal static class Log
    {
        private static Logger.Logger Loger { set; get; }

        internal static void WriteLog(string info,Stage stage)
        {
            Loger.WriteLog(info, stage);
        }
    }
}
