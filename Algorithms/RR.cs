using System;
using System.Collections.Generic;
using OS_Project.Models;

namespace OS_Project.Algorithms
{
    public static class RoundRobin
    {
        public static List<string> GanttChart = new List<string>();

        public static void Calculate(List<Process> processes, int quantum)
        {
            if (processes == null || processes.Count == 0)
                return;

            if (quantum <= 0)
                throw new ArgumentException("Time Quantum must be greater than 0.");

            Queue<int> queue = new Queue<int>();

            bool[] added = new bool[processes.Count];

            int currentTime = 0;
            int completed = 0;

            GanttChart.Clear();

            // Set remaining time
            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].RemainingTime = processes[i].BurstTime;
                processes[i].CompletionTime = 0;
                processes[i].WaitingTime = 0;
                processes[i].TurnaroundTime = 0;
            }

            while (completed < processes.Count)
            {
                // Add processes that have arrived
                for (int i = 0; i < processes.Count; i++)
                {
                    if (!added[i] &&
                        processes[i].ArrivalTime <= currentTime)
                    {
                        queue.Enqueue(i);
                        added[i] = true;
                    }
                }

                // If queue is empty, move to next arrival
                if (queue.Count == 0)
                {
                    int nextArrival = int.MaxValue;

                    for (int i = 0; i < processes.Count; i++)
                    {
                        if (!added[i] &&
                            processes[i].ArrivalTime < nextArrival)
                        {
                            nextArrival = processes[i].ArrivalTime;
                        }
                    }

                    currentTime = nextArrival;

                    for (int i = 0; i < processes.Count; i++)
                    {
                        if (!added[i] &&
                            processes[i].ArrivalTime <= currentTime)
                        {
                            queue.Enqueue(i);
                            added[i] = true;
                        }
                    }
                }

                // Get first process
                int p = queue.Dequeue();

                int startTime = currentTime;

                // Run for quantum or remaining time
                int executionTime;

                if (processes[p].RemainingTime > quantum)
                {
                    executionTime = quantum;
                }
                else
                {
                    executionTime = processes[p].RemainingTime;
                }

                currentTime += executionTime;

                processes[p].RemainingTime -= executionTime;

                // Save Gantt Chart information
                GanttChart.Add(
                    "P" + processes[p].Id +
                    " (" + startTime +
                    " - " + currentTime + ")"
                );

                // Add newly arrived processes
                for (int i = 0; i < processes.Count; i++)
                {
                    if (!added[i] &&
                        processes[i].ArrivalTime <= currentTime)
                    {
                        queue.Enqueue(i);
                        added[i] = true;
                    }
                }

                // If process is not finished
                if (processes[p].RemainingTime > 0)
                {
                    queue.Enqueue(p);
                }
                else
                {
                    processes[p].CompletionTime = currentTime;
                    completed++;
                }
            }

            // Calculate TAT and WT
            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].TurnaroundTime =
                    processes[i].CompletionTime -
                    processes[i].ArrivalTime;

                processes[i].WaitingTime =
                    processes[i].TurnaroundTime -
                    processes[i].BurstTime;
            }
        }
    }
}