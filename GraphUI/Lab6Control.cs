using GraphLogic;
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

namespace lab_4_6_graph
{
    public partial class Lab6Control : UserControl
    {
        public Lab6Control()
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

                        // 4. Информируем пользователя
                        lblResult.Text = "Успешно загружено!\n" +
                 $"Вершин (пещер): {allCaves.Length}\n" +
                 $"Рёбер (тоннелей): {edgeCount}";

                        // Выбираем первые элементы по умолчанию, чтобы не было пусто
                        if (cmbStart.Items.Count > 0) cmbStart.SelectedIndex = 0;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnArticulationPoints_Click(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            var points = caveSystem.FindArticulationPoints();
            stopwatch.Stop();

            var sb = new StringBuilder();
            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {time}");
            sb.AppendLine("Точки сочленения (критические пещеры):\n");

            if (points.Count == 0)
            {
                sb.AppendLine("Точки сочленения отсутствуют — граф устойчив к удалению пещеры.");
            }
            else
            {
                foreach (var point in points.OrderBy(p => p))
                {
                    sb.AppendLine($"{point}");
                }
                sb.AppendLine($"\nУдаление любой из этих пещер разорвёт систему на части!");
            }

            lblOutput.Text = sb.ToString();
        }

        private void btnMST_Click(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = caveSystem.PrimsAlgorithm();
            stopwatch.Stop();

            var sb = new StringBuilder();
            string time = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {time}");
            sb.AppendLine("Минимальное остовное дерево (алгоритм Прима):\n");

            var mstEdges = result.Item1;
            var totalWeight = result.Item2;

            if (mstEdges == null || mstEdges.Count == 0)
            {
                sb.AppendLine("Невозможно построить: граф пуст или несвязный.");
            }
            else
            {
                sb.AppendLine("Рёбра МОД:");
                foreach (var edge in mstEdges)
                {
                    sb.AppendLine($"-> {edge.Target} ({edge.Weight})");
                }
                sb.AppendLine($"\nСуммарная длина тоннелей: {totalWeight}м");
                sb.AppendLine($"Количество рёбер: {mstEdges.Count}");
            }

            lblOutput.Text = sb.ToString();
        }


        private void btnVariantTask_Click(object sender, EventArgs e)
        {
            string start = cmbStart.SelectedItem?.ToString();
            string exit = "Выход";

            if (string.IsNullOrEmpty(start))
            {
                lblOutput.Text = "Выберите стартовую пещеру!";
                return;
            }

            var stopwatch = Stopwatch.StartNew();
            var allVertices = caveSystem.GetAllVertices();

            if (!allVertices.Contains(exit))
            {
                lblOutput.Text = $"Вершина '{exit}' не найдена в графе.\n" +
                                $"Доступные вершины:\n{string.Join(", ", allVertices.Take(10))}" +
                                (allVertices.Count > 10 ? "..." : "");
                stopwatch.Stop();

                // Используем другое имя переменной
                string timeResult = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

                lblOutput.Text += $"\n\nВремя выполнения: {timeResult}";
                return;
            }

            var path = caveSystem.GetShortestPath(start, exit);
            var distances = caveSystem.Dijkstra(start);
            stopwatch.Stop();

            var sb = new StringBuilder();

            // Используем другое имя переменной
            string executionTime = stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " мс";

            sb.AppendLine($"Время выполнения: {executionTime}");
            sb.AppendLine($"Задача варианта 9: выход из пещеры {start}\n");

            if (path.Count == 0 || distances[exit] == int.MaxValue)
            {
                sb.AppendLine($"Выход {exit} недостижим из {start}!");
                sb.AppendLine("Проверьте связность графа или используйте поиск компонент.");
            }
            else
            {
                sb.AppendLine($"Кратчайший путь к выходу:\n");
                for (int i = 0; i < path.Count; i++)
                {
                    sb.AppendLine($"  {i + 1}. {path[i]}");
                }
                sb.AppendLine($"\nОбщая длина маршрута: {distances[exit]}м");
                sb.AppendLine($"Количество переходов: {path.Count - 1}");
            }

            lblOutput.Text = sb.ToString();
        }
    }
}
