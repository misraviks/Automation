using System;

public class SubTask
{
    public String Name { get; set; }
    public String Assignee { get; set; }
    public String EstimatedHours { get; set; }

    public override string ToString()
    {
        return $"Sub-Task { Name} is created with {EstimatedHours}. \n";
    }
}
