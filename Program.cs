using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3
{
    class Program
    {
        static void Main(string[] args)
        {

            // 
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
                                                        
            System.Threading.Thread.Sleep(500);
            

            PerformanceCounter cpu = new PerformanceCounter();
            cpu.CategoryName = "Processor Information";
            cpu.CounterName = "Processor Frequency";
            cpu.InstanceName = "0,0";

            PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

            
            ///-------------------------------------------

            Console.Write("Frequency of processor 0 is: ");
            Console.WriteLine(cpu.NextValue());

            Console.Write("Avalable Memory  (MB) is: ");
            Console.WriteLine(ram.NextValue());

            int nProcessID = Process.GetCurrentProcess().Id;
            Console.Write("Current PID: ");
            Console.WriteLine(nProcessID);

            

            int i, c = 0;
            for (i = 0; i < 1000; i++)
                c++;

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Console.Write("Current UserName is : ");
            Console.WriteLine(userName);

            //-------------------------------------------

            stopwatch.Stop();
            Console.WriteLine("Executiontime: "+stopwatch.ElapsedMilliseconds+" ms");

            Process p = null;
            try
            {
                p = new Process();
                p.StartInfo.FileName = "notepad";
                p.Start();
               
                Console.Write("Notepad PID is : ");
                Console.WriteLine(p.Id+ " (different from parent PID: "+ nProcessID+")");
                System.Threading.Thread.Sleep(5000);
                p.Kill();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception  :{0},{1}",
                         ex.Message, ex.StackTrace.ToString());
            }

            ProcessStartInfo _processStartConfig = new ProcessStartInfo();

            //Mettre le chemin de votre appication et le nom de l'executable
            _processStartConfig.WorkingDirectory = @"C:\Users\stark\source\repos\tp3-2\bin\Debug";
            _processStartConfig.FileName = @"tp3-2.exe";
           

            Process newProcess = Process.Start(_processStartConfig);

            Console.ReadKey();
        }
    }
}
