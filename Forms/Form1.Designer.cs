
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
            this.lblTitle = new System.Windows.Forms.Button();
            this.btnFCFS = new System.Windows.Forms.Button();
            this.btnSJFNonPreemptive = new System.Windows.Forms.Button();
            this.btnSJFPreemptive = new System.Windows.Forms.Button();
            this.btnPriorityNonPreemptive = new System.Windows.Forms.Button();
            this.btnPriorityPreemptive = new System.Windows.Forms.Button();
            this.btnRoundRobin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(171, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(492, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CPU Scheduling Algorithms";
            // 
            // btnFCFS
            // 
            this.btnFCFS.BackColor = System.Drawing.Color.IndianRed;
            this.btnFCFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFCFS.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnFCFS.Location = new System.Drawing.Point(45, 141);
            this.btnFCFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFCFS.Name = "btnFCFS";
            this.btnFCFS.Size = new System.Drawing.Size(180, 100);
            this.btnFCFS.TabIndex = 1;
            this.btnFCFS.Text = "FCFS";
            this.btnFCFS.UseVisualStyleBackColor = false;
            // 
            // btnSJFNonPreemptive
            // 
            this.btnSJFNonPreemptive.BackColor = System.Drawing.Color.LightCoral;
            this.btnSJFNonPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnSJFNonPreemptive.Location = new System.Drawing.Point(349, 141);
            this.btnSJFNonPreemptive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSJFNonPreemptive.Name = "btnSJFNonPreemptive";
            this.btnSJFNonPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnSJFNonPreemptive.TabIndex = 2;
            this.btnSJFNonPreemptive.Text = "SJF (N-Pre)";
            this.btnSJFNonPreemptive.UseVisualStyleBackColor = false;
            // 
            // btnSJFPreemptive
            // 
            this.btnSJFPreemptive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSJFPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSJFPreemptive.Location = new System.Drawing.Point(649, 141);
            this.btnSJFPreemptive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSJFPreemptive.Name = "btnSJFPreemptive";
            this.btnSJFPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnSJFPreemptive.TabIndex = 3;
            this.btnSJFPreemptive.Text = "SJF (Pre)";
            this.btnSJFPreemptive.UseVisualStyleBackColor = false;
            this.btnSJFPreemptive.Click += new System.EventHandler(this.btnSJFPreemptive_Click);
            // 
            // btnPriorityNonPreemptive
            // 
            this.btnPriorityNonPreemptive.BackColor = System.Drawing.Color.LightCoral;
            this.btnPriorityNonPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriorityNonPreemptive.Location = new System.Drawing.Point(45, 325);
            this.btnPriorityNonPreemptive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPriorityNonPreemptive.Name = "btnPriorityNonPreemptive";
            this.btnPriorityNonPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnPriorityNonPreemptive.TabIndex = 4;
            this.btnPriorityNonPreemptive.Text = "Priority (N-Pre)";
            this.btnPriorityNonPreemptive.UseVisualStyleBackColor = false;
            // 
            // btnPriorityPreemptive
            // 
            this.btnPriorityPreemptive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPriorityPreemptive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriorityPreemptive.Location = new System.Drawing.Point(349, 325);
            this.btnPriorityPreemptive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPriorityPreemptive.Name = "btnPriorityPreemptive";
            this.btnPriorityPreemptive.Size = new System.Drawing.Size(180, 100);
            this.btnPriorityPreemptive.TabIndex = 5;
            this.btnPriorityPreemptive.Text = "Priority (Pre)";
            this.btnPriorityPreemptive.UseVisualStyleBackColor = false;
            // 
            // btnRoundRobin
            // 
            this.btnRoundRobin.BackColor = System.Drawing.Color.IndianRed;
            this.btnRoundRobin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoundRobin.Location = new System.Drawing.Point(649, 325);
            this.btnRoundRobin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoundRobin.Name = "btnRoundRobin";
            this.btnRoundRobin.Size = new System.Drawing.Size(180, 100);
            this.btnRoundRobin.TabIndex = 6;
            this.btnRoundRobin.Text = "Round Robin";
            this.btnRoundRobin.UseVisualStyleBackColor = false;
            this.btnRoundRobin.Click += new System.EventHandler(this.btnRoundRobin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.btnRoundRobin);
            this.Controls.Add(this.btnPriorityPreemptive);
            this.Controls.Add(this.btnPriorityNonPreemptive);
            this.Controls.Add(this.btnSJFPreemptive);
            this.Controls.Add(this.btnSJFNonPreemptive);
            this.Controls.Add(this.btnFCFS);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPU Scheduling Algorithms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lblTitle;
        private System.Windows.Forms.Button btnFCFS;
        private System.Windows.Forms.Button btnSJFNonPreemptive;
        private System.Windows.Forms.Button btnSJFPreemptive;
        private System.Windows.Forms.Button btnPriorityNonPreemptive;
        private System.Windows.Forms.Button btnPriorityPreemptive;
        private System.Windows.Forms.Button btnRoundRobin;
    }
}

