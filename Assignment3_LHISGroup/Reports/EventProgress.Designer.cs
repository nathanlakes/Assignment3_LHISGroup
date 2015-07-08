namespace Assignment3_LHISGroup.Reports
{
    partial class EventProgress
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EPChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GenerateGraphBtn = new System.Windows.Forms.Button();
            this.WeddingNameTxtBx = new System.Windows.Forms.TextBox();
            this.WeddingLabel = new System.Windows.Forms.Label();
            this.AllWeddingslbl = new System.Windows.Forms.Label();
            this.SaveToFilebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EPChart)).BeginInit();
            this.SuspendLayout();
            // 
            // EPChart
            // 
            chartArea2.Name = "ChartArea1";
            this.EPChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.EPChart.Legends.Add(legend2);
            this.EPChart.Location = new System.Drawing.Point(12, 12);
            this.EPChart.Name = "EPChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "ExpectedOutstanding";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "ActualOutstanding";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.EPChart.Series.Add(series3);
            this.EPChart.Series.Add(series4);
            this.EPChart.Size = new System.Drawing.Size(499, 368);
            this.EPChart.TabIndex = 0;
            this.EPChart.Text = "chart1";
            this.EPChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // GenerateGraphBtn
            // 
            this.GenerateGraphBtn.Location = new System.Drawing.Point(593, 284);
            this.GenerateGraphBtn.Name = "GenerateGraphBtn";
            this.GenerateGraphBtn.Size = new System.Drawing.Size(111, 45);
            this.GenerateGraphBtn.TabIndex = 1;
            this.GenerateGraphBtn.Text = "Generate Graph";
            this.GenerateGraphBtn.UseVisualStyleBackColor = true;
            this.GenerateGraphBtn.Click += new System.EventHandler(this.GenerateGraphBtn_Click);
            // 
            // WeddingNameTxtBx
            // 
            this.WeddingNameTxtBx.Location = new System.Drawing.Point(604, 216);
            this.WeddingNameTxtBx.Name = "WeddingNameTxtBx";
            this.WeddingNameTxtBx.Size = new System.Drawing.Size(100, 20);
            this.WeddingNameTxtBx.TabIndex = 2;
            // 
            // WeddingLabel
            // 
            this.WeddingLabel.AutoSize = true;
            this.WeddingLabel.Location = new System.Drawing.Point(517, 219);
            this.WeddingLabel.Name = "WeddingLabel";
            this.WeddingLabel.Size = new System.Drawing.Size(81, 13);
            this.WeddingLabel.TabIndex = 3;
            this.WeddingLabel.Text = "Wedding Name";
            // 
            // AllWeddingslbl
            // 
            this.AllWeddingslbl.AutoSize = true;
            this.AllWeddingslbl.Location = new System.Drawing.Point(517, 23);
            this.AllWeddingslbl.Name = "AllWeddingslbl";
            this.AllWeddingslbl.Size = new System.Drawing.Size(0, 13);
            this.AllWeddingslbl.TabIndex = 4;
            // 
            // SaveToFilebtn
            // 
            this.SaveToFilebtn.Enabled = false;
            this.SaveToFilebtn.Location = new System.Drawing.Point(604, 345);
            this.SaveToFilebtn.Name = "SaveToFilebtn";
            this.SaveToFilebtn.Size = new System.Drawing.Size(89, 23);
            this.SaveToFilebtn.TabIndex = 5;
            this.SaveToFilebtn.Text = "Save To File";
            this.SaveToFilebtn.UseVisualStyleBackColor = true;
            this.SaveToFilebtn.Click += new System.EventHandler(this.SaveToFilebtn_Click);
            // 
            // EventProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 380);
            this.Controls.Add(this.SaveToFilebtn);
            this.Controls.Add(this.AllWeddingslbl);
            this.Controls.Add(this.WeddingLabel);
            this.Controls.Add(this.WeddingNameTxtBx);
            this.Controls.Add(this.GenerateGraphBtn);
            this.Controls.Add(this.EPChart);
            this.Name = "EventProgress";
            this.Text = "EventProgress";
            this.Load += new System.EventHandler(this.EventProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EPChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart EPChart;
        private System.Windows.Forms.Button GenerateGraphBtn;
        private System.Windows.Forms.TextBox WeddingNameTxtBx;
        private System.Windows.Forms.Label WeddingLabel;
        private System.Windows.Forms.Label AllWeddingslbl;
        private System.Windows.Forms.Button SaveToFilebtn;
    }
}