namespace Lab04
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
            this.fractalShowButton = new System.Windows.Forms.Button();
            this.midPointShowButton = new System.Windows.Forms.Button();
            this.splineShowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fractalShowButton
            // 
            this.fractalShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fractalShowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.fractalShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fractalShowButton.Location = new System.Drawing.Point(12, 12);
            this.fractalShowButton.Name = "fractalShowButton";
            this.fractalShowButton.Size = new System.Drawing.Size(249, 61);
            this.fractalShowButton.TabIndex = 0;
            this.fractalShowButton.Text = "Fractal";
            this.fractalShowButton.UseVisualStyleBackColor = false;
            this.fractalShowButton.Click += new System.EventHandler(this.fractalShowButton_Click);
            // 
            // midPointShowButton
            // 
            this.midPointShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.midPointShowButton.BackColor = System.Drawing.Color.Yellow;
            this.midPointShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.midPointShowButton.Location = new System.Drawing.Point(12, 79);
            this.midPointShowButton.Name = "midPointShowButton";
            this.midPointShowButton.Size = new System.Drawing.Size(249, 61);
            this.midPointShowButton.TabIndex = 1;
            this.midPointShowButton.Text = "Mid Point";
            this.midPointShowButton.UseVisualStyleBackColor = false;
            this.midPointShowButton.Click += new System.EventHandler(this.midPointShowButton_Click);
            // 
            // splineShowButton
            // 
            this.splineShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splineShowButton.BackColor = System.Drawing.Color.Brown;
            this.splineShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.splineShowButton.Location = new System.Drawing.Point(12, 146);
            this.splineShowButton.Name = "splineShowButton";
            this.splineShowButton.Size = new System.Drawing.Size(249, 61);
            this.splineShowButton.TabIndex = 2;
            this.splineShowButton.Text = "Spline";
            this.splineShowButton.UseVisualStyleBackColor = false;
            this.splineShowButton.Click += new System.EventHandler(this.splineShowButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 216);
            this.Controls.Add(this.splineShowButton);
            this.Controls.Add(this.midPointShowButton);
            this.Controls.Add(this.fractalShowButton);
            this.Name = "Form1";
            this.Text = "Choose Task";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fractalShowButton;
        private System.Windows.Forms.Button midPointShowButton;
        private System.Windows.Forms.Button splineShowButton;
    }
}

