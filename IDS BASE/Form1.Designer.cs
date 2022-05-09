namespace IDS_BASE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RUN_btn = new System.Windows.Forms.Button();
            this.Analyse_btn = new System.Windows.Forms.Button();
            this.sensitivity_txt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TrainData_btn = new System.Windows.Forms.Button();
            this.MainData_btn = new System.Windows.Forms.Button();
            this.TrainingDataPath_txt = new System.Windows.Forms.TextBox();
            this.DataSetPath_txt = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Config_gb = new System.Windows.Forms.GroupBox();
            this.dataSetCheck_pb = new System.Windows.Forms.PictureBox();
            this.DataSetUsesTraingData_cb = new System.Windows.Forms.CheckBox();
            this.DataSetAmmount_txt = new System.Windows.Forms.TextBox();
            this.DataSetAmmount_lbl = new System.Windows.Forms.Label();
            this.dataSet_pb = new System.Windows.Forms.PictureBox();
            this.TrainingData_pb = new System.Windows.Forms.PictureBox();
            this.TraingDataAmmount_txt = new System.Windows.Forms.TextBox();
            this.trainindDataAmmount_lbl = new System.Windows.Forms.Label();
            this.SensitivityTip_pb = new System.Windows.Forms.PictureBox();
            this.Sensitivity_tb = new System.Windows.Forms.TrackBar();
            this.Sensitivity_lbl = new System.Windows.Forms.Label();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.resultsDisplay_rtb = new System.Windows.Forms.RichTextBox();
            this.Config_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCheck_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingData_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTip_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sensitivity_tb)).BeginInit();
            this.SuspendLayout();
            // 
            // RUN_btn
            // 
            this.RUN_btn.Location = new System.Drawing.Point(12, 12);
            this.RUN_btn.Name = "RUN_btn";
            this.RUN_btn.Size = new System.Drawing.Size(210, 49);
            this.RUN_btn.TabIndex = 0;
            this.RUN_btn.Text = "Train";
            this.RUN_btn.UseVisualStyleBackColor = true;
            this.RUN_btn.Click += new System.EventHandler(this.RUN_btn_Click);
            // 
            // Analyse_btn
            // 
            this.Analyse_btn.Location = new System.Drawing.Point(228, 12);
            this.Analyse_btn.Name = "Analyse_btn";
            this.Analyse_btn.Size = new System.Drawing.Size(210, 49);
            this.Analyse_btn.TabIndex = 1;
            this.Analyse_btn.Text = "Analyse";
            this.Analyse_btn.UseVisualStyleBackColor = true;
            this.Analyse_btn.Click += new System.EventHandler(this.Analyse_btn_Click);
            // 
            // sensitivity_txt
            // 
            this.sensitivity_txt.Location = new System.Drawing.Point(109, 22);
            this.sensitivity_txt.Name = "sensitivity_txt";
            this.sensitivity_txt.PlaceholderText = "Sensitivity";
            this.sensitivity_txt.Size = new System.Drawing.Size(119, 23);
            this.sensitivity_txt.TabIndex = 2;
            // 
            // TrainData_btn
            // 
            this.TrainData_btn.Location = new System.Drawing.Point(12, 67);
            this.TrainData_btn.Name = "TrainData_btn";
            this.TrainData_btn.Size = new System.Drawing.Size(210, 28);
            this.TrainData_btn.TabIndex = 3;
            this.TrainData_btn.Text = "Select Training Data";
            this.TrainData_btn.UseVisualStyleBackColor = true;
            this.TrainData_btn.Click += new System.EventHandler(this.TrainData_btn_Click);
            // 
            // MainData_btn
            // 
            this.MainData_btn.Location = new System.Drawing.Point(228, 67);
            this.MainData_btn.Name = "MainData_btn";
            this.MainData_btn.Size = new System.Drawing.Size(210, 28);
            this.MainData_btn.TabIndex = 4;
            this.MainData_btn.Text = "Select Data Set";
            this.MainData_btn.UseVisualStyleBackColor = true;
            this.MainData_btn.Click += new System.EventHandler(this.MainData_btn_Click);
            // 
            // TrainingDataPath_txt
            // 
            this.TrainingDataPath_txt.Location = new System.Drawing.Point(12, 101);
            this.TrainingDataPath_txt.Name = "TrainingDataPath_txt";
            this.TrainingDataPath_txt.ReadOnly = true;
            this.TrainingDataPath_txt.Size = new System.Drawing.Size(210, 23);
            this.TrainingDataPath_txt.TabIndex = 5;
            // 
            // DataSetPath_txt
            // 
            this.DataSetPath_txt.Location = new System.Drawing.Point(228, 101);
            this.DataSetPath_txt.Name = "DataSetPath_txt";
            this.DataSetPath_txt.ReadOnly = true;
            this.DataSetPath_txt.Size = new System.Drawing.Size(210, 23);
            this.DataSetPath_txt.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Config_gb
            // 
            this.Config_gb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Config_gb.Controls.Add(this.dataSetCheck_pb);
            this.Config_gb.Controls.Add(this.DataSetUsesTraingData_cb);
            this.Config_gb.Controls.Add(this.DataSetAmmount_txt);
            this.Config_gb.Controls.Add(this.DataSetAmmount_lbl);
            this.Config_gb.Controls.Add(this.dataSet_pb);
            this.Config_gb.Controls.Add(this.TrainingData_pb);
            this.Config_gb.Controls.Add(this.TraingDataAmmount_txt);
            this.Config_gb.Controls.Add(this.trainindDataAmmount_lbl);
            this.Config_gb.Controls.Add(this.SensitivityTip_pb);
            this.Config_gb.Controls.Add(this.Sensitivity_tb);
            this.Config_gb.Controls.Add(this.Sensitivity_lbl);
            this.Config_gb.Controls.Add(this.sensitivity_txt);
            this.Config_gb.Location = new System.Drawing.Point(12, 130);
            this.Config_gb.Name = "Config_gb";
            this.Config_gb.Size = new System.Drawing.Size(261, 365);
            this.Config_gb.TabIndex = 7;
            this.Config_gb.TabStop = false;
            this.Config_gb.Text = "Configuratation";
            // 
            // dataSetCheck_pb
            // 
            this.dataSetCheck_pb.Image = ((System.Drawing.Image)(resources.GetObject("dataSetCheck_pb.Image")));
            this.dataSetCheck_pb.Location = new System.Drawing.Point(227, 161);
            this.dataSetCheck_pb.Name = "dataSetCheck_pb";
            this.dataSetCheck_pb.Size = new System.Drawing.Size(29, 23);
            this.dataSetCheck_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dataSetCheck_pb.TabIndex = 16;
            this.dataSetCheck_pb.TabStop = false;
            this.dataSetCheck_pb.Click += new System.EventHandler(this.dataSetCheck_pb_Click);
            // 
            // DataSetUsesTraingData_cb
            // 
            this.DataSetUsesTraingData_cb.AutoSize = true;
            this.DataSetUsesTraingData_cb.Location = new System.Drawing.Point(6, 161);
            this.DataSetUsesTraingData_cb.Name = "DataSetUsesTraingData_cb";
            this.DataSetUsesTraingData_cb.Size = new System.Drawing.Size(172, 19);
            this.DataSetUsesTraingData_cb.TabIndex = 15;
            this.DataSetUsesTraingData_cb.Text = "Use Traing Data As Data Set ";
            this.DataSetUsesTraingData_cb.UseVisualStyleBackColor = true;
            // 
            // DataSetAmmount_txt
            // 
            this.DataSetAmmount_txt.Location = new System.Drawing.Point(162, 132);
            this.DataSetAmmount_txt.Name = "DataSetAmmount_txt";
            this.DataSetAmmount_txt.PlaceholderText = "2%";
            this.DataSetAmmount_txt.Size = new System.Drawing.Size(48, 23);
            this.DataSetAmmount_txt.TabIndex = 14;
            // 
            // DataSetAmmount_lbl
            // 
            this.DataSetAmmount_lbl.AutoSize = true;
            this.DataSetAmmount_lbl.Location = new System.Drawing.Point(6, 132);
            this.DataSetAmmount_lbl.Name = "DataSetAmmount_lbl";
            this.DataSetAmmount_lbl.Size = new System.Drawing.Size(134, 15);
            this.DataSetAmmount_lbl.TabIndex = 13;
            this.DataSetAmmount_lbl.Text = "Data Set Ammount in %";
            // 
            // dataSet_pb
            // 
            this.dataSet_pb.Image = ((System.Drawing.Image)(resources.GetObject("dataSet_pb.Image")));
            this.dataSet_pb.Location = new System.Drawing.Point(227, 132);
            this.dataSet_pb.Name = "dataSet_pb";
            this.dataSet_pb.Size = new System.Drawing.Size(29, 23);
            this.dataSet_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dataSet_pb.TabIndex = 12;
            this.dataSet_pb.TabStop = false;
            this.dataSet_pb.Click += new System.EventHandler(this.dataSet_pb_Click);
            // 
            // TrainingData_pb
            // 
            this.TrainingData_pb.Image = ((System.Drawing.Image)(resources.GetObject("TrainingData_pb.Image")));
            this.TrainingData_pb.Location = new System.Drawing.Point(227, 103);
            this.TrainingData_pb.Name = "TrainingData_pb";
            this.TrainingData_pb.Size = new System.Drawing.Size(29, 23);
            this.TrainingData_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrainingData_pb.TabIndex = 11;
            this.TrainingData_pb.TabStop = false;
            this.TrainingData_pb.Click += new System.EventHandler(this.TrainingData_pb_Click);
            // 
            // TraingDataAmmount_txt
            // 
            this.TraingDataAmmount_txt.Location = new System.Drawing.Point(162, 103);
            this.TraingDataAmmount_txt.Name = "TraingDataAmmount_txt";
            this.TraingDataAmmount_txt.PlaceholderText = "2%";
            this.TraingDataAmmount_txt.Size = new System.Drawing.Size(48, 23);
            this.TraingDataAmmount_txt.TabIndex = 10;
            // 
            // trainindDataAmmount_lbl
            // 
            this.trainindDataAmmount_lbl.AutoSize = true;
            this.trainindDataAmmount_lbl.Location = new System.Drawing.Point(6, 106);
            this.trainindDataAmmount_lbl.Name = "trainindDataAmmount_lbl";
            this.trainindDataAmmount_lbl.Size = new System.Drawing.Size(150, 15);
            this.trainindDataAmmount_lbl.TabIndex = 8;
            this.trainindDataAmmount_lbl.Text = "Traing Data Ammount in %";
            // 
            // SensitivityTip_pb
            // 
            this.SensitivityTip_pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SensitivityTip_pb.Image = ((System.Drawing.Image)(resources.GetObject("SensitivityTip_pb.Image")));
            this.SensitivityTip_pb.Location = new System.Drawing.Point(227, 22);
            this.SensitivityTip_pb.Name = "SensitivityTip_pb";
            this.SensitivityTip_pb.Size = new System.Drawing.Size(29, 23);
            this.SensitivityTip_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SensitivityTip_pb.TabIndex = 8;
            this.SensitivityTip_pb.TabStop = false;
            this.SensitivityTip_pb.Click += new System.EventHandler(this.SensitivityTip_pb_Click);
            // 
            // Sensitivity_tb
            // 
            this.Sensitivity_tb.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Sensitivity_tb.Location = new System.Drawing.Point(6, 55);
            this.Sensitivity_tb.Name = "Sensitivity_tb";
            this.Sensitivity_tb.Size = new System.Drawing.Size(241, 45);
            this.Sensitivity_tb.TabIndex = 9;
            this.Sensitivity_tb.Scroll += new System.EventHandler(this.Sensitivity_tb_Scroll);
            // 
            // Sensitivity_lbl
            // 
            this.Sensitivity_lbl.AutoSize = true;
            this.Sensitivity_lbl.Location = new System.Drawing.Point(6, 25);
            this.Sensitivity_lbl.Name = "Sensitivity_lbl";
            this.Sensitivity_lbl.Size = new System.Drawing.Size(97, 15);
            this.Sensitivity_lbl.TabIndex = 8;
            this.Sensitivity_lbl.Text = "Adjust Sensitivity";
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.MainProgressBar.Location = new System.Drawing.Point(12, 501);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(261, 27);
            this.MainProgressBar.Step = 500;
            this.MainProgressBar.TabIndex = 8;
            // 
            // resultsDisplay_rtb
            // 
            this.resultsDisplay_rtb.Location = new System.Drawing.Point(279, 130);
            this.resultsDisplay_rtb.Name = "resultsDisplay_rtb";
            this.resultsDisplay_rtb.Size = new System.Drawing.Size(418, 365);
            this.resultsDisplay_rtb.TabIndex = 9;
            this.resultsDisplay_rtb.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 562);
            this.Controls.Add(this.resultsDisplay_rtb);
            this.Controls.Add(this.MainProgressBar);
            this.Controls.Add(this.Config_gb);
            this.Controls.Add(this.DataSetPath_txt);
            this.Controls.Add(this.TrainingDataPath_txt);
            this.Controls.Add(this.MainData_btn);
            this.Controls.Add(this.TrainData_btn);
            this.Controls.Add(this.Analyse_btn);
            this.Controls.Add(this.RUN_btn);
            this.MaximumSize = new System.Drawing.Size(745, 601);
            this.MinimumSize = new System.Drawing.Size(745, 601);
            this.Name = "Form1";
            this.Text = "IDS System";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Config_gb.ResumeLayout(false);
            this.Config_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCheck_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingData_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTip_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sensitivity_tb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button RUN_btn;
        private Button Analyse_btn;
        private TextBox sensitivity_txt;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button TrainData_btn;
        private Button MainData_btn;
        private TextBox TrainingDataPath_txt;
        private TextBox DataSetPath_txt;
        private OpenFileDialog openFileDialog1;
        private GroupBox Config_gb;
        private Label Sensitivity_lbl;
        private TrackBar Sensitivity_tb;
        private PictureBox SensitivityTip_pb;
        private TextBox TraingDataAmmount_txt;
        private Label trainindDataAmmount_lbl;
        private PictureBox TrainingData_pb;
        private TextBox DataSetAmmount_txt;
        private Label DataSetAmmount_lbl;
        private PictureBox dataSet_pb;
        private CheckBox DataSetUsesTraingData_cb;
        private PictureBox dataSetCheck_pb;
        private ProgressBar MainProgressBar;
        private RichTextBox resultsDisplay_rtb;
    }
}