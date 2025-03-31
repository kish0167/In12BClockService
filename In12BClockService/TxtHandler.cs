namespace In12BClockService;

public static class TxtHandler
{
    public static string ReadTxt(string path)
    {
        if (!path.EndsWith(".txt"))
        {
            path += ".txt";
        }

        if (!Path.Exists(path))
        {
            return "";
        }
        
        StreamReader r = new StreamReader(path);
        string txt = r.ReadToEnd();
        r.Close();
        return txt;
    }
}