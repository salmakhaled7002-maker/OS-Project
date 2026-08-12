using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Project.Models;
namespace OS_Project.Services
{
    public static class StatisticsCalculator
    {
        public static void CalculateTimes(List<Process> processes)
        {
            foreach (Process process in processes)
            {
                process.TurnaroundTime =
                    process.CompletionTime - process.ArrivalTime;

                process.WaitingTime =
                    process.TurnaroundTime - process.BurstTime;
            }
        }

        public static double CalculateAverageWaitingTime(List<Process> processes)
        {
            if (processes.Count == 0)
                return 0;

            return processes.Average(p => p.WaitingTime);
        }

        public static double CalculateAverageTurnaroundTime(List<Process> processes)
        {
            if (processes.Count == 0)
                return 0;

            return processes.Average(p => p.TurnaroundTime);
        }
    }
}
