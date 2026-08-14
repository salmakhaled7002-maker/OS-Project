using System;
using System.Collections.Generic;
using System.Linq;
using OS_Project.Models;
using OS_Project.Services;

namespace OS_Project.Algorithms
{
    public static class SJFPreemptive
    {
        // كل عنصر = Process اشتغلت لمدة Time Unit واحدة
        public static List<string> GanttChart =
            new List<string>();


        public static List<Process> Schedule(
            List<Process> processes)
        {
            List<Process> result =
                new List<Process>();

            // =========================================
            // CHECK INPUT
            // =========================================

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
            // SJF PREEMPTIVE / SRTF
            // =========================================

            while (completed < remainingProcesses.Count)
            {
                // Get all processes that:
                // 1. Have arrived
                // 2. Are not finished

                List<Process> availableProcesses =
                    remainingProcesses
                    .Where(p =>
                        p.ArrivalTime <= currentTime &&
                        p.RemainingTime > 0)
                    .OrderBy(p => p.RemainingTime)
                    .ThenBy(p => p.ArrivalTime)
                    .ThenBy(p => p.Id)
                    .ToList();


                // =====================================
                // CPU IDLE
                // =====================================

                if (availableProcesses.Count == 0)
                {
                    GanttChart.Add("Idle");

                    currentTime++;

                    continue;
                }


                // =====================================
                // SELECT SHORTEST REMAINING JOB
                // =====================================

                Process currentProcess =
                    availableProcesses[0];


                // =====================================
                // ADD TO GANTT
                // =====================================

                GanttChart.Add(
                    "P" + currentProcess.Id);


                // =====================================
                // EXECUTE ONE TIME UNIT
                // =====================================

                currentProcess.RemainingTime--;

                currentTime++;


                // =====================================
                // CHECK COMPLETION
                // =====================================

                if (currentProcess.RemainingTime == 0)
                {
                    currentProcess.CompletionTime =
                        currentTime;

                    completed++;
                }
            }


            // =========================================
            // CALCULATE TAT AND WT
            // =========================================

            StatisticsCalculator.CalculateTimes(
                remainingProcesses);


            // =========================================
            // RETURN RESULT SORTED BY PROCESS ID
            // =========================================

            result =
                remainingProcesses
                .OrderBy(p => p.Id)
                .ToList();


            return result;
        }
    }
}   