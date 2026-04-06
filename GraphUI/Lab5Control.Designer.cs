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
            SuspendLayout();
            // 
            // lblMes
            // 
            lblMes.AutoSize = true;
            lblMes.BackColor = Color.Transparent;
            lblMes.Location = new Point(168, 13);
            lblMes.Name = "lblMes";
            lblMes.Size = new Size(172, 15);
            lblMes.TabIndex = 25;
            lblMes.Text = "Тут и ниже будет вывод всего:";
            // 
            // lblOutput
            // 
            lblOutput.BackColor = Color.Transparent;
            lblOutput.BorderStyle = BorderStyle.FixedSingle;
            lblOutput.Location = new Point(168, 28);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(179, 310);
            lblOutput.TabIndex = 24;
            // 
            // Lab5Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMes);
            Controls.Add(lblOutput);
            Name = "Lab5Control";
            Size = new Size(364, 365);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMes;
        private Label lblOutput;
    }
}
