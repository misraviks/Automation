using OpenQA.Selenium;
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
        public static string baseUrl = "https://globallogic.udemy.com/";
        public static string udemyJsDownload = "var videoLink = document.querySelector(\".vjs - tech\").getAttribute('src');window.open(videoLink,'_blank');";
        public static string loginInputId = "email";
        public static string continueClickJS = "$(\"button:contains('Continue')\").click();";
        public static string loginClickJS = "$(\"button:contains('Log In')\").click();";
        public static string loginId = "amar.srivastava@globallogic.com";
        public static string passwordInputId = "password";
        public static string password = "";
        public static string myCoursesURL = "https://globallogic.udemy.com/home/my-courses/learning/";
        private IWebElement webElement;
        public void Login()
        {
           string  dir = Directory.GetCurrentDirectory();
            openBrowser();
            openURL(baseUrl);
            webElement = WaitUntilElementIsPresent(By.Id(loginInputId));
            EnterText(webElement, loginId);
            ExecuteJs(continueClickJS);
            webElement = WaitUntilElementIsPresent(By.Id(passwordInputId));
            EnterText(webElement, password);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
