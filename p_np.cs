using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS
{
    class Pnp_alg
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


        public Pnp_alg(int[] a, int[] b, int[] c, int n)
        {
            num_process = n;
            arrivalTime = a;
            cpu_burstTime = b;
            priority = c;
            waitingTime = new int[2000];
            turnaroundTime = new int[2000];
            start = new int[2000];
            end = new int[2000];
            proc = new int[2000];
            for (int i = 0; i < 2000; i++)
            {
                waitingTime[i] = 0; turnaroundTime[i] = 0; start[i] = 0; end[i] = 0; proc[i] = -1;
            }

        }
        public void clearData()
        {
            arrivalTime = new int[0]; cpu_burstTime = new int[0]; priority = new int[0];
            for (int i = 0; i < 2000; i++)
            {
                waitingTime[i] = 0; turnaroundTime[i] = 0; start[i] = 0; end[i] = 0; proc[i] = -1;
            }
        }

        public void computePriority_N()
        {
            List<process> p = new List<process>(num_process);

            for (int i = 0; i < num_process; i++)
            {
                p.Add(new process(i, arrivalTime[i], cpu_burstTime[i], priority[i]));
            }
            process.sort1(p);
            int cnt = 0;
            int idx = 0;

            while (p.Count != 0)
            {
                List<process> ready = new List<process>(num_process);
                if (p.First().arrival > cnt)
                {
                    start[idx] = cnt;
                    end[idx] = p.First().arrival;
                    proc[idx] = -1;
                    idx++;
                    cnt = p.First().arrival;
                }
                for (int i = 0, j = 0; j < p.Count; i++)
                {
                    if (p[j].arrival <= cnt)
                    {
                        ready.Add(p[j]);
                        p.RemoveAt(j);
                    }
                    else j++;
                }
                while (ready.Count != 0)
                {
                    process.sort2(ready);
                    process readyProcess = ready[0];
                    ready.RemoveAt(0);
                    start[idx] = cnt;
                    end[idx] = cnt + readyProcess.burst_time;
                    proc[idx] = readyProcess.index;
                    waitingTime[idx] = start[idx] - readyProcess.arrival;
                    turnaroundTime[idx] = end[idx] - readyProcess.arrival;
                    idx++;
                    cnt += readyProcess.burst_time;
                    for (int i = 0, j = 0; i < p.Count; i++)
                    {
                        if (p[j].arrival <= cnt)
                        {
                            ready.Add(p[j]);
                            p.RemoveAt(j);
                        }
                        else j++;
                    }
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