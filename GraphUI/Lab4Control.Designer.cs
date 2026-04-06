namespace lab_4_6_graph
{
    partial class Lab4Control
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
            buttonLoadGraph = new Button();
            buttonBFS = new Button();
            buttonDFS = new Button();
            lblResult = new Label();
            cmbStart = new ComboBox();
            cmbEnd = new ComboBox();
            labelStart = new Label();
            labelVivod = new Label();
            labelMess = new Label();
            btnCheckReachable = new Button();
            btnFindComponents = new Button();
            lblOutput = new Label();
            lblMes = new Label();
            SuspendLayout();
            // 
            // buttonLoadGraph
            // 
            buttonLoadGraph.Location = new Point(20, 12);
            buttonLoadGraph.Name = "buttonLoadGraph";
            buttonLoadGraph.Size = new Size(162, 24);
            buttonLoadGraph.TabIndex = 0;
            buttonLoadGraph.Text = "Загрузить граф";
            buttonLoadGraph.UseVisualStyleBackColor = true;
            buttonLoadGraph.Click += buttonLoadGraph_Click;
            // 
            // buttonBFS
            // 
            buttonBFS.Location = new Point(20, 158);
            buttonBFS.Name = "buttonBFS";
            buttonBFS.Size = new Size(162, 24);
            buttonBFS.TabIndex = 1;
            buttonBFS.Text = "BFS";
            buttonBFS.UseVisualStyleBackColor = true;
            buttonBFS.Click += buttonBFS_Click;
            // 
            // buttonDFS
            // 
            buttonDFS.Location = new Point(20, 188);
            buttonDFS.Name = "buttonDFS";
            buttonDFS.Size = new Size(162, 24);
            buttonDFS.TabIndex = 2;
            buttonDFS.Text = "DFS";
            buttonDFS.UseVisualStyleBackColor = true;
            buttonDFS.Click += buttonDFS_Click;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.Transparent;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(18, 57);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(162, 52);
            lblResult.TabIndex = 3;
            // 
            // cmbStart
            // 
            cmbStart.FormattingEnabled = true;
            cmbStart.Location = new Point(20, 270);
            cmbStart.Name = "cmbStart";
            cmbStart.Size = new Size(160, 23);
            cmbStart.TabIndex = 4;
            // 
            // cmbEnd
            // 
            cmbEnd.FormattingEnabled = true;
            cmbEnd.Location = new Point(20, 314);
            cmbEnd.Name = "cmbEnd";
            cmbEnd.Size = new Size(160, 23);
            cmbEnd.TabIndex = 5;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.BackColor = Color.Transparent;
            labelStart.Location = new Point(20, 252);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(119, 15);
            labelStart.TabIndex = 6;
            labelStart.Text = "Стартовая вершина:";
            // 
            // labelVivod
            // 
            labelVivod.AutoSize = true;
            labelVivod.BackColor = Color.Transparent;
            labelVivod.Location = new Point(20, 296);
            labelVivod.Name = "labelVivod";
            labelVivod.Size = new Size(116, 15);
            labelVivod.TabIndex = 7;
            labelVivod.Text = "Конечная вершина:";
            // 
            // labelMess
            // 
            labelMess.AutoSize = true;
            labelMess.BackColor = Color.Transparent;
            labelMess.Location = new Point(20, 42);
            labelMess.Name = "labelMess";
            labelMess.Size = new Size(135, 15);
            labelMess.TabIndex = 10;
            labelMess.Text = "Сообщение о загрузке:";
            // 
            // btnCheckReachable
            // 
            btnCheckReachable.Location = new Point(20, 218);
            btnCheckReachable.Name = "btnCheckReachable";
            btnCheckReachable.Size = new Size(162, 24);
            btnCheckReachable.TabIndex = 15;
            btnCheckReachable.Text = "Проверить достижимость";
            btnCheckReachable.UseVisualStyleBackColor = true;
            btnCheckReachable.Click += btnCheckReachable_Click;
            // 
            // btnFindComponents
            // 
            btnFindComponents.Location = new Point(20, 126);
            btnFindComponents.Name = "btnFindComponents";
            btnFindComponents.Size = new Size(162, 24);
            btnFindComponents.TabIndex = 16;
            btnFindComponents.Text = "Компоненты";
            btnFindComponents.UseVisualStyleBackColor = true;
            btnFindComponents.Click += btnFindComponents_Click;
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.Transparent;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(204, 27);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(179, 310);
            lblOutput.TabIndex = 22;
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.BackColor = Color.Transparent;
            lblMes.Location = new Point(204, 12);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(172, 15);
            lblMes.TabIndex = 23;
            lblMes.Text = "Тут и ниже будет вывод всего:";
            // 
            // Lab4Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMes);
            Controls.Add(lblOutput);
            Controls.Add(btnFindComponents);
            Controls.Add(btnCheckReachable);
            Controls.Add(labelMess);
            Controls.Add(labelVivod);
            Controls.Add(labelStart);
            Controls.Add(cmbEnd);
            Controls.Add(cmbStart);
            Controls.Add(lblResult);
            Controls.Add(buttonDFS);
            Controls.Add(buttonBFS);
            Controls.Add(buttonLoadGraph);
            Name = "Lab4Control";
            Size = new Size(425, 363);
            Load += Lab4Control_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLoadGraph;
        private Button buttonBFS;
        private Button buttonDFS;
        private Label lblResult;
        private ComboBox cmbStart;
        private ComboBox cmbEnd;
        private Label labelStart;
        private Label labelVivod;
        private Label labelMess;
        private Button btnCheckReachable;
        private Button btnFindComponents;
        private Label lblOutput;
        private Label lblMes;
    }
}
