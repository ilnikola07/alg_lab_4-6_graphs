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

            buttonLoadGraph = new Button();

        }



        // Остальные методы...

        private void buttonBFS_Click(object sender, EventArgs e)
        {
            string startNode = cmbStart.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(startNode))
            {
                lblOutput.Text = "Выберите стартовую вершину!";
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            var result = caveSystem.GetBFS(startNode);
            stopwatch.Stop();

            var sb = new StringBuilder();
            string executionTime = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {executionTime}");
            sb.AppendLine("Порядок BFS:\n");
            sb.AppendLine(string.Join("\n", result));

            lblOutput.BackColor = Color.Transparent;
            lblOutput.Text = sb.ToString();
        }

        private void btnFindComponents_Click(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            var components = caveSystem.FindConnectedComponents();
            stopwatch.Stop();

            lblOutput.Text = "";
            lblOutput.BackColor = System.Drawing.Color.Transparent;

            var sb = new StringBuilder();
            string executionTime = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {executionTime}");

            if (components == null || components.Count == 0)
            {
                sb.AppendLine("Граф пуст или не загружен!");
                lblOutput.Text = sb.ToString();
                return;
            }

            for (int i = 0; i < components.Count; i++)
            {
                sb.AppendLine($"Компонент №{i + 1}:");
                sb.AppendLine(string.Join("\n", components[i]));
                sb.AppendLine();
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

            var stopwatch = Stopwatch.StartNew();
            try
            {
                bool isReachable = caveSystem.IsReachable(from, to);
                stopwatch.Stop();

                var sb = new StringBuilder();
                string executionTime = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

                sb.AppendLine($"Время выполнения: {executionTime}");

                if (isReachable)
                {
                    sb.AppendLine($" '{to}' достижима из '{from}'");
                }
                else
                {
                    sb.AppendLine($" '{to}' НЕ достижима из '{from}'");
                }

                lblOutput.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDFS_Click(object sender, EventArgs e)
        {
            // 1. Получаем стартовую и конечную вершины из выпадающих списков
            string startNode = cmbStart.SelectedItem?.ToString();
            string endNode = cmbEnd.SelectedItem?.ToString(); // Добавили получение конечной точки

            if (string.IsNullOrEmpty(startNode) || string.IsNullOrEmpty(endNode))
            {
                lblOutput.Text = "Выберите и стартовую, и конечную вершины!";
                return;
            }

            // Добавляем замер времени
            var stopwatch = Stopwatch.StartNew();

            // 2. Вызываем метод, передавая ОБА аргумента
            var result = caveSystem.GetDFS(startNode, endNode);

            stopwatch.Stop();

            // Форматируем время
            var sb = new StringBuilder();
            string executionTime = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            // 3. Настраиваем внешний вид
            lblOutput.BackColor = Color.Transparent;

            // 4. Формируем строку вывода
            sb.AppendLine($"Время выполнения: {executionTime}");
            sb.AppendLine("Порядок обхода DFS:");
            sb.AppendLine(); // Пустая строка для красоты
            sb.AppendLine(string.Join("\n", result));

            lblOutput.Text = sb.ToString();
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
    }
}

