﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using FaceRecogniser;

namespace FaceRecogniser
{
    public partial class MainForm : Form
    {
        Capture grabber;
        HaarCascade face;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        private Image<Gray, byte> TrainedFace = null;
        int NumLabels, t, ContTrain;
        private Image<Gray, byte> gray = null;
        private Image<Gray, byte> result;
        private Image<Bgr, Byte> currentFrame;
        EventHandler IdleEvenHandler;

        public MainForm()
        {
            InitializeComponent();
            
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Load of previous trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                //ContTrain = NumLabels;
                string LoadFaces;
                ContTrain = NumLabels;
                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception e)
            {
                MessageBox.Show("Database loading error. Database is empty. Add new faces into database.", "Database loaded successfully.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void RunButton_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            FrameGrabber grabberHandler = new FrameGrabber(grabber, face, trainingImages, NumLabels, labels, this);
            Application.Idle += IdleEvenHandler = new EventHandler(grabberHandler.StartGrabber);
            RunButton.Enabled = false;
            StopButton.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopRecogniser();
        }

        private void AddFaceButton_Click(object sender, System.EventArgs e)
        {
            if (StopButton.Enabled) StopRecogniser();
            var tForm = new TrainingForm(this);
            tForm.Show();
            /* 
            
            
            */
        }

        /*
        void FrameGrabber(object sender, EventArgs e)
        {
            AmountCounter.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
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
                        t = t + 1;
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                        if (trainingImages.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                            //Draw the label for each face detected and recognized
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                        }

                            NamePersons[t-1] = name;
                            NamePersons.Add("");


                        //Set the number of faces detected on the scene
                        AmountCounter.Text = facesDetected[0].Length.ToString();
                       
                    }
                        t = 0;

                        //Names concatenation of persons recognized
                    for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                    {
                        names = names + NamePersons[nnn] + ", ";
                    }
                    //Show the faces procesed and recognized
                    imageBoxFrameGrabber.Image = currentFrame;
                    label4.Text = names;
                    names = "";
                    //Clear the list(vector) of names
                    NamePersons.Clear();

                }
        */

        public void SetAmount(string am)
        {
            AmountCounter.Text = am;
        }

        public void UpdateForm(Image<Bgr, Byte> cFrame, string sNames)
        {
            imageBoxFrameGrabber.Image = cFrame;
            label4.Text = sNames;
        }

        public void StopRecogniser()
        {
            Application.Idle -= IdleEvenHandler;
            grabber.Dispose();
            imageBoxFrameGrabber.Image = null;

            RunButton.Enabled = true;
            StopButton.Enabled = false;
        }

        public void NoPersonAlarm()
        {
            Application.Idle -= IdleEvenHandler;
            grabber.Dispose();
            imageBoxFrameGrabber.Image = null;

            RunButton.Enabled = true;
            StopButton.Enabled = false;
            MessageBox.Show("No persons on capture!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void AddExtraTrainigFace()
        {
            try
            {

                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

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
                labels.Add(AddNameTextBox.Text);

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