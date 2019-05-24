using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages
{
    class CSharpStar :Operations,ILogin
    {
        public static string baseUrl = "https://www.csharpstar.com/";
        private IWebElement webElement;
        private String CategTreeId = "dtree_cat1";

        public CSharpStar()
        {
            
        }

        public void Login()
        {
            openBrowser();
            openURL(baseUrl);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
