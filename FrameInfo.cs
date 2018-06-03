using System;
using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace FaceRecogniser
{
    public class FrameInfo
    {
        private Image<Bgr, Byte> currentFrame;
        private Image<Gray, byte> result;
        private List<string> NamePersons = new List<string>();
        private int facesDetected, NumLabels;
       

        public FrameInfo()
        {
            currentFrame = null;
            result = null;
            NamePersons = null;
            facesDetected = 0;
            NumLabels = 0;
        }

        public FrameInfo(Image<Bgr, Byte> cFrame, Image<Gray, byte> res, 
            List<string> NPers, int fDetected, int nLabels)
        {
            currentFrame = cFrame;
            result = res;
            NamePersons = NPers;
            facesDetected = fDetected;
            NumLabels = nLabels;
        }

        public void setFrameInfo(Image<Bgr, Byte> cFrame, Image<Gray, byte> res,
            List<string> NPers, int fDetected)
        {
            currentFrame = cFrame;
            result = res;
            NamePersons = NPers;
            facesDetected = fDetected;
        }

        public bool AllowTraining()
        {
            return ((facesDetected == 1) && (NamePersons.Count == 0));

        }

        public Image<Bgr, Byte> getCurrentFrame()
        {
            return currentFrame;
        }
        public Image<Gray, byte> getResult()
        {
            return result;
        }
        public int getNumLabels()
        {
            return NumLabels;
        }
    }
}