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
            this.SuspendLayout();
            // 
            // RUN_btn
            // 
            this.RUN_btn.Location = new System.Drawing.Point(12, 12);
            this.RUN_btn.Name = "RUN_btn";
            this.RUN_btn.Size = new System.Drawing.Size(140, 81);
            this.RUN_btn.TabIndex = 0;
            this.RUN_btn.Text = "RUN";
            this.RUN_btn.UseVisualStyleBackColor = true;
            this.RUN_btn.Click += new System.EventHandler(this.RUN_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 551);
            this.Controls.Add(this.RUN_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button RUN_btn;
    }
}