namespace Lab04
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.drawHillButton = new System.Windows.Forms.Button();
            this.rTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startLineButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // drawHillButton
            // 
            this.drawHillButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawHillButton.Location = new System.Drawing.Point(806, 12);
            this.drawHillButton.Name = "drawHillButton";
            this.drawHillButton.Size = new System.Drawing.Size(116, 30);
            this.drawHillButton.TabIndex = 1;
            this.drawHillButton.Text = "Draw";
            this.drawHillButton.UseVisualStyleBackColor = true;
            this.drawHillButton.Click += new System.EventHandler(this.drawHillButton_Click);
            // 
            // rTextBox
            // 
            this.rTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rTextBox.Location = new System.Drawing.Point(806, 68);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(116, 26);
            this.rTextBox.TabIndex = 2;
            this.rTextBox.Text = "0,5";
            this.rTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rTextBox.TextChanged += new System.EventHandler(this.rTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(853, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // startLineButton
            // 
            this.startLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startLineButton.Location = new System.Drawing.Point(806, 100);
            this.startLineButton.Name = "startLineButton";
            this.startLineButton.Size = new System.Drawing.Size(116, 30);
            this.startLineButton.TabIndex = 4;
            this.startLineButton.Text = "Line";
            this.startLineButton.UseVisualStyleBackColor = true;
            this.startLineButton.Click += new System.EventHandler(this.startLineButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(854, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startLineButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rTextBox);
            this.Controls.Add(this.drawHillButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button drawHillButton;
        private System.Windows.Forms.TextBox rTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startLineButton;
        private System.Windows.Forms.Label label2;
    }
}