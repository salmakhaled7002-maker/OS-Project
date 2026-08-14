using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using OS_Project.Forms;
namespace OS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Connect buttons
            btnRoundRobin.Click -= btnRoundRobin_Click;
            btnRoundRobin.Click += btnRoundRobin_Click;

            btnSJFPreemptive.Click -= btnSJFPreemptive_Click;
            btnSJFPreemptive.Click += btnSJFPreemptive_Click;

            btnPriorityPreemptive.Click -= btnPriorityPreemptive_Click;
            btnPriorityPreemptive.Click += btnPriorityPreemptive_Click;
        }


        // ==============================
        // ROUND ROBIN
        // ==============================
        private void btnRoundRobin_Click(object sender, EventArgs e)
        {
            RoundRobinForm form = new RoundRobinForm();
            form.Show();
        }


        // ==============================
        // SJF PREEMPTIVE
        // ==============================
        private void btnSJFPreemptive_Click(object sender, EventArgs e)
        {
            SJFPreemptiveForm form = new SJFPreemptiveForm();
            form.Show();
        }


        // ==============================
        // PRIORITY PREEMPTIVE
        // ==============================
        private void btnPriorityPreemptive_Click(object sender, EventArgs e)
        {
            PriorityPreemptiveForm form =
                new PriorityPreemptiveForm();

            form.Show();
        }
    }
}