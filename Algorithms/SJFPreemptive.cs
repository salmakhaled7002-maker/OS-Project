using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Project.Models;
using OS_Project.Services;
namespace OS_Project.Algorithms
{
    public static class SJFPreemptive
    {
        public static List<Process> Schedule(List<Process> processes)
        {
            List<Process> result = new List<Process>();

            if (processes == null || processes.Count == 0)
                return result;

            // Create a copy so we don't modify the original processes
            List<Process> remainingProcesses = processes
                .Select(p => new Process
                {
                    Id = p.Id,
                    ArrivalTime = p.ArrivalTime,
                    BurstTime = p.BurstTime,
                    Priority = p.Priority,
                    RemainingTime = p.BurstTime
                })
                .ToList();

            int currentTime = 0;
            int completed = 0;

            while (completed < remainingProcesses.Count)
            {
                // Get processes that have arrived and are not finished
                List<Process> availableProcesses = remainingProcesses
                    .Where(p => p.ArrivalTime <= currentTime && p.RemainingTime > 0)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();

                // If no process has arrived yet, move time forward
                if (availableProcesses.Count == 0)
                {
                    currentTime++;
                    continue;
                }

                Process currentProcess = availableProcesses[0];

                // Execute for one time unit
                currentProcess.RemainingTime--;
                currentTime++;

                // Process finished
                if (currentProcess.RemainingTime == 0)
                {
                    currentProcess.CompletionTime = currentTime;
                    completed++;
                }
            }

            // Calculate Waiting Time and Turnaround Time
            StatisticsCalculator.CalculateTimes(remainingProcesses);

            result = remainingProcesses
                .OrderBy(p => p.Id)
                .ToList();

            return result;
        }
    }
}
