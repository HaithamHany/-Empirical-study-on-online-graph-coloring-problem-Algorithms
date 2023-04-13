namespace FirstFit_Algorithim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = new int[]{ 50, 100, 200, 400, 800, 1600 }; //n 
            var k = new int []{ 2, 3, 4 };

            KColorableGraphGenerator generator = new KColorableGraphGenerator();
            Dictionary<int, List<List<Graph>>> allGraphs = new Dictionary<int, List<List<Graph>>>();

            foreach (var k_value in k)
            {
                var k_graphsList = new List<List<Graph>>();

                foreach (var n_value in n)
                {
                    var graphs = generator.GenerateGraphs(n_value, k_value, 0.5d, 100);
                    k_graphsList.Add(graphs);
                }

                if(!allGraphs.ContainsKey(k_value))
                {
                    allGraphs.Add(k_value, k_graphsList);
                }
                else
                {
                    allGraphs[k_value] = k_graphsList;
                }
            }

            foreach (var all in allGraphs)
            {
                var allAvg = new List<double>();

                foreach (var graphs in all.Value)
                {
                    var firstFitResults = new List<double>();
                    foreach (Graph graph in graphs)
                    {
                        // Add the FirstFit or CBIP calls here using the graph as input variable.
                        var algorithims = new GreedyColoringAlgorithims();
                        var FirstFitResult = algorithims.FirstFit(graph);
                        firstFitResults.Add(FirstFitResult);
                    }
                    var res = CalculateAverageCompetitiveRatio(all.Key, firstFitResults);
                    Console.WriteLine($"This avg for {all.Key} of count {graphs.FirstOrDefault().NumVertices - 1} is {res}");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    allAvg.Add(res);
                }
            }
        }


        static double CalculateAverageCompetitiveRatio(int current_k, List<double> algorithmColorsUsed)
        {
            int N = 100; // Total number of graphs
            double sumOfCompetitiveRatios = 0;

            for (int i = 0; i < N; i++)
            {
                double competitiveRatio = algorithmColorsUsed[i] / current_k;
                sumOfCompetitiveRatios += competitiveRatio;
            }

            double averageCompetitiveRatio = sumOfCompetitiveRatios / N;
            return averageCompetitiveRatio;
        }
    }
}