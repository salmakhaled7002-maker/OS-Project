using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Algorithms;
using OS_Project.Services;
namespace OS_Project.Forms
{
    public partial class Priority_Non_Pre_Form : Form
    {
        public Priority_Non_Pre_Form()
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

            dgvProcesses.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProcesses.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProcesses.ScrollBars =
                ScrollBars.Vertical;


            
            pnlGanttChart.AutoScroll = true;
        }

 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int arrivalTime;
            int burstTime;
            int priority;

 
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

             
            int processId =
                dgvProcesses.Rows.Count + 1;
             
            dgvProcesses.Rows.Add(
                processId,
                arrivalTime,
                burstTime,
                priority,
                "",
                "",
                ""
            );

             
            txtArrivalTime.Clear();
            txtBurstTime.Clear();
            txtPRIORITY.Clear();

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
             
            pnlGanttChart.Controls.Clear();

            pnlGanttChart.AutoScrollMinSize =
                new Size(0, 0);

            pnlGanttChart.Invalidate();
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

            List<Process> processes = new List<Process>();
             
            foreach (DataGridViewRow row in dgvProcesses.Rows)
            {
                if (row.IsNewRow)
                    continue;

                Process process = new Process();

                process.Id = Convert.ToInt32(row.Cells[0].Value);
                process.ArrivalTime = Convert.ToInt32(row.Cells[1].Value);
                process.BurstTime = Convert.ToInt32(row.Cells[2].Value);
                process.Priority = Convert.ToInt32(row.Cells[3].Value);

                processes.Add(process);
            }
             
            List<Process> result =
                PriorityScheduling.Schedule(processes);
             
            foreach (Process process in result)
            {
                foreach (DataGridViewRow row in dgvProcesses.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int id = Convert.ToInt32(row.Cells[0].Value);

                    if (id == process.Id)
                    {
                        row.Cells[4].Value = process.CompletionTime;
                        row.Cells[5].Value = process.TurnaroundTime;
                        row.Cells[6].Value = process.WaitingTime;

                        break;
                    }
                }
            }
             
            double averageWaiting =
                StatisticsCalculator.CalculateAverageWaitingTime(result);

            double averageTurnaround =
                StatisticsCalculator.CalculateAverageTurnaroundTime(result);

            lblAverageWaiting.Text =
                "Average Waiting Time: " +
                averageWaiting.ToString("0.##");

            lblAverageTurnaround.Text =
                "Average Turnaround Time: " +
                averageTurnaround.ToString("0.##");
 
            DrawGanttChart(PriorityScheduling.GanttChart);
        }
        private void DrawGanttChart(List<string> ganttChart)
{
    pnlGanttChart.Controls.Clear();

    if (ganttChart == null || ganttChart.Count == 0)
    {
        pnlGanttChart.AutoScrollMinSize =
            new Size(0, 0);

        pnlGanttChart.Invalidate();
        return;
    }

    int x = 10;
    int y = 15;

    int boxWidth = 100;
    int boxHeight = 70;

    foreach (string processName in ganttChart)
    {
        Panel box = new Panel();

        box.Left = x;
        box.Top = y;

        box.Width = boxWidth;
        box.Height = boxHeight;

        box.BorderStyle =
            BorderStyle.FixedSingle;

        box.BackColor =
            Color.MistyRose;

        Label processLabel = new Label();

        processLabel.Text = processName;

        processLabel.Left = 0;
        processLabel.Top = 0;

        processLabel.Width = boxWidth;
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

        box.Controls.Add(processLabel);

        pnlGanttChart.Controls.Add(box);

        x += boxWidth;
    }

    pnlGanttChart.AutoScrollMinSize =
        new Size(
            x + 20,
            boxHeight + y + 20);

    pnlGanttChart.Invalidate();
}
         
        private void Priority_Non_Pre_Form_Load(
            object sender,
            EventArgs e)
        {
        }


        private void txtBurstTime_TextChanged(
            object sender,
            EventArgs e)
        {
        }


        private void txtPRIORITY_TextChanged(
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
