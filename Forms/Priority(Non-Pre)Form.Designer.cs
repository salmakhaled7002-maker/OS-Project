
namespace OS_Project.Forms
{
    partial class Priority_Non_Pre_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.lblAverageTurnaround = new System.Windows.Forms.Label();
            this.lblAverageWaiting = new System.Windows.Forms.Label();
            this.colWT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGanttChart = new System.Windows.Forms.Label();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBurstTime = new System.Windows.Forms.TextBox();
            this.txtPRIORITY = new System.Windows.Forms.TextBox();
            this.txtArrivalTime = new System.Windows.Forms.TextBox();
            this.lblPRIORITY = new System.Windows.Forms.Label();
            this.lblBurstTime = new System.Windows.Forms.Label();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.AutoScroll = true;
            this.pnlGanttChart.BackColor = System.Drawing.Color.White;
            this.pnlGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGanttChart.Location = new System.Drawing.Point(12, 552);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(1253, 157);
            this.pnlGanttChart.TabIndex = 29;
            // 
            // lblAverageTurnaround
            // 
            this.lblAverageTurnaround.AutoSize = true;
            this.lblAverageTurnaround.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTurnaround.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAverageTurnaround.Location = new System.Drawing.Point(253, 488);
            this.lblAverageTurnaround.Name = "lblAverageTurnaround";
            this.lblAverageTurnaround.Size = new System.Drawing.Size(293, 26);
            this.lblAverageTurnaround.TabIndex = 27;
            this.lblAverageTurnaround.Text = "Average Turnaround Time:";
            // 
            // lblAverageWaiting
            // 
            this.lblAverageWaiting.AutoSize = true;
            this.lblAverageWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageWaiting.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAverageWaiting.Location = new System.Drawing.Point(712, 488);
            this.lblAverageWaiting.Name = "lblAverageWaiting";
            this.lblAverageWaiting.Size = new System.Drawing.Size(253, 26);
            this.lblAverageWaiting.TabIndex = 26;
            this.lblAverageWaiting.Text = "Average Waiting Time:";
            // 
            // colWT
            // 
            this.colWT.HeaderText = "WT";
            this.colWT.MinimumWidth = 8;
            this.colWT.Name = "colWT";
            this.colWT.ReadOnly = true;
            this.colWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTAT
            // 
            this.colTAT.HeaderText = "TAT";
            this.colTAT.MinimumWidth = 8;
            this.colTAT.Name = "colTAT";
            this.colTAT.ReadOnly = true;
            this.colTAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCT
            // 
            this.colCT.HeaderText = "CT";
            this.colCT.MinimumWidth = 8;
            this.colCT.Name = "colCT";
            this.colCT.ReadOnly = true;
            this.colCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBT
            // 
            this.colBT.HeaderText = "BT";
            this.colBT.MinimumWidth = 8;
            this.colBT.Name = "colBT";
            this.colBT.ReadOnly = true;
            this.colBT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAT
            // 
            this.colAT.HeaderText = "AT";
            this.colAT.MinimumWidth = 8;
            this.colAT.Name = "colAT";
            this.colAT.ReadOnly = true;
            this.colAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPID
            // 
            this.colPID.HeaderText = "P_ID";
            this.colPID.MinimumWidth = 8;
            this.colPID.Name = "colPID";
            this.colPID.ReadOnly = true;
            this.colPID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblGanttChart
            // 
            this.lblGanttChart.AutoSize = true;
            this.lblGanttChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanttChart.ForeColor = System.Drawing.Color.Maroon;
            this.lblGanttChart.Location = new System.Drawing.Point(12, 517);
            this.lblGanttChart.Name = "lblGanttChart";
            this.lblGanttChart.Size = new System.Drawing.Size(172, 32);
            this.lblGanttChart.TabIndex = 28;
            this.lblGanttChart.Text = "Gantt Chart";
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.AllowUserToAddRows = false;
            this.dgvProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProcesses.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPID,
            this.colAT,
            this.colBT,
            this.colCT,
            this.colTAT,
            this.colWT});
            this.dgvProcesses.Location = new System.Drawing.Point(30, 217);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.ReadOnly = true;
            this.dgvProcesses.RowHeadersVisible = false;
            this.dgvProcesses.RowHeadersWidth = 62;
            this.dgvProcesses.RowTemplate.Height = 28;
            this.dgvProcesses.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProcesses.Size = new System.Drawing.Size(1207, 252);
            this.dgvProcesses.TabIndex = 25;
            // 
            // btnCalculate
            // 
            this.btnCalculate.AutoSize = true;
            this.btnCalculate.BackColor = System.Drawing.Color.MistyRose;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(833, 166);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(113, 35);
            this.btnCalculate.TabIndex = 24;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(544, 166);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 35);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.BackColor = System.Drawing.Color.MistyRose;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(258, 166);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(89, 35);
            this.btnSubmit.TabIndex = 22;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // txtBurstTime
            // 
            this.txtBurstTime.Location = new System.Drawing.Point(657, 116);
            this.txtBurstTime.Name = "txtBurstTime";
            this.txtBurstTime.Size = new System.Drawing.Size(100, 26);
            this.txtBurstTime.TabIndex = 21;
            // 
            // txtPRIORITY
            // 
            this.txtPRIORITY.Location = new System.Drawing.Point(1076, 114);
            this.txtPRIORITY.Name = "txtPRIORITY";
            this.txtPRIORITY.Size = new System.Drawing.Size(100, 26);
            this.txtPRIORITY.TabIndex = 20;
            // 
            // txtArrivalTime
            // 
            this.txtArrivalTime.Location = new System.Drawing.Point(229, 114);
            this.txtArrivalTime.Name = "txtArrivalTime";
            this.txtArrivalTime.Size = new System.Drawing.Size(100, 26);
            this.txtArrivalTime.TabIndex = 19;
            // 
            // lblPRIORITY
            // 
            this.lblPRIORITY.AutoSize = true;
            this.lblPRIORITY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRIORITY.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPRIORITY.Location = new System.Drawing.Point(882, 116);
            this.lblPRIORITY.Name = "lblPRIORITY";
            this.lblPRIORITY.Size = new System.Drawing.Size(159, 26);
            this.lblPRIORITY.TabIndex = 18;
            this.lblPRIORITY.Text = "Enter Priority:";
            this.lblPRIORITY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBurstTime
            // 
            this.lblBurstTime.AutoSize = true;
            this.lblBurstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBurstTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBurstTime.Location = new System.Drawing.Point(440, 116);
            this.lblBurstTime.Name = "lblBurstTime";
            this.lblBurstTime.Size = new System.Drawing.Size(198, 26);
            this.lblBurstTime.TabIndex = 17;
            this.lblBurstTime.Text = "Enter Burst Time:";
            this.lblBurstTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.AutoSize = true;
            this.lblArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lblArrivalTime.Location = new System.Drawing.Point(12, 114);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(211, 26);
            this.lblArrivalTime.TabIndex = 16;
            this.lblArrivalTime.Text = "Enter Arrival Time:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(437, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(419, 46);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "PRIORITY (Non_Pre)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Priority_Non_Pre_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1277, 744);
            this.Controls.Add(this.pnlGanttChart);
            this.Controls.Add(this.lblAverageTurnaround);
            this.Controls.Add(this.lblAverageWaiting);
            this.Controls.Add(this.lblGanttChart);
            this.Controls.Add(this.dgvProcesses);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBurstTime);
            this.Controls.Add(this.txtPRIORITY);
            this.Controls.Add(this.txtArrivalTime);
            this.Controls.Add(this.lblPRIORITY);
            this.Controls.Add(this.lblBurstTime);
            this.Controls.Add(this.lblArrivalTime);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Priority_Non_Pre_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Priority(Non_Pre)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGanttChart;
        private System.Windows.Forms.Label lblAverageTurnaround;
        private System.Windows.Forms.Label lblAverageWaiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPID;
        private System.Windows.Forms.Label lblGanttChart;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtBurstTime;
        private System.Windows.Forms.TextBox txtPRIORITY;
        private System.Windows.Forms.TextBox txtArrivalTime;
        private System.Windows.Forms.Label lblPRIORITY;
        private System.Windows.Forms.Label lblBurstTime;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.Label lblTitle;
    }
}