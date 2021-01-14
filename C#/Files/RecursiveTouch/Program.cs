using System;
using System.Collections.Generic;
using System.IO;
using Console = System.Console;

namespace RecursiveTouch
{
    class Program
    {
        public static void TouchAll(string path, ISet<string> exclude = null)
        {
            if (!Directory.Exists(path) || (exclude != null && exclude.Contains(path)))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(path))
            {
                Console.WriteLine(file);
                File.WriteAllText(file, $"\n{File.ReadAllText(file)}");
            }

            foreach (var directory in Directory.GetDirectories(path))
            {
                TouchAll(directory, exclude);
            }
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Need exactly 1 parameter - the path to the root directory");
                return;
            }

            var exclusions = new HashSet<string>
            {
                @"C:\Users\Gautham\projects\apache\wsl\hadoop\.git",
                @"C:\Users\Gautham\projects\apache\wsl\hadoop\.github"
            };

            TouchAll(args[0], exclusions);
        }
    }
}
