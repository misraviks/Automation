using Automation.Classes;
using System;
using System.Collections.Generic;

public class Login
{
    public String UserId { get; set; }
    public String UserName { get; set; }
    public String Password { get; set; }
    public String FixVersion    { get; set; }
    public String Component    { get; set; }
    public ExcelReader excelReader { get; set; }
    public List<Story> Stories { get; set; }
    public override string ToString()
    {
        return $"{UserName}";
    }

}
