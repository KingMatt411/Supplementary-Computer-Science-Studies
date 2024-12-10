namespace DSAExercisesProject.Sorting.InsertionSort
{
    class InsertionSort
    {
        private static void Sort(int[] arr)
        {
            int n = arr.Length;
            
            for (int i = 1; i < n; i++)
            {
                int key = arr[i]; // The element to be inserted into the sorted portion, which is at the lowest index of the unsorted portion
                int j = i - 1; // `j` starts as the highest index of the sorted portion of the array
                
                while (j >= 0 && arr[j] > key) // Compare the key with each element in the sorted portion (in order of descending indexes) until an element smaller than or equal to the key is found, or the beginning of the array is reached
                {
                    arr[j + 1] = arr[j]; // Move each element that is larger than the key to the right (to make room for the key which will be inserted at a lower index). Assigning a new value to the initial position of the key does not matter as it has been copied to the `key` variable.
                    
                    j--; // Decrement `j` to compare the key with the next element in the sorted portion
                }
                
                arr[j + 1] = key; // Insert the key into its correct position. Since `j` was just decremented, the correct index is `j + 1`. Or, if the `while` loop was never entered, it is essentially just rewriting the key back to its original position.
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }
        
        public static void RunExercises()
        {
            int[] arr = { 5, 2, 8, 9, 0, 6, 4, 1, 3, 7 };
            Console.WriteLine("Unsorted array:");
            PrintArray(arr);
            Sort(arr);
            Console.WriteLine("Sorted array:");
            PrintArray(arr);
        }
        
    }
}