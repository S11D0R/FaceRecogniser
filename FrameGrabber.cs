using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceRecogniser
{
    /// <summary>
    /// Класс детектирования и идентификации лиц. 
    /// </summary>
    public class FrameGrabber
    {
        //Ссылка на главную форму
        private MainForm _mainForm;
        //Текущий захваченный кадр
        private Image<Bgr, Byte> currentFrame;
        //Объект захвата видеопотока с камеры
        private Capture grabber;
        //Каскад Хаара для детектирования лица
        private HaarCascade face;
        //Настройки шрифта
        private MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        //Изображение с выделенными и распознаными лицами
        private Image<Gray, byte> result;
        //Тренировочное изображение
        private Image<Gray, byte> TrainedFace = null;
        //Изображение в градациях серого
        private Image<Gray, byte> gray = null;
        //Тренировочные изображения
        private List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        //Иетки к изображениям лиц
        private List<string> labels = new List<string>();
        private List<string> NamePersons = new List<string>();
        //Служебные счетчики
        private int ContTrain;
        private int NumLabels;
        private int t;
        //Буферы меток к изображениям лиц
        private string name;
        private string names = null;
        //Флаг наличия человека в кадре
        private int NoPersonWarning;
        //конструктор
        public FrameGrabber(Capture gbr, HaarCascade face, List<Image<Gray, byte>> tImages, int numLabels, List<string> lbls, MainForm mainForm)
        {
            this.grabber = gbr;
            this.face = face;
            this.trainingImages = tImages;
            NumLabels = numLabels;
            labels = lbls;
            ContTrain = NumLabels;
            _mainForm = mainForm;
        }
        //Запуск идентификации лиц
        public void StartGrabber(object sender, EventArgs e)
        {
            _mainForm.SetAmount("0");
            NamePersons.Add("");
            //Получение кадра с камеры в градациях серого
            currentFrame = grabber.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            gray = currentFrame.Convert<Gray, Byte>();
            //Обнаружение лиц
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
            //Идентификация лиц
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Выделение лица на картинке
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //Переменная веса каждой новой итерации обучения
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                    //Распознавание лица
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                        trainingImages.ToArray(),
                        labels.ToArray(),
                        3000,
                        ref termCrit);
                    name = recognizer.Recognize(result);
                    //Прорисовка подписи к лицу
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                NamePersons[t - 1] = name;
                NamePersons.Add("");
                //Установка количества детектированных лиц
                _mainForm.SetAmount(facesDetected[0].Length.ToString());
            }
            t = 0;
            //Установка подписей распознанных людей
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                NoPersonWarning = 0;
                names = names + NamePersons[nnn] + ", ";
            }
            _mainForm.UpdateForm(currentFrame, names);
            //Определение наличия лица в кадре
            if (NoPersonWarning == 50) _mainForm.NoPersonAlarm();
            names = "";
            NamePersons.Clear();
            }
    }
}