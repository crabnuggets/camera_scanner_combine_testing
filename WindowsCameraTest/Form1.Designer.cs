using System.Windows.Forms;
using System;

namespace WebcamCapture
{
    partial class MainForm : Form
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
            this.pictureBox = new PictureBox();
            this.btnCapture = new Button();
            this.buttonSetResolution = new Button();
            this.textBoxWidth = new TextBox();
            this.textBoxHeight = new TextBox();
            this.comboBox1 = new ComboBox();

            this.SuspendLayout();

            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 480);
            this.pictureBox.TabIndex = 0;

            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(658, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(130, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new EventHandler(this.btnCapture_Click);

            // 
            // buttonSetResolution
            // 
            this.buttonSetResolution.Location = new System.Drawing.Point(658, 72);
            this.buttonSetResolution.Name = "buttonSetResolution";
            this.buttonSetResolution.Size = new System.Drawing.Size(130, 23);
            this.buttonSetResolution.TabIndex = 2;
            this.buttonSetResolution.Text = "Set Resolution";
            this.buttonSetResolution.UseVisualStyleBackColor = true;
            this.buttonSetResolution.Click += new EventHandler(this.buttonSetResolution_Click);

            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(658, 42);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(60, 20);
            this.textBoxWidth.TabIndex = 3;

            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(728, 42);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(60, 20);
            this.textBoxHeight.TabIndex = 4;

            //
            // comboBox1
            //
            this.comboBox1.Location = new System.Drawing.Point(658, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 23);
            this.comboBox1.TabIndex = 5;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.buttonSetResolution);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.pictureBox);
            this.Name = "MainForm";
            this.Text = "Camera Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}