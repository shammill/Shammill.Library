using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.Algorithms
{
    public class Dijkstras
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void AddVertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public List<char> ShortestPath(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph();
            g.AddVertex('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            g.AddVertex('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            g.AddVertex('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            g.AddVertex('D', new Dictionary<char, int>() { { 'F', 8 } });
            g.AddVertex('E', new Dictionary<char, int>() { { 'H', 1 } });
            g.AddVertex('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            g.AddVertex('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            g.AddVertex('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });

            g.ShortestPath('A', 'H').ForEach(x => Console.WriteLine(x));
        }
    }
}
}
