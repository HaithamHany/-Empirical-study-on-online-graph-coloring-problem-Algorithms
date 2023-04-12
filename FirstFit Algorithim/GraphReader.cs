using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit_Algorithim
{
    public class GraphReader
    {
        public List<Graph> ReadGraphs()
        {
            using (StreamReader reader = new StreamReader("all_graphs.txt"))
            {
                List<Graph> graphs = new List<Graph>();
                string line;
                List<string> edges = new List<string>();

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        // end of graph, create new Graph object and add to list
                        graphs.Add(ParseGraph(edges));
                        edges = new List<string>();
                    }
                    else
                    {
                        edges.Add(line);
                    }
                }

                // create Graph object for the last graph
                if (edges.Count > 0)
                {
                    graphs.Add(ParseGraph(edges));
                }

                return graphs;
            }
        }

        private static Graph ParseGraph(List<string> edges)
        {
            HashSet<int> vertices = new HashSet<int>();
            foreach (string edge in edges)
            {
                string[] parts = edge.Split(' ');
                int u = int.Parse(parts[0]) - 1; // subtract 1 to convert to 0-based indexing
                int v = int.Parse(parts[1]) - 1;
                vertices.Add(u);
                vertices.Add(v);
            }

            Graph graph = new Graph(50);
            foreach (string edge in edges)
            {
                string[] parts = edge.Split(' ');
                int u = int.Parse(parts[0]) - 1;
                int v = int.Parse(parts[1]) - 1;
                graph.AddEdge(u, v);
            }
            return graph;
        }
    }
}
