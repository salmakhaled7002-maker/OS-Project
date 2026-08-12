using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Project.Models;
using OS_Project.Services;
namespace OS_Project.Algorithms
{
    public static class PriorityPreemptive
    {
        public static List<Process> Schedule(List<Process> processes)
        {
            List<Process> result = new List<Process>();

            if (processes == null || processes.Count == 0)
                return result;

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
                List<Process> availableProcesses = remainingProcesses
                    .Where(p => p.ArrivalTime <= currentTime && p.RemainingTime > 0)
                    .OrderBy(p => p.Priority)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();

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

            StatisticsCalculator.CalculateTimes(remainingProcesses);

            result = remainingProcesses
                .OrderBy(p => p.Id)
                .ToList();

            return result;
        }
    }
}
