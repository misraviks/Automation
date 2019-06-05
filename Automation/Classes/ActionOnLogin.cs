using System;
using System.Text;

class ActionOnLogin:IActionRequired<Login>
{
    public ActionOnLogin()
    {

    }
    public void ActionTaken(Login action)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Story story in action.Stories)
        {
            sb.Append("Story Number:" + story.StoryNumber);
            sb.Append("Assigned to:" + story.Assignee);
            Int32 totalHour = 0;
            foreach (SubTask subTask in story.SubTasks)
            {
                totalHour += GetHours.Minutes(subTask.EstimatedHours);
                sb.Append(subTask);
            }
            sb.Append("Total Time Taken =" + GetHours.GetTime(totalHour));
        }
        Helper.AppendToFile(sb.ToString(), action.UserName);
    }

    
}

