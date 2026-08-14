using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;
using OS_Project.Services;

namespace OS_Project.Forms
{
    public partial class SJFPreemptiveForm : Form
    {
        public SJFPreemptiveForm()
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
            // GANTT PANEL
            // =========================================

            pnlGanttChart.AutoScroll = true;
        }


        // =========================================================
        // SUBMIT BUTTON
        // =========================================================

        private void btnSubmit_Click(
            object sender,
            EventArgs e)
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
            // PROCESS ID
            // =========================================

            int processId =
                dgvProcesses.Rows.Count + 1;


            // =========================================
            // ADD PROCESS
            // =========================================

            dgvProcesses.Rows.Add(
                processId,
                arrivalTime,
                burstTime,
                "",
                "",
                "");


            // =========================================
            // CLEAR INPUT
            // =========================================

            txtArrivalTime.Clear();

            txtBurstTime.Clear();

            txtArrivalTime.Focus();
        }


        // =========================================================
        // DELETE BUTTON
        // =========================================================

        private void btnDelete_Click(
            object sender,
            EventArgs e)
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
            // RENUMBER PROCESS IDs
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
            // RESET STATISTICS
            // =========================================

            lblAverageWaiting.Text =
                "Average Waiting Time:";

            lblAverageTurnaround.Text =
                "Average Turnaround Time:";


            // =========================================
            // CLEAR GANTT
            // =========================================

            pnlGanttChart.Controls.Clear();

            pnlGanttChart.AutoScrollMinSize =
                new Size(0, 0);

            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // CALCULATE BUTTON
        // =========================================================

        private void btnCalculate_Click(
            object sender,
            EventArgs e)
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

                            ArrivalTime =
                                arrivalTime,

                            BurstTime =
                                burstTime,

                            Priority = 0
                        };


                    processes.Add(process);
                }


                // =========================================
                // RUN SJF PREEMPTIVE
                // =========================================

                List<Process> result =
                    SJFPreemptive.Schedule(
                        processes);


                // =========================================
                // DISPLAY CT / TAT / WT
                // =========================================

                for (int i = 0;
                     i < result.Count;
                     i++)
                {
                    dgvProcesses.Rows[i]
                        .Cells[3]
                        .Value =
                        result[i].CompletionTime;


                    dgvProcesses.Rows[i]
                        .Cells[4]
                        .Value =
                        result[i].TurnaroundTime;


                    dgvProcesses.Rows[i]
                        .Cells[5]
                        .Value =
                        result[i].WaitingTime;
                }


                // =========================================
                // AVERAGES
                // =========================================

                double averageWaitingTime =
                    StatisticsCalculator
                    .CalculateAverageWaitingTime(
                        result);


                double averageTurnaroundTime =
                    StatisticsCalculator
                    .CalculateAverageTurnaroundTime(
                        result);


                // =========================================
                // DISPLAY AVERAGES
                // =========================================

                lblAverageWaiting.Text =
                    "Average Waiting Time: " +
                    averageWaitingTime
                    .ToString("0.##");


                lblAverageTurnaround.Text =
                    "Average Turnaround Time: " +
                    averageTurnaroundTime
                    .ToString("0.##");


                // =========================================
                // DRAW GANTT
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
        // GANTT CHART
        // =========================================================

        private void DrawGanttChart()
        {
            // Clear old chart
            pnlGanttChart.Controls.Clear();

            if (SJFPreemptive.GanttChart == null ||
                SJFPreemptive.GanttChart.Count == 0)
            {
                pnlGanttChart.AutoScrollMinSize = new Size(0, 0);
                pnlGanttChart.Invalidate();
                return;
            }

            // =========================================
            // GROUP CONSECUTIVE PROCESSES
            // =========================================

            List<string> processNames = new List<string>();
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();

            int currentStart = 0;
            string currentProcess = SJFPreemptive.GanttChart[0];

            for (int i = 1; i <= SJFPreemptive.GanttChart.Count; i++)
            {
                if (i == SJFPreemptive.GanttChart.Count ||
                    SJFPreemptive.GanttChart[i] != currentProcess)
                {
                    processNames.Add(currentProcess);
                    startTimes.Add(currentStart);
                    endTimes.Add(i);

                    if (i < SJFPreemptive.GanttChart.Count)
                    {
                        currentProcess = SJFPreemptive.GanttChart[i];
                        currentStart = i;
                    }
                }
            }

            // =========================================
            // GANTT CHART SETTINGS
            // =========================================

            int x = 10;
            int y = 15;

            int boxHeight = 80;

            // Width depends on execution duration
            int unitWidth = 45;

            // =========================================
            // CREATE GANTT BOXES
            // =========================================

            for (int i = 0; i < processNames.Count; i++)
            {
                string processName = processNames[i];

                int startTime = startTimes[i];
                int endTime = endTimes[i];

                int duration = endTime - startTime;

                int boxWidth = duration * unitWidth;

                // =====================================
                // CREATE BOX
                // =====================================

                Panel box = new Panel();

                box.Left = x;
                box.Top = y;

                box.Width = boxWidth;
                box.Height = boxHeight;

                box.BorderStyle = BorderStyle.FixedSingle;

                if (processName == "Idle")
                {
                    box.BackColor = Color.LightGray;
                }
                else
                {
                    box.BackColor = Color.MistyRose;
                }

                // =====================================
                // PROCESS LABEL
                // =====================================

                Label processLabel = new Label();

                processLabel.Text = processName;

                processLabel.Left = 0;
                processLabel.Top = 5;

                processLabel.Width = boxWidth;
                processLabel.Height = 35;

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

                Label timeLabel = new Label();

                timeLabel.Text =
                    startTime + " - " + endTime;

                timeLabel.Left = 0;
                timeLabel.Top = 40;

                timeLabel.Width = boxWidth;
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
                // ADD LABELS
                // =====================================

                box.Controls.Add(processLabel);
                box.Controls.Add(timeLabel);

                // =====================================
                // ADD BOX TO PANEL
                // =====================================

                pnlGanttChart.Controls.Add(box);

                // Next box
                x += boxWidth;
            }

            // =========================================
            // PANEL SIZE
            // =========================================

            pnlGanttChart.AutoScrollMinSize = new Size(0, 0);

            pnlGanttChart.Invalidate();
        }


        // =========================================================
        // OLD DESIGNER EVENTS
        // =========================================================

        private void txtBurstTime_TextChanged(
            object sender,
            EventArgs e)
        {
        }


        private void SJFPreemptiveForm_Load(
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