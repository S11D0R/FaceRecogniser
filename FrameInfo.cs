using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace FaceRecogniser
{
    /// <summary>
    /// Информация о текущем кадре. 
    /// </summary>
    public class FrameInfo
    {
        private Image<Bgr, Byte> currentFrame;
        private Image<Gray, byte> result;
        private List<string> NamePersons = new List<string>();
        private int facesDetected, NumLabels;
        //Конструктор
        public FrameInfo()
        {
            currentFrame = null;
            result = null;
            NamePersons = null;
            facesDetected = 0;
            NumLabels = 0;
        }
        //Кнструктор с параметрами
        public FrameInfo(Image<Bgr, Byte> cFrame, Image<Gray, byte> res, 
            List<string> NPers, int fDetected, int nLabels)
        {
            currentFrame = cFrame;
            result = res;
            NamePersons = NPers;
            facesDetected = fDetected;
            NumLabels = nLabels;
        }
        //Метод установки данных
        public void setFrameInfo(Image<Bgr, Byte> cFrame, Image<Gray, byte> res,
            List<string> NPers, int fDetected)
        {
            currentFrame = cFrame;
            result = res;
            NamePersons = NPers;
            facesDetected = fDetected;
        }
        //Метод определения правильных условий для обучения
        public bool AllowTraining()
        {
            return ((facesDetected == 1) && (NamePersons.Count == 0));
        }
        //Получение текущего фрейма
        public Image<Bgr, Byte> getCurrentFrame()
        {
            return currentFrame;
        }
        //Получение текущего резкльтирующего изображения
        public Image<Gray, byte> getResult()
        {
            return result;
        }
        //Получение количества распознанных лиц
        public int getNumLabels()
        {
            return NumLabels;
        }
    }
}