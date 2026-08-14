using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OS_Project.Forms
{
    public partial class Priority_Non_Pre_Form : Form
    {
        public Priority_Non_Pre_Form()
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
            // ADD PROCESS TO GRID
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


            // =========================================
            // ALGORITHM NOT READY YET
            // =========================================

            MessageBox.Show(
                "Priority Non-Preemptive algorithm is not connected yet.",
                "Calculate",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // =========================================================
        // DESIGNER / OLD EVENTS
        // =========================================================

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
