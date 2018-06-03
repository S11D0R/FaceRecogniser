using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private TrainingCapture tCapture;
        private HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");
        private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        private List<string> labels = new List<string>();
        private int NumLabels, t;
        

        private const int TrainingSetMax = 50;

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
            tCapture = new TrainingCapture(TrainingGrabber, face, trainingImages, NumLabels, labels, this);
            //StartCapture();
        }

        private void StartCapture()
        {

            tCapture.StartCapture();
        }

        public void SetAmount(string am)
        {
            AmountCounter.Text = am;
        }

        private void StartTrainingButton_Click(object sender, EventArgs e)
        {
            FrameInfo fInfo = new FrameInfo();
            Image<Gray, byte> gray = null;
            int ContTrain;
            Image<Gray, byte> result = null;
            Image<Gray, byte> TrainedFace = null;
            Image<Bgr, Byte> currentFrame;
            for (int k = 0; k < TrainingSetMax; k++)
            {
                fInfo = tCapture.StartCapture();
                ContTrain = fInfo.getNumLabels();
                result = fInfo.getResult();
                currentFrame = fInfo.getCurrentFrame();
                if (fInfo.AllowTraining())
                {
                    try
                    {
                        //Trained face counter
                        ContTrain = ContTrain + 1;

                        //Get a gray frame from capture device
                        //gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        gray = currentFrame.Convert<Gray, Byte>();
                        //Face Detector
                        MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                        face,
                        1.2,
                        10,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20));

                        //Action for each element detected
                        foreach (MCvAvgComp f in facesDetected[0])
                        {
                            TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                            break;
                        }

                        //resize face detected image for force to compare the same size with the 
                        //test image with cubic interpolation type method
                        TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        trainingImages.Add(TrainedFace);
                        

                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                        //Write the labels of triained faces in a file text for further load
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                        }
                        
                    }
                    catch
                    {
                        MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }
        }

        public void UpdateForm(Image<Bgr, Byte> cFrame)
        {
            imageBoxFrameGrabber.Image = cFrame;
        }
    }
}
