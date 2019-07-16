
using Automation.Classes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

class EntryPoint
    {
        static void Main()
        {
        new Download().Login();
        }
    }



