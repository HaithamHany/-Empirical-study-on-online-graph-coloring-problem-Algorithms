using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit_Algorithim
{
    public class CBIP
    {
        private Graph graph;
        private int[] color;
        private int maxUsedColor;
        private HashSet<int> set1, set2;

        //Using Bipartite graph
        public CBIP(Graph inputGraph)
        {
            graph = inputGraph;
            int n = graph.NumVertices;
            color = new int[n];
            Array.Fill(color, -1);
            set1 = new HashSet<int>();
            set2 = new HashSet<int>();
        }

        private void ProcessVertex(int v)
        {
            if (color[v] == -1)
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(v);
                color[v] = 0;
                set1.Add(v);
                int maxColor = 0;
                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();
                    int uColor = color[u];
                    HashSet<int> neighborSet = (uColor == 0) ? set2 : set1;
                    foreach (int w in graph.GetNeighbors(u))
                    {
                        if (color[w] == -1)
                        {
                            neighborSet.Add(w);
                            maxColor = Math.Max(maxColor, uColor + 1);
                            color[w] = uColor + 1;
                            queue.Enqueue(w);
                        }
                    }
                }
                maxUsedColor = Math.Max(maxUsedColor, maxColor);
            }
        }

        public int GetColorsUsed()
        {
            for (int i = 0; i < graph.NumVertices; i++)
            {
                ProcessVertex(i);
            }

            int[] colorCount = new int[maxUsedColor + 1];
            for (int i = 0; i < color.Length; i++)
            {
                colorCount[color[i]]++;
            }

            int totalColors = 0;

            for (int i = 0; i < colorCount.Length; i++)
            {
                if (colorCount[i] > 0)
                {
                    totalColors++;
                }
            }

            return  totalColors;
        }
    }
}
