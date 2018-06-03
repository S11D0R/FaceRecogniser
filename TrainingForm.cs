using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using FaceRecogniser;

namespace FaceRecogniser
{
    public partial class TrainingForm : Form
    {
        private MainForm MainFormPtr;
        private Capture TrainingGrabber;

        public TrainingForm(MainForm f)
        {
            InitializeComponent();
            InitializeGrabber();
            MainFormPtr = f;
        }

        private void InitializeGrabber()
        {
            //Initialize the capture device
            TrainingGrabber = new Capture();
            TrainingGrabber.QueryFrame();
            
            
        }

        public void SetAmount(string am)
        {
            AmountCounter.Text = am;
        }

        public void UpdateForm(Image<Bgr, Byte> cFrame)
        {
            imageBoxFrameGrabber.Image = cFrame;
        }
    }
}
