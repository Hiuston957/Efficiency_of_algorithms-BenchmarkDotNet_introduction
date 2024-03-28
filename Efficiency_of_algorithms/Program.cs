
using BenchmarkDotNet.Running;

namespace Efficiency_of_algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] myIntArray = { 5, 2, 8, 1, 6 };
            Generators XD = new Generators();

           // XD.showArray();
            //XD.insertionSort();


           XD.quickSort();
         
       
          //  XD.showArray();

            var results = BenchmarkRunner.Run<Generators>();




        }
    }
}
