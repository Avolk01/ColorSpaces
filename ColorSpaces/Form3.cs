using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace color_spaces
{
    public partial class Form3 : Form
    {
        Bitmap mainImage;
        public Form3(Bitmap image)
        {
            InitializeComponent();
            pictureBox1.Image = image;    
            mainImage = image;
        }

        private Bitmap Refresh(Bitmap image, double hValue, double sValue, double vValue)
        {
            double h = 0;
            double s = 0;
            double v = 0;
            Bitmap HSVImage = new Bitmap(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    ColorToHSV(pixelColor, out h, out s, out v);
                    h += hValue;
                    if (h > 360)
                        h = 360;
                    if (h < 0)
                        h = 0;
                    s += sValue;
                    if (s > 1)
                        s = 1;
                    if (s < 0)
                        s = 0;
                    v += vValue;
                    if (v > 1)
                        v = 1;
                    if (v < 0)
                        v = 0;
                    Color newColor1 = ColorFromHSV(h, s, v);
                    HSVImage.SetPixel(x, y, newColor1);
                }
            }
            return HSVImage;
        }

        Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }


        private void decH_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), -1, 0, 0);
        }

        private void decS_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), 0, -0.1, 0);
        }

        private void decV_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), 0, 0, -0.1); 
        }

        private void incH_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), 1, 0, 0);
        }

        private void incS_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), 0, 0.1, 0);
        }

        private void incV_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Refresh(new Bitmap(pictureBox1.Image), 0, 0, 0.1);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mainImage.Save("Before.png");
            pictureBox1.Image.Save("After.png");
        }
    }
}
