namespace FirstFit_Algorithim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n number of graph vertices");
            var n_input = Console.ReadLine();
            var n = Convert.ToInt32(n_input);

            Console.WriteLine("Enter value of k value for colorable graph");
            var k_input = Console.ReadLine();
            var k = Convert.ToInt32(k_input);

            Console.WriteLine("Set the number N of graph instances");
            var N_input = Console.ReadLine();
            var N = Convert.ToInt32(N_input);

            Console.WriteLine("Loading.... the bigger n the more time it takes.");
            KColorableGraphGenerator generator = new KColorableGraphGenerator();
            var graphs = generator.GenerateGraphs(n, k, N);
            var firstFitResults = new List<double>();
     
            // print the graphs for verification
           foreach (Graph graph in graphs)
           {
                var algorithims = new GreedyColoringAlgorithims();
                var FirstFitResult = algorithims.FirstFit(graph);
                firstFitResults.Add(FirstFitResult);
           }

            Console.WriteLine($"The average competitve ratio is {CalculateAverageCompetitiveRatio(k, firstFitResults)}");
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