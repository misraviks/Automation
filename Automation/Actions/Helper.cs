
using Automation.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

public class Helper
 {
    public static Login readStoryFile(String FileName)
    {
        String storyData = "";
        Login login = new Login(); ;
        try
        {
            if (File.Exists(FileName))
            {
                storyData = File.ReadAllText(FileName);
                Serializer ser = new Serializer();
                login = ser.Deserialize<Login>(storyData);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return login;
    }


    public static Login readStoryFromExcel()
    {
        Login login = new Login(); ;
        try
        {
            if (File.Exists("Subtask.xlsx"))
            {
                ExcelReader excelReader = new ExcelReader("Subtask.xlsx", ExcelType.XLSX);
                login.excelReader = excelReader;
                DataTable dataTable = new DataTable();
                dataTable = excelReader.ReadExcel("Login");
                login.Stories = new List<Story>();
                login.UserName = dataTable.Rows[0]["UserName"].ToString();
                login.UserId = dataTable.Rows[0]["Email"].ToString();
                login.Password = dataTable.Rows[0]["Password"].ToString();
                login.FixVersion = dataTable.Rows[0]["FixVersion"].ToString();
                login.Component = dataTable.Rows[0]["Component"].ToString();
                dataTable = excelReader.ReadExcel("Stories");
                string prevStory = "";
                Story story = new Story();
                foreach (DataRow row in dataTable.Rows)
                {

                    if (row["Status"].ToString() == "1") continue;
                    if (prevStory == "" || !prevStory.Equals(row["StoryNumber"].ToString()))
                    {
                        prevStory = row["StoryNumber"].ToString();
                        story = new Story();
                        story.SubTasks = new List<SubTask>();
                        story.StoryNumber = prevStory;
                        story.FixVersion = login.FixVersion;
                        story.Component = login.Component;
                        if (story.StoryNumber.Length > 0) login.Stories.Add(story);
                    }
                    SubTask subTask = new SubTask();
                    subTask.Assignee = row["Assignee"].ToString();
                    subTask.EstimatedHours = row["EstimatedHours"].ToString();
                    subTask.Name = row["SubTask"].ToString();
                    story.SubTasks.Add(subTask);
                    //byte err = 0; string errmsg = "";
                   // excelReader.UpdateData($"UPDATE [Stories$] SET Status = 1 WHERE SubTask ='{subTask.Name}' and StoryNumber ={story.StoryNumber} ", ref err, ref errmsg);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return login;
    }

    public static void AppendToFile(string FileName, string text)
    {
        try
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName);
            }
            File.AppendText(text);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void OverRideFile(string fileName, string text)
    {
        try
        {
            File.WriteAllText(fileName, text);
        }
        catch
        {
        }
    }
}
