using System;
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
        //Объект захвата видеопотока с камеры 
        Capture grabber;
        //Каскад Хаара для детектирования лица
        HaarCascade face;
        //Тренировочные изображения
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        //Подписи к тренировочным изображениям
        List<string> labels= new List<string>();
        //Тренировочное изображение
        private Image<Gray, byte> TrainedFace = null;
        //Служебные счетчики
        int NumLabels, t, ContTrain;
        //Изображение в градациях серого
        private Image<Gray, byte> gray = null;
        //Изображение с выделенными и распознаными лицами
        private Image<Gray, byte> result;
        //Текущий захваченный кадр
        private Image<Bgr, Byte> currentFrame;
        //Обработчик простоя
        EventHandler IdleEvenHandler;

        public MainForm()
        {
            //Инициализация при запуске. 
            InitializeComponent();
            //Загрузка необходимого каскада
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                //Загрузка тренировочной базы
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
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
        /// <summary>
        /// Обработчик кнопки запуска распознавания. 
        /// </summary>
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
        /// <summary>
        /// Обработчик кнопки останова распознавания. 
        /// </summary>
        private void StopButton_Click(object sender, EventArgs e)
        {
            StopRecogniser();
        }
        /// <summary>
        /// Обработчик кнопки добавления нового лица пользователя. 
        /// </summary>
        private void AddFaceButton_Click(object sender, System.EventArgs e)
        {
            if (StopButton.Enabled) StopRecogniser();
            var tForm = new TrainingForm(this);
            tForm.Show();
        }
        /// <summary>
        /// Установка счетчика детектированных лиц. 
        /// </summary>
        public void SetAmount(string am)
        {
            AmountCounter.Text = am;
        }
        /// <summary>
        /// Обновление кадра и подписей. 
        /// </summary>
        public void UpdateForm(Image<Bgr, Byte> cFrame, string sNames)
        {
            imageBoxFrameGrabber.Image = cFrame;
            label4.Text = sNames;
        }
        /// <summary>
        /// Останов распознавания. 
        /// </summary>
        public void StopRecogniser()
        {
            Application.Idle -= IdleEvenHandler;
            grabber.Dispose();
            imageBoxFrameGrabber.Image = null;

            RunButton.Enabled = true;
            StopButton.Enabled = false;
        }
        /// <summary>
        /// Сообщение о длительном выходе человека из кадра. 
        /// </summary>
        public void NoPersonAlarm()
        {
            Application.Idle -= IdleEvenHandler;
            grabber.Dispose();
            imageBoxFrameGrabber.Image = null;

            RunButton.Enabled = true;
            StopButton.Enabled = false;
            MessageBox.Show("No persons on capture!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>
        /// Добавление дополнительного лица к тренировочной базе пользователя. 
        /// </summary>
        public void AddExtraTrainigFace()
        {
            try
            {
                //Увеличение счетчика тренировочных объектов
                ContTrain = ContTrain + 1;
                //Полечение черно-белого изображения с камеры
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Детектирование лиц
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(AddNameTextBox.Text);
                //Изменеие файлов тренировочно базы
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
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