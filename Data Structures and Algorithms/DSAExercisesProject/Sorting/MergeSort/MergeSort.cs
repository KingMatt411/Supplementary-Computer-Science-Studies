namespace DSAExercisesProject.Sorting.MergeSort
{
    static class MergeSort
    {
        private static void Sort(int[] arr)
        {
            if (arr.Length <= 1) return; // Base case: array is already sorted
      
            int mid = arr.Length / 2;
      
            // Split the array into left and right halves
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
      
            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);
      
            // Recursively sort both halves
            Sort(left);
            Sort(right);
      
            // Merge the sorted halves back into the original array
            Merge(arr, left, right);
        }

        private static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            
            // Compare elements from left and right arrays, and merge them in sorted order
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k++] = left[i++];
                }
                else
                {
                    arr[k++] = right[j++];
                }
            }
            
            // Copy any remaining elements from the left array
            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }
            
            // Copy any remaining elements from the right array
            while (j < right.Length)
            {
                arr[k++] = right[j++];
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        public static void RunTests()
        {
            int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Original Array:");
            PrintArray(arr);

            Sort(arr);

            Console.WriteLine("Sorted Array:");
            PrintArray(arr);
        }
    }
}