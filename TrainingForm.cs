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

namespace MultiFaceRec
{
    public partial class TrainingForm : Form
    {
        private MainForm MainFormPtr;
        private Capture grabber;

        public TrainingForm(MainForm f)
        {
            InitializeComponent();
            InitializeGrabber();
            MainFormPtr = f;
        }

        private void InitializeGrabber()
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += IdleEvenHandler = new EventHandler(FrameGrabber);
            
        }

       
    }
}
