using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Project.Models;

namespace OS_Project.Algorithms
{
    public static class First_come_first_serve
    {
        

        public static List<string> GanttChart =
            new List<string>();


        public static List<Process> Calculate(
            List<Process> processes)
        {
            if (processes == null ||
                processes.Count == 0)
            {
                return new List<Process>();
            }

            GanttChart.Clear();


            List<Process> result =
                processes
                .OrderBy(p => p.ArrivalTime)
                .ThenBy(p => p.Id)
                .ToList();


            int currentTime = 0;


         

            foreach (Process process in result)
            {

                if (currentTime < process.ArrivalTime)
                {
                    while (currentTime < process.ArrivalTime)
                    {
                        GanttChart.Add("Idle");
                        currentTime++;
                    }
                }

                for (int i = 0;
                     i < process.BurstTime;
                     i++)
                {
                    GanttChart.Add(
                        "P" + process.Id);

                    currentTime++;
                }


                process.CompletionTime =
                    currentTime;

                process.TurnaroundTime =
                    process.CompletionTime -
                    process.ArrivalTime;

                process.WaitingTime =
                    process.TurnaroundTime -
                    process.BurstTime;
            }


            return result
                .OrderBy(p => p.Id)
                .ToList();
        }


        public static double GetAverageWaitingTime(
            List<Process> processes)
        {
            if (processes == null ||
                processes.Count == 0)
            {
                return 0;
            }

            return processes.Average(
                p => p.WaitingTime);
        }

        public static double GetAverageTurnaroundTime(
            List<Process> processes)
        {
            if (processes == null ||
                processes.Count == 0)
            {
                return 0;
            }

            return processes.Average(
                p => p.TurnaroundTime);
        }
    }
}