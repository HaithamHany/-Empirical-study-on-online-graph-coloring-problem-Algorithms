namespace FirstFit_Algorithim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GraphReader reader = new GraphReader();
            var graphs  = reader.ReadGraphs();
            var 

            // print the graphs for verification
            foreach (Graph graph in graphs)
            {
                // Add the FirstFit or CBIP calls here using the graph as input variable.
            }
        }
    }
}