using GraphLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace lab_4_6_graph
{
    public partial class Lab5Control : UserControl
    {
        public Lab5Control()
        {
            InitializeComponent();
        }

        private CaveGraph caveSystem = new CaveGraph();

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


        private void btnDijkstraAll_Click(object sender, EventArgs e)
        {
            string start = cmbStart.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(start))
            {
                lblOutput.Text = "Выберите стартовую пещеру!";
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            var distances = caveSystem.Dijkstra(start);
            stopwatch.Stop();

            var sb = new StringBuilder();
            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {time}");
            sb.AppendLine($"Кратчайшие расстояния от {start}:\n");
            foreach (var kvp in distances.OrderBy(x => x.Value))
            {
                string dist = kvp.Value == int.MaxValue ? " (недостижима)" : kvp.Value.ToString() + "м";
                sb.AppendLine($"{kvp.Key,-20} {dist}");
            }

            lblOutput.Text = sb.ToString();
        }

        private void btnDijkstraPath_Click(object sender, EventArgs e)
        {
            string from = cmbStart.SelectedItem?.ToString();
            string to = cmbEnd.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                lblOutput.Text = "Выберите обе пещеры!";
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            var path = caveSystem.GetShortestPath(from, to);
            var distances = caveSystem.Dijkstra(from);
            stopwatch.Stop();

            var sb = new StringBuilder();
            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {time}");

            if (path.Count == 0 || distances[to] == int.MaxValue)
            {
                sb.AppendLine($"Путь от {from} до {to} не найден!");
            }
            else
            {
                sb.AppendLine($"Кратчайший маршрут от {from} до {to}:\n");
                sb.AppendLine(string.Join(" -> ", path));
                sb.AppendLine($"Общая длина: {distances[to]}м");
            }

            lblOutput.Text = sb.ToString();
        }
    }
}
