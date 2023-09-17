using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using SysIO = System.IO;

namespace NeverSpace
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS fs = new CosmosVFS();

        protected override void BeforeRun()
        {
            VFSManager.RegisterVFS(fs);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("NeverDOS Cosmos Edition Runned Successfully.");
            Console.WriteLine("Important: This Is Not Affilated With Microsoft");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        protected override void Run()
        {
            var available_space = fs.GetAvailableFreeSpace(@"0:");
            string input = "";

            Console.Beep();
            while (true)
            {
                input = Console.ReadLine();
                HandleThisCommand(input);
            }
        }


        private void HandleThisCommand(string input) {
            string inputTheme = "";
            if (input == "help" || input == "h")
            {
                Console.WriteLine("help / h -- List Of Commands");
                Console.WriteLine("ver / v -- Version Of The OS");
                Console.WriteLine("echo / p -- echoes the command");
                Console.WriteLine("NeverOS / NOS -- Not Implemented");
                Console.WriteLine("time / t -- Shows The Current Time");
                Console.WriteLine("theme / th -- Change Text Theme");
                Console.WriteLine("beep / b -- Play The 'Beep' Sound");
                Console.WriteLine("shutdown / s -- Shut Down The Computer/VM");
                Console.WriteLine("reboot / r -- Restart The Computer/VM");
                Console.WriteLine("disklist / dl -- Returns All Disks");
                Console.WriteLine("diskspace / d -- Returns Disk Space On Current Disk");
            }
            else if (input == "ver" || input == "v")
            {
                Console.WriteLine("NeverDOS Version 1.3 Public Pre-Alpha");
                Console.WriteLine("Made Using COSMOS User Kit");
                Console.WriteLine();
                Console.WriteLine("Started Development On 15.09.2023 (Probably)");
            }
            else if (input == "echo" || input == "p")
            {
                Console.WriteLine("Text To Echo");
                string echoinput = Console.ReadLine();
                Console.WriteLine(echoinput);
            }
            else if (input == "time" || input == "t")
            {
                Console.WriteLine("Current Time Is " + DateTime.Now.ToString("dd.MM.yyyy"));
            }
            else if (input == "NeverOS" || input == "NOS")
            {
                Console.WriteLine("Command Not Supported/Implemented");
            }
            else if (input == "theme" || input == "th")
            {
                Console.WriteLine("Choose Theme: Dark, Light, Blue, Dark Blue");
                inputTheme = Console.ReadLine();
                if (inputTheme == "Dark")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                } else if (inputTheme == "Light")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                } else if (inputTheme == "Dark Blue")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                } else if (inputTheme == "Blue")
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else
                {
                    Console.WriteLine("Theme Does Not Exist/Its Case Sensitive");
                }
            } else if (input == "beep" || input == "b")
            {
                Console.WriteLine("Playing The 'Beep' Sound");
                Console.Beep();
            } else if (input == "shutdown" || input == "s")
            {
                Cosmos.System.Power.Shutdown();
            } else if (input == "reboot" || input == "r")
            {
                Cosmos.System.Power.Reboot();
            } else if (input == "disklist" || input == "dl") {
                foreach (Disk disk in VFSManager.GetDisks())
                {
                    Console.WriteLine(disk.Type);
                }
            }
            else
            {
                Console.WriteLine("Command Not Found, type 'help' for list of commands/Commands Are Case Sensitive.");
            }
        }

    }
}