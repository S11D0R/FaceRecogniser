using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FaceRecogniser
{
    /// <summary>
    /// Главный класс приложения. 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Главная функция. 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Запуск главной формы
            Application.Run(new MainForm());
        }
    }
}
