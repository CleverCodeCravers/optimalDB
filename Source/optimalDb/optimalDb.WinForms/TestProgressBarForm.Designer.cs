namespace optimalDb.WinForms
{
    partial class TestProgressBarForm
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
            this.PerformanceProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressValueLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AsyncWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // PerformanceProgressBar
            // 
            this.PerformanceProgressBar.Location = new System.Drawing.Point(70, 102);
            this.PerformanceProgressBar.Name = "PerformanceProgressBar";
            this.PerformanceProgressBar.Size = new System.Drawing.Size(267, 30);
            this.PerformanceProgressBar.TabIndex = 0;
            // 
            // progressValueLabel
            // 
            this.progressValueLabel.Location = new System.Drawing.Point(12, 61);
            this.progressValueLabel.Name = "progressValueLabel";
            this.progressValueLabel.Size = new System.Drawing.Size(382, 15);
            this.progressValueLabel.TabIndex = 1;
            this.progressValueLabel.Text = "View";
            this.progressValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(162, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AsyncWorker
            // 
            this.AsyncWorker.WorkerReportsProgress = true;
            this.AsyncWorker.WorkerSupportsCancellation = true;
            this.AsyncWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AsyncWorker_DoWork);
            this.AsyncWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AsyncWorker_ProgressChanged);
            this.AsyncWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AsyncWorker_RunWorkerCompleted_1);
            // 
            // TestProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(406, 238);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressValueLabel);
            this.Controls.Add(this.PerformanceProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestProgressBar";
            this.ResumeLayout(false);

        }

        #endregion
        private Label progressValueLabel;
        public ProgressBar PerformanceProgressBar;
        public Button cancelButton;
        private System.ComponentModel.BackgroundWorker AsyncWorker;
    }
}