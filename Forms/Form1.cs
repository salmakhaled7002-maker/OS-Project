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

            // =========================================
            // CONNECT BUTTON EVENTS
            // =========================================

            btnRoundRobin.Click -= btnRoundRobin_Click;
            btnRoundRobin.Click += btnRoundRobin_Click;

            btnSJFPreemptive.Click -= btnSJFPreemptive_Click;
            btnSJFPreemptive.Click += btnSJFPreemptive_Click;

            btnPriorityPreemptive.Click -= btnPriorityPreemptive_Click;
            btnPriorityPreemptive.Click += btnPriorityPreemptive_Click;

            btnSJFNonPreemptive.Click -= btnSJFNonPre_Click;
            btnSJFNonPreemptive.Click += btnSJFNonPre_Click;

            btnPriorityNonPreemptive.Click -= btnPriorityNonPre_Click;
            btnPriorityNonPreemptive.Click += btnPriorityNonPre_Click;

            btnFCFS.Click -= btnFCFS_Click;
            btnFCFS.Click += btnFCFS_Click;
        }


        // =========================================
        // ROUND ROBIN
        // =========================================

        private void btnRoundRobin_Click(
            object sender,
            EventArgs e)
        {
            RoundRobinForm form =
                new RoundRobinForm();

            form.Show();
        }


        // =========================================
        // SJF PREEMPTIVE
        // =========================================

        private void btnSJFPreemptive_Click(
            object sender,
            EventArgs e)
        {
            SJFPreemptiveForm form =
                new SJFPreemptiveForm();

            form.Show();
        }


        // =========================================
        // PRIORITY PREEMPTIVE
        // =========================================

        private void btnPriorityPreemptive_Click(
            object sender,
            EventArgs e)
        {
            PriorityPreemptiveForm form =
                new PriorityPreemptiveForm();

            form.Show();
        }


        // =========================================
        // SJF NON-PREEMPTIVE
        // =========================================

        private void btnSJFNonPre_Click(
            object sender,
            EventArgs e)
        {
            SJF_Non_Pre_Form form =
                new SJF_Non_Pre_Form();

            form.Show();
        }


        // =========================================
        // PRIORITY NON-PREEMPTIVE
        // =========================================

        private void btnPriorityNonPre_Click(
            object sender,
            EventArgs e)
        {
            Priority_Non_Pre_Form form =
                new Priority_Non_Pre_Form();

            form.Show();
        }


        // =========================================
        // FCFS
        // =========================================

        private void btnFCFS_Click(
            object sender,
            EventArgs e)
        {
            FCFSForm form =
                new FCFSForm();

            form.Show();
        }
    }
}