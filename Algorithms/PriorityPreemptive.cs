using System;
using System.Collections.Generic;
using System.Linq;
using OS_Project.Models;
using OS_Project.Services;

namespace OS_Project.Algorithms
{
    public static class PriorityPreemptive
    {
        // Gantt Chart
        // Example:
        // P1 (0 - 2)
        // P2 (2 - 6)
        // P3 (6 - 7)
        // P1 (7 - 12)
        // P4 (12 - 16)

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

            // =========================================
            // CLEAR OLD GANTT CHART
            // =========================================

            GanttChart.Clear();


            // =========================================
            // CREATE COPY
            // =========================================

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


            // =========================================
            // VARIABLES FOR GANTT CHART
            // =========================================

            int ganttStartTime = 0;
            int lastProcessId = -1;


            // =========================================
            // PRIORITY PREEMPTIVE
            // Smaller Priority Number = Higher Priority
            // =========================================

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


                // =========================================
                // CPU IDLE
                // =========================================

                if (availableProcesses.Count == 0)
                {
                    // If another process was running,
                    // close its Gantt block first
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

                    // Start Idle block
                    if (GanttChart.Count == 0 ||
                        !GanttChart.Last().StartsWith("Idle"))
                    {
                        ganttStartTime = currentTime;
                    }

                    currentTime++;

                    continue;
                }


                // =========================================
                // SELECT HIGHEST PRIORITY
                // =========================================

                Process currentProcess =
                    availableProcesses[0];


                // =========================================
                // PROCESS CHANGED
                // =========================================

                if (lastProcessId != currentProcess.Id)
                {
                    // Close previous process block
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

                    // Start new process block
                    ganttStartTime = currentTime;
                    lastProcessId = currentProcess.Id;
                }


                // =========================================
                // EXECUTE ONE TIME UNIT
                // =========================================

                currentProcess.RemainingTime--;

                currentTime++;


                // =========================================
                // PROCESS COMPLETED
                // =========================================

                if (currentProcess.RemainingTime == 0)
                {
                    currentProcess.CompletionTime =
                        currentTime;

                    completed++;
                }
            }


            // =========================================
            // CLOSE LAST GANTT BLOCK
            // =========================================

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


            // =========================================
            // CALCULATE TAT & WT
            // =========================================

            StatisticsCalculator.CalculateTimes(
                remainingProcesses);


            // =========================================
            // RETURN SORTED BY PROCESS ID
            // =========================================

            result =
                remainingProcesses
                .OrderBy(p => p.Id)
                .ToList();


            return result;
        }
    }
}