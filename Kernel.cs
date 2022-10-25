﻿using System;
using Sys = Cosmos.System;
namespace OS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Welcome to SASos!");
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            if (input == "help")
            {
                Console.WriteLine("about: Know OS Version");
                Console.WriteLine("shutdown: To Shutdown");
                Console.WriteLine("restart: To Restart");
                Console.WriteLine("echo: Print the input as is");
                Console.WriteLine("fcfs: For the scheduling implementation of First Come first serve");
                Console.WriteLine("p_np: For the scheduling implementation of Priority Non Preemptive");
                Console.WriteLine("p_p: For the scheduling implementation of Priority Preemptive");
                Console.WriteLine("rr: For the scheduling implementation of Round Robin");
                Console.WriteLine("sjf_np: For the scheduling implementation of Shortest Job First Non Preemptive");
                Console.WriteLine("sjf_p: For the scheduling implementation of Shortest Job First Preemptive");
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
                var fcfs = new FCFS_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                fcfs.computeFCFS();
                fcfs.Display();
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
                var pnp = new Pnp_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                pnp.computePriority_N();
                pnp.Display();
                pnp.clearData();
            }
            if (input == "p_p")
            {
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                var pp_t = new Pp_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                pp_t.computePriority_P();
                pp_t.Display();
                pp_t.clearData();
            }
            if (input == "rr")
            {
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                int quantum;
                Console.WriteLine("\nEnter the time quantum for Round Robin Scheduling: ");
                quantum = Convert.ToInt32(Console.ReadLine());
                var rr_t = new RR_alg(processes_arrival, processes_burst, processes_priority, quantum, num_processes);
                rr_t.computeRR();
                rr_t.Display();
                rr_t.clearData();
            }
            if (input == "sjf_np")
            {
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                var sjfnp_t = new SJFnp_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                sjfnp_t.computeSJF_N();
                sjfnp_t.Display();
                sjfnp_t.clearData();
            }
            if (input == "sjf_p")
            {
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes_burst = new int[num_processes];
                int[] processes_arrival = new int[num_processes];
                int[] processes_priority = new int[num_processes];
                process.getProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
                var sjfp_t = new SJFp_alg(processes_arrival, processes_burst, processes_priority, num_processes);
                sjfp_t.computeSJF_P();
                sjfp_t.Display();
                sjfp_t.clearData();
            }
            if (input == "about")
            {
                Console.WriteLine("SAS OS v1.0");
            }

            if (input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }

            if (input == "restart")
            {
                Cosmos.System.Power.Reboot();
            }
            if (input == "echo")
            {
                Console.WriteLine("\nEnter the string: ");
                var echo_inp = Console.ReadLine();
                Console.WriteLine("Echo Output: {0}", echo_inp);

            }
        }
    }
}
