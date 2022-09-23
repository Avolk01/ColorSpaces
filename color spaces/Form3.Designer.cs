namespace color_spaces
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.decH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.incH = new System.Windows.Forms.Button();
            this.decS = new System.Windows.Forms.Button();
            this.decV = new System.Windows.Forms.Button();
            this.incS = new System.Windows.Forms.Button();
            this.incV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // decH
            // 
            this.decH.Location = new System.Drawing.Point(599, 12);
            this.decH.Name = "decH";
            this.decH.Size = new System.Drawing.Size(45, 23);
            this.decH.TabIndex = 0;
            this.decH.Text = "-";
            this.decH.UseVisualStyleBackColor = true;
            this.decH.Click += new System.EventHandler(this.decH_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hue";
            // 
            // incH
            // 
            this.incH.Location = new System.Drawing.Point(743, 12);
            this.incH.Name = "incH";
            this.incH.Size = new System.Drawing.Size(45, 23);
            this.incH.TabIndex = 3;
            this.incH.Text = "+";
            this.incH.UseVisualStyleBackColor = true;
            this.incH.Click += new System.EventHandler(this.incH_Click);
            // 
            // decS
            // 
            this.decS.Location = new System.Drawing.Point(599, 57);
            this.decS.Name = "decS";
            this.decS.Size = new System.Drawing.Size(45, 23);
            this.decS.TabIndex = 4;
            this.decS.Text = "-";
            this.decS.UseVisualStyleBackColor = true;
            this.decS.Click += new System.EventHandler(this.decS_Click);
            // 
            // decV
            // 
            this.decV.Location = new System.Drawing.Point(599, 106);
            this.decV.Name = "decV";
            this.decV.Size = new System.Drawing.Size(45, 23);
            this.decV.TabIndex = 5;
            this.decV.Text = "-";
            this.decV.UseVisualStyleBackColor = true;
            this.decV.Click += new System.EventHandler(this.decV_Click);
            // 
            // incS
            // 
            this.incS.Location = new System.Drawing.Point(743, 57);
            this.incS.Name = "incS";
            this.incS.Size = new System.Drawing.Size(45, 23);
            this.incS.TabIndex = 6;
            this.incS.Text = "+";
            this.incS.UseVisualStyleBackColor = true;
            this.incS.Click += new System.EventHandler(this.incS_Click);
            // 
            // incV
            // 
            this.incV.Location = new System.Drawing.Point(743, 106);
            this.incV.Name = "incV";
            this.incV.Size = new System.Drawing.Size(45, 23);
            this.incV.TabIndex = 7;
            this.incV.Text = "+";
            this.incV.UseVisualStyleBackColor = true;
            this.incV.Click += new System.EventHandler(this.incV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Saturation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(679, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Value";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(661, 415);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.incV);
            this.Controls.Add(this.incS);
            this.Controls.Add(this.decV);
            this.Controls.Add(this.decS);
            this.Controls.Add(this.incH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decH);
            this.Name = "Form3";
            this.Text = "Натройка HSV";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button decH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button incH;
        private System.Windows.Forms.Button decS;
        private System.Windows.Forms.Button decV;
        private System.Windows.Forms.Button incS;
        private System.Windows.Forms.Button incV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveButton;
    }
}