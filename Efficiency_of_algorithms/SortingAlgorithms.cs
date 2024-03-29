using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efficiency_of_algorithms
{
    public class SortingAlgorithms
    {
        [Params(10, 1000, 100000)]
        public int arraySize { get; set; }
        public static int[] arr { get; set; }


        //[Params("random", "sorted", "reversed", "almost sorted", "few unique")]
        [Params("random", "sorted", "reversed", "almost sorted", "few unique")]
        public string genType { get; set; }

        public SortingAlgorithms()
        {
           int[] myIntArray = Generators.GenerateReversedArray(arraySize);
           // arr = array;
            
         
            

            switch (genType)
            {
                case "random":
                    arr = Generators.GenerateRandomArray(arraySize);
                    break;
                case "sorted":
                    arr = Generators.GenerateSortedArray(arraySize);
                     break;
                case "reversed":
                    arr = Generators.GenerateReversedArray(arraySize);
                    break;
                case "almost sorted":
                    arr = Generators.GenerateAlmostSortedArray(arraySize,10);
                    break;
                case "few unique":
                    arr = Generators.GenerateFewUniqueArray(arraySize);
                    break;
                default:
                    arr = Generators.GenerateRandomArray(1);
                    break;
            }

           



        }


        public void showArray()
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");

        }

        //-------------------------------------------------------------------------------------------------------------------InsertionSort

        [Benchmark]
        public void insertionSort()
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------Merge Sort 
        void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        void mSort(int[] arr, int l, int r)
        {
            if (l < r)
            {

                // Find the middle point
                int m = l + (r - l) / 2;

                // Sort first and second halves
                mSort(arr, l, m);
                mSort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        [Benchmark]

        public void mergeSort()
        {


            mSort(arr, 0, arr.Length - 1);



        }


        //-------------------------------------------------------------------------------------------------------------------QuickSort

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // This function takes last element as pivot,
        // places the pivot element at its correct position
        // in sorted array, and places all smaller to left
        // of pivot and all greater elements to right of pivot
        static int partition(int[] arr, int low, int high)
        {
            // Choosing the pivot
            int pivot = arr[high];

            // Index of smaller element and indicates
            // the right position of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of smaller element
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, high);
            return (i + 1);
        }

        // The main function that implements QuickSort
        // arr[] --> Array to be sorted,
        // low --> Starting index,
        // high --> Ending index
        static void qSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // and after partition index
                qSort(arr, low, pi - 1);
                qSort(arr, pi + 1, high);
            }


        }


        [Benchmark]
        public void quickSort()
        {

            int N = arr.Length;
            qSort(arr, 0, N - 1);


        }







    }
}
