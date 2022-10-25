using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS
{
    class process
    {
        public int arrival;
        public int index;
        public int burst_time;
        public int priority;

        public process()
        {

        }
        public process(int i, int value, int b)
        {
            index = i;
            arrival = value;
            burst_time = b;
        }

        public process(int i, int value, int b, int p)
        {
            index = i;
            arrival = value;
            burst_time = b;
            priority = p;
        }

        public static void sort1(List<process> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    if (l[i].arrival < l[j].arrival)
                    {
                        process temp = l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }
        }

        public static void sort2(List<process> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    if (l[i].priority < l[j].priority)
                    {
                        process temp = l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }
        }
        public static void sort3(List<process> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    if (l[i].burst_time < l[j].burst_time)
                    {
                        process temp = l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }

        }
        public static void getProcessDetails(int num_processes, int[] processes_burst, int[] processes_arrival, int[] processes_priority)
        {
            int i;
            Console.Write("-----------------------------------------\n");

            Console.Write("Input {0} processes :\n", num_processes);
            for (i = 0; i < num_processes; i++)
            {
                Console.Write("process - {0} : ", i);
                Console.Write("Arrival Time of process {0}: ", i);
                processes_arrival[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (i = 0; i < num_processes; i++)
            {
                Console.Write("process - {0} : ", i);
                Console.Write("Burst Time of process {0}: ", i);
                processes_burst[i] = Convert.ToInt32(Console.ReadLine());             
            }        

            for (i = 0; i < num_processes; i++)
            {
                Console.Write("process - {0} : ", i);
                Console.Write("Priority of process {0}: ", i);
                processes_priority[i] = Convert.ToInt32(Console.ReadLine());
            }
            process.printProcessDetails(num_processes, processes_burst, processes_arrival, processes_priority);
        }
        public static void printProcessDetails(int num_processes, int[] processes_burst, int[] processes_arrival, int[] processes_priority)
        {
            Console.Write("-------------------------------------------------------\n");
            for (int i = 0;i<num_processes;i++)
            {
                Console.Write("Process Number: {0}\tArrival Time: {1}\tBurst Time: {2}\t Priority: {3}\n", i, processes_arrival[i], processes_burst[i], processes_priority[i]);
            }
            Console.Write("-------------------------------------------------------\n");
        }
    }
}