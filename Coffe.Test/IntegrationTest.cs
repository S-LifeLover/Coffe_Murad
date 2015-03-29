using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coffe.Test
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void IntTest()
        {
            var start = new ProcessStartInfo();
            start.FileName = "Coffe.exe";
            start.UseShellExecute = false;
            start.RedirectStandardInput= true;
            start.RedirectStandardOutput = true;

            // Кстати, обрати внимание, для чего нужен using
            using (var proc = Process.Start(start))
            {
                var line1 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line1);

                proc.StandardInput.WriteLine("1");
                var line2 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "No water",
                    line2);

                proc.StandardInput.WriteLine("3");
                proc.StandardInput.WriteLine("1");
                var line3 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "No  coffe",
                    line3);

                proc.StandardInput.WriteLine("2");
                proc.StandardInput.WriteLine("1");
                var line4 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line4);

                proc.StandardInput.WriteLine("1");
                var line5 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line5);

                proc.StandardInput.WriteLine("1");
                var line6 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line6);

                proc.StandardInput.WriteLine("1");
                var line7 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line7);

                proc.StandardInput.WriteLine("1");
                var line8 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line8);

                proc.StandardInput.WriteLine("1");
                var line9= proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "A lot of garbage",
                    line9);

                proc.StandardInput.WriteLine("4");
                proc.StandardInput.WriteLine("1");
                var line10 = proc.StandardOutput.ReadLine();
                Assert.AreEqual(
                    "Coffe is ready. Select command: 1 - make coffe, 2 - load coffe, 3 - load water, 4 - remove garbage",
                    line10);

                proc.StandardInput.WriteLine("0");
                proc.WaitForExit();
            }
        }
    }
}
