using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.Hlp
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        MainWindow prozor;

        AdminWindow mh;

        ClientWindow ch;

        public JavaScriptControlHelper(MainWindow w)
        {
            prozor = w;
        }

        public JavaScriptControlHelper(AdminWindow w)
        {
            mh = w;
        }

        public JavaScriptControlHelper(ClientWindow w)
        {
            ch = w;
        }

        public void RunFromJavascript(string param)
        {
            // ...
        }
    }
}
