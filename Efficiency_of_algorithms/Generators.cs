using System;
using System.Linq;

public static class Generators
{
    private static readonly Random random = new Random();

    public static int[] GenerateRandomArray(int size)
    {
        return Enumerable.Range(0, size)
                         .Select(_ => random.Next())
                         .ToArray();
    }

    public static int[] GenerateSortedArray(int size)
    {
        return Enumerable.Range(0, size)
                         .ToArray();
    }

    public static int[] GenerateReversedArray(int size)
    {
        return Enumerable.Range(0, size)
                         .Select(x => size - x - 1)
                         .ToArray();
    }

    public static int[] GenerateAlmostSortedArray(int size, double percentDisordered)
    {
        int[] sortedArray = GenerateSortedArray(size);
        int numDisordered = (int)(size * percentDisordered / 100);

        for (int i = 0; i < numDisordered; i++)
        {
            int index1 = random.Next(0, size);
            int index2 = random.Next(0, size);
            int temp = sortedArray[index1];
            sortedArray[index1] = sortedArray[index2];
            sortedArray[index2] = temp;
        }
        return sortedArray;
    }

    public static int[] GenerateFewUniqueArray(int size)
    {
        const int numUniqueValues = 10;
        const int minValue = 1;
        const int maxValue = 10;

        if (numUniqueValues > maxValue - minValue + 1)
        {
            throw new ArgumentException("Number of unique values exceeds the range of values.");
        }

        int[] uniqueValues = Enumerable.Range(minValue, numUniqueValues).ToArray();
        int[] array = new int[size];
        int currentIndex = 0;
        int valuesPerGroup = size / numUniqueValues;

        for (int i = 0; i < numUniqueValues; i++)
        {
            for (int j = 0; j < valuesPerGroup; j++)
            {
                array[currentIndex++] = uniqueValues[i];
            }
        }

        // Fill the remaining slots with random values from the range
        for (int i = currentIndex; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
        }

        // Shuffle the array
        for (int i = 0; i < size; i++)
        {
            int temp = array[i];
            int randomIndex = random.Next(i, size);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }

        return array;
    }
}
