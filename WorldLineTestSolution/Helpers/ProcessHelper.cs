using System.Diagnostics;

namespace WorldLineTestSolution.Helpers
{
    public class ProcessHelper
    {
        public ProcessHelper()
        {

        }

        private string PathToCmd => @"C:\Windows\System32\cmd.exe";

        private string ScriptForGenerateDocumentation => "livingdoc test-assembly WorldLineTestSolution.dll -t TestExecution.json";

        public void RunScript()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = PathToCmd;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(ScriptForGenerateDocumentation);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }
    }
}
