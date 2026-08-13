namespace OS_Project
{
    partial class AlgorithmForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAlgorithmTitle = new System.Windows.Forms.Label();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.lblBurstTime = new System.Windows.Forms.Label();
            this.txtArrivalTime = new System.Windows.Forms.TextBox();
            this.txtBurstTime = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.lblGanttTitle = new System.Windows.Forms.Label();
            this.lblAverageWaiting = new System.Windows.Forms.Label();
            this.lblAverageTurnaround = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();

            // 
            // lblAlgorithmTitle
            // 
            this.lblAlgorithmTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgorithmTitle.Location = new System.Drawing.Point(164, 21);
            this.lblAlgorithmTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlgorithmTitle.Name = "lblAlgorithmTitle";
            this.lblAlgorithmTitle.Size = new System.Drawing.Size(394, 30);
            this.lblAlgorithmTitle.TabIndex = 0;
            this.lblAlgorithmTitle.Text = "FIRST COME FIRST SERVE";
            this.lblAlgorithmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlgorithmTitle.Click += new System.EventHandler(this.lblAlgorithmTitle_Click);

            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.AutoSize = true;
            this.lblArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblArrivalTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblArrivalTime.Location = new System.Drawing.Point(26, 87);
            this.lblArrivalTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(168, 20);
            this.lblArrivalTime.TabIndex = 1;
            this.lblArrivalTime.Text = "Enter Arrival Time ";

            // 
            // lblBurstTime
            // 
            this.lblBurstTime.AutoSize = true;
            this.lblBurstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblBurstTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblBurstTime.Location = new System.Drawing.Point(382, 87);
            this.lblBurstTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBurstTime.Name = "lblBurstTime";
            this.lblBurstTime.Size = new System.Drawing.Size(153, 20);
            this.lblBurstTime.TabIndex = 2;
            this.lblBurstTime.Text = "Enter Burst Time";

            // 
            // txtArrivalTime
            // 
            this.txtArrivalTime.Location = new System.Drawing.Point(180, 86);
            this.txtArrivalTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtArrivalTime.Name = "txtArrivalTime";
            this.txtArrivalTime.Size = new System.Drawing.Size(160, 24);
            this.txtArrivalTime.TabIndex = 3;

            // 
            // txtBurstTime
            // 
            this.txtBurstTime.Location = new System.Drawing.Point(530, 86);
            this.txtBurstTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBurstTime.Name = "txtBurstTime";
            this.txtBurstTime.Size = new System.Drawing.Size(160, 24);
            this.txtBurstTime.TabIndex = 4;

            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MistyRose;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Location = new System.Drawing.Point(105, 122);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(70, 26);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(323, 122);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 26);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.MistyRose;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(530, 122);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(84, 26);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // 
            // dgvProcesses
            // 
            this.dgvProcesses.AllowUserToAddRows = false;
            this.dgvProcesses.AllowUserToResizeRows = false;
            this.dgvProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProcesses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcesses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPID,
            this.colAT,
            this.colBT,
            this.colCT,
            this.colTAT,
            this.colWT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProcesses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProcesses.Location = new System.Drawing.Point(30, 170);
            this.dgvProcesses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvProcesses.MultiSelect = false;
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.ReadOnly = true;
            this.dgvProcesses.RowHeadersVisible = false;
            this.dgvProcesses.RowHeadersWidth = 62;
            this.dgvProcesses.RowTemplate.Height = 28;
            this.dgvProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesses.Size = new System.Drawing.Size(698, 216);
            this.dgvProcesses.TabIndex = 8;

            // 
            // colPID
            // 
            this.colPID.HeaderText = "P_ID";
            this.colPID.MinimumWidth = 8;
            this.colPID.Name = "colPID";
            this.colPID.ReadOnly = true;
            this.colPID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // colAT
            // 
            this.colAT.HeaderText = "AT";
            this.colAT.MinimumWidth = 8;
            this.colAT.Name = "colAT";
            this.colAT.ReadOnly = true;
            this.colAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // colBT
            // 
            this.colBT.HeaderText = "BT";
            this.colBT.MinimumWidth = 8;
            this.colBT.Name = "colBT";
            this.colBT.ReadOnly = true;
            this.colBT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // colCT
            // 
            this.colCT.HeaderText = "CT";
            this.colCT.MinimumWidth = 8;
            this.colCT.Name = "colCT";
            this.colCT.ReadOnly = true;
            this.colCT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // colTAT
            // 
            this.colTAT.HeaderText = "TAT";
            this.colTAT.MinimumWidth = 8;
            this.colTAT.Name = "colTAT";
            this.colTAT.ReadOnly = true;
            this.colTAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // colWT
            // 
            this.colWT.HeaderText = "WT";
            this.colWT.MinimumWidth = 8;
            this.colWT.Name = "colWT";
            this.colWT.ReadOnly = true;
            this.colWT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.BackColor = System.Drawing.Color.White;
            this.pnlGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGanttChart.Location = new System.Drawing.Point(30, 491);
            this.pnlGanttChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(698, 80);
            this.pnlGanttChart.TabIndex = 9;

            // 
            // lblGanttTitle
            // 
            this.lblGanttTitle.AutoSize = true;
            this.lblGanttTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanttTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblGanttTitle.Location = new System.Drawing.Point(26, 454);
            this.lblGanttTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGanttTitle.Name = "lblGanttTitle";
            this.lblGanttTitle.Size = new System.Drawing.Size(113, 24);
            this.lblGanttTitle.TabIndex = 0;
            this.lblGanttTitle.Text = "Gantt Chart";

            // 
            // lblAverageWaiting
            // 
            this.lblAverageWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageWaiting.ForeColor = System.Drawing.Color.Maroon;
            this.lblAverageWaiting.Location = new System.Drawing.Point(26, 410);
            this.lblAverageWaiting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAverageWaiting.Name = "lblAverageWaiting";
            this.lblAverageWaiting.Size = new System.Drawing.Size(337, 30);
            this.lblAverageWaiting.TabIndex = 10;
            this.lblAverageWaiting.Text = "Average Waiting Time:";

            // 
            // lblAverageTurnaround
            // 
            this.lblAverageTurnaround.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTurnaround.ForeColor = System.Drawing.Color.Maroon;
            this.lblAverageTurnaround.Location = new System.Drawing.Point(383, 410);
            this.lblAverageTurnaround.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAverageTurnaround.Name = "lblAverageTurnaround";
            this.lblAverageTurnaround.Size = new System.Drawing.Size(337, 30);
            this.lblAverageTurnaround.TabIndex = 11;
            this.lblAverageTurnaround.Text = "Average Turnaround Time:";

            // 
            // AlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(761, 604);
            this.Controls.Add(this.lblAverageTurnaround);
            this.Controls.Add(this.lblAverageWaiting);
            this.Controls.Add(this.lblGanttTitle);
            this.Controls.Add(this.pnlGanttChart);
            this.Controls.Add(this.dgvProcesses);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBurstTime);
            this.Controls.Add(this.txtArrivalTime);
            this.Controls.Add(this.lblBurstTime);
            this.Controls.Add(this.lblArrivalTime);
            this.Controls.Add(this.lblAlgorithmTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AlgorithmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCFS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlgorithmTitle;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.Label lblBurstTime;
        private System.Windows.Forms.TextBox txtArrivalTime;
        private System.Windows.Forms.TextBox txtBurstTime;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWT;
        private System.Windows.Forms.Panel pnlGanttChart;
        private System.Windows.Forms.Label lblGanttTitle;
        private System.Windows.Forms.Label lblAverageWaiting;
        private System.Windows.Forms.Label lblAverageTurnaround;
    }
}