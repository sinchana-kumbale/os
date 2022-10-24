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
                //Console.WriteLine("This will work - 1");
                Console.WriteLine("\nEnter the Number of Processes: ");
                int num_processes;
                num_processes = Convert.ToInt32(Console.ReadLine());
                int[] processes = new int[num_processes];
                int i;
                Console.Write("-----------------------------------------\n");

                Console.Write("Input {0} processes :\n",processes);
                for (i = 0; i < 10; i++)
                {
                    Console.Write("element - {0} : ", i);
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("\nElements in array are: ");
                for (i = 0; i < 10; i++)
                {
                    Console.Write("{0}  ", arr[i]);
                }
                Console.Write("\n");
            }
            if (input == "p_np")
            {
                Console.WriteLine("This will work - 2");
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
