using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OS_Project.Models;

namespace OS_Project.Forms
{
    public partial class SJF_Non_Pre_Form : Form
    {
        public SJF_Non_Pre_Form()
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
            // ADD PROCESS
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
            // RESET RESULTS
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


            /*
             * ==============================================
             * ALGORITHM WILL BE CONNECTED LATER
             * ==============================================
             *
             * هنا الفريق لسه هيعمل SJF Non-Preemptive Algorithm.
             *
             * لما يخلصوا Algorithm هنقرأ الـ Processes
             * ونبعتها للـ Schedule() ونحط النتائج هنا.
             */


            MessageBox.Show(
                "SJF Non-Preemptive Algorithm is not connected yet.",
                "Waiting for Algorithm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // =========================================================
        // DRAW GANTT CHART
        // =========================================================

        private void DrawGanttChart(
            List<string> ganttChart)
        {
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

            int boxWidth = 100;
            int boxHeight = 70;

            int gap = 0;


            // =========================================
            // DRAW GANTT
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


                box.Controls.Add(
                    processLabel);


                pnlGanttChart.Controls.Add(
                    box);


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

        private void SJF_Non_Pre_Form_Load(
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