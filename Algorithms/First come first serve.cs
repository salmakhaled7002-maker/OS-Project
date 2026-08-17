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
        // =========================================================
        // GANTT CHART
        // =========================================================

        public static List<string> GanttChart =
            new List<string>();


        // =========================================================
        // FCFS CALCULATION
        // =========================================================

        public static List<Process> Calculate(
            List<Process> processes)
        {
            if (processes == null ||
                processes.Count == 0)
            {
                return new List<Process>();
            }

            // Clear old Gantt Chart
            GanttChart.Clear();


            // Sort by Arrival Time
            List<Process> result =
                processes
                .OrderBy(p => p.ArrivalTime)
                .ThenBy(p => p.Id)
                .ToList();


            int currentTime = 0;


            // =====================================================
            // FCFS
            // =====================================================

            foreach (Process process in result)
            {
                // =================================================
                // CPU IDLE
                // =================================================

                if (currentTime < process.ArrivalTime)
                {
                    // Add Idle for every idle time unit
                    while (currentTime < process.ArrivalTime)
                    {
                        GanttChart.Add("Idle");
                        currentTime++;
                    }
                }


                // =================================================
                // EXECUTE PROCESS
                // =================================================

                for (int i = 0;
                     i < process.BurstTime;
                     i++)
                {
                    GanttChart.Add(
                        "P" + process.Id);

                    currentTime++;
                }


                // =================================================
                // COMPLETION TIME
                // =================================================

                process.CompletionTime =
                    currentTime;


                // =================================================
                // TURNAROUND TIME
                // TAT = CT - AT
                // =================================================

                process.TurnaroundTime =
                    process.CompletionTime -
                    process.ArrivalTime;


                // =================================================
                // WAITING TIME
                // WT = TAT - BT
                // =================================================

                process.WaitingTime =
                    process.TurnaroundTime -
                    process.BurstTime;
            }


            // Return ordered by Process ID
            return result
                .OrderBy(p => p.Id)
                .ToList();
        }


        // =========================================================
        // AVERAGE WAITING TIME
        // =========================================================

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


        // =========================================================
        // AVERAGE TURNAROUND TIME
        // =========================================================

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