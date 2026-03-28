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
            txtOutput = new TextBox();
            txtLog = new TextBox();
            labelMess = new Label();
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
            buttonBFS.Location = new Point(20, 42);
            buttonBFS.Name = "buttonBFS";
            buttonBFS.Size = new Size(81, 24);
            buttonBFS.TabIndex = 1;
            buttonBFS.Text = "BFS";
            buttonBFS.UseVisualStyleBackColor = true;
            buttonBFS.Click += buttonBFS_Click;
            // 
            // buttonDFS
            // 
            buttonDFS.Location = new Point(107, 42);
            buttonDFS.Name = "buttonDFS";
            buttonDFS.Size = new Size(75, 24);
            buttonDFS.TabIndex = 2;
            buttonDFS.Text = "DFS";
            buttonDFS.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            lblResult.BackColor = Color.Transparent;
            lblResult.BorderStyle = BorderStyle.FixedSingle;
            lblResult.Location = new Point(220, 42);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(174, 52);
            lblResult.TabIndex = 3;
            // 
            // cmbStart
            // 
            cmbStart.FormattingEnabled = true;
            cmbStart.Location = new Point(18, 97);
            cmbStart.Name = "cmbStart";
            cmbStart.Size = new Size(165, 23);
            cmbStart.TabIndex = 4;
            // 
            // cmbEnd
            // 
            cmbEnd.FormattingEnabled = true;
            cmbEnd.Location = new Point(17, 143);
            cmbEnd.Name = "cmbEnd";
            cmbEnd.Size = new Size(165, 23);
            cmbEnd.TabIndex = 5;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.BackColor = Color.Transparent;
            labelStart.Location = new Point(21, 79);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(164, 15);
            labelStart.TabIndex = 6;
            labelStart.Text = "Введите стартовую вершину";
            // 
            // labelVivod
            // 
            labelVivod.AutoSize = true;
            labelVivod.BackColor = Color.Transparent;
            labelVivod.Location = new Point(17, 125);
            labelVivod.Name = "labelVivod";
            labelVivod.Size = new Size(162, 15);
            labelVivod.TabIndex = 7;
            labelVivod.Text = "Введите конечную вершину";
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(220, 200);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(174, 23);
            txtOutput.TabIndex = 8;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.White;
            txtLog.Location = new Point(203, 268);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(174, 36);
            txtLog.TabIndex = 9;
            // 
            // labelMess
            // 
            labelMess.AutoSize = true;
            labelMess.BackColor = Color.Transparent;
            labelMess.Location = new Point(220, 12);
            labelMess.Name = "labelMess";
            labelMess.Size = new Size(135, 15);
            labelMess.TabIndex = 10;
            labelMess.Text = "Сообщение о загрузке:";
            // 
            // Lab4Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelMess);
            Controls.Add(txtLog);
            Controls.Add(txtOutput);
            Controls.Add(labelVivod);
            Controls.Add(labelStart);
            Controls.Add(cmbEnd);
            Controls.Add(cmbStart);
            Controls.Add(lblResult);
            Controls.Add(buttonDFS);
            Controls.Add(buttonBFS);
            Controls.Add(buttonLoadGraph);
            Name = "Lab4Control";
            Size = new Size(474, 344);
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
        private TextBox txtOutput;
        private TextBox txtLog;
        private Label labelMess;
    }
}
