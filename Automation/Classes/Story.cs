using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class Story
{
    public String StoryNumber { get; set; }
    public List<SubTask> SubTasks { get; set; }
    public String Assignee { get; set; }
    public String Component { get; set; }
    public String FixVersion { get; set; }
    public override string ToString()
    {
        //string data = "";
        Int32 totalHour = 0;
        foreach (SubTask task in SubTasks)
        {
            totalHour += GetHours.Minutes(task.EstimatedHours);
        }
        return $"Story      :GLRH-{ StoryNumber.PadRight(44,' ')} \t Assigned to : {Assignee} \t Time :{GetHours.GetTime(totalHour).PadRight(11,' ')}|";
    }

}

