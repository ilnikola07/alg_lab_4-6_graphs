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

        // --- ЛАБОРАТОРНАЯ №4: ОБХОДЫ ---

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
    }
}