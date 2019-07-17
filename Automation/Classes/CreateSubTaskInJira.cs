using Automation.Classes;
using System.Collections.Generic;
using System.Data;

class CreateSubTaskInJira
{
    public CreateSubTaskInJira()
    {
        
        Login login = Helper.readStoryFile("SubTask.XML");
        
        new SaveStoriesToFile().PerformAction(login);
        JiraLoginPage jira = new JiraLoginPage();
        jira.Login(login);
        foreach (Story story in login.Stories)
        {
            jira.OpenSubTaskMenu(story.StoryNumber);
            int subTaskKnt = 1;
            foreach (SubTask subTask in story.SubTasks)
            {
                jira.FillSubTask(subTask.Name, subTask.Assignee != null ? subTask.Assignee : story.Assignee, subTask.EstimatedHours, subTaskKnt == story.SubTasks.Count ? false : true, story.FixVersion, story.Component);
                System.Console.WriteLine(subTask);
                subTaskKnt++;
            }
        }
        jira.Logout();
    }
    public CreateSubTaskInJira(string s)
    {
        Login login = Helper.readStoryFromExcel();

        new SaveStoriesToFile().PerformAction(login);
        JiraLoginPage jira = new JiraLoginPage();
        jira.Login(login);
        foreach (Story story in login.Stories)
        {
            jira.OpenSubTaskMenu(story.StoryNumber);
            int subTaskKnt = 1;
            foreach (SubTask subTask in story.SubTasks)
            {
                jira.FillSubTask(subTask.Name, subTask.Assignee != null ? subTask.Assignee : story.Assignee, subTask.EstimatedHours, subTaskKnt == story.SubTasks.Count ? false : true, story.FixVersion, story.Component);
                System.Console.WriteLine(subTask);
                byte err = 0;string errmsg = "";
                login.excelReader.UpdateData($"UPDATE [Stories$] SET Status = 1 WHERE SubTask ='{subTask.Name}' and StoryNumber ={story.StoryNumber} ", ref err, ref errmsg);
                subTaskKnt++;
            }
        }
        jira.Logout();
       

    }
}



