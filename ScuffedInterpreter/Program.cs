using System.Text.RegularExpressions;

public class Program
{
    static readonly string FILE_PATH = "C:\\Users\\Matthew\\Repos\\ArcanaLang\\ScuffedInterpreter\\test.arc";

    public static void Main(string[] args)
    {
        try
        {
            using (StreamReader reader = new StreamReader(File.Open(FILE_PATH, FileMode.Open)))
            {
                while (!reader.EndOfStream)
                    ProcessLines(reader.ReadToEnd());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void ProcessLines(string? raw)
    {
        if (raw == null)
            return;
        var lines = raw.Split("\n");

        foreach (var line in lines)
        {

        }

    }
}