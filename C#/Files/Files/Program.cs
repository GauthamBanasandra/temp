using System;
using System.Collections.Generic;
using System.IO;

namespace Files
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
