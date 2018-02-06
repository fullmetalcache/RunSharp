using System;
using System.Diagnostics;

namespace RunSharp
{
    public class RunSharp
    {
        public RunSharp()
        {
        }

        /// <summary>
        /// This function allows you to run a command as another user.
        /// 
        /// The function will call cmd.exe and pass in the command string contents as the command to execute.
        /// 
        /// The output of the command will be
        /// </summary>
        /// <param name="domain">Domain/Hostname for the Target user</param>
        /// <param name="userName">Username for the target User</param>
        /// <param name="password">Password for the Target User</param>
        /// <param name="command">Command to Execute as the Target User</param>
        public void RunCmd(string domain, string userName, string password, string command)
        {
            Process cmd = new Process();

            cmd.StartInfo.Domain = domain;
            cmd.StartInfo.UserName = userName;
            cmd.StartInfo.PasswordInClearText = password;

            Console.WriteLine("Executing : " + command);
            Console.WriteLine("Running as : " + domain + "\\" + userName);

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.WorkingDirectory = "C:\\Windows\\System32\\";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            cmd.WaitForExit();

            Console.WriteLine("\n------- Command Output -------\n" + cmd.StandardOutput.ReadToEnd());
            Console.WriteLine("\n------- Command Errors -------\n" + cmd.StandardError.ReadToEnd());
        }
    }
}
