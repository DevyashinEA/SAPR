using HangarModel;
using System.Windows.Forms;

namespace HangarGUI
{
    public class Program
    {
        /// <summary>
        /// Фкнция для сбора проекта отдельно от API.
        /// </summary>
        static public void Main()
        {
            MessageBox.Show("Welcome!");
            HangarParam hangarParam = new HangarParam();
            Form mainForm = new MainForm(hangarParam);
            mainForm.ShowDialog();
        }
    }
}