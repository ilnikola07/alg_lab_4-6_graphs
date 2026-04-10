using GraphLogic;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProjectLabs
{
    public class CaveGraphTests
    {
        private CaveGraph _graph;

        // В xUnit конструктор заменяет [TestInitialize]
        public CaveGraphTests()
        {
            _graph = new CaveGraph();
            _graph.AddEdge("A", "B", 1);
            _graph.AddEdge("A", "C", 4);
            _graph.AddEdge("B", "C", 2);
            _graph.AddEdge("B", "D", 5);
            _graph.AddEdge("C", "D", 1);
        }

        [Fact]
        public void TestDijkstra_SimpleCase()
        {
            var distances = _graph.Dijkstra("A");
            Assert.Equal(0, distances["A"]);
            Assert.Equal(1, distances["B"]);
            Assert.Equal(3, distances["C"]);
            Assert.Equal(4, distances["D"]);
        }

        [Fact]
        public void TestGetShortestPath_ExistingPath()
        {
            var path = _graph.GetShortestPath("A", "D");
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, path);
        }


        [Fact]
        public void TestDijkstra_SingleNode()
        {
            var singleNodeGraph = new CaveGraph();
            singleNodeGraph.AddEdge("X", "X", 0);
            var distances = singleNodeGraph.Dijkstra("X");
            Assert.Equal(0, distances["X"]);
        }

        [Fact]
        public void TestDijkstra_MultiplePaths()
        {
            _graph.AddEdge("A", "D", 10);
            var distances = _graph.Dijkstra("A");
            Assert.Equal(4, distances["D"]);
        }

        [Fact]
        public void TestBFS_ForComponent_SimpleGraph()
        {
            // Очищаем граф для чистого теста BFS, если нужно
            var localGraph = new CaveGraph();
            localGraph.AddEdge("A", "B", 1);
            localGraph.AddEdge("B", "C", 1);

            var visited = new HashSet<string>();
            var component = new List<string>();
            localGraph.BFS_ForComponent("A", visited, component);

            Assert.Equal(new List<string> { "A", "B", "C" }, component);
        }

        [Fact]
        public void TestGetAllVertices_SimpleGraph()
        {
            var vertices = _graph.GetAllVertices();
            // Проверяем, что все вершины присутствуют в результате
            Assert.Contains("A", vertices);
            Assert.Contains("B", vertices);
            Assert.Contains("C", vertices);
            Assert.Contains("D", vertices);
            Assert.Equal(4, vertices.Count);
        }

        [Fact]
        public void TestGetBFS_SimpleGraph()
        {
            var result = _graph.GetBFS("A");
            // Проверяем наличие всех достижимых вершин
            Assert.Equal(4, result.Count);
            Assert.Contains("D", result);
        }

        [Fact]
        public void TestGetDFS_SimpleGraph()
        {
            var result = _graph.GetDFS("A");
            Assert.Equal(4, result.Count);
            Assert.Contains("D", result);
        }

        [Fact]
        public void TestPrimsAlgorithm_SimpleGraph()
        {
            var graph = new CaveGraph();
            // Треугольник с разными весами
            graph.AddEdge("A", "B", 10);
            graph.AddEdge("B", "C", 5);
            graph.AddEdge("A", "C", 1); // Кратчайший путь A-C-B (вес 1+5=6)

            var (edges, totalWeight) = graph.PrimsAlgorithm();

            // Для 3 вершин в МОД должно быть 2 ребра
            Assert.Equal(2, edges.Count);
            Assert.Equal(6, totalWeight);
        }

        [Fact]
        public void TestPrimsAlgorithm_DisconnectedGraph()
        {
            var graph = new CaveGraph();
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("C", "D", 1); // Две разные компоненты

            var (edges, totalWeight) = graph.PrimsAlgorithm();

            // Алгоритм Прима из кода строит дерево только для ОДНОЙ компоненты (откуда начал)
            Assert.Single(edges);
            Assert.Equal(1, totalWeight);
        }

        [Fact]
        public void TestPrimsAlgorithm_EmptyGraph()
        {
            var graph = new CaveGraph();
            var (edges, totalWeight) = graph.PrimsAlgorithm();

            Assert.Empty(edges);
            Assert.Equal(0, totalWeight);
        }

        [Fact]
        public void TestFindArticulationPoints_StarGraph()
        {
            var graph = new CaveGraph();
            // Звезда: A в центре, B, C, D вокруг. A — точка сочленения.
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("A", "D", 1);

            var aps = graph.FindArticulationPoints();

            Assert.Single(aps);
            Assert.Equal("A", aps[0]);
        }
    }
}