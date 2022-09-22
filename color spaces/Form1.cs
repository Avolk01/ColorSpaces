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

    

    public partial class Form1 : Form
    {
        Form2 form2;
        Form2 f;
        List<int[]> data;
        public Form1()
        {
            InitializeComponent();   
            data = new List<int[]>();
            form2 = new Form2(data);
            form2.Width = 1357;
            form2.Height = 799;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Bitmap mainPicture = new Bitmap(Image.FromFile("test1.png"));            
            Bitmap greyscale1 = new Bitmap(mainPicture);
            Bitmap greyscale2 = new Bitmap(mainPicture);
            Bitmap diff = new Bitmap(mainPicture);
            int x, y;
            var greyscaleValues1 = new int[256];
            var greyscaleValues2 = new int[256];
            var diffValues = new int[256];            
            for (x = 0; x < mainPicture.Width; x++)
            {
                for (y = 0; y < mainPicture.Height; y++)
                {
                    Color pixelColor = mainPicture.GetPixel(x, y);
                    var value1 = (int)(pixelColor.R * 0.299f + pixelColor.G * 0.587f + pixelColor.B * 0.114f); // Другая формула
                    var value2 = (int)(pixelColor.R + pixelColor.G + pixelColor.B )/3; // (R + G + B) / 3
                    Color newColor1 = Color.FromArgb(value1, value1, value1);
                    Color newColor2 = Color.FromArgb(value2, value2, value2);
                    diff.SetPixel(x, y, Color.FromArgb(Math.Abs(newColor1.R - newColor2.R), Math.Abs(newColor1.G-newColor2.G), Math.Abs(newColor1.B-newColor2.B))); 
                    greyscale1.SetPixel(x, y, newColor1); 
                    greyscale2.SetPixel(x, y, newColor1);

                    greyscaleValues1[value1]++;                                         
                    greyscaleValues2[value2]++;
                    var p = diff.GetPixel(x,y);
                    diffValues[p.R]++;

                }
            }
            data.Add(greyscaleValues1);
            data.Add(greyscaleValues2);
            data.Add(diffValues);
            mainPictureBox.Image = mainPicture;
            pictureBox1.Image = greyscale1;
            pictureBox2.Image = greyscale2;
            pictureBox3.Image = diff;           
        }
        

        private void task2Button_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Bitmap mainPicture = new Bitmap(Image.FromFile("test.png"));
            Bitmap redPictureBox = new Bitmap(mainPicture);
            Bitmap greenPictureBox = new Bitmap(mainPicture);
            Bitmap bluePictureBox = new Bitmap(mainPicture);

            Bitmap[] arrayOfBitmap = new Bitmap[] { redPictureBox, greenPictureBox, bluePictureBox };
            for (int x = 0; x < mainPicture.Width; x++)
            {
                for (int y = 0; y < mainPicture.Height; y++)
                {
                    Color mainPictureColor = mainPicture.GetPixel(x, y);
                    arrayOfBitmap[0].SetPixel(x, y, Color.FromArgb(mainPictureColor.A, mainPictureColor.R, 0, 0));
                    arrayOfBitmap[1].SetPixel(x, y, Color.FromArgb(mainPictureColor.A, 0, mainPictureColor.G, 0));
                    arrayOfBitmap[2].SetPixel(x, y, Color.FromArgb(mainPictureColor.A, 0, 0, mainPictureColor.B));
                }
            }
            mainPictureBox.Image = mainPicture;
            pictureBox1.Image = arrayOfBitmap[0];
            pictureBox2.Image = arrayOfBitmap[1];
            pictureBox3.Image = arrayOfBitmap[2];
        }

        private void gistButton_Click_1(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
    }
}
