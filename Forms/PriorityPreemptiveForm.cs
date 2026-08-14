using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;
using OS_Project.Services;

namespace OS_Project.Forms
{
    public partial class PriorityPreemptiveForm : Form
    {
        public PriorityPreemptiveForm()
        {
            InitializeComponent();

            // =========================================
            // CONNECT BUTTON EVENTS
            // =========================================

            btnSubmit.Click -= btnSubmit_Click;
            btnSubmit.Click += btnSubmit_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            btnCalculate.Click -= btnCalculate_Click;
            btnCalculate.Click += btnCalculate_Click;


            // =========================================
            // DATA GRID SETTINGS
            // =========================================

            dgvProcesses.AllowUserToAddRows = false;
            dgvProcesses.ReadOnly = true;
            dgvProcesses.MultiSelect = false;

            dgvProcesses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProcesses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProcesses.ScrollBars =
                ScrollBars.Vertical;


            // =========================================
            // GANTT PANEL SETTINGS
            // =========================================

            pnlGanttChart.AutoScroll = true;
        }


        // =========================================================
        // SUBMIT BUTTON
        // =========================================================

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int arrivalTime;
            int burstTime;
            int priority;


            // =========================================
            // ARRIVAL TIME
            // =========================================

            if (!int.TryParse(
                txtArrivalTime.Text.Trim(),
                out arrivalTime))
            {
                MessageBox.Show(
                    "Please enter a valid Arrival Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtArrivalTime.Focus();
                return;
            }


            // =========================================
            // BURST TIME
            // =========================================

            if (!int.TryParse(
                txtBurstTime.Text.Trim(),
                out burstTime))
            {
                MessageBox.Show(
                    "Please enter a valid Burst Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBurstTime.Focus();
                return;
            }


            // =========================================
            // PRIORITY
            // =========================================

            if (!int.TryParse(
                txtPRIORITY.Text.Trim(),
                out priority))
            {
                MessageBox.Show(
                    "Please enter a valid Priority.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPRIORITY.Focus();
                return;
            }


            // =========================================
            // VALIDATION
            // =========================================

            if (arrivalTime < 0)
            {
                MessageBox.Show(
                    "Arrival Time cannot be negative.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtArrivalTime.Focus();
                return;
            }


            if (burstTime <= 0)
            {
                MessageBox.Show(
                    "Burst Time must be greater than 0.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBurstTime.Focus();
                return;
            }


            if (priority < 0)
            {
                MessageBox.Show(
                    "Priority cannot be negative.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPRIORITY.Focus();
                return;
            }


            // =========================================
            // GENERATE PROCESS ID
            // =========================================

            int processId =
                dgvProcesses.Rows.Count + 1;


            // =========================================
            // ADD PROCESS TO TABLE
            // =========================================

            dgvProcesses.Rows.Add(
                processId,
                arrivalTime,
                burstTime,
                priority,
                "",
                "",
                ""
            );


            // =========================================
            // CLEAR INPUTS
            // =========================================

            txtArrivalTime.Clear();
            txtBurstTime.Clear();
            txtPRIORITY.Clear();

            txtArrivalTime.Focus();
        }


        // =========================================================
        // DELETE BUTTON
        // =========================================================

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a process to delete.",
                    "Delete Process",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // Delete selected rows
            foreach (DataGridViewRow row
                in dgvProcesses.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvProcesses.Rows.Remove(row);
                }
            }


            // =========================================
            // RE-NUMBER PROCESS IDs
            // =========================================

            for (int i = 0;
                i < dgvProcesses.Rows.Count;
                i++)
            {
                dgvProcesses.Rows[i]
                    .Cells[0]
                    .Value = i + 1;
            }


            // =========================================
            // RESET AVERAGES
            // =========================================

            lblAverageWaiting.Text =
                "Average Waiting Time:";

            lblAverageTurnaround.Text =
                "Average Turnaround Time:";


            // =========================================
            // CLEAR GANTT CHART
            // =========================================

            pnlGanttChart.Controls.Clear();

            pnlGanttChart.AutoScrollMinSize =
                new Size(0, 0);

            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // CALCULATE BUTTON
        // =========================================================

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one process first.",
                    "No Processes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            try
            {
                // =========================================
                // CREATE PROCESS LIST
                // =========================================

                List<Process> processes =
                    new List<Process>();


                // =========================================
                // READ DATA FROM GRID
                // =========================================

                foreach (DataGridViewRow row
                    in dgvProcesses.Rows)
                {
                    if (row.IsNewRow)
                        continue;


                    int id =
                        Convert.ToInt32(
                            row.Cells[0].Value);

                    int arrivalTime =
                        Convert.ToInt32(
                            row.Cells[1].Value);

                    int burstTime =
                        Convert.ToInt32(
                            row.Cells[2].Value);

                    int priority =
                        Convert.ToInt32(
                            row.Cells[3].Value);


                    Process process =
                        new Process
                        {
                            Id = id,
                            ArrivalTime = arrivalTime,
                            BurstTime = burstTime,
                            Priority = priority
                        };


                    processes.Add(process);
                }


                // =========================================
                // RUN PRIORITY PREEMPTIVE
                // =========================================

                List<Process> results =
                    PriorityPreemptive.Schedule(
                        processes);


                // =========================================
                // DISPLAY RESULTS
                // =========================================

                for (int i = 0;
                    i < results.Count;
                    i++)
                {
                    // CT
                    dgvProcesses.Rows[i]
                        .Cells[4]
                        .Value =
                        results[i].CompletionTime;


                    // TAT
                    dgvProcesses.Rows[i]
                        .Cells[5]
                        .Value =
                        results[i].TurnaroundTime;


                    // WT
                    dgvProcesses.Rows[i]
                        .Cells[6]
                        .Value =
                        results[i].WaitingTime;
                }


                // =========================================
                // CALCULATE AVERAGES
                // =========================================

                double totalWaitingTime = 0;
                double totalTurnaroundTime = 0;


                foreach (Process process
                    in results)
                {
                    totalWaitingTime +=
                        process.WaitingTime;

                    totalTurnaroundTime +=
                        process.TurnaroundTime;
                }


                double averageWaitingTime =
                    totalWaitingTime /
                    results.Count;


                double averageTurnaroundTime =
                    totalTurnaroundTime /
                    results.Count;


                // =========================================
                // DISPLAY AVERAGES
                // =========================================

                lblAverageWaiting.Text =
                    "Average Waiting Time: " +
                    averageWaitingTime.ToString("0.##");


                lblAverageTurnaround.Text =
                    "Average Turnaround Time: " +
                    averageTurnaroundTime.ToString("0.##");


                // =========================================
                // DRAW GANTT CHART
                // =========================================

                DrawGanttChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred:\n\n" +
                    ex.Message,
                    "Calculation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DRAW GANTT CHART
        // =========================================================

        private void DrawGanttChart()
        {
            // Clear old chart
            pnlGanttChart.Controls.Clear();

            if (PriorityPreemptive.GanttChart == null ||
                PriorityPreemptive.GanttChart.Count == 0)
            {
                pnlGanttChart.AutoScrollMinSize =
                    new Size(0, 0);

                pnlGanttChart.Invalidate();
                return;
            }


            // =========================================
            // SETTINGS
            // =========================================

            int x = 10;
            int y = 15;

            int boxWidth = 100;
            int boxHeight = 80;

            int gap = 0;


            // =========================================
            // DRAW GANTT BLOCKS
            // =========================================

            foreach (string item in PriorityPreemptive.GanttChart)
            {
                string processName = "";
                string startTime = "";
                string endTime = "";


                // =====================================
                // PARSE:
                // P1 (0 - 2)
                // =====================================

                int openBracket =
                    item.IndexOf('(');

                int dash =
                    item.IndexOf('-');

                int closeBracket =
                    item.IndexOf(')');


                if (openBracket >= 0 &&
                    dash >= 0 &&
                    closeBracket >= 0)
                {
                    processName =
                        item.Substring(
                            0,
                            openBracket)
                        .Trim();

                    startTime =
                        item.Substring(
                            openBracket + 1,
                            dash - openBracket - 1)
                        .Trim();

                    endTime =
                        item.Substring(
                            dash + 1,
                            closeBracket - dash - 1)
                        .Trim();
                }
                else
                {
                    // For Idle
                    processName = item;
                }


                // =====================================
                // CREATE BOX
                // =====================================

                Panel box =
                    new Panel();

                box.Left = x;
                box.Top = y;

                box.Width = boxWidth;
                box.Height = boxHeight;

                box.BorderStyle =
                    BorderStyle.FixedSingle;

                box.BackColor =
                    Color.MistyRose;


                // =====================================
                // PROCESS NAME
                // =====================================

                Label processLabel =
                    new Label();

                processLabel.Text =
                    processName;

                processLabel.Left = 0;
                processLabel.Top = 0;

                processLabel.Width =
                    boxWidth;

                processLabel.Height = 45;

                processLabel.TextAlign =
                    ContentAlignment.MiddleCenter;

                processLabel.Font =
                    new Font(
                        "Arial",
                        12,
                        FontStyle.Bold);

                processLabel.BackColor =
                    Color.Transparent;


                // =====================================
                // TIME LABEL
                // =====================================

                Label timeLabel =
                    new Label();

                if (startTime != "" &&
                    endTime != "")
                {
                    timeLabel.Text =
                        startTime + " - " + endTime;
                }
                else
                {
                    timeLabel.Text = "";
                }

                timeLabel.Left = 0;
                timeLabel.Top = 45;

                timeLabel.Width =
                    boxWidth;

                timeLabel.Height = 30;

                timeLabel.TextAlign =
                    ContentAlignment.MiddleCenter;

                timeLabel.Font =
                    new Font(
                        "Arial",
                        9,
                        FontStyle.Regular);

                timeLabel.BackColor =
                    Color.Transparent;


                // =====================================
                // ADD LABELS TO BOX
                // =====================================

                box.Controls.Add(processLabel);
                box.Controls.Add(timeLabel);


                // =====================================
                // ADD BOX TO GANTT PANEL
                // =====================================

                pnlGanttChart.Controls.Add(box);


                // Move to next box
                x += boxWidth + gap;
            }


            // =========================================
            // SCROLL AREA
            // =========================================

            pnlGanttChart.AutoScrollMinSize =
                new Size(
                    x + 20,
                    boxHeight + y + 20);

            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // OLD / DESIGNER EVENTS
        // =========================================================

        private void PriorityPreemptiveForm_Load(
            object sender,
            EventArgs e)
        {
        }


        private void txtBurstTime_TextChanged(
            object sender,
            EventArgs e)
        {
        }


        private void lblAverageTurnaround_Click(
            object sender,
            EventArgs e)
        {
        }


        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }


        private void label2_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}