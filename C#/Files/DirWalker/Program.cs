using System;
using System.IO;

namespace DirWalker
{
    class Program
    {
        public static void DirWalk(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(path))
            {
                Console.WriteLine(file);
            }

            foreach (var directory in Directory.GetDirectories(path))
            {
                DirWalk(directory);
            }
        }

        static void Main(string[] args)
        {
            var path = @"C:\Users\Gautham\projects\apache\wsl\hadoop";
            DirWalk(path);
        }
    }
}
