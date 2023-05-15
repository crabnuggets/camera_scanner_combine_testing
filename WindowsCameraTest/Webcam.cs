using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace WebcamCapture
{
    public partial class WebcamForm : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        private string imgPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\img";

        private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
        private int counter = 0;

        public WebcamForm()
        {
            InitializeComponent();
            InitializeSerialPort();
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
            pictureBox.Image.Save(imgPath + $"\\{counter}.jpg");
            Stopwatch.Stop();
            Invoke(new Action(() =>
            {
                StopwatchLog.AppendText(Stopwatch.ElapsedMilliseconds.ToString()+"\r\n");
            }));
            counter += 1;
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

        /////////////////////////SCANNER START/////////////////////////////////////////////////////
        private SerialPort _serialPort;
        private void InitializeSerialPort()
        {
            _serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort.ReadExisting();
            Invoke(new Action(() =>
            {
                if (data.StartsWith("http"))
                {
                    Stopwatch.Restart();
                    Stopwatch.Start();
                    outputTextBox.AppendText(counter.ToString() + " " + data);
                    btnCapture_Click(null, null);
                }
            }));
        }

        private void ConnectScannerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                    ConnectScannerButton.Text = "Disconnect";
                }
                else
                {
                    _serialPort.Close();
                    ConnectScannerButton.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool activate = false;

        private void ActivateScannerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!activate)
                {
                    _serialPort.Write("Z");
                    ActivateScannerButton.Text = "Deactivate Scanner";
                    activate = true;
                }
                else
                {
                    _serialPort.Write("Y");
                    ActivateScannerButton.Text = "Activate Scanner";
                    activate = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
