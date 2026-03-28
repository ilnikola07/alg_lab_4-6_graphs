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
            SuspendLayout();
            // 
            // btnAbout
            // 
            btnAbout.BackgroundImageLayout = ImageLayout.Stretch;
            btnAbout.Location = new Point(12, 177);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(171, 33);
            btnAbout.TabIndex = 0;
            btnAbout.Text = "Что это?";
            btnAbout.UseVisualStyleBackColor = true;
            // 
            // button4lab
            // 
            button4lab.BackgroundImageLayout = ImageLayout.Stretch;
            button4lab.Location = new Point(12, 28);
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
            button5lab.Location = new Point(12, 76);
            button5lab.Name = "button5lab";
            button5lab.Size = new Size(171, 33);
            button5lab.TabIndex = 2;
            button5lab.Text = "Лабораторная работа №5";
            button5lab.UseVisualStyleBackColor = true;
            // 
            // button6lab
            // 
            button6lab.BackgroundImageLayout = ImageLayout.Stretch;
            button6lab.Location = new Point(12, 124);
            button6lab.Name = "button6lab";
            button6lab.Size = new Size(171, 33);
            button6lab.TabIndex = 3;
            button6lab.Text = "Лабораторная работа №6";
            button6lab.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.Transparent;
            pnlContent.Location = new Point(205, 28);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(447, 330);
            pnlContent.TabIndex = 4;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(673, 382);
            Controls.Add(pnlContent);
            Controls.Add(button6lab);
            Controls.Add(button5lab);
            Controls.Add(button4lab);
            Controls.Add(btnAbout);
            Name = "FormMain";
            Text = "Пещеры";
            Load += FormMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnAbout;
        private Button button4lab;
        private Button button5lab;
        private Button button6lab;
        private Panel pnlContent;
    }
}
