using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Program
{

    static readonly string FILE_PATH = "C:\\Users\\Matthew\\Repos\\ArcanaLang\\cs-test\\test.arc";

    public static void Main(string[] args)
    {
        try
        {
            using (StreamReader reader = new StreamReader(File.Open(FILE_PATH, FileMode.Open)))
            {
                var parser = new Parser();
                parser.CreateAST(reader.ReadToEnd());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    
}