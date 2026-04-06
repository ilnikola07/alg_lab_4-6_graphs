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


        private void button5lab_Click(object sender, EventArgs e)
        {
            //ShowControl(new Lab4Control());



            // Очищаем старое, если было
            pnlContent.Controls.Clear();

            Lab5Control lab5 = new Lab5Control();
            lab5.Dock = DockStyle.Fill;

            // Сделаем сам контрол полупрозрачным, если хотим видеть фон
            lab5.BackColor = Color.FromArgb(200, 255, 255, 255);

            pnlContent.Controls.Add(lab5);
            pnlContent.Visible = true; // Показываем панель только после клика
            pnlContent.BringToFront();
        }



        private void button6lab_Click(object sender, EventArgs e)
        {
            //ShowControl(new Lab4Control());



            // Очищаем старое, если было
            pnlContent.Controls.Clear();

            Lab6Control lab6 = new Lab6Control();
            lab6.Dock = DockStyle.Fill;

            // Сделаем сам контрол полупрозрачным, если хотим видеть фон
            lab6.BackColor = Color.FromArgb(200, 255, 255, 255);

            pnlContent.Controls.Add(lab6);
            pnlContent.Visible = true; // Показываем панель только после клика
            pnlContent.BringToFront();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void buttonLook_Click(object sender, EventArgs e)
        {
            // 1. Скрываем элементы на обеих панелях
            foreach (Control ctrl in panelButtons.Controls)
                ctrl.Visible = false;
            foreach (Control ctrl in pnlContent.Controls)
                ctrl.Visible = false;

            // 2. Ждем 10 секунд
            await Task.Delay(10000);

            // 3. Возвращаем всё обратно
            foreach (Control ctrl in panelButtons.Controls)
                ctrl.Visible = true;
            foreach (Control ctrl in pnlContent.Controls)
                ctrl.Visible = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pnlContent.Visible = false; // Панель исчезнет с экрана
        }
    }
}

