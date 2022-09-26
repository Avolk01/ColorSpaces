using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace color_spaces
{
    public partial class Form2 : Form
    {

        List<int[]> chartsData;
        public Form2(List<int[]> list)
        {
            InitializeComponent();
            chartsData = list;           
        }

        private void CreateCharts()
        {           
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[0].Points.AddXY(i, chartsData[0][i]);
                chart2.Series[0].Points.AddXY(i, chartsData[1][i]);
                chart3.Series[0].Points.AddXY(i, chartsData[2][i]);
            }
                              
        }
        private void redChart1_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            CreateCharts();            
        }
    }
}
