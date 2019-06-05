using System;

public class GetHours
{
    public static Int32 Minutes(String EstimatedHours)
    {
        int week=0, day = 0, hour = 0, minute = 0;
        EstimatedHours = EstimatedHours.ToLower();
        if (EstimatedHours.Contains("w"))
        {
            week = Convert.ToInt32(EstimatedHours.Substring(0, EstimatedHours.IndexOf("w")));
            EstimatedHours = EstimatedHours.Substring(EstimatedHours.IndexOf("w") + 1);
        }
        if (EstimatedHours.Contains("d"))
        {
            day = Convert.ToInt32(EstimatedHours.Substring(0, EstimatedHours.IndexOf("d")));
            EstimatedHours = EstimatedHours.Substring(EstimatedHours.IndexOf("d") + 1);
        }
        if (EstimatedHours.Contains("h"))
        {
            hour = Convert.ToInt32(EstimatedHours.Substring(0, EstimatedHours.IndexOf("h")));
            EstimatedHours = EstimatedHours.Substring(EstimatedHours.IndexOf("h") + 1);
        }
        if (EstimatedHours.Contains("m"))
        {
            minute = Convert.ToInt32(EstimatedHours.Substring(0, EstimatedHours.IndexOf("m")));
            //EstimatedHours = EstimatedHours.Substring(EstimatedHours.IndexOf("m") + 1);
        }
        minute = minute + (hour * 60) + (day * 8 * 60) + (week * 5 * 8 * 60);
        return minute;

    }
    public static String GetTime(Int32 time)
    {
        int week = 0, day = 0, hour = 0, minute = 0;
        
        hour = time / 60;
        minute = time - (hour * 60);
        day = hour / 8;
        hour = hour - (day * 8);
        week = day / 5;
        day = day - (week * 5);
        String totalTime = $"{week}w {day}d {hour}h {minute}m";
        return totalTime;
    }


}
