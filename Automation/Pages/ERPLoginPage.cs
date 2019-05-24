using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
public class ERPLoginPage : Operations,ILogin
{
    public static string baseUrl = "https://erp.globallogic.com/OA_HTML/AppsLocalLogin.jsp";
    public static string userIdInput = "usernameField";
    public static string passwordInput = "passwordField";
    public static string loginCss = "#ButtonBox > button.OraButton.left";
    public static string expandHr = @"#\35 4216\3a 800\3a -1\3a 0\3a mainMenuRESTi3hGLMOZ > a > div:nth-child(1) > img:nth-child(1)";
    public static string expandTimesheet = @"#\35 4216\3a 800\3a 73094\3a 0\3a mainMenuRESTbsQ9m467 > a > div:nth-child(1) > img:nth-child(1)";
    public static string createTimeCard = @"#LITimesheetRecent_Timecards > a";
    public static string review = "review";
    private IWebElement webElement;
    public void Login()
    {
        expandHr = @"#\35 4216\3a 800\3a -1\3a 0\3a mainMenuREST-pNNiWsZ > a";
        openBrowser();
        openURL(baseUrl);
        webElement = WaitUntilElementIsPresent(By.Id(userIdInput));
        EnterText(webElement, readConfigFile("UserName"));
        webElement = WaitUntilElementIsPresent(By.Id(passwordInput));
        EnterText(webElement, readConfigFile("Password"));
        webElement = WaitUntilElementIsPresent(By.CssSelector(loginCss));
        webElement.Click();
        Waits(3);
        openURL("https://erp.globallogic.com/OA_HTML/RF.jsp?function_id=16744&resp_id=54216&resp_appl_id=800&security_group_id=0&lang_code=US&oas=nBHhjIxSqA-yYBCR_O59kA..&params=zx908KnmOaGjiRwfhVqbYZNMYsprbnMXN1RH2hlHSl0");
        Waits(120);
        driverQuit();

    }

    public void Logout()
    {
        throw new System.NotImplementedException();
    }
}
