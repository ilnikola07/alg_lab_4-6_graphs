using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using GraphLogic;

namespace lab_4_6_graph
{
    public partial class Lab4Control : UserControl
    {
        private CaveGraph caveSystem = new CaveGraph();

        public Lab4Control()
        {
            InitializeComponent();
        }

        private void buttonLoadGraph_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Фильтр только для текстовых файлов
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                ofd.Title = "Выберите карту пещерной системы";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. Очищаем старые данные в графе и в интерфейсе
                        caveSystem.Clear();
                        cmbStart.Items.Clear();
                        cmbEnd.Items.Clear();
                        

                        // 2. Читаем файл построчно
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        int edgeCount = 0;

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            // Предполагаем формат: Пещера1;Пещера2;Расстояние
                            string[] parts = line.Split(';');
                            if (parts.Length >= 3)
                            {
                                string from = parts[0].Trim();
                                string to = parts[1].Trim();
                                if (int.TryParse(parts[2].Trim(), out int weight))
                                {
                                    // Добавляем ребро в нашу библиотеку классов
                                    caveSystem.AddEdge(from, to, weight);
                                    edgeCount++;
                                }
                            }
                        }

                        // 3. Заполняем ComboBox-ы уникальными названиями пещер
                        var allCaves = caveSystem.AdjacencyList.Keys.OrderBy(n => n).ToArray();
                        cmbStart.Items.AddRange(allCaves);
                        cmbEnd.Items.AddRange(allCaves);

                        // 4. Информируем пользователя
                        lblResult.Text = "Успешно загружено!\n" +
                 $"Вершин (пещер): {allCaves.Length}\n" +
                 $"Рёбер (тоннелей): {edgeCount}";

                        // Выбираем первые элементы по умолчанию, чтобы не было пусто
                        if (cmbStart.Items.Count > 0) cmbStart.SelectedIndex = 0;
                        if (cmbEnd.Items.Count > 1) cmbEnd.SelectedIndex = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Lab4Control_Load(object sender, EventArgs e)
        {

        }

        private void buttonBFS_Click(object sender, EventArgs e)
        {
            // 1. Берем начальную вершину из комбобокса
            string startNode = cmbStart.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(startNode))
            {
                lblOutput.Text = "Выберите стартовую вершину!";
                return;
            }

            // 2. Получаем результат обхода BFS
            var result = caveSystem.GetBFS(startNode);

            // 3. Формируем вывод в столбик
            lblOutput.BackColor = Color.Transparent; // Прозрачный фон
            lblOutput.Text = "Порядок BFS:\n" + string.Join("\n", result);
        }

        private void btnFindComponents_Click(object sender, EventArgs e)
        {
            var components = caveSystem.FindConnectedComponents();

            // Очистка и настройка прозрачности (можно сделать один раз в дизайнере)
            lblOutput.Text = "";
            lblOutput.BackColor = System.Drawing.Color.Transparent;

            if (components == null || components.Count == 0)
            {
                lblOutput.Text = "Граф пуст или не загружен!";
                return;
            }

            var sb = new System.Text.StringBuilder();

            for (int i = 0; i < components.Count; i++)
            {
                sb.AppendLine($"Компонент №{i + 1}:");

                // string.Join("\n", ...) выведет каждый элемент списка с новой строки
                string namesInColumn = string.Join("\n", components[i]);
                sb.AppendLine(namesInColumn);

                sb.AppendLine(); // Пустая строка между компонентами
            }

            lblOutput.Text = sb.ToString();
        }

        private void btnCheckReachable_Click(object sender, EventArgs e)
        {
            if (cmbStart.Items.Count == 0 || cmbEnd.Items.Count == 0)
            {
                lblOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string from = cmbStart.SelectedItem?.ToString();
            string to = cmbEnd.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                MessageBox.Show("Выберите обе вершины!");
                return;
            }

            try
            {
                bool isReachable = caveSystem.IsReachable(from, to);

                if (isReachable)
                {
                    lblOutput.Text = $" '{to}' достижима из '{from}'";
                }
                else
                {
                    lblOutput.Text = $" '{to}' НЕ достижима из '{from}'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDFS_Click(object sender, EventArgs e)
        {
            // 1. Получаем стартовую вершину из выпадающего списка
            string startNode = cmbStart.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(startNode))
            {
                lblOutput.Text = "Выберите стартовую вершину!";
                return;
            }

            // 2. Вызываем ваш метод обхода в глубину
            var result = caveSystem.GetDFS(startNode);

            // 3. Настраиваем внешний вид (очистка происходит автоматически при присваивании =)
            lblOutput.BackColor = Color.Transparent;

            // 4. Формируем строку: заголовок + список через перенос строки (\n)
            // string.Join("\n", result) расположит каждое название под предыдущим
            lblOutput.Text = "Порядок обхода DFS:\n" + string.Join("\n", result);
        }
    }
}

