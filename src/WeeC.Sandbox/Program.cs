using System;
using System.IO;

namespace WeeC.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Script();
            s.LoadString(File.ReadAllText("file.c"));
            Console.ReadLine();
        }
    }
}
