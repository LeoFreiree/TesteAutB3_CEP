using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutB3.Drivers
{
    public class KillCHDriver
    {

        public static void CloseBrowser()
        {
            Process[] processlist = Process.GetProcesses();
            string chromeServer = "chromedriver";
            string ch = "chrome";

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == chromeServer)
                {
                    theprocess.Kill();
                }

                if (theprocess.ProcessName == ch)
                {
                    theprocess.Kill();
                }
            }
        }

    }
}
