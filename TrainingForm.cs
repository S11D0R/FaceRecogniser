using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
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
            //Initialize the FrameGraber event
            //Application.Idle += IdleEvenHandler = new EventHandler(TrainingGrabber);
            
        }

       
    }
}
