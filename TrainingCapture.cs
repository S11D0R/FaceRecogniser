using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceRecogniser
{
    /// <summary>
    /// Обработка создания тренировочной базы для нового лица. 
    /// </summary>
    public class TrainingCapture
    {
        //Форма добавления нового лица пользователя
        private TrainingForm _trainingForm;
        private Image<Bgr, Byte> currentFrame;
        private Capture grabber;
        private HaarCascade face;
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        private Image<Gray, byte> result;
        private Image<Gray, byte> TrainedFace = null;
        private Image<Gray, byte> gray = null;
        private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        private List<string> labels = new List<string>();
        private List<string> NamePersons = new List<string>();
        private int ContTrain;
        private int NumLabels;
        private int t;
        private string name;
        private string names = null;
        //конструктор
        public TrainingCapture(Capture gbr, HaarCascade fc, List<Image<Gray, byte>> tImages, int numLabels, List<string> lbls, TrainingForm mainForm)
        {
            this.grabber = gbr;
            this.face = fc;
            this.trainingImages = tImages;
            NumLabels = numLabels;
            labels = lbls;
            ContTrain = NumLabels;
            _trainingForm = mainForm;
        }
        //Запуск добавления лица
        public FrameInfo StartCapture()
        {

            grabber.QueryFrame();
            _trainingForm.SetAmount("0");
            NamePersons.Add("");
            //Получение изображения с камеры в градациях серого
            currentFrame = grabber.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
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
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>()
                    .Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                if (trainingImages.ToArray().Length != 0)
                {
                    //Параметр значимости тренировочного сета на тренировочный набор
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                    //Идентификация лиц
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                        trainingImages.ToArray(),
                        labels.ToArray(),
                        3000,
                        ref termCrit);
                        name = recognizer.Recognize(result);
                        //Выделение лица на изображении
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2),
                            new Bgr(Color.LightGreen));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");
                //Установка счетчика детектированных лиц
                _trainingForm.SetAmount(facesDetected[0].Length.ToString());
            }
            t = 0;
            //Установка строки имен
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Обновление формы
            _trainingForm.UpdateForm(currentFrame);
            names = "";
            FrameInfo frameInfo = new FrameInfo(currentFrame, result, NamePersons, facesDetected[0].Length, NumLabels);
            NamePersons.Clear();
            return frameInfo;
        }
        /// <summary>
        /// Останов обучения. 
        /// </summary>
        public void StartVoidCapture(object sender, EventArgs e)
        {
            StartCapture();
        }
    }
}