class AppendAction
{
    public AppendAction(string FileName, string text)
    {
        Helper.AppendToFile(FileName, text);
    }
}

