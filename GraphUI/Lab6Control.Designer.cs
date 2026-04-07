namespace lab_4_6_graph
{
    partial class Lab6Control
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
            btnArticulationPoints = new Button();
            btnMST = new Button();
            btnVariantTask = new Button();
            labelStart = new Label();
            cmbStart = new ComboBox();
            SuspendLayout();
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.BackColor = Color.Transparent;
            lblMes.Location = new Point(213, 14);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(172, 15);
            lblMes.TabIndex = 25;
            lblMes.Text = "Тут и ниже будет вывод всего:";
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.Transparent;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(213, 29);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(179, 310);
            lblOutput.TabIndex = 24;
            // 
            // labelMess
            // 
            labelMess.AutoSize = true;
            labelMess.BackColor = Color.Transparent;
            labelMess.Location = new Point(17, 44);
            labelMess.Name = "labelMess";
            labelMess.Size = new Size(135, 15);
            labelMess.TabIndex = 31;
            labelMess.Text = "Сообщение о загрузке:";
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.Transparent;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(17, 59);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(160, 52);
            lblResult.TabIndex = 30;
            // 
            // buttonLoadGraph
            // 
            buttonLoadGraph.Location = new Point(17, 14);
            buttonLoadGraph.Name = "buttonLoadGraph";
            buttonLoadGraph.Size = new Size(162, 24);
            buttonLoadGraph.TabIndex = 29;
            buttonLoadGraph.Text = "Загрузить граф";
            buttonLoadGraph.UseVisualStyleBackColor = true;
            buttonLoadGraph.Click += buttonLoadGraph_Click;
            // 
            // btnArticulationPoints
            // 
            btnArticulationPoints.Location = new Point(17, 134);
            btnArticulationPoints.Name = "btnArticulationPoints";
            btnArticulationPoints.Size = new Size(162, 24);
            btnArticulationPoints.TabIndex = 36;
            btnArticulationPoints.Text = "Поиск точек сочленения";
            btnArticulationPoints.UseVisualStyleBackColor = true;
            btnArticulationPoints.Click += btnArticulationPoints_Click;
            // 
            // btnMST
            // 
            btnMST.Location = new Point(17, 164);
            btnMST.Name = "btnMST";
            btnMST.Size = new Size(162, 24);
            btnMST.TabIndex = 37;
            btnMST.Text = "Остовное дерево\r\n";
            btnMST.UseVisualStyleBackColor = true;
            btnMST.Click += btnMST_Click;
            // 
            // btnVariantTask
            // 
            btnVariantTask.Location = new Point(17, 194);
            btnVariantTask.Name = "btnVariantTask";
            btnVariantTask.Size = new Size(162, 24);
            btnVariantTask.TabIndex = 38;
            btnVariantTask.Text = "Найти выход из ...";
            btnVariantTask.UseVisualStyleBackColor = true;
            btnVariantTask.Click += btnVariantTask_Click;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.BackColor = Color.Transparent;
            labelStart.Location = new Point(17, 235);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(117, 15);
            labelStart.TabIndex = 41;
            labelStart.Text = "Выберите вершину:";
            // 
            // cmbStart
            // 
            cmbStart.FormattingEnabled = true;
            cmbStart.Location = new Point(17, 253);
            cmbStart.Name = "cmbStart";
            cmbStart.Size = new Size(160, 23);
            cmbStart.TabIndex = 40;
            // 
            // Lab6Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelStart);
            Controls.Add(cmbStart);
            Controls.Add(btnVariantTask);
            Controls.Add(btnMST);
            Controls.Add(btnArticulationPoints);
            Controls.Add(labelMess);
            Controls.Add(lblResult);
            Controls.Add(buttonLoadGraph);
            Controls.Add(lblMes);
            Controls.Add(lblOutput);
            Name = "Lab6Control";
            Size = new Size(406, 364);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMes;
        private Label lblOutput;
        private Label labelMess;
        private Label lblResult;
        private Button buttonLoadGraph;
        private Button btnArticulationPoints;
        private Button btnMST;
        private Button btnVariantTask;
        private Label labelStart;
        private ComboBox cmbStart;
    }
}
