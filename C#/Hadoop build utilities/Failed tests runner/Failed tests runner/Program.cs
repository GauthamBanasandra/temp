using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Failed_tests_runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var failedTests = new string[]
            {
                "org.apache.hadoop.hdfs.server.namenode.ha.TestPipelinesFailover.testFailoverRightBeforeCommitSynchronization",
                "org.apache.hadoop.yarn.sls.appmaster.TestAMSimulator.testAMSimulatorWithNodeLabels[0]",
                "org.apache.hadoop.yarn.server.resourcemanager.scheduler.fair.TestFairScheduler.testMoveWouldViolateMaxAppsConstraints",
                "org.apache.hadoop.yarn.server.resourcemanager.scheduler.fair.TestFairSchedulerPreemption.testRelaxLocalityPreemptionWithNoLessAMInRemainingNodes[MinSharePreemptionWithDRF]",
                "org.apache.hadoop.hdfs.server.blockmanagement.TestBlockTokenWithDFSStriped.testRead",
                "org.apache.hadoop.yarn.applications.distributedshell.TestDistributedShell.testDSShellWithOpportunisticContainers",
                "org.apache.hadoop.yarn.applications.distributedshell.TestDistributedShell.testDSShellWithEnforceExecutionType"
            };

            var info = failedTests.Select(e => e.Split('.')).Select(e => new FailedTestInfo() { TestName = e.Last(), TestClass = e.SkipLast(1).Last() });
            foreach (var t in info)
            {
                Console.WriteLine($"{t.TestClass}\t{t.TestName}");
            }
        }



        private void SomeMethod()
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
