using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;

namespace OS_Project.Forms
{
    public partial class FCFSForm : Form
    {
        public FCFSForm()
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
                "",
                "",
                ""
            );


            // =========================================
            // CLEAR INPUTS
            // =========================================

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


            // =========================================
            // DELETE SELECTED ROW
            // =========================================

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


                    Process process =
                        new Process
                        {
                            Id = id,
                            ArrivalTime = arrivalTime,
                            BurstTime = burstTime
                        };


                    processes.Add(process);
                }


                // =========================================
                // RUN FCFS ALGORITHM
                // =========================================

                List<Process> results =
                    First_come_first_serve.Calculate(
                        processes);


                // =========================================
                // DISPLAY RESULTS
                // =========================================

                // Results are returned ordered by ID
                for (int i = 0;
                    i < results.Count;
                    i++)
                {
                    // CT
                    dgvProcesses.Rows[i]
                        .Cells[3]
                        .Value =
                        results[i].CompletionTime;


                    // TAT
                    dgvProcesses.Rows[i]
                        .Cells[4]
                        .Value =
                        results[i].TurnaroundTime;


                    // WT
                    dgvProcesses.Rows[i]
                        .Cells[5]
                        .Value =
                        results[i].WaitingTime;
                }


                // =========================================
                // AVERAGES
                // =========================================

                double averageWaitingTime =
                    First_come_first_serve
                    .GetAverageWaitingTime(results);


                double averageTurnaroundTime =
                    First_come_first_serve
                    .GetAverageTurnaroundTime(results);


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

        // =========================================================
        // DRAW GANTT CHART
        // =========================================================

        private void DrawGanttChart()
        {
            // Clear old chart
            pnlGanttChart.Controls.Clear();

            if (First_come_first_serve.GanttChart == null ||
                First_come_first_serve.GanttChart.Count == 0)
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

            int boxWidth = 80;
            int boxHeight = 70;

            int gap = 0;

            // =========================================
            // GROUP CONSECUTIVE SAME PROCESSES
            // =========================================

            List<string> processNames =
                new List<string>();

            List<int> startTimes =
                new List<int>();

            List<int> endTimes =
                new List<int>();

            int currentStart = 0;

            string currentProcess =
                First_come_first_serve.GanttChart[0];

            for (int i = 1;
                 i <= First_come_first_serve.GanttChart.Count;
                 i++)
            {
                if (i < First_come_first_serve.GanttChart.Count &&
                    First_come_first_serve.GanttChart[i] == currentProcess)
                {
                    continue;
                }

                // Add current block
                processNames.Add(currentProcess);
                startTimes.Add(currentStart);
                endTimes.Add(i);

                // Start next block
                if (i < First_come_first_serve.GanttChart.Count)
                {
                    currentProcess =
                        First_come_first_serve.GanttChart[i];

                    currentStart = i;
                }
            }

            // =========================================
            // DRAW EACH BLOCK
            // =========================================

            for (int i = 0;
                 i < processNames.Count;
                 i++)
            {
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
                    processNames[i];

                processLabel.Left = 0;
                processLabel.Top = 5;

                processLabel.Width =
                    boxWidth;

                processLabel.Height = 35;

                processLabel.TextAlign =
                    ContentAlignment.MiddleCenter;

                processLabel.Font =
                    new Font(
                        "Arial",
                        11,
                        FontStyle.Bold);

                processLabel.BackColor =
                    Color.Transparent;


                // =====================================
                // TIME
                // =====================================

                Label timeLabel =
                    new Label();

                timeLabel.Text =
                    startTimes[i] +
                    " - " +
                    endTimes[i];

                timeLabel.Left = 0;
                timeLabel.Top = 42;

                timeLabel.Width =
                    boxWidth;

                timeLabel.Height = 25;

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
                // ADD LABELS
                // =====================================

                box.Controls.Add(
                    processLabel);

                box.Controls.Add(
                    timeLabel);


                // =====================================
                // ADD BOX TO PANEL
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
        // DESIGNER EVENTS
        // =========================================================

        private void FCFSForm_Load(
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