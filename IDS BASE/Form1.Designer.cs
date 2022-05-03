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
            this.Sensitivity_lbl = new System.Windows.Forms.Label();
            this.Sensitivity_tb = new System.Windows.Forms.TrackBar();
            this.Config_gb.SuspendLayout();
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
            this.Config_gb.Controls.Add(this.Sensitivity_tb);
            this.Config_gb.Controls.Add(this.Sensitivity_lbl);
            this.Config_gb.Controls.Add(this.sensitivity_txt);
            this.Config_gb.Location = new System.Drawing.Point(12, 130);
            this.Config_gb.Name = "Config_gb";
            this.Config_gb.Size = new System.Drawing.Size(253, 409);
            this.Config_gb.TabIndex = 7;
            this.Config_gb.TabStop = false;
            this.Config_gb.Text = "Configuratation";
            // 
            // Sensitivity_lbl
            // 
            this.Sensitivity_lbl.AutoSize = true;
            this.Sensitivity_lbl.Location = new System.Drawing.Point(6, 25);
            this.Sensitivity_lbl.Name = "Sensitivity_lbl";
            this.Sensitivity_lbl.Size = new System.Drawing.Size(97, 15);
            this.Sensitivity_lbl.TabIndex = 8;
            this.Sensitivity_lbl.Text = "Adjust Sensitivity";
            this.Sensitivity_lbl.Click += new System.EventHandler(this.label1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 551);
            this.Controls.Add(this.Config_gb);
            this.Controls.Add(this.DataSetPath_txt);
            this.Controls.Add(this.TrainingDataPath_txt);
            this.Controls.Add(this.MainData_btn);
            this.Controls.Add(this.TrainData_btn);
            this.Controls.Add(this.Analyse_btn);
            this.Controls.Add(this.RUN_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Config_gb.ResumeLayout(false);
            this.Config_gb.PerformLayout();
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
    }
}