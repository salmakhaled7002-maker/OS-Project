using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRoundRobin_Click(object sender, EventArgs e)
        {
            AlgorithmForm form = new AlgorithmForm("Round Robin");
            form.Show();
        }
    }
}
