using System.Diagnostics;

namespace WorldLineTestSolution.Helpers
{
    public class ProcessHelper
    {
        public ProcessHelper()
        {

        }

        private string _pathToCmd => @"C:\Windows\System32\cmd.exe";

        private string _scriptForGenerateDocumentation => "livingdoc test-assembly WorldLineTestSolution.dll -t TestExecution.json";

        private string _testExecutionJson => "TestExecution.json";

        private string _testExecutionHtml => "LivingDoc.html";

        public void GenerateReport()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = _pathToCmd;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(_scriptForGenerateDocumentation);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        public void CheckingIfReportFilesExist() 
        {
            var date = DateTime.Now.ToString("_yyyy-MM-ddh-mm-ss-tt");

            if (File.Exists(_testExecutionJson) && File.Exists(_testExecutionHtml))
            {
                File.Copy(_testExecutionJson, _testExecutionJson.Replace(".json", "") + date + ".json");
                File.Copy(_testExecutionHtml, _testExecutionHtml.Replace(".html", "") + date + ".html");
            }
        }
    }
}