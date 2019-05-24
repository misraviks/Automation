using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

public class JiraLoginPage : Operations,ILogin
{
    public static string baseUrl = "https://frontlinetechnologies.atlassian.net/";
    public static string googleSignInButton = "google-signin-button";
    public static string googleEmailId = "identifierId";
    public static string googleNextButton = "identifierNext";
    public static string glUserNmae = "username";
    public static string glPassword = "password";
    public static string glSubmitButton = "okta-signin-submit";//"Submit";
    public static string googleVerify = "#view_container > div > div > div.pwWryf.bxPAYd > div > div.zQJV3 > div > div.qhFLie > div";
    public static string startSubTaskingCss = @"#stalker > div > div > div > div > div.toolbar-split.toolbar-split-right > ul:nth-child(4) > li";
    public static string createSubTaskId = "//*[@id=\"create-subtask\"]";
    //".//*[contains(text(),'Create sub-task')]";//"#create-subtask";//"opsbar-operations_more_drop";//"create-subtask";
    private static string subtaskSummaryId = "summary";
    private static string fixesVersionId = "#fixVersions-multi-select";

    private IWebElement webElement;


    public void Login()
    {
        openBrowser();
        openURL(baseUrl);
        webElement = WaitUntilElementIsPresent(By.Id(googleSignInButton));
        webElement.Click();
        OpenNewTab("https://www.google.com");
        webElement = WaitUntilElementIsPresent(By.Id(googleEmailId));
        EnterText(webElement, readConfigFile("UserId"));
        webElement = WaitUntilElementIsPresent(By.Id(googleNextButton));
        webElement.Click();
        Waits(2);
        webElement = WaitUntilElementIsPresent(By.Name(glUserNmae));
        EnterText(webElement, readConfigFile("UserName"));
        webElement = WaitUntilElementIsPresent(By.Name(glPassword));
        EnterText(webElement, readConfigFile("Password"));
        webElement = WaitUntilElementIsPresent(By.Id(glSubmitButton));
        webElement.Click();
        webElement = WaitUntilElementIsPresent(By.CssSelector(googleVerify));
        webElement.Click();
        Waits(10);
        openURL("https://frontlinetechnologies.atlassian.net/browse/GLRH-757");
        //Waits(5);
        //webElement = WaitUntilElementIsPresent(By.TagName("body"));
        //EnterText(webElement, "C",1);
    }

    public void CreateSubTask()
    {
        System.Console.WriteLine("Creating Sub Task");
        webElement = WaitUntilElementIsPresent(By.CssSelector(startSubTaskingCss));
        //EnterText(webElement, );
        webElement.Click();
        //Waits(2);
        
        webElement = WaitUntilElementIsPresent(By.XPath(createSubTaskId));
        
        System.Console.WriteLine("Name:"+webElement.TagName+"::Text:"+ webElement.Text+""+webElement.GetAttribute("href"));
        string NewUrl = webElement.GetAttribute("href");
        //Waits(10);
        ////EnterText(webElement, "C");
        //webElement.Click();
        OpenNewTab(NewUrl);
       // Waits(10);
        System.Console.WriteLine("2");
        webElement = WaitUntilElementIsPresent(By.Id(subtaskSummaryId));
        EnterText(webElement, "Analysis");
        System.Console.WriteLine("3");
        webElement = WaitUntilElementIsPresent(By.CssSelector(fixesVersionId));
        //SelectDropDownByText(webElement, "Sec Compliance v1.0");

    }

    public void Logout()
    {

    }
}
