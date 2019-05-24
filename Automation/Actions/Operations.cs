using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using System.Linq;

public class Operations
{
    public static String winHandleBefore;
    public static string currentHandle;
    public static string parentHandle;
   
    public static void EnterText(IWebElement element, string value,int UseAction=0)
    {
        try
        {
            
            if (UseAction == 0)
            element.SendKeys(value);
            else
            {
                Actions actions = new Actions(WebDriverHelper.driver);
                actions.KeyDown(Keys.Control).SendKeys("c").Build();
                actions.Perform();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught in Sending values!");
            throw new Exception(e.Message);
        }
    }
    public static void KeyboardKey(IWebElement element, String key)
    {
        try
        {
            switch (key.ToLower())
            {
                case "enter":
                    element.SendKeys(Keys.Enter);
                    break;
                case "down":
                    element.SendKeys(Keys.ArrowDown);
                    break;
                case "left":
                    element.SendKeys(Keys.ArrowLeft);
                    break;
                case "right":
                    element.SendKeys(Keys.ArrowRight);
                    break;
                case "up":
                    element.SendKeys(Keys.ArrowUp);
                    break;
                case "end":
                    element.SendKeys(Keys.End);
                    break;
                case "alt":
                    element.SendKeys(Keys.Alt);
                    break;
                case "pagedown":
                    element.SendKeys(Keys.PageDown);
                    break;
                case "pageup":
                    element.SendKeys(Keys.PageUp);
                    break;
                default:
                    break;
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public static void Clicks(IWebElement element)
    {
        try
        {
            element.Click();
        }
        catch (Exception e)
        {
            
        }
    }
    // Move To Element
    public static IWebElement OpenNewTab(String url)
    {
        List<string> handles = WebDriverHelper.driver.WindowHandles.ToList();
        ((IJavaScriptExecutor)WebDriverHelper.driver).ExecuteScript("window.open();");
        currentHandle = handles[handles.Count-1];
        WebDriverHelper.driver.SwitchTo().Window(handles[handles.Count-1 ]);
        WebDriverHelper.driver.Navigate().GoToUrl(url);
        IWebElement body = WebDriverHelper.driver.FindElement(By.TagName("body"));
        body.SendKeys(Keys.Control + 't');
        return body;
    }
    public static void MoveToElement(IWebElement element)
    {
        try
        {
            Actions actions = new Actions(WebDriverHelper.driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //Switch to frame 
    public static void SwitchToFrame(String frameName)
    {
        try
        {
            WebDriverHelper.driver.SwitchTo().Frame(frameName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //switch back to default frame
    public static void SwitchBackToDefaultFrame()
    {
        try
        {
            WebDriverHelper.driver.SwitchTo().ParentFrame();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    // Selecting a drop down control
    public static void SelectDropDownByText(IWebElement element, String value)
    {
        try
        {
            new SelectElement(element).SelectByText(value);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
        }
    }
    public static void SelectDropDownByIndex(IWebElement element, int index)
    {
        try
        {
            new SelectElement(element).SelectByIndex(index);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
        }
    }

    // open URL
    public static void openURL(String url)
    {
        try
        {
            //WebDriverHelper.driver.Navigate().GoToUrl(readConfigFile(url));
            WebDriverHelper.driver.Navigate().GoToUrl(url);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    // open Browser
    public static void openBrowser()
    {
        try
        {
            WebDriverHelper.driver = new ChromeDriver();

            parentHandle = WebDriverHelper.driver.CurrentWindowHandle;
            winHandleBefore = parentHandle;
            //WebDriverHelper.driver.Manage().Timeouts().ImplicitWait=10;
            WebDriverHelper.driver.Manage().Window.Maximize();
            //WebDriverHelper.helperModules = new HelperModules(WebDriverHelper.driver);
            //WebDriverHelper helper = new WebDriverHelper();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    // closes driver
    public static void driverQuit()
    {
        try
        {
            WebDriverHelper.driver.Quit();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    // closes current broswer
    public static void CloseCurrentTab()
    {
        try
        {
            WebDriverHelper.driver.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }
    public static void CloseTabByIndex(int index=0)
    {
        try
        {
            List<string> handles = WebDriverHelper.driver.WindowHandles.ToList();
            ((IJavaScriptExecutor)WebDriverHelper.driver).ExecuteScript("window.open();");
            currentHandle = handles[handles.Count - 1];
            WebDriverHelper.driver.SwitchTo().Window(handles[handles.Count - 1]);
            WebDriverHelper.driver.Close();
            WebDriverHelper.driver.SwitchTo().Window(parentHandle);
            //WebDriverHelper.driver.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //switch to newly opened window
    public static void SwitchToNewlyOpenedWindow()
    {
        try
        {
            winHandleBefore = WebDriverHelper.driver.CurrentWindowHandle;
            foreach (String winHandle in WebDriverHelper.driver.WindowHandles)
            {
                WebDriverHelper.driver.SwitchTo().Window(winHandle);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //switch back to the previously opened window
    public void SwitchToPreviouslyOpenedWindow()
    {
        try
        {
            WebDriverHelper.driver.SwitchTo().Window(winHandleBefore);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //Clears
    public static void Clears(IWebElement element)
    {
        try
        {
            element.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //Explicit time wait
    public static void Waits(int timeInSeconds =1)
    {
        try
        {
            Thread.Sleep(timeInSeconds*1000);
        }
        catch (ThreadInterruptedException e)
        {
            throw new Exception(e.Message);
        }
    }
    public static IWebElement WaitUntilElementIsPresent( By by, int timeout = 0)
    {
        IWebElement webElement;
        while (true)
        {
            try
            {
                webElement= WebDriverHelper.driver.FindElement(by);
                if (webElement.Displayed)
                {
                    break;
                }
            }
            catch
            {

            }
        }
        return webElement;
        
    }
  
    // JavaScript scroll to bottom
    public static void scrollToBottom()
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriverHelper.driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //  Switch to Alert and write a text
    public static void switchToAlertWriteText(String value)
    {
        try
        {
            WebDriverHelper.driver.SwitchTo().Alert().SendKeys(value);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //Switch to Alert and Accept
    public static void ClickAlertOkButton()
    {
        try
        {
            WebDriverHelper.driver.SwitchTo().Alert().Accept();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }


    // Read Config file    
    public static String readConfigFile(String keyname)
    {
        
        try
        {
           return ConfigurationManager.AppSettings[keyname].ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    // JavaScript scroll to postion      
    public static void scrollToPosition(int length, int width)
    {
        try
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriverHelper.driver;
            js.ExecuteScript("window.scrollTo(length, width);");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

        //Getting innertext of a Web Element
    public static String GetText(IWebElement element)
    {
        try
        {
            return element.Text;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

    //Getting Value of a Web Element
    public static String GetValue(IWebElement element)
    {
        try
        {
            return element.GetAttribute("value");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }

        //returns list of webelements
    public static List<string> ListOfWebElements(List<IWebElement> listOfElements)
    {
        try
        {
            List<string> list = new List<string>();
            foreach (IWebElement webElement in listOfElements)
            {
                list.Add(GetText(webElement));
            }
            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Caught");
            throw new Exception(e.Message);
        }
    }
}

