using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphLogic
{
    // Описание тоннеля (Ребро)
    public class Edge
    {
        public string Target { get; set; }
        public int Weight { get; set; }



    }

    public class CaveGraph
    {
        // Список смежности: Название пещеры -> Список тоннелей
        public Dictionary<string, List<Edge>> AdjacencyList { get; private set; } = new Dictionary<string, List<Edge>>();

        public void AddEdge(string source, string target, int weight)
        {
            if (!AdjacencyList.ContainsKey(source)) AdjacencyList[source] = new List<Edge>();
            if (!AdjacencyList.ContainsKey(target)) AdjacencyList[target] = new List<Edge>();

            // Тоннели в пещерах обычно двусторонние
            if (!AdjacencyList[source].Any(e => e.Target == target))
                AdjacencyList[source].Add(new Edge { Target = target, Weight = weight });

            if (!AdjacencyList[target].Any(e => e.Target == source))
                AdjacencyList[target].Add(new Edge { Target = source, Weight = weight });
        }

        public List<List<string>> FindConnectedComponents()
        {
            var components = new List<List<string>>();
            var visited = new HashSet<string>();
            var allVertices = AdjacencyList.Keys.ToList();

            foreach (var vertex in allVertices)
            {
                if (!visited.Contains(vertex))
                {
                    var component = new List<string>();
                    BFS_ForComponent(vertex, visited, component);
                    components.Add(component);
                }
            }

            return components;
        }


        // Вспомогательный метод BFS для сбора компоненты
        private void BFS_ForComponent(string start, HashSet<string> visited, List<string> component)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                component.Add(current);

                foreach (var neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor.Target))
                    {
                        visited.Add(neighbor.Target);
                        queue.Enqueue(neighbor.Target);
                    }
                }
            }
        }



        // Получить список всех вершин (удобно для UI)
        public List<string> GetAllVertices()
        {
            return AdjacencyList.Keys.ToList();
        }


        // BFS (Обход в ширину) - находит кратчайший путь по количеству ребер
        public List<string> GetBFS(string startNode)
        {
            var visited = new List<string>();
            var queue = new Queue<string>();

            if (!AdjacencyList.ContainsKey(startNode)) return visited;

            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor.Target))
                    {
                        visited.Add(neighbor.Target);
                        queue.Enqueue(neighbor.Target);
                    }
                }
            }
            return visited;
        }

        // DFS (Обход в глубину) - на основе рекурсии
        public List<string> GetDFS(string startNode)
        {
            var visited = new List<string>();
            DFS_Recursive(startNode, visited);
            return visited;
        }

        private void DFS_Recursive(string current, List<string> visited)
        {
            if (!AdjacencyList.ContainsKey(current) || visited.Contains(current)) return;

            visited.Add(current);
            foreach (var neighbor in AdjacencyList[current])
            {
                DFS_Recursive(neighbor.Target, visited);
            }
        }

        // Проверка достижимости (используем BFS)
        public bool IsReachable(string start, string end)
        {
            return GetBFS(start).Contains(end);
        }

        public void Clear() => AdjacencyList.Clear();

        // Вставьте этот код внутрь класса CaveGraph, после существующих методов

        /// <summary>
        /// Реализация алгоритма Дейкстры. Возвращает словарь с кратчайшими расстояниями от startNode до всех остальных вершин.
        /// Если вершина недостижима, расстояние будет int.MaxValue.
        /// </summary>
        public Dictionary<string, int> Dijkstra(string startNode)
        {
            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>(); // Для восстановления пути
            var unvisited = new HashSet<string>(AdjacencyList.Keys);

            // Инициализация расстояний
            foreach (var vertex in AdjacencyList.Keys)
            {
                distances[vertex] = int.MaxValue;
                previousNodes[vertex] = null;
            }
            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                // Находим непосещенную вершину с минимальным расстоянием
                string current = null;
                int minDistance = int.MaxValue;
                foreach (var vertex in unvisited)
                {
                    if (distances[vertex] < minDistance)
                    {
                        minDistance = distances[vertex];
                        current = vertex;
                    }
                }

                // Если все оставшиеся вершины недостижимы, выходим
                if (current == null || minDistance == int.MaxValue) break;

                unvisited.Remove(current);

                // Обновляем расстояния до соседей
                foreach (var neighbor in AdjacencyList[current])
                {
                    int alt = distances[current] + neighbor.Weight;
                    if (alt < distances[neighbor.Target])
                    {
                        distances[neighbor.Target] = alt;
                        previousNodes[neighbor.Target] = current;
                    }
                }
            }

            return distances;
        }

        /// <summary>
        /// Восстанавливает и возвращает список вершин кратчайшего пути от startNode до endNode.
        /// Использует данные, полученные из алгоритма Дейкстры.
        /// </summary>
        //public List<string> GetShortestPath(string startNode, string endNode)
        //{
        //    var distances = Dijkstra(startNode);

        //    // Если конечная вершина недостижима
        //    if (distances[endNode] == int.MaxValue)
        //    {
        //        return new List<string>(); // Возвращаем пустой список
        //    }

        //    var path = new Stack<string>();
        //    string current = endNode;

        //    // Восстанавливаем путь, двигаясь назад от конца к началу
        //    while (current != null)
        //    {
        //        path.Push(current);
        //        // Чтобы найти предыдущую вершину, нам нужно снова запустить логику Дейкстры,
        //        // но для простоты можно модифицировать основной метод, чтобы он возвращал и previousNodes.
        //        // Для текущей архитектуры мы можем сделать небольшой хак или добавить вспомогательный метод.
        //        // Более правильный вариант - изменить Dijkstra, чтобы он возвращал кортеж (distances, previousNodes).

        //        // --- Исправление для более чистой архитектуры ---
        //        // Лучше создать приватный метод, который возвращает оба словаря
        //        var dijkstraResult = RunDijkstraFull(startNode);
        //        var prev = dijkstraResult.PreviousNodes[current];
        //        current = prev;
        //    }

        //    return path.ToList();
        //}

        // Приватная структура для хранения результатов полного запуска Дейкстры
        private class DijkstraResult
        {
            public Dictionary<string, int> Distances { get; set; }
            public Dictionary<string, string> PreviousNodes { get; set; }
        }

        // Приватный метод, который делает всю работу и возвращает оба нужных словаря
        private DijkstraResult RunDijkstraFull(string startNode)
        {
            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var unvisited = new HashSet<string>(AdjacencyList.Keys);

            foreach (var vertex in AdjacencyList.Keys)
            {
                distances[vertex] = int.MaxValue;
                previousNodes[vertex] = null;
            }
            distances[startNode] = 0;

            while (unvisited.Count > 0)
            {
                string current = null;
                int minDistance = int.MaxValue;
                foreach (var vertex in unvisited)
                {
                    if (distances[vertex] < minDistance)
                    {
                        minDistance = distances[vertex];
                        current = vertex;
                    }
                }

                if (current == null || minDistance == int.MaxValue) break;
                unvisited.Remove(current);

                foreach (var neighbor in AdjacencyList[current])
                {
                    int alt = distances[current] + neighbor.Weight;
                    if (alt < distances[neighbor.Target])
                    {
                        distances[neighbor.Target] = alt;
                        previousNodes[neighbor.Target] = current;
                    }
                }
            }
            return new DijkstraResult { Distances = distances, PreviousNodes = previousNodes };
        }

        // Переписываем публичные методы, чтобы они использовали общую логику
        //public Dictionary<string, int> Dijkstra(string startNode)
        //{
        //    return RunDijkstraFull(startNode).Distances;
        //}

        public List<string> GetShortestPath(string startNode, string endNode)
        {
            var result = RunDijkstraFull(startNode);
            if (result.Distances[endNode] == int.MaxValue) return new List<string>();

            var path = new Stack<string>();
            string current = endNode;
            while (current != null)
            {
                path.Push(current);
                current = result.PreviousNodes[current];
            }
            return path.ToList();
        }




        // Вставьте этот код внутрь класса CaveGraph

        /// <summary>
        /// Находит все точки сочленения в графе.
        /// Точка сочленения — это вершина, удаление которой увеличивает количество компонент связности.
        /// </summary>
        public List<string> FindArticulationPoints()
        {
            var articulationPoints = new HashSet<string>();
            var visited = new HashSet<string>();
            var disc = new Dictionary<string, int>(); // Время обнаружения вершины
            var low = new Dictionary<string, int>();  // Самое раннее время обнаружения, доступное из поддерева
            var parent = new Dictionary<string, string>();
            int time = 0;

            // Вспомогательная рекурсивная функция
            void APUtil(string u)
            {
                int children = 0;
                visited.Add(u);
                disc[u] = low[u] = ++time;

                foreach (var neighborEdge in AdjacencyList[u])
                {
                    string v = neighborEdge.Target;
                    if (!visited.Contains(v))
                    {
                        children++;
                        parent[v] = u;
                        APUtil(v);

                        // Обновляем low значение для u
                        low[u] = Math.Min(low[u], low[v]);

                        // u является точкой сочленения в двух случаях:
                        // 1) u - корень дерева обхода и имеет >= 2 детей
                        if (parent.ContainsKey(u) == false && children > 1)
                            articulationPoints.Add(u);

                        // 2) u не корень и low[v] >= disc[u]
                        if (parent.ContainsKey(u) && low[v] >= disc[u])
                            articulationPoints.Add(u);
                    }
                    else if (v != parent[u]) // Обратное ребро
                    {
                        low[u] = Math.Min(low[u], disc[v]);
                    }
                }
            }

            // Запускаем поиск для каждой компоненты связности
            foreach (var vertex in AdjacencyList.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    parent[vertex] = null; // Корень не имеет родителя
                    APUtil(vertex);
                }
            }

            return articulationPoints.ToList();
        }





        // Вставьте этот код внутрь класса CaveGraph

        /// <summary>
        /// Строит минимальное остовное дерево с помощью алгоритма Прима.
        /// Возвращает список ребер, входящих в МОД, и его общий вес.
        /// </summary>
        public (List<Edge> MSTEdges, int TotalWeight) PrimsAlgorithm()
        {
            var mstEdges = new List<Edge>();
            var inMST = new HashSet<string>();
            var allVertices = AdjacencyList.Keys.ToList();

            if (allVertices.Count == 0) return (mstEdges, 0);

            // Начинаем с первой вершины
            string startVertex = allVertices[0];
            inMST.Add(startVertex);

            // Используем приоритетную очередь для выбора ребра с минимальным весом
            // PriorityQueue доступен в .NET 6+, если у вас старая версия, используйте SortedSet или простой список
            var pq = new System.Collections.Generic.PriorityQueue<(int weight, string from, string to), int>();

            // Добавляем все ребра из стартовой вершины в очередь
            foreach (var edge in AdjacencyList[startVertex])
            {
                pq.Enqueue((edge.Weight, startVertex, edge.Target), edge.Weight);
            }

            int totalWeight = 0;

            while (pq.Count > 0 && inMST.Count < allVertices.Count)
            {
                var (weight, from, to) = pq.Dequeue();

                // Если вершина 'to' уже в дереве, пропускаем это ребро (оно создает цикл)
                if (inMST.Contains(to)) continue;

                // Добавляем вершину и ребро в МОД
                inMST.Add(to);
                mstEdges.Add(new Edge { Target = to, Weight = weight }); // Храним как "ребро из 'from' в 'to'"
                totalWeight += weight;

                // Добавляем все ребра из новой вершины 'to' в очередь
                foreach (var nextEdge in AdjacencyList[to])
                {
                    if (!inMST.Contains(nextEdge.Target))
                    {
                        pq.Enqueue((nextEdge.Weight, to, nextEdge.Target), nextEdge.Weight);
                    }
                }
            }

            return (mstEdges, totalWeight);
        }




    }
}
