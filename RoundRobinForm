using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OS_Project.Models;
using OS_Project.Services;
using OS_Project.Algorithms;
using Microsoft.VisualBasic;

namespace OS_Project
{
    public partial class AlgorithmForm : Form
    {
        private string algorithmName;

        private List<Process> processes = new List<Process>();

        public AlgorithmForm(string algorithmName)
        {
            InitializeComponent();

            this.algorithmName = algorithmName;

            lblAlgorithmTitle.Text = algorithmName;
            this.Text = algorithmName;
        }

        // =========================
        // SUBMIT
        // =========================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int arrivalTime;
            int burstTime;
            int priority;

            bool valid = InputValidator.IsValidProcessData(
                txtArrivalTime.Text,
                txtBurstTime.Text,
                "0",
                out arrivalTime,
                out burstTime,
                out priority
            );

            if (!valid)
            {
                MessageBox.Show(
                    "Please enter valid values.\nArrival Time must be >= 0.\nBurst Time must be > 0.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            Process process = new Process();

            process.Id = processes.Count + 1;
            process.ArrivalTime = arrivalTime;
            process.BurstTime = burstTime;
            process.Priority = 0;

            processes.Add(process);

            dgvProcesses.Rows.Add(
                "P" + process.Id,
                process.ArrivalTime,
                process.BurstTime,
                "",
                "",
                ""
            );

            txtArrivalTime.Clear();
            txtBurstTime.Clear();

            txtArrivalTime.Focus();
        }

        // =========================
        // DELETE
        // =========================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a process to delete.",
                    "Delete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int selectedIndex =
                dgvProcesses.SelectedRows[0].Index;

            dgvProcesses.Rows.RemoveAt(selectedIndex);

            processes.RemoveAt(selectedIndex);

            // Re-number processes
            for (int i = 0; i < processes.Count; i++)
            {
                processes[i].Id = i + 1;
                dgvProcesses.Rows[i].Cells[0].Value = "P" + (i + 1);
            }
        }

        // =========================
        // CALCULATE
        // =========================
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (processes.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one process first.",
                    "Calculate",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // We only implement Round Robin here
            if (algorithmName.ToLower().Contains("round"))
            {
                string quantumText = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter Time Quantum:",
                    "Round Robin",
                     "2"
                );

                int quantum;

                if (!int.TryParse(quantumText, out quantum) || quantum <= 0)
                {
                    MessageBox.Show(
                        "Time Quantum must be greater than 0.",
                        "Invalid Quantum",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                try
                {
                    RoundRobin.Calculate(processes, quantum);

                    // Update table
                    for (int i = 0; i < processes.Count; i++)
                    {
                        dgvProcesses.Rows[i].Cells[0].Value =
                            "P" + processes[i].Id;

                        dgvProcesses.Rows[i].Cells[1].Value =
                            processes[i].ArrivalTime;

                        dgvProcesses.Rows[i].Cells[2].Value =
                            processes[i].BurstTime;

                        dgvProcesses.Rows[i].Cells[3].Value =
                            processes[i].CompletionTime;

                        dgvProcesses.Rows[i].Cells[4].Value =
                            processes[i].TurnaroundTime;

                        dgvProcesses.Rows[i].Cells[5].Value =
                            processes[i].WaitingTime;
                    }

                    double averageWaiting =
                        StatisticsCalculator.CalculateAverageWaitingTime(processes);

                    double averageTurnaround =
                        StatisticsCalculator.CalculateAverageTurnaroundTime(processes);

                    lblAverageWaiting.Text =
                        "Average Waiting Time: " +
                        averageWaiting.ToString("0.00");

                    lblAverageTurnaround.Text =
                        "Average Turnaround Time: " +
                        averageTurnaround.ToString("0.00");
                    // Draw Gantt Chart
                    pnlGanttChart.Controls.Clear();

                    int x = 10;

                    foreach (string item in RoundRobin.GanttChart)
                    {
                        Label block = new Label();

                        block.Text = item;
                        block.BorderStyle = BorderStyle.FixedSingle;
                        block.TextAlign = ContentAlignment.MiddleCenter;

                        block.Location = new Point(x, 20);
                        block.Size = new Size(100, 40);

                        pnlGanttChart.Controls.Add(block);

                        x += 100;
                    }

                    MessageBox.Show(
                        "Round Robin calculation completed!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "This algorithm is not implemented yet.",
                    "Algorithm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void lblAlgorithmTitle_Click(object sender, EventArgs e)
        {

        }
    }
}