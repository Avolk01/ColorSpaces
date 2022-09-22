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

    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void drawButton_Click(object sender, EventArgs e)
        {

            Bitmap mainPicture = new Bitmap(Image.FromFile("test1.png"));            
            Bitmap greyscale1 = new Bitmap(mainPicture);
            Bitmap greyscale2 = new Bitmap(mainPicture);
            Bitmap diff = new Bitmap(mainPicture);
            int x, y;

            for (x = 0; x < mainPicture.Width; x++)
            {
                for (y = 0; y < mainPicture.Height; y++)
                {
                    Color pixelColor = mainPicture.GetPixel(x, y);
                    var value1 = pixelColor.R * 0.299f + pixelColor.G * 0.587f + pixelColor.B * 0.114f; // Другая формула
                    var value2 = (pixelColor.R + pixelColor.G + pixelColor.B )/3; // (R + G + B) / 3
                    Color newColor1 = Color.FromArgb((int)value1, (int)value1, (int)value1);
                    Color newColor2 = Color.FromArgb((int)value2, (int)value2, (int)value2);
                    diff.SetPixel(x, y, Color.FromArgb(Math.Abs(newColor1.R - newColor2.R), Math.Abs(newColor1.G-newColor2.G), Math.Abs(newColor1.B-newColor2.B))); 
                    greyscale1.SetPixel(x, y, newColor1); 
                    greyscale2.SetPixel(x, y, newColor1); 
                }
            }
            mainPictureBox.Image = mainPicture;
            greyscaleBox1.Image = greyscale1;
            greyscaleBox2.Image = greyscale2;
            differenceImage.Image = diff;
        }
    }
}
