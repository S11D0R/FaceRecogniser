using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
        //Флаг разрешения тренировки
        private bool captureAllowed = true;
        //Количество тренировочных изображений
        private const int TrainingSetMax = 50;
        EventHandler IdleEvenHandler;
        public TrainingForm(MainForm f)
        {
            InitializeComponent();
            InitializeGrabber();
            MainFormPtr = f;
        }
        //Инициализация обработчика распознавания
        private void InitializeGrabber()
        {
            TrainingGrabber = new Capture();
            tCapture = new TrainingCapture(TrainingGrabber, face, trainingImages, NumLabels, labels, this);
            StartCapture();
        }
        //Запуск вывода резкльтата распознавания
        private void StartCapture()
        {
            Application.Idle += IdleEvenHandler = new EventHandler(tCapture.StartVoidCapture);
        }
        //Установцик счетчика детектированных лиц
        public void SetAmount(string am)
        {
            AmountCounter.Text = am;
        }
        //Обработчик кнопки старта тренировки
        private void StartTrainingButton_Click(object sender, EventArgs e)
        {
            captureAllowed = false;
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
                //Проверка на выполнение требований к тренировочному кадру
                while (fInfo.AllowTraining() == false)
                {
                    System.Threading.Thread.Sleep(5);
                    fInfo = tCapture.StartCapture();
                    ContTrain = fInfo.getNumLabels();
                    result = fInfo.getResult();
                    currentFrame = fInfo.getCurrentFrame();
                }
                FieldLight(k);
                    try
                    {
                        //Счетчик Тренировочных лиц 
                        ContTrain = ContTrain + 1;
                        //Получение кадра в градациях серого
                        gray = currentFrame.Convert<Gray, Byte>();
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
                        //Работа с фалами тренировочной базы
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
        //Обновление кадра
        public void UpdateForm(Image<Bgr, Byte> cFrame)
        {
            imageBoxFrameGrabber.Image = cFrame;
        }
        //Обработка подсветки сторон
        private void FieldLight(int iter)
        {
            switch (iter)
            {
                case 10:
                    LeftArrowPicture.BackColor = Color.Red;
                    RightArrowPicture.BackColor = Color.White;
                    TopArrowPicture.BackColor = Color.White;
                    BottomArrowPicture.BackColor = Color.White;
                    break;
                case 20:
                    LeftArrowPicture.BackColor = Color.White;
                    RightArrowPicture.BackColor = Color.Red;
                    TopArrowPicture.BackColor = Color.White;
                    BottomArrowPicture.BackColor = Color.White;
                    break;
                case 30:
                    LeftArrowPicture.BackColor = Color.White;
                    RightArrowPicture.BackColor = Color.White;
                    TopArrowPicture.BackColor = Color.Red;
                    BottomArrowPicture.BackColor = Color.White;
                    break;
                case 40:
                    LeftArrowPicture.BackColor = Color.White;
                    RightArrowPicture.BackColor = Color.White;
                    TopArrowPicture.BackColor = Color.White;
                    BottomArrowPicture.BackColor = Color.Red;
                    break;
                case 50:
                    LeftArrowPicture.BackColor = Color.White;
                    RightArrowPicture.BackColor = Color.White;
                    TopArrowPicture.BackColor = Color.White;
                    BottomArrowPicture.BackColor = Color.White;
                    break;
            }

        }
    }
}
