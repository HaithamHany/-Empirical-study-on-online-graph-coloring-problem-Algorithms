using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit_Algorithim
{
    public class Graph
    {
        private List<int>[] adjacencyList;
        private int numVertices;

        public Graph(int n)
        {
            numVertices = n;
            adjacencyList = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public int NumVertices
        {
            get { return numVertices; }
        }

        public bool IsAdjacent(int i, int j)
        {
            return adjacencyList[i].Contains(j);
        }

        public void AddEdge(int i, int j)
        {
            adjacencyList[i].Add(j);
            adjacencyList[j].Add(i);
        }

        public List<int> GetNeighbors(int vertex)
        {
            return adjacencyList[vertex];
        }

    }
}
