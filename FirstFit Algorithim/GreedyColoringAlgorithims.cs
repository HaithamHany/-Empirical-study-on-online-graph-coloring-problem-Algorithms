using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFit_Algorithim
{
    public class GreedyColoringAlgorithims
    {
        public int FirstFit(Graph G)
        {
            // Initialize an array to keep track of the colors assigned to each vertex
            int[] colors = new int[G.NumVertices];

            // Assign the first vertex the first color
            colors[0] = 1;

            // Loop through the remaining vertices
            for (int i = 1; i < G.NumVertices; i++)
            {
                // Initialize an array to keep track of the colors used by the neighbors of the current vertex
                bool[] usedColors = new bool[G.NumVertices + 1];

                // Loop through the neighbors of the current vertex
                for (int j = 0; j < G.NumVertices; j++)
                {
                    if (G.IsAdjacent(i, j) && colors[j] != 0)
                    {
                        // Mark the color used by the neighbor as used
                        usedColors[colors[j]] = true;
                    }
                }

                // Find the smallest unused color for the current vertex
                int color = 1;
                while (usedColors[color])
                {
                    color++;
                }

                // Assign the smallest unused color to the current vertex
                colors[i] = color;
            }

            // Find the maximum color used
            int maxColor = 0;
            for (int i = 0; i < G.NumVertices; i++)
            {
                if (colors[i] > maxColor)
                {
                    maxColor = colors[i];
                }
            }

            // Return the number of colors used
            return maxColor;
        }
    }
}
