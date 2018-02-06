using RunSharp;
using System;
using System.Configuration.Install;
using System.Runtime.InteropServices;

namespace RunSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            if( args.Length < 4)
            {
                Console.WriteLine("Usage: RunSharp.exe Domain UserName Password Command");
                return;
            }

            string domain = args[0];
            string userName = args[1];
            string password = args[2];
            string command = args[3];

            Program.Exec(domain, userName, password, command);
        }

        /// <summary>
        /// Method that will be run when using InstallUtil.
        /// 
        /// This function expects that arguments Domain, Username, Password, and Command will
        /// be contained in a file named input.txt. TEach argument should be on its own line
        /// and the arguments should be in the order shown above. The input.txt file should be
        /// in the same directory as the RunSharp.exe program. Here is an example file:
        /// 
        /// CORP
        /// fullmetalcache
        /// thisisntreallymypassword
        /// whoami >> C:\\Users\\Public\\test.txt
        /// 
        /// 
        /// </summary>
        [System.ComponentModel.RunInstaller(true)]
        public class Sample : System.Configuration.Install.Installer
        {
            public override void Uninstall(System.Collections.IDictionary savedState)
            {
                string[] args = new String[4];
                string line;
                int idx = 0;

                System.IO.StreamReader file = new System.IO.StreamReader(".\\input.txt");
                while ((line = file.ReadLine()) != null)
                {
                    args[idx] = line;
                    idx++;
                    
                    if( idx >= 4)
                    {
                        break;
                    }
                }

                if( idx < 4)
                {
                    Console.WriteLine("Usage: RunSharp.exe Domain UserName Password Command");
                    return;
                }

                string domain = args[0];
                string userName = args[1];
                string password = args[2];
                string command = args[3];

                Program.Exec(domain, userName, password, command);
            }
        }

        public static void Exec(string domain, string userName, string password, string command)
        {
            RunSharp runSharp = new RunSharp();
            runSharp.RunCmd(domain, userName, password, command);
        }

    }
}



