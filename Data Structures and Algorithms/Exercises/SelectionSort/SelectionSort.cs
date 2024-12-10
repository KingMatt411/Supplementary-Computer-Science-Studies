using System;

namespace Exercises.SelectionSort
{
    class SelectionSort
    {
        private static void Sort(int[] arr)
        {
            int n = arr.Length;
            int swapCount = 0;
      
            for (int i = 0; i < n - 1; i++) // Start each cycle from incrementing array indexes
            {
                int minIndex = i; // Start by assuming the current index holds the smallest element

                for (int j = i + 1; j < n; j++) // Find the smallest index in the rest of the array
                {
                    if (arr[j] < arr[minIndex]) minIndex = j; // Update minIndex if a smaller value is found
                }

                // Swap the positions of the smallest index and the starting (outer loop) position
                // ReSharper disable once SwapViaDeconstruction
                if (minIndex != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                    swapCount++;
                }
            }
            Console.WriteLine("Swaps performed during selection sort: " + swapCount);
        }
        
    
        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        public static void RunTests()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Original Array:");
            PrintArray(arr);

            Sort(arr);

            Console.WriteLine("Sorted Array:");
            PrintArray(arr);
        }
    }  
}