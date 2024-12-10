using System;

namespace DSAExercisesProject.Sorting.BubbleSort {

    class BubbleSort
    {
        private static void StandardSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }


        private static void OptimisedSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                
                        swapped = true;
                    }
                }

                if(!swapped) break;
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        public static void RunTests()
        {
            int[] arr1 = { 64, 34, 25, 12, 22, 11, 90 };
            int[] arr2 = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Original Array 1:");
            PrintArray(arr1);
            StandardSort(arr1);
            Console.WriteLine("Sorted Array 1 (Unoptimised):");
            PrintArray(arr1);
            Console.WriteLine("Original Array 2:");
            PrintArray(arr2);
            OptimisedSort(arr2);
            Console.WriteLine("Sorted Array 2 (Optimised)");
            PrintArray(arr2);

        }


    }


}





