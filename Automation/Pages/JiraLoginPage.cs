using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

public enum SubTaskEnum
{
    Analysis, Coding, UnitTesting, CodeReview, Recoding, BugFixing, Documentation
}
public class JiraLoginPage : Operations, ILogin
{

    public static string baseUrl = "https://frontlinetechnologies.atlassian.net/";
    private static string loginAsID = "hints-container";
    private static string homePageWelcomeId = "profileGlobalItem";
    public static string googleSignInButton = "google-signin-button";
    public static string googleEmailId = "identifierId";
    public static string selectedForDevelopmentXPath = "//*[@id=\"action_id_21\"]";
    public static string googleNextButton = "identifierNext";
    public static string glUserNmae = "username";
    public static string glPassword = "password";
    public static string glSubmitButton = "okta-signin-submit";//"Submit";
    public static string googleVerify = "#view_container > div > div > div.pwWryf.bxPAYd > div > div.zQJV3 > div > div.qhFLie > div";
    public static string startSubTaskingCss = @"#stalker > div > div > div > div > div.toolbar-split.toolbar-split-right > ul:nth-child(4) > li";
    public static string createSubTaskId = "//*[@id=\"create-subtask\"]";
    //".//*[contains(text(),'Create sub-task')]";//"#create-subtask";//"opsbar-operations_more_drop";//"create-subtask";
    private static string subtaskSummaryId = "summary";
    private static string fixesVersionId = "fixVersions-textarea";
    private static string componentId = "components-textarea";
    private static string assignToMeId = "assign-to-me-trigger";
    private static string timetrackingId = "timetracking_originalestimate";
    private static string createAnotherId = "qf-create-another";
    private static string submitSubTaskId = "create-issue-submit";
    private static string FixedVersionValue = "Sec Compliance v1.0";
    private static string componentValue = "GLRH Team 2";
    private static string assigneeInputId = "assignee-field";

    private IWebElement webElement;

    

    public void Login()
    {
        
        openBrowser();
        openURL(baseUrl);
        webElement = WaitUntilElementIsPresent(By.Id(googleSignInButton));
        webElement.Click();
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
        Waits(5);
        
    }

    public void Login(Login login)
    {
        openBrowser();
        while (true)
        {
            openURL(baseUrl);
            webElement = WaitUntilElementIsPresent(By.Id(googleSignInButton));
            webElement.Click();
            webElement = WaitUntilElementIsPresent(By.Id(googleEmailId));
            EnterText(webElement, login.UserId);
            webElement = WaitUntilElementIsPresent(By.Id(googleNextButton));
            webElement.Click();
            Waits(2);
            webElement = WaitUntilElementIsPresent(By.Name(glUserNmae));
            EnterText(webElement, login.UserName);
            webElement = WaitUntilElementIsPresent(By.Name(glPassword));
            EnterText(webElement, login.Password);
            webElement = WaitUntilElementIsPresent(By.Id(glSubmitButton));
            webElement.Click();
            webElement = WaitUntilElementIsPresent(By.CssSelector(googleVerify));
            webElement.Click();
            Waits(5);
            webElement = WaitUntilElementIsPresent(By.Id(homePageWelcomeId),1);
            if (webElement.Displayed)
            {
                System.Console.WriteLine("Login Success");
                break;
            }
            
        }
    }


    public void OpenSubTaskMenu(string TicketNumber)
    {
        openURL($"{baseUrl}browse/GLRH-{TicketNumber}?oldIssueView=true");
        System.Console.WriteLine("Creating Sub Task For Ticket Number:"+TicketNumber);
        webElement = WaitUntilElementIsPresent(By.CssSelector(startSubTaskingCss));
        ExecuteJs("$(\"a:contains('sub-task')\").click();"); 
        Waits(5);
        System.Console.WriteLine("SubTask Menu Opened!");  
    }
    public void FillSubTask(SubTaskEnum subTask, string assignee="", string estimatedHour="1h", bool checkBox=false, string fixversion = "", string component = "")
    {
        if (fixversion.Length > 0) FixedVersionValue = fixversion;
        if (component.Length > 0) componentValue = component;
        webElement = WaitUntilElementIsPresent(By.Id(subtaskSummaryId));
        EnterText(webElement, GetSubTask(subTask));
        webElement = WaitUntilElementIsPresent(By.Id(fixesVersionId));
        EnterText(webElement, FixedVersionValue);
        webElement = WaitUntilElementIsPresent(By.Id(componentId));
        EnterText(webElement, componentValue);
        if (assignee.Length <= 0)
        {
            webElement = WaitUntilElementIsPresent(By.Id(assignToMeId));
            webElement.Click();
        }
        else
        {
            webElement = WaitUntilElementIsPresent(By.Id(assigneeInputId));
            EnterText(webElement, assignee);
        }
        
        webElement = WaitUntilElementIsPresent(By.Id(timetrackingId));
        EnterText(webElement, estimatedHour);
        webElement = WaitUntilElementIsPresent(By.Id(createAnotherId));
        if (checkBox)
        {
            if (!webElement.Selected)
            {
                webElement.Click();
            }
        }
        else
        {
            if (webElement.Selected) webElement.Click();
        }
        webElement = WaitUntilElementIsPresent(By.Id(submitSubTaskId));
        webElement.Submit();
        System.Console.WriteLine($"SubTask: {GetSubTask(subTask)} created!");
        Waits(1);
    }

