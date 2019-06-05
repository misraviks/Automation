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
    

}

