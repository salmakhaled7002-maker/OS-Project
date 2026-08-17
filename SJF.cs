using System;
using System.Collections.Generic;
using System.Linq;
using OS_Project.Models;
using OS_Project.Services;

namespace OS_Project.Algorithms
{
    public static class SJF
    {
        public static List<string> GanttChart =
            new List<string>();

        public static List<Process> Schedule(
            List<Process> processes)
        {
            List<Process> result =
                new List<Process>();

            if (processes == null ||
                processes.Count == 0)
            {
                return result;
            }

            GanttChart.Clear();

            List<Process> remainingProcesses =
                processes
                .Select(p => new Process
                {
                    Id = p.Id,
                    ArrivalTime = p.ArrivalTime,
                    BurstTime = p.BurstTime,
                    Priority = p.Priority,
                    RemainingTime = p.BurstTime,
                    CompletionTime = 0,
                    WaitingTime = 0,
                    TurnaroundTime = 0
                })
                .ToList();

            int currentTime = 0;
            int completed = 0;

            while (completed < remainingProcesses.Count)
            {
                List<Process> availableProcesses =
                    remainingProcesses
                    .Where(p =>
                        p.ArrivalTime <= currentTime &&
                        p.RemainingTime > 0)
                    .OrderBy(p => p.BurstTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();

                if (availableProcesses.Count == 0)
                {
                    GanttChart.Add("Idle");

                    int nextArrival =
                        remainingProcesses
                        .Where(p =>
                            p.RemainingTime > 0 &&
                            p.ArrivalTime > currentTime)
                        .Min(p => p.ArrivalTime);

                    currentTime = nextArrival;
                    continue;
                }

                Process currentProcess =
                    availableProcesses[0];

                int startTime = currentTime;

                currentTime += currentProcess.BurstTime;
                currentProcess.RemainingTime = 0;

                currentProcess.CompletionTime =
                    currentTime;

                completed++;

                GanttChart.Add(
                    "P" + currentProcess.Id +
                    " (" +
                    startTime +
                    " - " +
                    currentTime +
                    ")"
                );
            }

            StatisticsCalculator.CalculateTimes(
                remainingProcesses);

            result =
                remainingProcesses
                .OrderBy(p => p.Id)
                .ToList();

            return result;
        }
    }
}