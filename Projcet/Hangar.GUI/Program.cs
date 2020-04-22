using HangarModel;
using System.Windows.Forms;

namespace HangarGUI
{
    public class Program
    {
        static public void Main()
        {
            MessageBox.Show("Welcome!");
            HangarParam hangarParam = new HangarParam();
            Form mainForm = new MainForm(hangarParam);
            mainForm.ShowDialog();
        }
    }
}