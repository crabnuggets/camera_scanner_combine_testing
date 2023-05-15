using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebcamCapture
{
    public partial class WebcamForm : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        private string imgPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\img";

        public WebcamForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            FinalFrame = new VideoCaptureDevice();

            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0; // default camera using first device
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(imgPath))
            {
                Directory.CreateDirectory(imgPath);
            }
            pictureBox.Image.Save(imgPath + "\\capture.jpg");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.SignalToStop();
                FinalFrame.WaitForStop();
            }
        }

        private void buttonSetResolution_Click(object sender, EventArgs e)
        {
            int width = int.Parse(textBoxWidth.Text);
            int height = int.Parse(textBoxHeight.Text);

            // Get the closest matching resolution
            VideoCapabilities matchingResolution = FinalFrame.VideoCapabilities
                .OrderBy(x => Math.Abs((long)x.FrameSize.Width * x.FrameSize.Height - width * height))
                .First();

            if (matchingResolution.FrameSize.Width == width && matchingResolution.FrameSize.Height == height)
            {
                FinalFrame.SignalToStop();
                FinalFrame.WaitForStop();
                FinalFrame.VideoResolution = matchingResolution;
                FinalFrame.Start();
            }
            else
            {
                MessageBox.Show($"Desired resolution {width}x{height} is not supported. The closest available resolution {matchingResolution.FrameSize.Width}x{matchingResolution.FrameSize.Height} will be used.");
            }
        }

    }
}
