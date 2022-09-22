namespace color_spaces
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.greyscaleBox2 = new System.Windows.Forms.PictureBox();
            this.greyscaleBox1 = new System.Windows.Forms.PictureBox();
            this.differenceImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscaleBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscaleBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.drawButton.Location = new System.Drawing.Point(1058, 666);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 0;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.differenceImage);
            this.panel1.Controls.Add(this.mainPictureBox);
            this.panel1.Controls.Add(this.greyscaleBox2);
            this.panel1.Controls.Add(this.greyscaleBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 702);
            this.panel1.TabIndex = 1;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(12, 377);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(484, 312);
            this.mainPictureBox.TabIndex = 2;
            this.mainPictureBox.TabStop = false;
            // 
            // greyscaleBox2
            // 
            this.greyscaleBox2.Location = new System.Drawing.Point(559, 12);
            this.greyscaleBox2.Name = "greyscaleBox2";
            this.greyscaleBox2.Size = new System.Drawing.Size(484, 312);
            this.greyscaleBox2.TabIndex = 1;
            this.greyscaleBox2.TabStop = false;
            // 
            // greyscaleBox1
            // 
            this.greyscaleBox1.Location = new System.Drawing.Point(12, 12);
            this.greyscaleBox1.Name = "greyscaleBox1";
            this.greyscaleBox1.Size = new System.Drawing.Size(484, 312);
            this.greyscaleBox1.TabIndex = 0;
            this.greyscaleBox1.TabStop = false;
            // 
            // differenceImage
            // 
            this.differenceImage.Location = new System.Drawing.Point(559, 377);
            this.differenceImage.Name = "differenceImage";
            this.differenceImage.Size = new System.Drawing.Size(484, 312);
            this.differenceImage.TabIndex = 3;
            this.differenceImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.drawButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscaleBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscaleBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.PictureBox greyscaleBox2;
        private System.Windows.Forms.PictureBox greyscaleBox1;
        private System.Windows.Forms.PictureBox differenceImage;
    }
}

