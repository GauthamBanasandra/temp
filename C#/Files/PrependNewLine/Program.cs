using System;
using System.IO;

namespace PrependNewLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Gautham\Documents\doc-chat.txt";
            File.WriteAllText(path, $"\n{File.ReadAllText(path)}");
        }
    }
}
