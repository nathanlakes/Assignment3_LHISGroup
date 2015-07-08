namespace Assignment3_LHISGroup.Reports
{
    partial class EventProgressGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            chartArea1.Name = "ChartArea1";
            this.EPChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.EPChart.Legends.Add(legend1);
            this.EPChart.Location = new System.Drawing.Point(12, 12);
            this.EPChart.Name = "EPChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "ExpectedOutstanding";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "ActualOutstanding";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.EPChart.Series.Add(series1);
            this.EPChart.Series.Add(series2);
            this.EPChart.Size = new System.Drawing.Size(499, 368);
            this.EPChart.TabIndex = 0;
            this.EPChart.Text = "chart1";
            this.EPChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // GenerateGraphBtn
            // 
            this.GenerateGraphBtn.Location = new System.Drawing.Point(604, 284);
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
            this.AllWeddingslbl.Location = new System.Drawing.Point(533, 23);
            this.AllWeddingslbl.Name = "AllWeddingslbl";
            this.AllWeddingslbl.Size = new System.Drawing.Size(0, 13);
            this.AllWeddingslbl.TabIndex = 4;
            // 
            // SaveToFilebtn
            // 
            this.SaveToFilebtn.Enabled = false;
            this.SaveToFilebtn.Location = new System.Drawing.Point(618, 345);
            this.SaveToFilebtn.Name = "SaveToFilebtn";
            this.SaveToFilebtn.Size = new System.Drawing.Size(86, 23);
            this.SaveToFilebtn.TabIndex = 5;
            this.SaveToFilebtn.Text = "Save To File";
            this.SaveToFilebtn.UseVisualStyleBackColor = true;
            this.SaveToFilebtn.Click += new System.EventHandler(this.SaveToFilebtn_Click_1);
            // 
            // EventProgressGraph
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
            this.Name = "EventProgressGraph";
            this.Text = "EventProgress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventProgressGraph_FormClosing);
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