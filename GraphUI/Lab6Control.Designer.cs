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
            buttonNoConnecting = new Button();
            buttonMinOstTree = new Button();
            buttonShortExit = new Button();
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
            // 
            // buttonNoConnecting
            // 
            buttonNoConnecting.Location = new Point(17, 134);
            buttonNoConnecting.Name = "buttonNoConnecting";
            buttonNoConnecting.Size = new Size(162, 24);
            buttonNoConnecting.TabIndex = 36;
            buttonNoConnecting.Text = "Поиск точек сочленения";
            buttonNoConnecting.UseVisualStyleBackColor = true;
            // 
            // buttonMinOstTree
            // 
            buttonMinOstTree.Location = new Point(17, 164);
            buttonMinOstTree.Name = "buttonMinOstTree";
            buttonMinOstTree.Size = new Size(162, 24);
            buttonMinOstTree.TabIndex = 37;
            buttonMinOstTree.Text = "Остовное дерево\r\n";
            buttonMinOstTree.UseVisualStyleBackColor = true;
            // 
            // buttonShortExit
            // 
            buttonShortExit.Location = new Point(17, 194);
            buttonShortExit.Name = "buttonShortExit";
            buttonShortExit.Size = new Size(162, 24);
            buttonShortExit.TabIndex = 38;
            buttonShortExit.Text = "Найти выход из ...";
            buttonShortExit.UseVisualStyleBackColor = true;
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
            Controls.Add(buttonShortExit);
            Controls.Add(buttonMinOstTree);
            Controls.Add(buttonNoConnecting);
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
        private Button buttonNoConnecting;
        private Button buttonMinOstTree;
        private Button buttonShortExit;
        private Label labelStart;
        private ComboBox cmbStart;
    }
}
