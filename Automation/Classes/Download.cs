using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Classes
{
    class Download : Operations, ILogin
    {
        public static string baseUrl = "https://www.youtube.com/watch?v=5KFCD-DxEhw";
        public void Login()
        {
           string  dir = Directory.GetCurrentDirectory();
           openBrowserWithExtension(dir+"\\AVD-CRX-4.3-Release");
            openURL(baseUrl);

        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
