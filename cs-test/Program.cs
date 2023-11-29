using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Program
{

    static readonly string FILE_PATH = "C:\\Users\\Matthew\\Repos\\ArcanaLang\\cs-test\\test.arc";

    public static void Main(string[] args)
    {
        foreach (var a in args)
        {
            Console.WriteLine(a);
        }
        if (args.Length > 0)
        {
            if (File.Exists(args[0]))
                ReadFile(args[0]);
            else
                ProcessCode(args[0]);
        }
        else
        {
            ReadFile(FILE_PATH);
        }


    }
    public static void ReadFile(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(File.Open(path, FileMode.Open)))
            {
                ProcessCode(reader.ReadToEnd());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public static void ProcessCode(string code) {
        var parser = new Parser();
        var prog = parser.CreateAST(code);
        Console.WriteLine(prog);
    }

}
