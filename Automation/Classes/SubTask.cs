using System;

public class SubTask
{
    public String Name { get; set; }
    public String Assignee { get; set; }
    public String EstimatedHours { get; set; }

    public override string ToString()
    {
        return $"Sub-Task   :{(Name.PadRight(44,' '))}{(Assignee == null ? string.Empty : "\t Assigned to : " + Assignee)} \t Time :{EstimatedHours.PadRight(11,' ')}|";
    }
}
