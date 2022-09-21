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
            this.mainPictureBox.Image = mainPicture;
            Bitmap greyscale1 = new Bitmap(mainPicture);
            Bitmap greyscale2 = new Bitmap(mainPicture);
            int x, y;

            // Loop through the images pixels to reset color.
            for (x = 0; x < mainPicture.Width; x++)
            {
                for (y = 0; y < mainPicture.Height; y++)
                {
                    Color pixelColor = mainPicture.GetPixel(x, y);
                    var value1 = pixelColor.R * 0.299f + pixelColor.G * 0.587f + pixelColor.B * 0.114f;
                    var value2 = pixelColor.R * 0.2126f + pixelColor.G * 0.7152f + pixelColor.B * 0.0722f;
                    Color newColor1 = Color.FromArgb((int)value1, (int)value1, (int)value1);
                    Color newColor2 = Color.FromArgb((int)value1, (int)value1, (int)value1);
                    greyscale1.SetPixel(x, y, newColor1); 
                    greyscale2.SetPixel(x, y, newColor1); 
                }
            }            
            greyscaleBox1.Image = greyscale1;
            greyscaleBox2.Image = greyscale2;
        }
    }
}
