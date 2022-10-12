namespace Lab04
{
    partial class Form2
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.drawFractalButton = new System.Windows.Forms.Button();
            this.drawTreeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileButton.Location = new System.Drawing.Point(1446, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(126, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1440, 810);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // drawFractalButton
            // 
            this.drawFractalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawFractalButton.Location = new System.Drawing.Point(1446, 41);
            this.drawFractalButton.Name = "drawFractalButton";
            this.drawFractalButton.Size = new System.Drawing.Size(126, 23);
            this.drawFractalButton.TabIndex = 2;
            this.drawFractalButton.Text = "Draw Fractal";
            this.drawFractalButton.UseVisualStyleBackColor = true;
            this.drawFractalButton.Click += new System.EventHandler(this.drawFractalButton_Click);
            // 
            // drawTreeButton
            // 
            this.drawTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drawTreeButton.Location = new System.Drawing.Point(1446, 70);
            this.drawTreeButton.Name = "drawTreeButton";
            this.drawTreeButton.Size = new System.Drawing.Size(126, 23);
            this.drawTreeButton.TabIndex = 3;
            this.drawTreeButton.Text = "Draw Tree";
            this.drawTreeButton.UseVisualStyleBackColor = true;
            this.drawTreeButton.Click += new System.EventHandler(this.drawTreeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1464, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawTreeButton);
            this.Controls.Add(this.drawFractalButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form2";
            this.Text = "Fractal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button drawFractalButton;
        private System.Windows.Forms.Button drawTreeButton;
        private System.Windows.Forms.Label label1;
    }
}