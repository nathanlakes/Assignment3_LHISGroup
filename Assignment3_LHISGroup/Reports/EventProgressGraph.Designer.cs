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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EPChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GenerateGraphBtn = new System.Windows.Forms.Button();
            this.SaveToFilebtn = new System.Windows.Forms.Button();
            this.WeddingDetailsView = new System.Windows.Forms.DataGridView();
            this.WeddingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EPChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsView)).BeginInit();
            this.SuspendLayout();
            // 
            // EPChart
            // 
            chartArea3.Name = "ChartArea1";
            this.EPChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.EPChart.Legends.Add(legend3);
            this.EPChart.Location = new System.Drawing.Point(12, 183);
            this.EPChart.Name = "EPChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "ExpectedOutstanding";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "ActualOutstanding";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.EPChart.Series.Add(series5);
            this.EPChart.Series.Add(series6);
            this.EPChart.Size = new System.Drawing.Size(750, 406);
            this.EPChart.TabIndex = 0;
            this.EPChart.Text = "chart1";
            // 
            // GenerateGraphBtn
            // 
            this.GenerateGraphBtn.Location = new System.Drawing.Point(624, 12);
            this.GenerateGraphBtn.Name = "GenerateGraphBtn";
            this.GenerateGraphBtn.Size = new System.Drawing.Size(138, 45);
            this.GenerateGraphBtn.TabIndex = 1;
            this.GenerateGraphBtn.Text = "Generate Graph";
            this.GenerateGraphBtn.UseVisualStyleBackColor = true;
            this.GenerateGraphBtn.Click += new System.EventHandler(this.GenerateGraphBtn_Click);
            // 
            // SaveToFilebtn
            // 
            this.SaveToFilebtn.Enabled = false;
            this.SaveToFilebtn.Location = new System.Drawing.Point(624, 124);
            this.SaveToFilebtn.Name = "SaveToFilebtn";
            this.SaveToFilebtn.Size = new System.Drawing.Size(138, 44);
            this.SaveToFilebtn.TabIndex = 5;
            this.SaveToFilebtn.Text = "Save To File";
            this.SaveToFilebtn.UseVisualStyleBackColor = true;
            this.SaveToFilebtn.Click += new System.EventHandler(this.SaveToFilebtn_Click_1);
            // 
            // WeddingDetailsView
            // 
            this.WeddingDetailsView.AllowUserToDeleteRows = false;
            this.WeddingDetailsView.BackgroundColor = System.Drawing.Color.White;
            this.WeddingDetailsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeddingDetailsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeddingID,
            this.Title,
            this.Client1,
            this.Client2});
            this.WeddingDetailsView.Location = new System.Drawing.Point(12, 12);
            this.WeddingDetailsView.Name = "WeddingDetailsView";
            this.WeddingDetailsView.ReadOnly = true;
            this.WeddingDetailsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WeddingDetailsView.Size = new System.Drawing.Size(606, 156);
            this.WeddingDetailsView.TabIndex = 7;
            // 
            // WeddingID
            // 
            this.WeddingID.HeaderText = "ID";
            this.WeddingID.Name = "WeddingID";
            this.WeddingID.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Client1
            // 
            this.Client1.HeaderText = "Client 1";
            this.Client1.Name = "Client1";
            this.Client1.ReadOnly = true;
            // 
            // Client2
            // 
            this.Client2.HeaderText = "Client 2";
            this.Client2.Name = "Client2";
            this.Client2.ReadOnly = true;
            // 
            // EventProgressGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(774, 601);
            this.Controls.Add(this.WeddingDetailsView);
            this.Controls.Add(this.SaveToFilebtn);
            this.Controls.Add(this.GenerateGraphBtn);
            this.Controls.Add(this.EPChart);
            this.Name = "EventProgressGraph";
            this.Text = "EventProgress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventProgressGraph_FormClosing);
            this.Load += new System.EventHandler(this.EventProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EPChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeddingDetailsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart EPChart;
        private System.Windows.Forms.Button GenerateGraphBtn;
        private System.Windows.Forms.Button SaveToFilebtn;
        private System.Windows.Forms.DataGridView WeddingDetailsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeddingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client2;
    }
}