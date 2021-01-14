using System;
using System.IO;

namespace ShowDirectoryName
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Gautham\projects\apache\wsl\hadoop\.git";
            Console.WriteLine(Path.GetDirectoryName(path));
        }
    }
}
