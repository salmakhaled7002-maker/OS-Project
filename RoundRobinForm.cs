using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;

namespace OS_Project
{
    public partial class RoundRobinForm : Form
    {
        public RoundRobinForm()
        {
            InitializeComponent();

            // =========================
            // CONNECT BUTTON EVENTS
            // =========================

            btnSubmit.Click -= btnSubmit_Click;
            btnSubmit.Click += btnSubmit_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            btnCalculate.Click -= btnCalculate_Click;
            btnCalculate.Click += btnCalculate_Click;

            // =========================
            // DATA GRID SETTINGS
            // =========================

            dgvProcesses.AllowUserToAddRows = false;
            dgvProcesses.ReadOnly = true;
            dgvProcesses.MultiSelect = false;

            dgvProcesses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProcesses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProcesses.ScrollBars = ScrollBars.Vertical;

            // =========================
            // GANTT PANEL SETTINGS
            // =========================

            pnlGanttChart.AutoScroll = true;
        }


        // =========================================================
        // SUBMIT BUTTON
        // =========================================================

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int arrivalTime;
            int burstTime;

            // Check Arrival Time
            if (!int.TryParse(txtArrivalTime.Text.Trim(), out arrivalTime))
            {
                MessageBox.Show(
                    "Please enter a valid Arrival Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtArrivalTime.Focus();
                return;
            }

            // Check Burst Time
            if (!int.TryParse(txtBurstTime.Text.Trim(), out burstTime))
            {
                MessageBox.Show(
                    "Please enter a valid Burst Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBurstTime.Focus();
                return;
            }

            // Arrival Time cannot be negative
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

            // Burst Time must be greater than 0
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

            // Generate Process ID
            int processId = dgvProcesses.Rows.Count + 1;

            // Add process to table
            dgvProcesses.Rows.Add(
                processId,
                arrivalTime,
                burstTime,
                "",
                "",
                ""
            );

            // Clear inputs
            txtArrivalTime.Clear();
            txtBurstTime.Clear();

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

            // Delete selected process
            foreach (DataGridViewRow row in dgvProcesses.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvProcesses.Rows.Remove(row);
                }
            }

            // Re-number Process IDs
            for (int i = 0; i < dgvProcesses.Rows.Count; i++)
            {
                dgvProcesses.Rows[i].Cells[0].Value = i + 1;
            }

            // Reset averages
            lblAverageWaiting.Text =
                "Average Waiting Time:";

            lblAverageTurnaround.Text =
                "Average Turnaround Time:";

            // Clear Gantt Chart
            pnlGanttChart.Controls.Clear();
            pnlGanttChart.AutoScrollMinSize = new Size(0, 0);
            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // CALCULATE BUTTON
        // =========================================================

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int quantum;

            // Check Time Quantum
            if (!int.TryParse(txtTimeQuantum.Text.Trim(), out quantum))
            {
                MessageBox.Show(
                    "Please enter a valid Time Quantum.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTimeQuantum.Focus();
                return;
            }

            // Quantum must be greater than 0
            if (quantum <= 0)
            {
                MessageBox.Show(
                    "Time Quantum must be greater than 0.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTimeQuantum.Focus();
                return;
            }

            // Check processes
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
                // Create process list
                List<Process> processes =
                    new List<Process>();

                // Read processes from DataGridView
                foreach (DataGridViewRow row in dgvProcesses.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int id =
                        Convert.ToInt32(row.Cells[0].Value);

                    int arrivalTime =
                        Convert.ToInt32(row.Cells[1].Value);

                    int burstTime =
                        Convert.ToInt32(row.Cells[2].Value);

                    Process process = new Process
                    {
                        Id = id,
                        ArrivalTime = arrivalTime,
                        BurstTime = burstTime
                    };

                    processes.Add(process);
                }

                // =========================================
                // RUN ROUND ROBIN ALGORITHM
                // =========================================

                RoundRobin.Calculate(
                    processes,
                    quantum);


                // =========================================
                // DISPLAY RESULTS IN DATA GRID
                // =========================================

                for (int i = 0; i < processes.Count; i++)
                {
                    // CT
                    dgvProcesses.Rows[i].Cells[3].Value =
                        processes[i].CompletionTime;

                    // TAT
                    dgvProcesses.Rows[i].Cells[4].Value =
                        processes[i].TurnaroundTime;

                    // WT
                    dgvProcesses.Rows[i].Cells[5].Value =
                        processes[i].WaitingTime;
                }


                // =========================================
                // CALCULATE AVERAGES
                // =========================================

                double totalWaitingTime = 0;
                double totalTurnaroundTime = 0;

                foreach (Process process in processes)
                {
                    totalWaitingTime +=
                        process.WaitingTime;

                    totalTurnaroundTime +=
                        process.TurnaroundTime;
                }

                double averageWaitingTime =
                    totalWaitingTime / processes.Count;

                double averageTurnaroundTime =
                    totalTurnaroundTime / processes.Count;


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
                    "An error occurred:\n\n" + ex.Message,
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

            if (RoundRobin.GanttChart == null ||
                RoundRobin.GanttChart.Count == 0)
            {
                pnlGanttChart.AutoScrollMinSize =
                    new Size(0, 0);

                pnlGanttChart.Invalidate();
                return;
            }


            // =========================================
            // GANTT BOX SETTINGS
            // =========================================

            int x = 10;
            int y = 15;

            int boxWidth = 100;
            int boxHeight = 70;

            int gap = 0;


            // =========================================
            // CREATE EACH GANTT BOX
            // =========================================

            foreach (string item in RoundRobin.GanttChart)
            {
                /*
                    Example:

                    P1 (0 - 2)
                    P2 (2 - 4)
                    P3 (4 - 6)
                */

                string processName = "";
                string startTime = "";
                string endTime = "";


                // Find brackets
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
                    // Process name
                    processName =
                        item.Substring(
                            0,
                            openBracket)
                        .Trim();

                    // Start time
                    startTime =
                        item.Substring(
                            openBracket + 1,
                            dash - openBracket - 1)
                        .Trim();

                    // End time
                    endTime =
                        item.Substring(
                            dash + 1,
                            closeBracket - dash - 1)
                        .Trim();
                }
                else
                {
                    // Fallback
                    processName = item;
                    startTime = "";
                    endTime = "";
                }


                // =====================================
                // CREATE BOX
                // =====================================

                Panel box = new Panel();

                box.Left = x;
                box.Top = y;

                box.Width = boxWidth;
                box.Height = boxHeight;

                box.BorderStyle =
                    BorderStyle.FixedSingle;

                box.BackColor =
                    Color.MistyRose;


                // =====================================
                // PROCESS NAME LABEL
                // =====================================

                Label processLabel =
                    new Label();

                processLabel.Text =
                    processName;

                processLabel.Left = 0;
                processLabel.Top = 0;

                processLabel.Width =
                    boxWidth;

                processLabel.Height = 40;

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

                timeLabel.Text =
                    startTime + " - " + endTime;

                timeLabel.Left = 0;
                timeLabel.Top = 40;

                timeLabel.Width =
                    boxWidth;

                timeLabel.Height = 28;

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
            // MAKE PANEL LARGE ENOUGH
            // =========================================

            pnlGanttChart.AutoScrollMinSize =
                new Size(
                    x + 20,
                    boxHeight + y + 20);

            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // OLD EVENTS
        // =========================================================
        // Keep these because the Designer may still
        // have these events connected.
        // =========================================================

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void RoundRobinForm_Load(object sender, EventArgs e)
        {
        }

        private void lblAverageTurnaround_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}