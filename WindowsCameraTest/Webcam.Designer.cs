using System.Windows.Forms;
using System;

namespace WebcamCapture
{
    partial class WebcamForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBox;
        private Button btnCapture;
        private Button buttonSetResolution;
        private TextBox textBoxWidth;
        private TextBox textBoxHeight;
        private ComboBox comboBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.buttonSetResolution = new System.Windows.Forms.Button();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.ConnectScannerButton = new System.Windows.Forms.Button();
            this.ActivateScannerButton = new System.Windows.Forms.Button();
            this.StopwatchLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(16, 15);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(853, 591);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(877, 15);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(173, 28);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // buttonSetResolution
            // 
            this.buttonSetResolution.Location = new System.Drawing.Point(877, 89);
            this.buttonSetResolution.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSetResolution.Name = "buttonSetResolution";
            this.buttonSetResolution.Size = new System.Drawing.Size(173, 28);
            this.buttonSetResolution.TabIndex = 2;
            this.buttonSetResolution.Text = "Set Resolution";
            this.buttonSetResolution.UseVisualStyleBackColor = true;
            this.buttonSetResolution.Click += new System.EventHandler(this.buttonSetResolution_Click);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(877, 52);
            this.textBoxWidth.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(79, 22);
            this.textBoxWidth.TabIndex = 3;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(971, 52);
            this.textBoxHeight.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(79, 22);
            this.textBoxHeight.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(877, 138);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(877, 181);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(356, 266);
            this.outputTextBox.TabIndex = 6;
            this.outputTextBox.Text = "";
            // 
            // ConnectScannerButton
            // 
            this.ConnectScannerButton.Location = new System.Drawing.Point(877, 471);
            this.ConnectScannerButton.Name = "ConnectScannerButton";
            this.ConnectScannerButton.Size = new System.Drawing.Size(162, 30);
            this.ConnectScannerButton.TabIndex = 7;
            this.ConnectScannerButton.Text = "Connect";
            this.ConnectScannerButton.UseVisualStyleBackColor = true;
            this.ConnectScannerButton.Click += new System.EventHandler(this.ConnectScannerButton_Click);
            // 
            // ActivateScannerButton
            // 
            this.ActivateScannerButton.Location = new System.Drawing.Point(877, 520);
            this.ActivateScannerButton.Name = "ActivateScannerButton";
            this.ActivateScannerButton.Size = new System.Drawing.Size(162, 26);
            this.ActivateScannerButton.TabIndex = 8;
            this.ActivateScannerButton.Text = "Activate Scanner";
            this.ActivateScannerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ActivateScannerButton.UseVisualStyleBackColor = true;
            this.ActivateScannerButton.Click += new System.EventHandler(this.ActivateScannerButton_Click);
            // 
            // StopwatchLog
            // 
            this.StopwatchLog.Location = new System.Drawing.Point(1058, 471);
            this.StopwatchLog.Name = "StopwatchLog";
            this.StopwatchLog.Size = new System.Drawing.Size(175, 107);
            this.StopwatchLog.TabIndex = 9;
            this.StopwatchLog.Text = "";
            // 
            // WebcamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 636);
            this.Controls.Add(this.StopwatchLog);
            this.Controls.Add(this.ActivateScannerButton);
            this.Controls.Add(this.ConnectScannerButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.buttonSetResolution);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WebcamForm";
            this.Text = "Camera Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox outputTextBox;
        private Button ConnectScannerButton;
        private Button ActivateScannerButton;
        private RichTextBox StopwatchLog;
    }
}