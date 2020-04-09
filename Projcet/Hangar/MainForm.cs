using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Hangar
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// _textBoxes - Лист шести основных TextBox.
        /// _hangarParam - класс, хранящий в себе введённые пар-ры ангара.
        /// </summary>
        private List<TextBox> _textBoxes = new List<TextBox>();
        private HangarParam _hangarParam = new HangarParam();

        /// <summary>
        /// Функция инициализирует элементы управления на экране и добавляет в лист основные поля ввода. 
        /// </summary>
        public  MainForm()
        {
            InitializeComponent();
            _textBoxes.Add(textHangarHeight);
            _textBoxes.Add(textHangarLenght);
            _textBoxes.Add(textHangarWidth);
            _textBoxes.Add(textWallHeight);
            _textBoxes.Add(textGateHeight);
            _textBoxes.Add(textGateWidth);
        }

        /// <summary>
        /// Функция, срабатывающая при нажатии клавиш во время ввода текста в поля, которая разрешает ввод только дробных чисел больше нуля.
        /// </summary>
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!double.TryParse(textBox.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                if (!((e.KeyChar > 47 && e.KeyChar < 58) && e.KeyChar == 46))
                    e.Handled = true;
            }
        }

        /// <summary>
        /// Функция срабатывает на событие изменения текста в TextBox и производит отправку изменённого поля на проверку содержимого. 
        /// По мимо того, выводит ошибку о неправильном вводе, в случае возникновения исключения во время проверки.
        /// Также заполняет ProgressBar.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int i = 0;
            foreach (TextBox tb in _textBoxes)
            {
                if (tb.Text != string.Empty)
                    i++;
            }
            progress.Value = i * 100 / 6;
            try
            {
                CheckParamHangar(textBox);
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
                textBox.BackColor = Color.FromArgb(0xff, 0xe1, 0xe1);
            }
        }

        /// <summary>
        /// Функция округляет значения до 10см, при переводе курсора на другой TextBox
        /// </summary>
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "")
                textBox.Text = Math.Round(double.Parse(textBox.Text), 1).ToString();
        }

        /// <summary>
        /// Событие нажатия кнопки "Ок". Производит проверку всех полей листа _textBoxes и пар-ов грунта, 
        /// (в случае исключения, выводит ошибку не только в label на форме, но и вызывает MessageBox)
        /// Создаёт класс проектирования и вызывает метод CheckCompatibilitу, после чего закрывает форму.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TextBox textBox in _textBoxes)
                {
                    textBox.BackColor = Color.FromArgb(0xff, 0xe1, 0xe1);
                    CheckParamHangar(textBox);
                }
                if (checkBoxThirdSoil.Checked == true)
                {
                    CheckParamHangar(textThirdSoil);
                    if (comboBoxThirdSoil.SelectedIndex == -1)
                        throw new NullReferenceException("Указаны не все параметры грунта.");
                }
                if (checkBoxSecondSoil.Checked == true)
                { 
                    CheckParamHangar(textSecondSoil);
                    if (comboBoxSecondSoil.SelectedIndex == -1)
                        throw new NullReferenceException("Указаны не все параметры грунта.");
                }
                CheckParamHangar(textFirstSoil);
                if (comboBoxFirstSoil.SelectedIndex == -1)
                    throw new NullReferenceException("Указаны не все параметры грунта.");
                Desing desing = new Desing();
                desing.hangarParam = _hangarParam;
                desing.CheckCompatibility();
                Close();
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Основываясь на имени TextBox-а, производит запись соответствующего пар-ра в класс,
        /// в случае, если ошибка не воникла, отчищает labelError и textBox, до изначального состояния.
        /// Если поле было пустым, то выбрасывает исключение.
        /// </summary>
        /// <param name="textBox">Принимает TextBox для последующей проверки</param>
        private void CheckParamHangar(TextBox textBox)
        {
            if (textBox.Text != string.Empty)
            {
                switch (textBox.Name)
                {
                    case "textGateHeight":
                        _hangarParam.GateHeight = double.Parse(textGateHeight.Text);
                        break;
                    case "textGateWidth":
                        _hangarParam.GateWidth = double.Parse(textGateWidth.Text);
                        break;
                    case "textHangarHeight":
                        _hangarParam.HangarHeight = double.Parse(textHangarHeight.Text);
                        break;
                    case "textHangarLenght":
                        _hangarParam.HangarLength = double.Parse(textHangarLenght.Text);
                        break;
                    case "textHangarWidth":
                        _hangarParam.HangarWidth = double.Parse(textHangarWidth.Text);
                        break;
                    case "textWallHeight":
                        _hangarParam.WallHeight = double.Parse(textWallHeight.Text);
                        break;
                    case "textFirstSoil":
                        _hangarParam.FirstSoil.SoilTypes = (SoilTypes)comboBoxFirstSoil.SelectedIndex;
                        _hangarParam.FirstSoil.Size = double.Parse(textFirstSoil.Text);
                        break;
                    case "textSecondSoil":
                        _hangarParam.SecondSoil.SoilTypes = (SoilTypes)comboBoxSecondSoil.SelectedIndex;
                        _hangarParam.SecondSoil.Size = double.Parse(textSecondSoil.Text);
                        break;
                    case "textThirdSoil":
                        _hangarParam.ThirdSoil.SoilTypes = (SoilTypes)comboBoxThirdSoil.SelectedIndex;
                        _hangarParam.ThirdSoil.Size = double.Parse(textThirdSoil.Text);
                        break;
                }
                textBox.BackColor = Color.White;
                labelError.Text = string.Empty;
            }
            else
                throw new ArgumentException("Некоторые или все поля пусты.");
        }

        /// <summary>
        /// Событие на изменение checkBox второго слоя.
        /// Если true - включается возможность ввода второго слоя и включение третьего слоя
        /// Если false - отключается возможность ввода второго слоя и включения третьего слоя
        /// </summary>
        private void checkBoxSecondSoil_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSecondSoil.Enabled = checkBoxSecondSoil.Checked;
            textSecondSoil.Enabled = checkBoxSecondSoil.Checked;
            checkBoxThirdSoil.Enabled = checkBoxSecondSoil.Checked;
            if (checkBoxSecondSoil.Checked == false)
            {
                _hangarParam.SecondSoil = null;
                textSecondSoil.Text = string.Empty;
                comboBoxSecondSoil.SelectedIndex = -1;
                checkBoxThirdSoil.Checked = false;
            }
        }

        /// <summary>
        /// Событие на изменение checkBox третьего слоя.
        /// Если true - включается возможность ввода третьего слоя
        /// Если false - отключается возможность ввода третьего слоя 
        /// </summary>
        private void checkBoxThirdSoil_CheckedChanged(object sender, EventArgs e)
        {
                comboBoxThirdSoil.Enabled = checkBoxThirdSoil.Checked;
                textThirdSoil.Enabled = checkBoxThirdSoil.Checked;
            if (checkBoxThirdSoil.Checked == false)
            {
                _hangarParam.ThirdSoil = null;
                textThirdSoil.Text = string.Empty;
                comboBoxThirdSoil.SelectedIndex = -1;
            }
        }
    }
}
