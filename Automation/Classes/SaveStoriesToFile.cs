using System;
using System.Text;

class SaveStoriesToFile : IAction<Login>
{
    
    public void PerformAction(Login action)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Story story in action.Stories)
        {
            sb.Append("==============================================================================");
            sb.AppendLine();
            sb.Append("Story Number:" + story.StoryNumber+"\t");
            sb.Append("Assigned to:" + story.Assignee);
            sb.AppendLine();
            Int32 totalHour = 0;
            foreach (SubTask subTask in story.SubTasks)
            {
                totalHour += GetHours.Minutes(subTask.EstimatedHours);
                sb.Append(subTask);
                sb.AppendLine();
            }
            sb.Append("Total Time Taken =" + GetHours.GetTime(totalHour));
            sb.AppendLine();
            sb.Append("==============================================================================");
            sb.AppendLine();
        }
        Helper.OverRideFile(action.UserName+".TXT",sb.ToString());
    }
}

