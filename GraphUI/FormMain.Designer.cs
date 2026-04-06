namespace lab_4_6_graph
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnAbout = new Button();
            button4lab = new Button();
            button5lab = new Button();
            button6lab = new Button();
            pnlContent = new Panel();
            buttonExit = new Button();
            buttonClear = new Button();
            panelButtons = new Panel();
            buttonLasts = new Button();
            buttonLook = new Button();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // btnAbout
            // 
            btnAbout.BackgroundImageLayout = ImageLayout.Stretch;
            btnAbout.Location = new Point(12, 248);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(171, 33);
            btnAbout.TabIndex = 0;
            btnAbout.Text = "Что это?";
            btnAbout.UseVisualStyleBackColor = true;
            // 
            // button4lab
            // 
            button4lab.BackgroundImageLayout = ImageLayout.Stretch;
            button4lab.Location = new Point(12, 14);
            button4lab.Name = "button4lab";
            button4lab.Size = new Size(171, 33);
            button4lab.TabIndex = 1;
            button4lab.Text = "Лабораторная работа №4";
            button4lab.UseVisualStyleBackColor = true;
            button4lab.Click += button4lab_Click;
            // 
            // button5lab
            // 
            button5lab.BackgroundImageLayout = ImageLayout.Stretch;
            button5lab.Location = new Point(12, 53);
            button5lab.Name = "button5lab";
            button5lab.Size = new Size(171, 33);
            button5lab.TabIndex = 2;
            button5lab.Text = "Лабораторная работа №5";
            button5lab.UseVisualStyleBackColor = true;
            button5lab.Click += button5lab_Click;
            // 
            // button6lab
            // 
            button6lab.BackgroundImageLayout = ImageLayout.Stretch;
            button6lab.Location = new Point(12, 92);
            button6lab.Name = "button6lab";
            button6lab.Size = new Size(171, 33);
            button6lab.TabIndex = 3;
            button6lab.Text = "Лабораторная работа №6";
            button6lab.UseVisualStyleBackColor = true;
            button6lab.Click += button6lab_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.Transparent;
            pnlContent.Location = new Point(240, 18);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(432, 362);
            pnlContent.TabIndex = 4;
            // 
            // buttonExit
            // 
            buttonExit.BackgroundImageLayout = ImageLayout.Stretch;
            buttonExit.Location = new Point(12, 287);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(171, 33);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "Выход из приложения";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonClear
            // 
            buttonClear.BackgroundImageLayout = ImageLayout.Stretch;
            buttonClear.Location = new Point(12, 170);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(171, 33);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Очистить экран справа\r\n";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.Transparent;
            panelButtons.Controls.Add(buttonLasts);
            panelButtons.Controls.Add(btnAbout);
            panelButtons.Controls.Add(buttonLook);
            panelButtons.Controls.Add(buttonClear);
            panelButtons.Controls.Add(buttonExit);
            panelButtons.Controls.Add(button5lab);
            panelButtons.Controls.Add(button6lab);
            panelButtons.Controls.Add(button4lab);
            panelButtons.Location = new Point(12, 18);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(196, 362);
            panelButtons.TabIndex = 7;
            // 
            // buttonLasts
            // 
            buttonLasts.BackgroundImageLayout = ImageLayout.Stretch;
            buttonLasts.Location = new Point(12, 131);
            buttonLasts.Name = "buttonLasts";
            buttonLasts.Size = new Size(171, 33);
            buttonLasts.TabIndex = 8;
            buttonLasts.Text = "Итоги";
            buttonLasts.UseVisualStyleBackColor = true;
            // 
            // buttonLook
            // 
            buttonLook.BackgroundImageLayout = ImageLayout.Stretch;
            buttonLook.Location = new Point(12, 209);
            buttonLook.Name = "buttonLook";
            buttonLook.Size = new Size(171, 33);
            buttonLook.TabIndex = 7;
            buttonLook.Text = "Посмотреть на фон 10 сек\r\n";
            buttonLook.UseVisualStyleBackColor = true;
            buttonLook.Click += buttonLook_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(702, 403);
            Controls.Add(panelButtons);
            Controls.Add(pnlContent);
            Name = "FormMain";
            Text = "Пещеры";
            Load += FormMain_Load;
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAbout;
        private Button button4lab;
        private Button button5lab;
        private Button button6lab;
        private Panel pnlContent;
        private Button buttonExit;
        private Button buttonClear;
        private Panel panelButtons;
        private Button buttonLook;
        private Button buttonLasts;
    }
}
