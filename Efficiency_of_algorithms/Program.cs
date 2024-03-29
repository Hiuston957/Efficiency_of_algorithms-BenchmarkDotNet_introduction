
using BenchmarkDotNet.Running;

namespace Efficiency_of_algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

           var results = BenchmarkRunner.Run<SortingAlgorithms>();


        }
    }
}
