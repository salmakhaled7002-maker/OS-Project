using System;
using System.Collections.Generic;
using System.Linq;
using OS_Project.Models;
using OS_Project.Services;

namespace OS_Project.Algorithms
{
    public static class SJFPreemptive
    {
        public static List<string> GanttChart = new List<string>();
        public static List<Process> Schedule(List<Process> processes)
        {
            List<Process> result = new List<Process>();
            if (processes == null || processes.Count == 0)
            {
                return result;
            }
            GanttChart.Clear();
            List<Process> remainingProcesses = processes.Select(
                p => new Process
                {
                    Id = p.Id,
                    ArrivalTime = p.ArrivalTime,
                    BurstTime = p.BurstTime,
                    Priority = p.Priority,
                    RemainingTime = p.BurstTime,
                    CompletionTime = 0,
                    WaitingTime = 0,
                    TurnaroundTime = 0
                }).ToList();
            int currentTime = 0;
            int completed = 0;
            while (completed < remainingProcesses.Count)
            {
                List<Process> availableProcesses = remainingProcesses.Where(p =>p.ArrivalTime <= currentTime && p.RemainingTime > 0)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();
                if (availableProcesses.Count == 0)
                {
                    GanttChart.Add("Idle");

                    currentTime++;

                    continue;
                }
                Process currentProcess = availableProcesses[0];
                GanttChart.Add("P" + currentProcess.Id);
                currentProcess.RemainingTime--;
                currentTime++;
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