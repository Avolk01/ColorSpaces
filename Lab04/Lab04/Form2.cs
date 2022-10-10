using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }        

        private void drawFractalButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            string res = seks(C);
            drawFractalButton.Text = res;
            if(scaledSize>3)
                scaledSize /= 1.5;
            Risovat(res, x1, y1, startAngle, scaledSize);
            C++;
            pictureBox1.Invalidate();
        }
        Graphics g;
        double scaledSize = 60;
        double rotateAngle = 0;
        double startAngle = 0;
        string inputString = "";
        string[] rules = new string[6];
        double x1 = 500;
        double y1 = 400;
        int C = 0;
        string filename;

        private void Risovat(string seks, double x1, double y1, double angle, double size)
        {     
            g = Graphics.FromImage(pictureBox1.Image);
            var rnd = new Random();
            Pen pen = new Pen(Color.Black, 1);
            double x2 = 0;
            double y2 = 0;
            Stack<Point> stack = new Stack<Point>();
            Point p1 = new Point((int)x1, (int)y1);
            Point p2 = new Point((int)x2, (int)y2);            
            for (int i = 0; i < seks.Length; i++)
            {
                char x = seks[i];
                x2 = (x1 + Math.Cos(angle * Math.PI / 180) * size);
                y2 = (y1 + Math.Sin(angle * Math.PI / 180) * size);
                if (x == 'F')
                {
                    p1 = new Point((int)x1, (int)y1);
                    p2 = new Point((int)x2, (int)y2);

                    g.DrawLine(pen, p1, p2);
                    x1 = x2;
                    y1 = y2;
                }
                if (x == '-')
                {
                    angle -= rotateAngle;
                }
                if (x == '+')
                {
                    angle += rotateAngle;
                }
                if (x == '[')
                {                    
                    var left = i;
                    var right = left+1;
                    var kaef = 1; 
                    while (kaef != 0)
                    {
                        if(seks[right] == '[')
                            kaef++;
                        if (seks[right] == ']')
                            kaef--;
                        right++;
                    }
                    var temp = seks.Substring(left+1, right - left-2);                                     
                    Risovat(temp, x1, y1, angle, size);
                    i = right-1;
                }
                angle %= 360;
            }
        }



        private void kazel()
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string[] lines = new string[6];
                string line;
                int numb = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (numb >= 1)
                    {
                        rules[numb] = line.Substring(3);
                    }
                    lines[numb] = line;
                    numb++;
                }
                lines = lines[0].Split(' ');
                inputString = lines[0];
                Double.TryParse(lines[1], out startAngle);
                Double.TryParse(lines[2], out rotateAngle);
            }
        }
        private string seks(int iterations)
        {
            kazel();
            string newStr = "";
            for (int i = 1; i < iterations + 1; i++)
            {
                foreach (char x in inputString)
                {
                    if (x == 'F')
                    {
                        newStr += rules[1];
                    }
                    if (x == 'X')
                    {
                        newStr += rules[2];
                    }
                    if (x == 'Y')
                    {
                        newStr += rules[3];
                    }
                    if ((x == '+') || (x == '-') || (x == '[') || (x == ']'))
                    {
                        newStr += x;
                    }
                }
                inputString = newStr;                
                newStr = "";                
            }
            return inputString;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            //C = 0;
        }
    }
}
