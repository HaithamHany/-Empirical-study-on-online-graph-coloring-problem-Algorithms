using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit_Algorithim
{
    internal class KColorableGraphGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">number of vertices</param>
        /// <param name="k">number of colors</param>
        /// <param name="N">number of graphs to generate</param>
        /// <exception cref="Exception"></exception>
        public List<Graph> GenerateGraphs(int n, int k, int N)
        {
            var graphs = new List<Graph>();
            double p = 0.5d; //probability of choosing edges

            for (int t = 0; t < N; t++)
            {
                List<int>[] sets = new List<int>[k];
                Random random = new Random();
                var graph = new Graph(n + 1);

                // partition {1, 2, ..., n} into k disjoint subsets
                for (int i = 0; i < k; i++)
                {
                    sets[i] = new List<int>();
                    for (int j = i + 1; j <= n; j += k)
                    {
                        sets[i].Add(j);
                    }
                }
                sets = sets.OrderBy(x => random.Next()).ToArray();

                // assign colors to vertices based on their subset
                int[] coloring = new int[n];
                for (int i = 0; i < k; i++)
                {
                    foreach (int j in sets[i])
                    {
                        coloring[j - 1] = i;
                    }
                }

            
                //Initialize 
                bool[][] adjacency = new bool[n][];
                for (int i = 0; i < n; i++)
                {
                    adjacency[i] = new bool[n];    
                }

                // generate edges with probability p
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (!adjacency[i][j])
                        {
                            bool edge = false;
                            for (int s = 0; s < k; s++)
                            {
                                if (sets[s].Contains(i + 1) && sets[s].Contains(j + 1))
                                {
                                    edge = true;
                                    break;
                                }
                            }

                            if (!edge && random.NextDouble() < p)
                            {
                                adjacency[i][j] = adjacency[j][i] = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (adjacency[i][j] && coloring[i] == coloring[j])
                        {
                            throw new Exception($"Error: edge ({i + 1}, {j + 1}) is not properly colored.");
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (adjacency[i][j])
                        {
                            graph.AddEdge(i + 1, j + 1);
                        }
                    }
                }

                graphs.Add(graph);
            }

            return graphs;
        }

    }
}
