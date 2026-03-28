namespace lab_4_6_graph
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void ShowControl(UserControl control)
        {
            // Очищаем панель от предыдущей лабы
            pnlContent.Controls.Clear();

            // Растягиваем новый контрол на всю панель
            control.Dock = DockStyle.Fill;

            // Добавляем его на форму
            pnlContent.Controls.Add(control);
        }

        private void button4lab_Click(object sender, EventArgs e)
        {
            //ShowControl(new Lab4Control());



            // Очищаем старое, если было
            pnlContent.Controls.Clear();

            Lab4Control lab4 = new Lab4Control();
            lab4.Dock = DockStyle.Fill;

            // Сделаем сам контрол полупрозрачным, если хотим видеть фон
            lab4.BackColor = Color.FromArgb(200, 255, 255, 255);

            pnlContent.Controls.Add(lab4);
            pnlContent.Visible = true; // Показываем панель только после клика
            pnlContent.BringToFront();
        }
    }
}

