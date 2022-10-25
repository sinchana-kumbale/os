using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS
{
    class FCFS_alg
    {
        //inputs
        public int num_process;
        public int[] cpu_burstTime;
        public int[] arrivalTime;
        public int[] priority;

        //outputs
        public int[] waitingTime;
        public int[] turnaroundTime;
        public int[] start;
        public int[] end;
        public int[] proc;
        public float avg_waiting;
        public float avg_turnaround;
        public int lastValid;

        public FCFS_alg(int[] a, int[] b, int[] c, int num)
        {
            num_process = num;
            arrivalTime = a;
            cpu_burstTime = b;
            priority = c;
            waitingTime = new int[10];
            turnaroundTime = new int[10];
            start = new int[10];
            end = new int[10];
            proc = new int[10];
            for (int i = 0; i < 10; i++)
            {
                waitingTime[i] = 0; turnaroundTime[i] = 0; start[i] = 0; end[i] = 0; proc[i] = -1;
            }

        }
        public void clearData()
        {
            arrivalTime = new int[0]; cpu_burstTime = new int[0]; priority = new int[0];
            for (int i = 0; i < 10; i++)
            {
                waitingTime[i] = 0; turnaroundTime[i] = 0; start[i] = 0; end[i] = 0; proc[i] = -1;
            }
        }
        public void computeFCFS()
        {
            List<process> p = new List<process>(num_process);
            for (int i = 0; i < num_process; i++)
            {

                process a = new process(i, arrivalTime[i], cpu_burstTime[i]);
                p.Add(a);
            }

            process.sort1(p);


            int cnt = 0, idx = 0;
            for (int i = 0; i < num_process; i++)
            {
                if (p[i].arrival <= cnt)
                {
                    start[idx] = cnt;
                    end[idx] = cnt + p[i].burst_time;
                    proc[idx] = p[i].index;
                    waitingTime[i] = start[idx] - p[i].arrival;
                    turnaroundTime[i] = end[idx] - p[i].arrival;
                    cnt += p[i].burst_time;
                    idx++;
                }
                else
                {
                    start[idx] = cnt;
                    end[idx] = p[i].arrival;
                    proc[idx] = -1;
                    cnt = p[i].arrival;
                    idx++;
                    start[idx] = cnt;
                    end[idx] = cnt + p[i].burst_time;
                    proc[idx] = p[i].index;
                    waitingTime[i] = start[idx] - p[i].arrival;
                    turnaroundTime[i] = end[idx] - p[i].arrival;
                    cnt += p[i].burst_time;
                    idx++;
                }
            }
            for (int i = 0; i < num_process; i++)
            {
                if (waitingTime[i] == 0) continue;
                else
                {
                    avg_waiting += waitingTime[i];
                }
            }
            avg_waiting /= num_process;
            for (int i = 0; i < num_process; i++)
            {
                if (turnaroundTime[i] == 0) continue;
                else
                {
                    avg_turnaround += turnaroundTime[i];
                }
            }
            avg_turnaround /= num_process;
            lastValid = idx;
        }
        public void Display()
        {
            Console.Write("-------------------------------------------------------\n");
            for (int i = 0; i < lastValid; i++)
            {
                Console.Write(start[i]);
                Console.Write("--");
                Console.Write(end[i]);
                Console.Write("  Process : ");
                Console.Write(proc[i]);
                Console.Write("  Waiting Time : ");
                Console.Write(waitingTime[i]);
                Console.Write("  Turnaround Time : ");
                Console.Write(turnaroundTime[i]);
                Console.Write("\n");
            }
            Console.Write("-------------------------------------------------------\n");
            Console.Write("Average Waiting Time : ");
            Console.WriteLine(avg_waiting);
            Console.Write("Average Turnaround Time : ");
            Console.WriteLine(avg_turnaround);
            Console.Write("-------------------------------------------------------\n");
        }
    }
}