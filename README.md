Efficiency of Sorting Algorithms Benchmarking
This C# program benchmarks the efficiency of various sorting algorithms using the BenchmarkDotNet library. Here's a brief overview of the program components:

SortingAlgorithms Class
This class contains implementations of three sorting algorithms: Insertion Sort, Merge Sort, and Quick Sort. It also includes methods for generating different types of arrays for testing the sorting algorithms.

Properties:
arraySize: Specifies the size of the arrays to be generated and sorted. It's set as a parameter with values 10, 1000, and 100000.
genType: Specifies the type of array to generate (random, sorted, reversed, almost sorted, few unique). It's also set as a parameter.
Constructor:
Initializes the array based on the selected genType.
Methods:
showArray(): Displays the contents of the array.
Sorting Algorithms:
Insertion Sort: Sorts the array using the Insertion Sort algorithm.
Merge Sort: Sorts the array using the Merge Sort algorithm.
Quick Sort: Sorts the array using the Quick Sort algorithm.
Generators Class
This class contains methods for generating different types of arrays:

GenerateRandomArray(): Generates an array of random integers.
GenerateSortedArray(): Generates an array of integers in ascending order.
GenerateReversedArray(): Generates an array of integers in descending order.
GenerateAlmostSortedArray(): Generates an almost sorted array with a specified percent of disorder.
GenerateFewUniqueArray(): Generates an array with few unique values.
