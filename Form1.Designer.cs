
namespace OS_Project
{
    partial class Form1
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFCFS = new System.Windows.Forms.Label();
            this.btnSJFNonPreemptive = new System.Windows.Forms.Label();
            this.btnSJFPreemptive = new System.Windows.Forms.Label();
            this.btnPriorityNonPreemptive = new System.Windows.Forms.Label();
            this.btnPriorityPreemptive = new System.Windows.Forms.Label();
            this.btnRoundRobin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(171, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(438, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CPU Scheduling Algorithms";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFCFS
            // 
            this.btnFCFS.BackColor = System.Drawing.Color.IndianRed;
            this.btnFCFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCFS.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFCFS.Location = new System.Drawing.Point(45, 141);
            this.btnFCFS.Name = "btnFCFS";
            this.btnFCFS.Size = new System.Drawing.Size(180, 100);
            this.btnFCFS.TabIndex = 1;
            this.btnFCFS.Text = "FCFS";
            this.btnFCFS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSJFNonPreemptive
            // 
            this.btnSJFNonPreemptive.BackColor = System.Drawing.Color.LightCoral;
            this.btnSJFNonPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnSJFNonPreemptive.Location = new System.Drawing.Point(312, 141);
            this.btnSJFNonPreemptive.Name = "btnSJFNonPreemptive";
            this.btnSJFNonPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnSJFNonPreemptive.TabIndex = 2;
            this.btnSJFNonPreemptive.Text = "SJF (N-Pre)";
            this.btnSJFNonPreemptive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSJFPreemptive
            // 
            this.btnSJFPreemptive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSJFPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSJFPreemptive.Location = new System.Drawing.Point(558, 141);
            this.btnSJFPreemptive.Name = "btnSJFPreemptive";
            this.btnSJFPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnSJFPreemptive.TabIndex = 3;
            this.btnSJFPreemptive.Text = "SJF (Pre)";
            this.btnSJFPreemptive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPriorityNonPreemptive
            // 
            this.btnPriorityNonPreemptive.BackColor = System.Drawing.Color.LightCoral;
            this.btnPriorityNonPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriorityNonPreemptive.Location = new System.Drawing.Point(45, 272);
            this.btnPriorityNonPreemptive.Name = "btnPriorityNonPreemptive";
            this.btnPriorityNonPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnPriorityNonPreemptive.TabIndex = 4;
            this.btnPriorityNonPreemptive.Text = "Priority (N-Pre)";
            this.btnPriorityNonPreemptive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPriorityPreemptive
            // 
            this.btnPriorityPreemptive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPriorityPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriorityPreemptive.Location = new System.Drawing.Point(312, 272);
            this.btnPriorityPreemptive.Name = "btnPriorityPreemptive";
            this.btnPriorityPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnPriorityPreemptive.TabIndex = 5;
            this.btnPriorityPreemptive.Text = "Priority (Pre)";
            this.btnPriorityPreemptive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRoundRobin
            // 
            this.btnRoundRobin.BackColor = System.Drawing.Color.IndianRed;
            this.btnRoundRobin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoundRobin.Location = new System.Drawing.Point(558, 272);
            this.btnRoundRobin.Name = "btnRoundRobin";
            this.btnRoundRobin.Size = new System.Drawing.Size(180, 100);
            this.btnRoundRobin.TabIndex = 6;
            this.btnRoundRobin.Text = "Round Robin";
            this.btnRoundRobin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.btnRoundRobin);
            this.Controls.Add(this.btnPriorityPreemptive);
            this.Controls.Add(this.btnPriorityNonPreemptive);
            this.Controls.Add(this.btnSJFPreemptive);
            this.Controls.Add(this.btnSJFNonPreemptive);
            this.Controls.Add(this.btnFCFS);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPU Scheduling Algorithms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnFCFS;
        private System.Windows.Forms.Label btnSJFNonPreemptive;
        private System.Windows.Forms.Label btnSJFPreemptive;
        private System.Windows.Forms.Label btnPriorityNonPreemptive;
        private System.Windows.Forms.Label btnPriorityPreemptive;
        private System.Windows.Forms.Label btnRoundRobin;
    }
}

