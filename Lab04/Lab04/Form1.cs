using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fractalShowButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.ShowDialog();
        }

        private void midPointShowButton_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.ShowDialog();
        }

        private void splineShowButton_Click(object sender, EventArgs e)
        {
            var form3 = new Form4();
            form3.ShowDialog();
        }
    }
}
