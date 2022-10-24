using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
namespace OS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            if (input == "?")
            {
                Console.WriteLine("fcfs: For the scheduling implementation of First Come first serve");
                Console.WriteLine("p_np: For the scheduling implementation of First Come first serve");
                Console.WriteLine("p_p: For the scheduling implementation of First Come first serve");
                Console.WriteLine("rr: For the scheduling implementation of First Come first serve");
                Console.WriteLine("sjf_np: For the scheduling implementation of First Come first serve");
                Console.WriteLine("sjf_p: For the scheduling implementation of First Come first serve");
            }
            if (input == "fcfs")
            {

                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                var fcfs_t = new FCFS_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                fcfs_t.computeFCFS();
                fcfs_t.Display();
            }
            if (input == "p_np")
            {
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                var pnp_t = new Pnp_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                pnp_t.computePriority_N();
                pnp_t.Display();
                pnp_t.clearData();
            }
            if (input == "p_p")
            {
                Console.WriteLine("This will work - 3");
            }
            if (input == "rr")
            {
                Console.WriteLine("This will work - 4");
            }
            if (input == "sjf_np")
            {
                Console.WriteLine("This will work - 5");
            }
            if (input == "sjf_p")
            {
                Console.WriteLine("This will work - 6");
            }
        }
    }
}
