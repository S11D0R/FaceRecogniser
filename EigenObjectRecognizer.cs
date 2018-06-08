using System;
using System.Diagnostics;
using Emgu.CV.Structure;

namespace Emgu.CV
{
   /// <summary>
   /// Распознавание лиц с использованием метода PCA 
   /// </summary>
   [Serializable]
   public class EigenObjectRecognizer
   {
      //Ихображения для обработки
      private Image<Gray, Single>[] _eigenImages;
      //Среднее тренировочных изображений
      private Image<Gray, Single> _avgImage;
      //Матрица единиц совпадения изображений
      private Matrix<float>[] _eigenValues;
      //Метки изображений
      private string[] _labels;
      //Полоса пропускания для совпадения изображений
      private double _eigenDistanceThreshold;
      //Массив изображений для обработки
      public Image<Gray, Single>[] EigenImages
      {
         get { return _eigenImages; }
         set { _eigenImages = value; }
      }
      /// <summary>
      /// Установка подписей к изображениям
      /// </summary>
      public String[] Labels
      {
         get { return _labels; }
         set { _labels = value; }
      }
      /// <summary>
      /// Изменение или получение совпадения при сравнении
      /// </summary>
      public double EigenDistanceThreshold
      {
         get { return _eigenDistanceThreshold; }
         set { _eigenDistanceThreshold = value; }
      }
      /// <summary>
      /// Изменеие или получение среднего из тренировочной базы. 
      /// </summary>
      public Image<Gray, Single> AverageImage
      {
         get { return _avgImage; }
         set { _avgImage = value; }
      }

      /// <summary>
      /// Изменеие или получение совпадения для каждого изображения. 
      /// </summary>
        public Matrix<float>[] EigenValues
      {
         get { return _eigenValues; }
         set { _eigenValues = value; }
      }
      //Конструктор
      private EigenObjectRecognizer()
      {
      }
      /// <summary>
      /// Конструктор с параметрами
      /// </summary>
      public EigenObjectRecognizer(Image<Gray, Byte>[] images, ref MCvTermCriteria termCrit)
         : this(images, GenerateLabels(images.Length), ref termCrit)
      {
      }
      private static String[] GenerateLabels(int size)
      {
         String[] labels = new string[size];
         for (int i = 0; i < size; i++)
            labels[i] = i.ToString();
         return labels;
      }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public EigenObjectRecognizer(Image<Gray, Byte>[] images, String[] labels, ref MCvTermCriteria termCrit)
         : this(images, labels, 0, ref termCrit)
      {
      }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="eigenDistanceThreshold"> Отвечает за точность распознавания (0, ~1000]
        public EigenObjectRecognizer(Image<Gray, Byte>[] images, String[] labels, double eigenDistanceThreshold, ref MCvTermCriteria termCrit)
        {
            Debug.Assert(images.Length == labels.Length, "The number of images should equals the number of labels");
            Debug.Assert(eigenDistanceThreshold >= 0.0, "Eigen-distance threshold should always >= 0.0");
            CalcEigenObjects(images, ref termCrit, out _eigenImages, out _avgImage);
            _eigenValues = Array.ConvertAll<Image<Gray, Byte>, Matrix<float>>(images,
                delegate(Image<Gray, Byte> img)
                {
                   return new Matrix<float>(EigenDecomposite(img, _eigenImages, _avgImage));
                });
            _labels = labels;
            _eigenDistanceThreshold = eigenDistanceThreshold;
        }

      #region static methods
      /// <summary>
      /// Вычисление среднего из тренировочной базы
      /// </summary>
      /// <param name="avg">Результирующее среднее</param>
      public static void CalcEigenObjects(Image<Gray, Byte>[] trainingImages, ref MCvTermCriteria termCrit, out Image<Gray, Single>[] eigenImages, out Image<Gray, Single> avg)
      {
         int width = trainingImages[0].Width;
         int height = trainingImages[0].Height;
         IntPtr[] inObjs = Array.ConvertAll<Image<Gray, Byte>, IntPtr>(trainingImages, delegate(Image<Gray, Byte> img) { return img.Ptr; });
         if (termCrit.max_iter <= 0 || termCrit.max_iter > trainingImages.Length)
            termCrit.max_iter = trainingImages.Length;
         int maxEigenObjs = termCrit.max_iter;
         #region initialize eigen images
         eigenImages = new Image<Gray, float>[maxEigenObjs];
         for (int i = 0; i < eigenImages.Length; i++)
            eigenImages[i] = new Image<Gray, float>(width, height);
         IntPtr[] eigObjs = Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate(Image<Gray, Single> img) { return img.Ptr; });
         #endregion
         avg = new Image<Gray, Single>(width, height);
         CvInvoke.cvCalcEigenObjects(
             inObjs,
             ref termCrit,
             eigObjs,
             null,
             avg.Ptr);
      }
      /// <summary>
      /// Вычисление декомпозиции изображений
      /// </summary>
      public static float[] EigenDecomposite(Image<Gray, Byte> src, Image<Gray, Single>[] eigenImages, Image<Gray, Single> avg)
      {
         return CvInvoke.cvEigenDecomposite(
             src.Ptr,
             Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate(Image<Gray, Single> img) { return img.Ptr; }),
             avg.Ptr);
      }
      #endregion
      /// <summary>
      /// Вычисление проекций изображений
      /// </summary>
      public Image<Gray, Byte> EigenProjection(float[] eigenValue)
      {
         Image<Gray, Byte> res = new Image<Gray, byte>(_avgImage.Width, _avgImage.Height);
         CvInvoke.cvEigenProjection(
             Array.ConvertAll<Image<Gray, Single>, IntPtr>(_eigenImages, delegate(Image<Gray, Single> img) { return img.Ptr; }),
             eigenValue,
             _avgImage.Ptr,
             res.Ptr);
         return res;
      }
      /// <summary>
      /// Вычислет различие между заданным изображением и изображениями тренировочной базы
      /// </summary>
      /// <param name="image">Заданное изображение</param>
      /// <returns>Массив различительных величин</returns>
      public float[] GetEigenDistances(Image<Gray, Byte> image)
      {
         using (Matrix<float> eigenValue = new Matrix<float>(EigenDecomposite(image, _eigenImages, _avgImage)))
            return Array.ConvertAll<Matrix<float>, float>(_eigenValues,
                delegate(Matrix<float> eigenValueI)
                {
                   return (float)CvInvoke.cvNorm(eigenValue.Ptr, eigenValueI.Ptr, Emgu.CV.CvEnum.NORM_TYPE.CV_L2, IntPtr.Zero);
                });
      }
      /// <summary>
      /// Поиск самого похожего объекта по тренировочной базе
      /// </summary>
      public void FindMostSimilarObject(Image<Gray, Byte> image, out int index, out float eigenDistance, out String label)
      {
         float[] dist = GetEigenDistances(image);

         index = 0;
         eigenDistance = dist[0];
         for (int i = 1; i < dist.Length; i++)
         {
            if (dist[i] < eigenDistance)
            {
               index = i;
               eigenDistance = dist[i];
            }
         }
         label = Labels[index];
      }
        /// <summary>
      /// Распознавание изображения, возвращает метку распознанного изображения, либо пустую строку
      /// </summary>
      public String Recognize(Image<Gray, Byte> image)
      {
         int index;
         float eigenDistance;
         String label;
         FindMostSimilarObject(image, out index, out eigenDistance, out label);

         return (_eigenDistanceThreshold <= 0 || eigenDistance < _eigenDistanceThreshold )  ? _labels[index] : String.Empty;
      }
   }
}
