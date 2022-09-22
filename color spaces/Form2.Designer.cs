namespace color_spaces
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.greyscale1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.greyscale2Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.diffChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.showButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.greyscale1Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscale2Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffChart)).BeginInit();
            this.SuspendLayout();
            // 
            // greyscale1Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.greyscale1Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.greyscale1Chart.Legends.Add(legend1);
            this.greyscale1Chart.Location = new System.Drawing.Point(0, 1);
            this.greyscale1Chart.Name = "greyscale1Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.greyscale1Chart.Series.Add(series1);
            this.greyscale1Chart.Size = new System.Drawing.Size(1251, 238);
            this.greyscale1Chart.TabIndex = 0;
            this.greyscale1Chart.Text = "chart1";
            this.greyscale1Chart.Click += new System.EventHandler(this.redChart1_Click);
            // 
            // greyscale2Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.greyscale2Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.greyscale2Chart.Legends.Add(legend2);
            this.greyscale2Chart.Location = new System.Drawing.Point(0, 245);
            this.greyscale2Chart.Name = "greyscale2Chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.greyscale2Chart.Series.Add(series2);
            this.greyscale2Chart.Size = new System.Drawing.Size(1251, 238);
            this.greyscale2Chart.TabIndex = 1;
            this.greyscale2Chart.Text = "chart2";
            // 
            // diffChart
            // 
            chartArea3.Name = "ChartArea1";
            this.diffChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.diffChart.Legends.Add(legend3);
            this.diffChart.Location = new System.Drawing.Point(0, 489);
            this.diffChart.Name = "diffChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.diffChart.Series.Add(series3);
            this.diffChart.Size = new System.Drawing.Size(1251, 238);
            this.diffChart.TabIndex = 2;
            this.diffChart.Text = "chart3";
            // 
            // showButton
            // 
            this.showButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showButton.Location = new System.Drawing.Point(1254, 725);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 7;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 760);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.diffChart);
            this.Controls.Add(this.greyscale2Chart);
            this.Controls.Add(this.greyscale1Chart);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.greyscale1Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greyscale2Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart greyscale1Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart greyscale2Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart diffChart;
        private System.Windows.Forms.Button showButton;
    }
}