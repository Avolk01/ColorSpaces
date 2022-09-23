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
        Form3 form3;

        List<int[]> data = new List<int[]>();
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ClearData()
        {
            data.Clear();
            for (int i = 0; i < 3; i++)            
                data.Add(new int[256]);                               
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            ClearData();
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
                    var value1 = (int)(pixelColor.R * 0.299f + pixelColor.G * 0.587f + pixelColor.B * 0.114f); // Другая формула
                    var value2 = (int)(pixelColor.R + pixelColor.G + pixelColor.B )/3; // (R + G + B) / 3
                    Color newColor1 = Color.FromArgb(value1, value1, value1);
                    Color newColor2 = Color.FromArgb(value2, value2, value2);
                    diff.SetPixel(x, y, Color.FromArgb(Math.Abs(newColor1.R - newColor2.R), Math.Abs(newColor1.G-newColor2.G), Math.Abs(newColor1.B-newColor2.B))); 
                    greyscale1.SetPixel(x, y, newColor1); 
                    greyscale2.SetPixel(x, y, newColor1);

                    data[0][value1]++;
                    data[1][value2]++;
                    var p = diff.GetPixel(x,y);
                    data[2][p.R]++;

                }
            }
            mainPictureBox.Image = mainPicture;
            pictureBox1.Image = greyscale1;
            pictureBox2.Image = greyscale2;
            pictureBox3.Image = diff;           
        }
        

        private void task2Button_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            ClearData();
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
                    data[0][mainPictureColor.R]++;
                    data[1][mainPictureColor.G]++;            
                    data[2][mainPictureColor.B]++;
                }
            }            
            mainPictureBox.Image = mainPicture;
            pictureBox1.Image = arrayOfBitmap[0];
            pictureBox2.Image = arrayOfBitmap[1];
            pictureBox3.Image = arrayOfBitmap[2];
        }

        private void gistButton_Click_1(object sender, EventArgs e)
        {
            form2 = new Form2(data);
            form2.Width = 1357;
            form2.Height = 799;
            form2.ShowDialog();
        }  
       
        private void task3Button_Click(object sender, EventArgs e)
        {
            Bitmap mainPicture = new Bitmap(Image.FromFile("test1.png"));
            form3 = new Form3(mainPicture);
            form3.Width = 816;
            form3.Height = 489;
            form3.ShowDialog();                        
        }
    }
}
