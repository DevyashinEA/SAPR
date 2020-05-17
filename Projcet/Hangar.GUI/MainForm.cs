using HangarModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HangarGUI
{
    /// <summary>
    /// Класс главной формы, необходимый для заполнения основных пар-ров ангара.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// _textBoxes - Лист шести основных TextBox. Для их перебора во время проверки пар-ов.
        /// _hangarParam - класс, хранящий в себе введённые пар-ры ангара.
        /// </summary>
        private List<TextBox> _textBoxes = new List<TextBox>();
        private HangarParam _hangarParam = new HangarParam();

        /// <summary>
        /// Функция инициализирует элементы управления на экране и добавляет в лист основные поля ввода. 
        /// </summary>
        public MainForm(HangarParam hangarParam)
        {
            InitializeComponent();
            _hangarParam = hangarParam;
            _textBoxes.Add(textHangarHeight);
            _textBoxes.Add(textHangarLenght);
            _textBoxes.Add(textHangarWidth);
            _textBoxes.Add(textWallHeight);
            _textBoxes.Add(textGateHeight);
            _textBoxes.Add(textGateWidth);
        }

        /// <summary>
        /// Функция, срабатывающая при нажатии клавиш во время ввода текста в поля.
        /// Разрешает ввод только дробных чисел больше нуля.
        /// Запрещает нажатие букв, символов и сочетаний клавиш, чтобы ограничить ввод неверных значений.
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
        /// По мимо того, вызывает функцию для вывода ошибки, в случае возникновения исключения во время проверки.
        /// Также заполняет ProgressBar.
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CheckParamHangar(textBox);
            int i = 0;
            foreach (TextBox tb in _textBoxes)
            {
                if (tb.Text != string.Empty && tb.BackColor != Color.FromArgb(0xff, 0xe1, 0xe1))
                    i++;
            }
            if (i == 6)
            {
                try
                {
                    _hangarParam.CheckCompatibility();
                }
                catch (Exception ex)
                {
                    WriteErrors(ex.Message);
                }
                if (_hangarParam.HeightPiles != 0)
                    progress.Value = 100;
            }
            else
                progress.Value = i * 100 / 7;
        }

        /// <summary>
        /// Функция округляет значения до 10см, при переводе курсора на другой объект, чтобы избежать переполнения текстом ТекстБокса.
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
        /// Используется перегруженный метод для проверки, чтобы накапливать ошибки в параметре lineErrors, для дальнейшего его вывода.
        /// Вызывает метод CheckCompatibilitу, для проверки выносливости грунта.
        /// В случае удачи, закрывает форму.
        /// </summary>
        private void Ok_Click(object sender, EventArgs e)
        {
            string lineErrors = "";
            foreach (TextBox textBox in _textBoxes)
            {
                lineErrors = CheckParamHangar(textBox, lineErrors);
            }
            if (checkBoxThirdSoil.Checked == true)
            {
                lineErrors = CheckParamHangar(textThirdSoil, lineErrors);
                if (comboBoxThirdSoil.SelectedIndex == -1)
                {
                    WriteErrors("Не указан тип третьего слоя.");
                    lineErrors = lineErrors + labelError.Text + "\n";
                }
            }
            if (checkBoxSecondSoil.Checked == true)
            {
                lineErrors = CheckParamHangar(textSecondSoil, lineErrors);
                if (comboBoxSecondSoil.SelectedIndex == -1)
                {
                    WriteErrors("Не указан тип второго слоя.");
                    lineErrors = lineErrors + labelError.Text + "\n";
                }
            }
            lineErrors = CheckParamHangar(textFirstSoil, lineErrors);
            if (comboBoxFirstSoil.SelectedIndex == -1)
            {
                WriteErrors("Не указан тип первого слоя.");
                lineErrors = lineErrors + labelError.Text + "\n";
            }
            try
            {
                if (lineErrors == "")
                    _hangarParam.CheckCompatibility();
            }
            catch (Exception ex)
            {
                WriteErrors(ex.Message);
                lineErrors = lineErrors + labelError.Text + "\n";
            }
            if (lineErrors != "")
                MessageBox.Show(lineErrors);
            else
                Close();
        }

        /// <summary>
        /// Перегруженный метод проверки пар-ов.
        /// Добавляет к строке lineErrors ошибки, которые обнаружил другой метод CheckParamHangar.
        /// Таким образом происходит запись всех найденных ошибок за раз. 
        /// </summary>
        /// <param name="textBox">Проверяемый параметр.</param>
        /// <param name="lineErrors">Строка для записи ошибок.</param>
        /// <returns></returns>
        private string CheckParamHangar(TextBox textBox, string lineErrors)
        {
            CheckParamHangar(textBox);
            if (labelError.Text != "")
                lineErrors = lineErrors + labelError.Text + "\n";
            return lineErrors;
        }

        /// <summary>
        /// Основываясь на TextBox-e, производит запись соответствующего пар-ра в класс.
        /// При ошибке записывает в текст labelError сообщение исключения и окрашивает поле в красный.
        /// В случае, если ошибка не возникла, отчищает labelError и textBox, до изначального состояния.
        /// </summary>
        /// <param name="textBox">Текстбокс для проверки</param>
        private void CheckParamHangar(TextBox textBox)
        {
            try
            {
                if(textGateHeight == textBox)
                        _hangarParam.GateHeight = double.Parse(textGateHeight.Text);
                if (textGateWidth == textBox)
                        _hangarParam.GateWidth = double.Parse(textGateWidth.Text);
                if (textHangarHeight == textBox)
                        _hangarParam.HangarHeight = double.Parse(textHangarHeight.Text);
                if (textHangarLenght == textBox)
                        _hangarParam.HangarLength = double.Parse(textHangarLenght.Text);
                if (textHangarWidth == textBox)
                        _hangarParam.HangarWidth = double.Parse(textHangarWidth.Text);
                if (textWallHeight == textBox)
                        _hangarParam.WallHeight = double.Parse(textWallHeight.Text);
                if (textFirstSoil == textBox)
                {
                    _hangarParam.FirstSoil.SoilTypes = (SoilTypes)comboBoxFirstSoil.SelectedIndex;
                    _hangarParam.FirstSoil.Size = double.Parse(textFirstSoil.Text);
                }
                if (textSecondSoil == textBox)
                {
                    _hangarParam.SecondSoil.SoilTypes = (SoilTypes)comboBoxSecondSoil.SelectedIndex;
                    _hangarParam.SecondSoil.Size = double.Parse(textSecondSoil.Text);
                }
                if (textThirdSoil == textBox)
                {
                    _hangarParam.ThirdSoil.SoilTypes = (SoilTypes)comboBoxThirdSoil.SelectedIndex;
                    _hangarParam.ThirdSoil.Size = double.Parse(textThirdSoil.Text);
                }
                textBox.BackColor = Color.White;
                labelError.Text = "";
            }
            catch (Exception ex)
            {
                WriteErrors(ex.Message);
                textBox.BackColor = Color.FromArgb(0xff, 0xe1, 0xe1);
            }
        }

        /// <summary>
        /// Событие на изменение checkBox второго слоя.
        /// Если true - включается возможность ввода второго слоя и включение выбора третьего слоя.
        /// Если false - отключается возможность ввода второго слоя и выбора третьего слоя, отчищаются поля и их цвет.
        /// </summary>
        private void checkBoxSecondSoil_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSecondSoil.Enabled = checkBoxSecondSoil.Checked;
            textSecondSoil.Enabled = checkBoxSecondSoil.Checked;
            checkBoxThirdSoil.Enabled = checkBoxSecondSoil.Checked;
            if (checkBoxSecondSoil.Checked == false)
            {
                _hangarParam.SecondSoil = new Soil();
                textSecondSoil.Text = string.Empty;
                comboBoxSecondSoil.SelectedIndex = -1;
                checkBoxThirdSoil.Checked = false;
                textSecondSoil.BackColor = Color.FromArgb(240, 240, 240);
                textThirdSoil.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
                textSecondSoil.BackColor = Color.White;
        }

        /// <summary>
        /// Событие на изменение checkBox третьего слоя.
        /// Если true - включается возможность ввода третьего слоя.
        /// Если false - отключается возможность ввода третьего слоя, отчищаются поля и их цвет.
        /// </summary>
        private void checkBoxThirdSoil_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxThirdSoil.Enabled = checkBoxThirdSoil.Checked;
            textThirdSoil.Enabled = checkBoxThirdSoil.Checked;
            if (checkBoxThirdSoil.Checked == false)
            {
                _hangarParam.ThirdSoil = new Soil();
                textThirdSoil.Text = string.Empty;
                comboBoxThirdSoil.SelectedIndex = -1;
                textThirdSoil.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
                textThirdSoil.BackColor = Color.White;
        }

        /// <summary>
        /// Функция вывода ошибки в labelError на форме.
        /// </summary>
        /// <param name="error"></param>
        private void WriteErrors(string error)
        {
            labelError.Text = error;
        }

        /// <summary>
        /// Функция реагирующая на изменение ТрэкБара, которая заносит изменённое значение в снеговые нагрузки
        /// пар-ов ангара.
        /// А также изменяет текстовое поле на форме в соответствие выбранной нагрузке.
        /// </summary>
        private void snowLoadBar_Scroll(object sender, EventArgs e)
        {
            TrackBar bar = (TrackBar)sender;
            _hangarParam.SnowLoad = (int)(400 *bar.Value / 10 + 200);
            labelSnowLoad.Text = "Снеговые нагрузки, кг/м2=" + _hangarParam.SnowLoad;
            try
            {
                _hangarParam.CheckCompatibility();
                labelError.Text = "";
            }
            catch (Exception ex)
            {
                WriteErrors(ex.Message);
            }
        }
    }
}
