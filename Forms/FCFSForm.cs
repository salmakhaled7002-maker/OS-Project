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

            int processId =
                dgvProcesses.Rows.Count + 1;

             
            dgvProcesses.Rows.Add(
                processId,
                arrivalTime,
                burstTime,
                "",
                "",
                ""
            );

             
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


            try
            { 
                List<Process> processes =
                    new List<Process>();

                 
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

                 
                List<Process> results =
                    First_come_first_serve.Calculate(
                        processes);

 
                for (int i = 0;
                    i < results.Count;
                    i++)
                {
                    
                    dgvProcesses.Rows[i]
                        .Cells[3]
                        .Value =
                        results[i].CompletionTime;


                    dgvProcesses.Rows[i]
                        .Cells[4]
                        .Value =
                        results[i].TurnaroundTime;


                     dgvProcesses.Rows[i]
                        .Cells[5]
                        .Value =
                        results[i].WaitingTime;
                }
                 
                double averageWaitingTime =
                    First_come_first_serve
                    .GetAverageWaitingTime(results);


                double averageTurnaroundTime =
                    First_come_first_serve
                    .GetAverageTurnaroundTime(results);


                
                lblAverageWaiting.Text =
                    "Average Waiting Time: " +
                    averageWaitingTime.ToString("0.##");


                lblAverageTurnaround.Text =
                    "Average Turnaround Time: " +
                    averageTurnaroundTime.ToString("0.##");

                 
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
             
            int x = 10;
            int y = 15;

            int boxWidth = 80;
            int boxHeight = 70;

            int gap = 0;
             
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

                 processNames.Add(currentProcess);
                startTimes.Add(currentStart);
                endTimes.Add(i);

                 if (i < First_come_first_serve.GanttChart.Count)
                {
                    currentProcess =
                        First_come_first_serve.GanttChart[i];

                    currentStart = i;
                }
            }
             
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

                 
                box.Controls.Add(
                    processLabel);

                box.Controls.Add(
                    timeLabel);
 
                pnlGanttChart.Controls.Add(box);


                 x += boxWidth + gap;
            }

 
            pnlGanttChart.AutoScrollMinSize =
                new Size(
                    x + 20,
                    boxHeight + y + 20);

            pnlGanttChart.Invalidate();
        }
         
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