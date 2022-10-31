namespace Lab05
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.rotateXButton = new System.Windows.Forms.Button();
            this.rotateYButton = new System.Windows.Forms.Button();
            this.rotateZButton = new System.Windows.Forms.Button();
            this.scaleXButton = new System.Windows.Forms.Button();
            this.scaleZButton = new System.Windows.Forms.Button();
            this.scaleYButton = new System.Windows.Forms.Button();
            this.translateXButton = new System.Windows.Forms.Button();
            this.translateYButton = new System.Windows.Forms.Button();
            this.translateZButton = new System.Windows.Forms.Button();
            this.figureBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(806, 12);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // rotateXButton
            // 
            this.rotateXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateXButton.Location = new System.Drawing.Point(827, 203);
            this.rotateXButton.Name = "rotateXButton";
            this.rotateXButton.Size = new System.Drawing.Size(75, 23);
            this.rotateXButton.TabIndex = 3;
            this.rotateXButton.Text = "Rotate X";
            this.rotateXButton.UseVisualStyleBackColor = true;
            this.rotateXButton.Click += new System.EventHandler(this.rotateXButton_Click);
            this.rotateXButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateXButton_MouseDown);
            // 
            // rotateYButton
            // 
            this.rotateYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateYButton.Location = new System.Drawing.Point(827, 232);
            this.rotateYButton.Name = "rotateYButton";
            this.rotateYButton.Size = new System.Drawing.Size(75, 23);
            this.rotateYButton.TabIndex = 4;
            this.rotateYButton.Text = "Rotate Y";
            this.rotateYButton.UseVisualStyleBackColor = true;
            this.rotateYButton.Click += new System.EventHandler(this.rotateYButton_Click);
            this.rotateYButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateYButton_MouseDown);
            // 
            // rotateZButton
            // 
            this.rotateZButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateZButton.Location = new System.Drawing.Point(827, 261);
            this.rotateZButton.Name = "rotateZButton";
            this.rotateZButton.Size = new System.Drawing.Size(75, 23);
            this.rotateZButton.TabIndex = 5;
            this.rotateZButton.Text = "Rotate Z";
            this.rotateZButton.UseVisualStyleBackColor = true;
            this.rotateZButton.Click += new System.EventHandler(this.rotateZButton_Click);
            this.rotateZButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateZButton_MouseDown);
            // 
            // scaleXButton
            // 
            this.scaleXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleXButton.Location = new System.Drawing.Point(908, 203);
            this.scaleXButton.Name = "scaleXButton";
            this.scaleXButton.Size = new System.Drawing.Size(75, 23);
            this.scaleXButton.TabIndex = 6;
            this.scaleXButton.Text = "Scale X";
            this.scaleXButton.UseVisualStyleBackColor = true;
            this.scaleXButton.Click += new System.EventHandler(this.scaleXButton_Click);
            // 
            // scaleZButton
            // 
            this.scaleZButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleZButton.Location = new System.Drawing.Point(908, 261);
            this.scaleZButton.Name = "scaleZButton";
            this.scaleZButton.Size = new System.Drawing.Size(75, 23);
            this.scaleZButton.TabIndex = 7;
            this.scaleZButton.Text = "Scale Z";
            this.scaleZButton.UseVisualStyleBackColor = true;
            this.scaleZButton.Click += new System.EventHandler(this.scaleZButton_Click);
            // 
            // scaleYButton
            // 
            this.scaleYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleYButton.Location = new System.Drawing.Point(908, 232);
            this.scaleYButton.Name = "scaleYButton";
            this.scaleYButton.Size = new System.Drawing.Size(75, 23);
            this.scaleYButton.TabIndex = 8;
            this.scaleYButton.Text = "Scale Y";
            this.scaleYButton.UseVisualStyleBackColor = true;
            this.scaleYButton.Click += new System.EventHandler(this.scaleYButton_Click);
            // 
            // translateXButton
            // 
            this.translateXButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.translateXButton.Location = new System.Drawing.Point(989, 203);
            this.translateXButton.Name = "translateXButton";
            this.translateXButton.Size = new System.Drawing.Size(75, 23);
            this.translateXButton.TabIndex = 9;
            this.translateXButton.Text = "Translate X";
            this.translateXButton.UseVisualStyleBackColor = true;
            this.translateXButton.Click += new System.EventHandler(this.translateXButton_Click);
            // 
            // translateYButton
            // 
            this.translateYButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.translateYButton.Location = new System.Drawing.Point(989, 232);
            this.translateYButton.Name = "translateYButton";
            this.translateYButton.Size = new System.Drawing.Size(75, 23);
            this.translateYButton.TabIndex = 10;
            this.translateYButton.Text = "Translate Y";
            this.translateYButton.UseVisualStyleBackColor = true;
            this.translateYButton.Click += new System.EventHandler(this.translateYButton_Click);
            // 
            // translateZButton
            // 
            this.translateZButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.translateZButton.Location = new System.Drawing.Point(989, 261);
            this.translateZButton.Name = "translateZButton";
            this.translateZButton.Size = new System.Drawing.Size(75, 23);
            this.translateZButton.TabIndex = 11;
            this.translateZButton.Text = "Translate Z";
            this.translateZButton.UseVisualStyleBackColor = true;
            this.translateZButton.Click += new System.EventHandler(this.translateZButton_Click);
            // 
            // figureBox
            // 
            this.figureBox.FormattingEnabled = true;
            this.figureBox.Location = new System.Drawing.Point(887, 12);
            this.figureBox.Name = "figureBox";
            this.figureBox.Size = new System.Drawing.Size(121, 21);
            this.figureBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 599);
            this.Controls.Add(this.figureBox);
            this.Controls.Add(this.translateZButton);
            this.Controls.Add(this.translateYButton);
            this.Controls.Add(this.translateXButton);
            this.Controls.Add(this.scaleYButton);
            this.Controls.Add(this.scaleZButton);
            this.Controls.Add(this.scaleXButton);
            this.Controls.Add(this.rotateZButton);
            this.Controls.Add(this.rotateYButton);
            this.Controls.Add(this.rotateXButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button rotateXButton;
        private System.Windows.Forms.Button rotateYButton;
        private System.Windows.Forms.Button rotateZButton;
        private System.Windows.Forms.Button scaleXButton;
        private System.Windows.Forms.Button scaleZButton;
        private System.Windows.Forms.Button scaleYButton;
        private System.Windows.Forms.Button translateXButton;
        private System.Windows.Forms.Button translateYButton;
        private System.Windows.Forms.Button translateZButton;
        private System.Windows.Forms.ComboBox figureBox;
    }
}

