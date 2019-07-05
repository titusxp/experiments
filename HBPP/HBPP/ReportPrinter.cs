using System;
using System.Diagnostics;
using System.IO;

namespace HBPP
{
    public static class ReportPrinter
    {
        public static void PrintReport(string html)
        {
            var directoryName = "Cache";
            if (Directory.Exists(directoryName) == false)
            {
                Directory.CreateDirectory(directoryName);
            }

            var guid = Guid.NewGuid();
            var fileName = $"{directoryName}\\{guid}.html";
            File.WriteAllText(fileName, html);
            Process.Start(fileName);

            //string curDir = Directory.GetCurrentDirectory();
            //var url = $"file:///{curDir}/{directoryName}/{guid}.html";

            //using (var reportWindow = new ReportPrinterWindow(url))
            //{
            //    reportWindow.ShowDialog();
            //}
        }
    }
}