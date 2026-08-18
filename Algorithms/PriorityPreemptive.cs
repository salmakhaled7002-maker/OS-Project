using System;
using System.Collections.Generic;
using System.Linq;
using OS_Project.Models;
using OS_Project.Services;

namespace OS_Project.Algorithms
{
    public static class PriorityPreemptive
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


            int ganttStartTime = 0;
            int lastProcessId = -1;


            while (completed < remainingProcesses.Count)
            {
                List<Process> availableProcesses =
                    remainingProcesses
                    .Where(p =>
                        p.ArrivalTime <= currentTime &&
                        p.RemainingTime > 0)
                    .OrderBy(p => p.Priority)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();


                
                if (availableProcesses.Count == 0)
                {
                    
                    if (lastProcessId != -1)
                    {
                        GanttChart.Add(
                            "P" + lastProcessId +
                            " (" +
                            ganttStartTime +
                            " - " +
                            currentTime +
                            ")");

                        lastProcessId = -1;
                    }

                    if (GanttChart.Count == 0 ||
                        !GanttChart.Last().StartsWith("Idle"))
                    {
                        ganttStartTime = currentTime;
                    }

                    currentTime++;

                    continue;
                }


                Process currentProcess =
                    availableProcesses[0];

                if (lastProcessId != currentProcess.Id)
                {
                    if (lastProcessId != -1)
                    {
                        GanttChart.Add(
                            "P" + lastProcessId +
                            " (" +
                            ganttStartTime +
                            " - " +
                            currentTime +
                            ")");
                    }

                    ganttStartTime = currentTime;
                    lastProcessId = currentProcess.Id;
                }


                currentProcess.RemainingTime--;

                currentTime++;


                if (currentProcess.RemainingTime == 0)
                {
                    currentProcess.CompletionTime =
                        currentTime;

                    completed++;
                }
            }


            if (lastProcessId != -1)
            {
                GanttChart.Add(
                    "P" + lastProcessId +
                    " (" +
                    ganttStartTime +
                    " - " +
                    currentTime +
                    ")");
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