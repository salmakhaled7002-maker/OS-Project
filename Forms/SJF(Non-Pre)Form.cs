using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;
using OS_Project.Services;

namespace OS_Project.Forms
{
    public partial class SJF_Non_Pre_Form : Form
    {
        public SJF_Non_Pre_Form()
        {
            InitializeComponent();
            btnSubmit.Click -= btnSubmit_Click;
            btnSubmit.Click += btnSubmit_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            btnCalculate.Click -= btnCalculate_Click;
            btnCalculate.Click += btnCalculate_Click;

            dgvProcesses.AllowUserToAddRows = false;
            dgvProcesses.ReadOnly = true;
            dgvProcesses.MultiSelect = false;
            dgvProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProcesses.ScrollBars = ScrollBars.Vertical;
            pnlGanttChart.AutoScroll = true;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int arrivalTime;
            int burstTime;
            if (!int.TryParse(txtArrivalTime.Text.Trim(),out arrivalTime))
            {
                MessageBox.Show(
                    "Please enter a valid Arrival Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtArrivalTime.Focus();
                return;
            }
            if (!int.TryParse(txtBurstTime.Text.Trim(),out burstTime))
            {
                MessageBox.Show(
                    "Please enter a valid Burst Time.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBurstTime.Focus();
                return;
            }
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
            int processId = dgvProcesses.Rows.Count + 1;
            dgvProcesses.Rows.Add( processId, arrivalTime, burstTime,"","","");

            txtArrivalTime.Clear();
            txtBurstTime.Clear();
            txtArrivalTime.Focus();
        }
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
            foreach (DataGridViewRow row
                in dgvProcesses.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvProcesses.Rows.Remove(row);
                }
            }
            for (int i = 0;
                i < dgvProcesses.Rows.Count;
                i++)
            {
                dgvProcesses.Rows[i]
                    .Cells[0]
                    .Value = i + 1;
            }
            lblAverageWaiting.Text =
                "Average Waiting Time:";

            lblAverageTurnaround.Text =
                "Average Turnaround Time:";

            for (int i = 0;i < dgvProcesses.Rows.Count;i++)
            {
                dgvProcesses.Rows[i].Cells[3].Value = "";
                dgvProcesses.Rows[i].Cells[4].Value = "";
                dgvProcesses.Rows[i].Cells[5].Value = "";
            }
            pnlGanttChart.Controls.Clear();

            pnlGanttChart.AutoScrollMinSize =
                new Size(0, 0);

            pnlGanttChart.Invalidate();
            SJF.GanttChart.Clear();
        }
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

                List<Process> processes = new List<Process>();
                foreach (DataGridViewRow row
                    in dgvProcesses.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int id = Convert.ToInt32(row.Cells[0].Value);
                    int arrivalTime = Convert.ToInt32(row.Cells[1].Value);

                    int burstTime = Convert.ToInt32(row.Cells[2].Value);
                    Process process = new Process
                        {
                            Id = id,
                            ArrivalTime = arrivalTime,
                            BurstTime = burstTime,
                            RemainingTime = burstTime
                        };


                    processes.Add(process);
                }
                List<Process> results = SJF.Schedule(processes);
                if (results == null || results.Count == 0)
                {
                    MessageBox.Show(
                        "No results were returned.",
                        "Calculation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                foreach (Process process
                    in results)
                {
                    foreach (DataGridViewRow row
                        in dgvProcesses.Rows)
                    {
                        if (row.IsNewRow)
                            continue;


                        int id = Convert.ToInt32(row.Cells[0].Value);
                        if (id == process.Id)
                        {
                            row.Cells[3].Value = process.CompletionTime;
                            row.Cells[4].Value = process.TurnaroundTime;
                            row.Cells[5].Value = process.WaitingTime;
                            break;
                        }
                    }
                }
                double averageWaitingTime =
                    StatisticsCalculator
                    .CalculateAverageWaitingTime(
                        results);


                double averageTurnaroundTime =
                    StatisticsCalculator
                    .CalculateAverageTurnaroundTime(
                        results);


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

                DrawGanttChart(
                    SJF.GanttChart);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while calculating:\n\n" +
                    ex.Message,
                    "Calculation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // DRAW GANTT CHART
        // =========================================================

        private void DrawGanttChart(
            List<string> ganttChart)
        {
            // Clear old chart
            pnlGanttChart.Controls.Clear();


            if (ganttChart == null ||
                ganttChart.Count == 0)
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

            // Smaller boxes
            int boxWidth = 80;
            int boxHeight = 60;

            int gap = 0;


            // =========================================
            // DRAW EACH GANTT BLOCK
            // =========================================

            foreach (string processName
                in ganttChart)
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
                // PROCESS LABEL
                // =====================================

                Label processLabel =
                    new Label();


                processLabel.Text =
                    processName;

                processLabel.Left = 0;
                processLabel.Top = 0;

                processLabel.Width =
                    boxWidth;

                processLabel.Height =
                    boxHeight;

                processLabel.TextAlign =
                    ContentAlignment.MiddleCenter;

                processLabel.Font =
                    new Font(
                        "Arial",
                        9,
                        FontStyle.Bold);

                processLabel.BackColor =
                    Color.Transparent;


                // =====================================
                // ADD LABEL TO BOX
                // =====================================

                box.Controls.Add(
                    processLabel);


                // =====================================
                // ADD BOX TO GANTT PANEL
                // =====================================

                pnlGanttChart.Controls.Add(
                    box);


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
        // DESIGNER / OLD EVENTS
        // =========================================================

        private void SJF_Non_Pre_Form_Load(object sender,EventArgs e)
        {
        }
        private void txtBurstTime_TextChanged(object sender,EventArgs e)
        {
        }
        private void lblAverageTurnaround_Click(object sender,EventArgs e)
        {
        }
        private void label1_Click(object sender,EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}