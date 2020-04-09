using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;

namespace CreaterHangar
{
    public class Program
    {
        /// <summary>
        /// Commands реализует интерфейс автокада, храня в себе обязательные методы.
        /// </summary>
        public class Commands : IExtensionApplication
        {

            // функция Initialize() необходима, чтобы реализовать интерфейс IExtensionApplication. Запускается при загрузке библиотеки.
            public void Initialize()
            {
                MessageBox.Show("Welcome!");
                Form mainForm = new Hangar.MainForm();
                mainForm.Show();
            }

            // функция Terminate() необходима, чтобы реализовать интерфейс IExtensionApplication. Запускается при закрытии автокада.
            public void Terminate()
            {

            }
        }
    }
}