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

         
        private void btnRoundRobin_Click(
            object sender,
            EventArgs e)
        {
            RoundRobinForm form =
                new RoundRobinForm();

            form.Show();
        }

 
        private void btnSJFPreemptive_Click(
            object sender,
            EventArgs e)
        {
            SJFPreemptiveForm form =
                new SJFPreemptiveForm();

            form.Show();
        }

         
        private void btnPriorityPreemptive_Click(
            object sender,
            EventArgs e)
        {
            PriorityPreemptiveForm form =
                new PriorityPreemptiveForm();

            form.Show();
        }


         
        private void btnSJFNonPre_Click(
            object sender,
            EventArgs e)
        {
            SJF_Non_Pre_Form form =
                new SJF_Non_Pre_Form();

            form.Show();
        }

         
        private void btnPriorityNonPre_Click(
            object sender,
            EventArgs e)
        {
            Priority_Non_Pre_Form form =
                new Priority_Non_Pre_Form();

            form.Show();
        }

 
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