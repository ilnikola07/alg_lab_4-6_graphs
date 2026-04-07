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
                sb.AppendLine($"\n Удаление любой из этих пещер разорвёт систему на части!");
            }
            sb.AppendLine($"\n Время выполнения: {stopwatch.ElapsedMilliseconds} мс");

            lblOutput.Text = sb.ToString();
        }

        private void btnMST_Click(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();

            // Получаем данные. Обратите внимание на тип возвращаемого значения!
            var result = caveSystem.PrimsAlgorithm();

            stopwatch.Stop();

            var sb = new StringBuilder();
            sb.AppendLine("Минимальное остовное дерево (алгоритм Прима):\n");

            // Предположим, что result.Item1 - это список ребер, а result.Item2 - вес
            // Если PrimsAlgorithm возвращает кортеж (List<Edge>, int):
            var mstEdges = result.Item1;
            var totalWeight = result.Item2;

            if (mstEdges == null || mstEdges.Count == 0)
            {
                sb.AppendLine("Невозможно построить: граф пуст или несвязный.");
            }
            else
            {
                sb.AppendLine("Рёбра МОД:");

                // ВАЖНО: Так как у Edge нет свойства From, нам нужно знать, как библиотека хранит связи.
                // Часто в таких лабораторных работах ребра в MST хранятся как "Parent -> Child".
                // Если CaveGraph возвращает Dictionary<string, Edge> (где ключ - это текущая вершина, а Edge.Target - родитель),
                // то код будет другим.

                // ПОПРОБУЙТЕ ЭТОТ ВАРИАНТ (если mstEdges это List<Edge>):
                // Скорее всего, вам придется вывести просто веса или целевые узлы, 
                // ЛИБО библиотека возвращает не List<Edge>, а List<(string U, string V, int W)>

                // Попробуем вывести через foreach с явным типом, чтобы понять структуру:
                foreach (var edge in mstEdges)
                {
                    // Так как у Edge есть только Target и Weight, мы не знаем Source.
                    // Это ошибка проектирования библиотеки для задачи MST.

                    // ВРЕМЕННЫЙ КОД ДЛЯ ОТЛАДКИ:
                    sb.AppendLine($"  ... -> {edge.Target} (Вес: {edge.Weight})");
                }

                sb.AppendLine($"\n Суммарная длина тоннелей: {totalWeight} м");
                sb.AppendLine($" Количество рёбер: {mstEdges.Count}");
            }
            sb.AppendLine($"\n Время выполнения: {stopwatch.ElapsedMilliseconds} мс");

            lblOutput.Text = sb.ToString();
        }

        private void btnVariantTask_Click(object sender, EventArgs e)
        {
            // ВАРИАНТ 9: Найти кратчайший маршрут выхода из пещеры
            // Предположим, что "Выход" — это специальная вершина, или пользователь выбирает её

            string start = cmbStart.SelectedItem?.ToString();
            string exit = "Выход"; // Или добавьте cmbExit и берите из него

            if (string.IsNullOrEmpty(start))
            {
                lblOutput.Text = "Выберите стартовую пещеру!";
                return;
            }

            var stopwatch = Stopwatch.StartNew();

            // Проверяем, существует ли вершина "Выход"
            var allVertices = caveSystem.GetAllVertices();
            if (!allVertices.Contains(exit))
            {
                // Если "Выход" не найден, предлагаем выбрать конечную вершину
                lblOutput.Text = $"Вершина '{exit}' не найдена в графе.\n" +
                                $"Доступные вершины:\n{string.Join(", ", allVertices.Take(10))}" +
                                (allVertices.Count > 10 ? "..." : "");
                stopwatch.Stop();
                lblOutput.Text += $"\n\n Время выполнения: {stopwatch.ElapsedMilliseconds} мс";
                return;
            }

            var path = caveSystem.GetShortestPath(start, exit);
            var distances = caveSystem.Dijkstra(start);
            stopwatch.Stop();

            var sb = new StringBuilder();
            sb.AppendLine($" Задача варианта 9: выход из пещеры '{start}'\n");

            if (path.Count == 0 || distances[exit] == int.MaxValue)
            {
                sb.AppendLine($"Выход '{exit}' недостижим из '{start}'!");
                sb.AppendLine("Проверьте связность графа или используйте поиск компонент.");
            }
            else
            {
                sb.AppendLine($"Кратчайший путь к выходу:\n");
                for (int i = 0; i < path.Count; i++)
                {
                    sb.AppendLine($"  {i + 1}. {path[i]}");
                }
                sb.AppendLine($"\nОбщая длина маршрута: {distances[exit]} м");
                sb.AppendLine($"Количество переходов: {path.Count - 1}");
            }
            sb.AppendLine($"\nВремя выполнения: {stopwatch.ElapsedMilliseconds} мс");

            lblOutput.Text = sb.ToString();
        }
    }
}
