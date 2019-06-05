
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
