using System;
using System.Diagnostics;
using System.Text;

namespace Failed_tests_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("mvn", "--version")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            StringBuilder outputBuilder = new StringBuilder();
            using Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.OutputDataReceived += (sendingProcess, outLine) =>
            {
                if (String.IsNullOrEmpty(outLine.Data))
                {
                    return;
                }

                if (outputBuilder.Length > 0)
                {
                    outputBuilder.Append(Environment.NewLine);
                }
                outputBuilder.Append(outLine.Data);
            };

            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();

            Console.WriteLine("Maven output");
            Console.WriteLine(outputBuilder.ToString());
        }
    }
}