    public void FillSubTask(string subTask, string assignee = "", string estimatedHour = "1h", bool checkBox = false,string fixversion="",string component="")
    {
        if (fixversion.Length > 0) FixedVersionValue = fixversion;
        if (component.Length > 0) componentValue = component;
        webElement = WaitUntilElementIsPresent(By.Id(subtaskSummaryId));
        EnterText(webElement, subTask);
        Waits(3);
        webElement = WaitUntilElementIsPresent(By.Id(fixesVersionId));
        EnterText(webElement, FixedVersionValue);
        Waits(3);
        webElement = WaitUntilElementIsPresent(By.Id(componentId));
        EnterText(webElement, componentValue);
        if (assignee.Length <= 0)
        {
            webElement = WaitUntilElementIsPresent(By.Id(assignToMeId));
            webElement.Click();
        }
        else
        {
            webElement = WaitUntilElementIsPresent(By.Id(assigneeInputId));
            EnterText(webElement, assignee);
            Waits(1);
            ExecuteJs($"$(\"a:contains('{assignee}')\").click();");
            Waits(3);
        }

        webElement = WaitUntilElementIsPresent(By.Id(timetrackingId));
        EnterText(webElement, estimatedHour);
        Waits(3);
        webElement = WaitUntilElementIsPresent(By.Id(createAnotherId));
        if (checkBox)
        {
            if (!webElement.Selected)
            {
                webElement.Click();
            }
        }
        else
        {
            if (webElement.Selected) webElement.Click();
        }
        webElement = WaitUntilElementIsPresent(By.Id(submitSubTaskId));
        webElement.Submit();
        //System.Console.WriteLine($"SubTask :{subTask} created!");
        Waits(5);
    }
    public void CreateSubTask1()
    {
        System.Console.WriteLine("Creating Sub Task");
        //webElement = WaitUntilElementIsPresent(By.CssSelector(startSubTaskingCss));
        ////EnterText(webElement, );
        //webElement.Click();
        ////Waits(2);

        ////webElement = WaitUntilElementIsPresent(By.XPath(createSubTaskId));
        //webElement = WaitUntilElementIsPresent(By.Id("create-subtask"));
        Actions action = new Actions(WebDriverHelper.driver);
        action.MoveToElement(WebDriverHelper.driver.FindElement(By.CssSelector(startSubTaskingCss))).Click().Click(WebDriverHelper.driver.FindElement(By.XPath(createSubTaskId))).Perform();
        System.Console.WriteLine("1::");
        Waits(10);
        //IWebElement moveToManageAssessmnt = WebDriverHelper.driver.FindElement(By.CssSelector(startSubTaskingCss));
        //action.MoveToElement(WebDriverHelper.driver.FindElement(By.XPath(createSubTaskId))).Click().Perform();
        System.Console.WriteLine("2::");
        //System.Console.WriteLine("Name:" + webElement.TagName + "::Text:" + webElement.Text);// +""+webElement.GetAttribute("href"));
        Waits(20);
       // string NewUrl = webElement.GetAttribute("href");
        //Waits(10);
        ////EnterText(webElement, "C");
        //webElement.Click();
        //webElement = WaitUntilElementIsPresent(By.Id("create-subtask-dialog"));
        //webElement.vi
        //OpenNewTab(NewUrl);
        // Waits(10);
        //System.Console.WriteLine("2");
        //webElement = WaitUntilElementIsPresent(By.Id(subtaskSummaryId));
        //EnterText(webElement, "Analysis");
        //System.Console.WriteLine("3");
        //webElement = WaitUntilElementIsPresent(By.CssSelector(fixesVersionId));
        //SelectDropDownByText(webElement, "Sec Compliance v1.0");

    }

    public string GetSubTask(SubTaskEnum subTask)
    {
        string task = "";

        switch (subTask)
        {
            case SubTaskEnum.Analysis:
                task = "Analysis";
                break;
            case SubTaskEnum.Coding:
                task = "Coding";
                break;
            case SubTaskEnum.UnitTesting:
                task = "Unit Testing";
                break;
            case SubTaskEnum.CodeReview:
                task = "Code review";
                break;
            case SubTaskEnum.Recoding:
                task = "Re-coding (Code changes done after review)";
                break;
            case SubTaskEnum.BugFixing:
                task = "Bug Fixing";
                break;
            case SubTaskEnum.Documentation:
                task = "Documentation";
                break;
            default:
                task = subTask.ToString();
                break;
        }
        return task;
    }
    public void Logout()
    {
        driverQuit();
    }
}
