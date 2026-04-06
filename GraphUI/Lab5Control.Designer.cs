namespace lab_4_6_graph
{
    partial class Lab5Control
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            lblMes = new Label();
            lblOutput = new Label();
            labelMess = new Label();
            lblResult = new Label();
            buttonLoadGraph = new Button();
            buttonShortestAll = new Button();
            buttonBetween = new Button();
            labelVivod = new Label();
            labelStart = new Label();
            cmbEnd = new ComboBox();
            cmbStart = new ComboBox();
            SuspendLayout();
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.BackColor = Color.Transparent;
            lblMes.Location = new Point(208, 13);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(172, 15);
            lblMes.TabIndex = 25;
            lblMes.Text = "Тут и ниже будет вывод всего:";
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.Transparent;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(208, 28);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(179, 314);
            lblOutput.TabIndex = 24;
            // 
            // labelMess
            // 
            labelMess.AutoSize = true;
            labelMess.BackColor = Color.Transparent;
            labelMess.Location = new Point(23, 43);
            labelMess.Name = "labelMess";
            labelMess.Size = new Size(135, 15);
            labelMess.TabIndex = 28;
            labelMess.Text = "Сообщение о загрузке:";
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.Transparent;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(23, 58);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(160, 52);
            lblResult.TabIndex = 27;
            // 
            // buttonLoadGraph
            // 
            buttonLoadGraph.Location = new Point(23, 13);
            buttonLoadGraph.Name = "buttonLoadGraph";
            buttonLoadGraph.Size = new Size(162, 24);
            buttonLoadGraph.TabIndex = 26;
            buttonLoadGraph.Text = "Загрузить граф";
            buttonLoadGraph.UseVisualStyleBackColor = true;
            buttonLoadGraph.Click += buttonLoadGraph_Click;
            // 
            // buttonShortestAll
            // 
            buttonShortestAll.Location = new Point(23, 133);
            buttonShortestAll.Name = "buttonShortestAll";
            buttonShortestAll.Size = new Size(162, 24);
            buttonShortestAll.TabIndex = 35;
            buttonShortestAll.Text = "Расстояние до всех";
            buttonShortestAll.UseVisualStyleBackColor = true;
            // 
            // buttonBetween
            // 
            buttonBetween.Location = new Point(23, 163);
            buttonBetween.Name = "buttonBetween";
            buttonBetween.Size = new Size(162, 24);
            buttonBetween.TabIndex = 36;
            buttonBetween.Text = "Расстояние между двумя ";
            buttonBetween.UseVisualStyleBackColor = true;
            // 
            // labelVivod
            // 
            labelVivod.AutoSize = true;
            labelVivod.BackColor = Color.Transparent;
            labelVivod.Location = new Point(23, 300);
            labelVivod.Name = "labelVivod";
            labelVivod.Size = new Size(116, 15);
            labelVivod.TabIndex = 40;
            labelVivod.Text = "Конечная вершина:";
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.BackColor = Color.Transparent;
            labelStart.Location = new Point(23, 256);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(119, 15);
            labelStart.TabIndex = 39;
            labelStart.Text = "Стартовая вершина:";
            // 
            // cmbEnd
            // 
            cmbEnd.FormattingEnabled = true;
            cmbEnd.Location = new Point(23, 318);
            cmbEnd.Name = "cmbEnd";
            cmbEnd.Size = new Size(160, 23);
            cmbEnd.TabIndex = 38;
            // 
            // cmbStart
            // 
            cmbStart.FormattingEnabled = true;
            cmbStart.Location = new Point(23, 274);
            cmbStart.Name = "cmbStart";
            cmbStart.Size = new Size(160, 23);
            cmbStart.TabIndex = 37;
            // 
            // Lab5Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelVivod);
            Controls.Add(labelStart);
            Controls.Add(cmbEnd);
            Controls.Add(cmbStart);
            Controls.Add(buttonBetween);
            Controls.Add(buttonShortestAll);
            Controls.Add(labelMess);
            Controls.Add(lblResult);
            Controls.Add(buttonLoadGraph);
            Controls.Add(lblMes);
            Controls.Add(lblOutput);
            Name = "Lab5Control";
            Size = new Size(404, 365);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMes;
        private Label lblOutput;
        private Label labelMess;
        private Label lblResult;
        private Button buttonLoadGraph;
        private Button buttonShortestAll;
        private Button buttonBetween;
        private Label labelVivod;
        private Label labelStart;
        private ComboBox cmbEnd;
        private ComboBox cmbStart;
    }
}
