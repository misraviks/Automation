using System;
using System.Text;

class SaveStoriesToFile : IAction<Login>
{
    
    public void PerformAction(Login action)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Story story in action.Stories)
        {
            sb.Append("=".PadLeft(114, '='));
            sb.AppendLine();
           // sb.Append("Story Number:" + story.StoryNumber+"\t");
            sb.Append(story);
            sb.AppendLine();
            Int32 totalHour = 0;
            foreach (SubTask subTask in story.SubTasks)
            {
                if (subTask.Assignee == null) subTask.Assignee = story.Assignee;
                totalHour += GetHours.Minutes(subTask.EstimatedHours);
                sb.Append(subTask);
                sb.AppendLine();
            }
            sb.Append("=".PadLeft(114,'='));
            sb.AppendLine();
        }
        Helper.OverRideFile(action+".txt",sb.ToString());
    }
}

