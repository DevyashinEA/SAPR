namespace Hangar
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelFirstSoil = new System.Windows.Forms.Panel();
            this.textFirstSoil = new System.Windows.Forms.TextBox();
            this.comboBoxFirstSoil = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelSecondSoil = new System.Windows.Forms.Panel();
            this.textSecondSoil = new System.Windows.Forms.TextBox();
            this.comboBoxSecondSoil = new System.Windows.Forms.ComboBox();
            this.checkBoxSecondSoil = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelThirdSoil = new System.Windows.Forms.Panel();
            this.textThirdSoil = new System.Windows.Forms.TextBox();
            this.comboBoxThirdSoil = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxThirdSoil = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textHangarHeight = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.panelHangar = new System.Windows.Forms.Panel();
            this.textWallHeight = new System.Windows.Forms.TextBox();
            this.textGateWidth = new System.Windows.Forms.TextBox();
            this.textGateHeight = new System.Windows.Forms.TextBox();
            this.textHangarWidth = new System.Windows.Forms.TextBox();
            this.textHangarLenght = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.panelFirstSoil.SuspendLayout();
            this.panelSecondSoil.SuspendLayout();
            this.panelThirdSoil.SuspendLayout();
            this.panelHangar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFirstSoil
            // 
            this.panelFirstSoil.Controls.Add(this.textFirstSoil);
            this.panelFirstSoil.Controls.Add(this.comboBoxFirstSoil);
            this.panelFirstSoil.Controls.Add(this.label8);
            this.panelFirstSoil.Controls.Add(this.label7);
            this.panelFirstSoil.Location = new System.Drawing.Point(12, 12);
            this.panelFirstSoil.Name = "panelFirstSoil";
            this.panelFirstSoil.Size = new System.Drawing.Size(188, 132);
            this.panelFirstSoil.TabIndex = 12;
            // 
            // textFirstSoil
            // 
            this.textFirstSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textFirstSoil.Location = new System.Drawing.Point(3, 96);
            this.textFirstSoil.Name = "textFirstSoil";
            this.textFirstSoil.Size = new System.Drawing.Size(142, 26);
            this.textFirstSoil.TabIndex = 13;
            this.textFirstSoil.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textFirstSoil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textFirstSoil.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // comboBoxFirstSoil
            // 
            this.comboBoxFirstSoil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFirstSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxFirstSoil.FormattingEnabled = true;
            this.comboBoxFirstSoil.Items.AddRange(new object[] {
            "Щебень",
            "Пески крупные",
            "Пески средние",
            "Пески мелкие",
            "Суспеси",
            "Суглинки",
            "Глины твёрдые",
            "Глины пластичные"});
            this.comboBoxFirstSoil.Location = new System.Drawing.Point(3, 32);
            this.comboBoxFirstSoil.Name = "comboBoxFirstSoil";
            this.comboBoxFirstSoil.Size = new System.Drawing.Size(142, 28);
            this.comboBoxFirstSoil.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 67);
            this.label8.MinimumSize = new System.Drawing.Size(142, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Высота грунта, м";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.MinimumSize = new System.Drawing.Size(142, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Первый слой грунта";
            // 
            // panelSecondSoil
            // 
            this.panelSecondSoil.Controls.Add(this.textSecondSoil);
            this.panelSecondSoil.Controls.Add(this.comboBoxSecondSoil);
            this.panelSecondSoil.Controls.Add(this.checkBoxSecondSoil);
            this.panelSecondSoil.Controls.Add(this.label9);
            this.panelSecondSoil.Location = new System.Drawing.Point(12, 150);
            this.panelSecondSoil.Name = "panelSecondSoil";
            this.panelSecondSoil.Size = new System.Drawing.Size(188, 121);
            this.panelSecondSoil.TabIndex = 16;
            // 
            // textSecondSoil
            // 
            this.textSecondSoil.Enabled = false;
            this.textSecondSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textSecondSoil.Location = new System.Drawing.Point(3, 83);
            this.textSecondSoil.Name = "textSecondSoil";
            this.textSecondSoil.Size = new System.Drawing.Size(142, 26);
            this.textSecondSoil.TabIndex = 19;
            this.textSecondSoil.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textSecondSoil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textSecondSoil.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // comboBoxSecondSoil
            // 
            this.comboBoxSecondSoil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecondSoil.Enabled = false;
            this.comboBoxSecondSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSecondSoil.FormattingEnabled = true;
            this.comboBoxSecondSoil.Items.AddRange(new object[] {
            "Щебень",
            "Пески крупные",
            "Пески средние",
            "Пески мелкие",
            "Суспеси",
            "Суглинки",
            "Глины твёрдые",
            "Глины пластичные"});
            this.comboBoxSecondSoil.Location = new System.Drawing.Point(3, 25);
            this.comboBoxSecondSoil.Name = "comboBoxSecondSoil";
            this.comboBoxSecondSoil.Size = new System.Drawing.Size(142, 28);
            this.comboBoxSecondSoil.TabIndex = 18;
            // 
            // checkBoxSecondSoil
            // 
            this.checkBoxSecondSoil.AutoSize = true;
            this.checkBoxSecondSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSecondSoil.Location = new System.Drawing.Point(7, 2);
            this.checkBoxSecondSoil.Name = "checkBoxSecondSoil";
            this.checkBoxSecondSoil.Size = new System.Drawing.Size(178, 24);
            this.checkBoxSecondSoil.TabIndex = 16;
            this.checkBoxSecondSoil.Text = "Второй слой грунта";
            this.checkBoxSecondSoil.UseVisualStyleBackColor = true;
            this.checkBoxSecondSoil.CheckedChanged += new System.EventHandler(this.checkBoxSecondSoil_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 60);
            this.label9.MinimumSize = new System.Drawing.Size(142, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Высота грунта, м";
            // 
            // panelThirdSoil
            // 
            this.panelThirdSoil.Controls.Add(this.textThirdSoil);
            this.panelThirdSoil.Controls.Add(this.comboBoxThirdSoil);
            this.panelThirdSoil.Controls.Add(this.label10);
            this.panelThirdSoil.Controls.Add(this.checkBoxThirdSoil);
            this.panelThirdSoil.Location = new System.Drawing.Point(12, 277);
            this.panelThirdSoil.Name = "panelThirdSoil";
            this.panelThirdSoil.Size = new System.Drawing.Size(188, 128);
            this.panelThirdSoil.TabIndex = 17;
            // 
            // textThirdSoil
            // 
            this.textThirdSoil.Enabled = false;
            this.textThirdSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textThirdSoil.Location = new System.Drawing.Point(3, 90);
            this.textThirdSoil.Name = "textThirdSoil";
            this.textThirdSoil.Size = new System.Drawing.Size(142, 26);
            this.textThirdSoil.TabIndex = 20;
            this.textThirdSoil.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textThirdSoil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textThirdSoil.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // comboBoxThirdSoil
            // 
            this.comboBoxThirdSoil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThirdSoil.Enabled = false;
            this.comboBoxThirdSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxThirdSoil.FormattingEnabled = true;
            this.comboBoxThirdSoil.Items.AddRange(new object[] {
            "Щебень",
            "Пески крупные",
            "Пески средние",
            "Пески мелкие",
            "Суспеси",
            "Суглинки",
            "Глины твёрдые",
            "Глины пластичные"});
            this.comboBoxThirdSoil.Location = new System.Drawing.Point(3, 32);
            this.comboBoxThirdSoil.Name = "comboBoxThirdSoil";
            this.comboBoxThirdSoil.Size = new System.Drawing.Size(142, 28);
            this.comboBoxThirdSoil.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 67);
            this.label10.MinimumSize = new System.Drawing.Size(142, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Высота грунта, м";
            // 
            // checkBoxThirdSoil
            // 
            this.checkBoxThirdSoil.AutoSize = true;
            this.checkBoxThirdSoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxThirdSoil.Location = new System.Drawing.Point(7, 2);
            this.checkBoxThirdSoil.Name = "checkBoxThirdSoil";
            this.checkBoxThirdSoil.Size = new System.Drawing.Size(176, 24);
            this.checkBoxThirdSoil.TabIndex = 16;
            this.checkBoxThirdSoil.Text = "Третий слой грунта";
            this.checkBoxThirdSoil.UseVisualStyleBackColor = true;
            this.checkBoxThirdSoil.CheckedChanged += new System.EventHandler(this.checkBoxThirdSoil_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.MinimumSize = new System.Drawing.Size(142, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Высота ворот, м";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 131);
            this.label5.MinimumSize = new System.Drawing.Size(142, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ширина ворот, м";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(2, 163);
            this.label6.MinimumSize = new System.Drawing.Size(142, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Высота стены, м";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ширина ангара, м";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.MinimumSize = new System.Drawing.Size(142, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Длина ангара, м";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.MinimumSize = new System.Drawing.Size(142, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Высота ангара, м";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textHangarHeight
            // 
            this.textHangarHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textHangarHeight.Location = new System.Drawing.Point(151, 3);
            this.textHangarHeight.Name = "textHangarHeight";
            this.textHangarHeight.Size = new System.Drawing.Size(63, 26);
            this.textHangarHeight.TabIndex = 18;
            this.textHangarHeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textHangarHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textHangarHeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // Ok
            // 
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.Location = new System.Drawing.Point(347, 375);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(81, 30);
            this.Ok.TabIndex = 30;
            this.Ok.Text = "Ок";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // panelHangar
            // 
            this.panelHangar.Controls.Add(this.textWallHeight);
            this.panelHangar.Controls.Add(this.textGateWidth);
            this.panelHangar.Controls.Add(this.textGateHeight);
            this.panelHangar.Controls.Add(this.textHangarWidth);
            this.panelHangar.Controls.Add(this.textHangarLenght);
            this.panelHangar.Controls.Add(this.label1);
            this.panelHangar.Controls.Add(this.textHangarHeight);
            this.panelHangar.Controls.Add(this.label4);
            this.panelHangar.Controls.Add(this.label2);
            this.panelHangar.Controls.Add(this.label5);
            this.panelHangar.Controls.Add(this.label3);
            this.panelHangar.Controls.Add(this.label6);
            this.panelHangar.Location = new System.Drawing.Point(206, 12);
            this.panelHangar.Name = "panelHangar";
            this.panelHangar.Size = new System.Drawing.Size(222, 191);
            this.panelHangar.TabIndex = 32;
            // 
            // textWallHeight
            // 
            this.textWallHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWallHeight.Location = new System.Drawing.Point(151, 160);
            this.textWallHeight.Name = "textWallHeight";
            this.textWallHeight.Size = new System.Drawing.Size(63, 26);
            this.textWallHeight.TabIndex = 34;
            this.textWallHeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textWallHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textWallHeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textGateWidth
            // 
            this.textGateWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textGateWidth.Location = new System.Drawing.Point(151, 128);
            this.textGateWidth.Name = "textGateWidth";
            this.textGateWidth.Size = new System.Drawing.Size(63, 26);
            this.textGateWidth.TabIndex = 33;
            this.textGateWidth.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textGateWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textGateWidth.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textGateHeight
            // 
            this.textGateHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textGateHeight.Location = new System.Drawing.Point(151, 96);
            this.textGateHeight.Name = "textGateHeight";
            this.textGateHeight.Size = new System.Drawing.Size(63, 26);
            this.textGateHeight.TabIndex = 32;
            this.textGateHeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textGateHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textGateHeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textHangarWidth
            // 
            this.textHangarWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textHangarWidth.Location = new System.Drawing.Point(151, 64);
            this.textHangarWidth.Name = "textHangarWidth";
            this.textHangarWidth.Size = new System.Drawing.Size(63, 26);
            this.textHangarWidth.TabIndex = 31;
            this.textHangarWidth.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textHangarWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textHangarWidth.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textHangarLenght
            // 
            this.textHangarLenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textHangarLenght.Location = new System.Drawing.Point(151, 32);
            this.textHangarLenght.Name = "textHangarLenght";
            this.textHangarLenght.Size = new System.Drawing.Size(63, 26);
            this.textHangarLenght.TabIndex = 30;
            this.textHangarLenght.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textHangarLenght.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textHangarLenght.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // labelError
            // 
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(206, 342);
            this.labelError.MinimumSize = new System.Drawing.Size(135, 30);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(222, 30);
            this.labelError.TabIndex = 16;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(206, 375);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(135, 30);
            this.progress.TabIndex = 33;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 412);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.panelHangar);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.panelThirdSoil);
            this.Controls.Add(this.panelSecondSoil);
            this.Controls.Add(this.panelFirstSoil);
            this.Name = "MainForm";
            this.Text = "Ангар";
            this.panelFirstSoil.ResumeLayout(false);
            this.panelFirstSoil.PerformLayout();
            this.panelSecondSoil.ResumeLayout(false);
            this.panelSecondSoil.PerformLayout();
            this.panelThirdSoil.ResumeLayout(false);
            this.panelThirdSoil.PerformLayout();
            this.panelHangar.ResumeLayout(false);
            this.panelHangar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFirstSoil;
        private System.Windows.Forms.TextBox textFirstSoil;
        private System.Windows.Forms.ComboBox comboBoxFirstSoil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelSecondSoil;
        private System.Windows.Forms.CheckBox checkBoxSecondSoil;
        private System.Windows.Forms.Panel panelThirdSoil;
        private System.Windows.Forms.CheckBox checkBoxThirdSoil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textHangarHeight;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ComboBox comboBoxSecondSoil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxThirdSoil;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelHangar;
        private System.Windows.Forms.TextBox textSecondSoil;
        private System.Windows.Forms.TextBox textThirdSoil;
        private System.Windows.Forms.TextBox textWallHeight;
        private System.Windows.Forms.TextBox textGateWidth;
        private System.Windows.Forms.TextBox textGateHeight;
        private System.Windows.Forms.TextBox textHangarWidth;
        private System.Windows.Forms.TextBox textHangarLenght;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ProgressBar progress;
    }
}