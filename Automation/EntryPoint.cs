
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class EntryPoint
    {
        static void Main()
        {
        JiraLoginPage jiraLoginPage = new JiraLoginPage();
        jiraLoginPage.Login();
        jiraLoginPage.CreateSubTask();
       // new ERPLoginPage().Login();
       // string url = "https://frontlinetechnologies.atlassian.net/";
       // string selector = "google-signin-button";
       // string emailInput = "identifierId";
       // string nextclick = "identifierNext";
       // string glname = "username";
       // string glpassword = "password";
       // string submit = "Submit";
       // string verify = "#view_container > div > div > div.pwWryf.bxPAYd > div > div.zQJV3 > div > div.qhFLie > div";
       //     IWebDriver driver = new ChromeDriver();
       //     driver.Navigate().GoToUrl(url);

        // IWebElement element = driver.FindElement(By.Id(selector));
        // element.Click();
        // element = driver.FindElement(By.Id(emailInput));
        // element.SendKeys("vikas.mishra@globallogic.com");
        // element = driver.FindElement(By.Id(nextclick));
        // element.Click();
        // Thread.Sleep(1000);
        // element = driver.FindElement(By.Name    (glname));
        // element.SendKeys("vikas.mishra");
        // element = driver.FindElement(By.Name(glpassword));
        // element.SendKeys("");
        // element = driver.FindElement(By.Name(submit));
        // element.Click();
        // element = driver.FindElement(By.CssSelector(verify));
        // element.Click();
        // Thread.Sleep(15000);
        // //driver.Quit();
        // driver.Navigate().GoToUrl("https://frontlinetechnologies.atlassian.net/browse/GLRH-717");
        // //string continueas = "continue-as";
        //// Thread.Sleep(5000);
        // //element = driver.FindElement(By.Id(continueas));
        ////s element.Click();
    }
    }

