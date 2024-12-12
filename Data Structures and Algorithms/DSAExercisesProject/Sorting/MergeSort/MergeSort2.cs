namespace DSAExercisesProject.Sorting.MergeSort
{
    static class MergeSortTwo
    {
        private static void Sort(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            PrintArray(left);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);
            PrintArray(right);
            
            Sort(left);
            Sort(right);

            Merge(arr, left, right);
        }

        private static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int k = 0;

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

            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }

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
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            Console.WriteLine("Unsorted array:");
            PrintArray(arr);
            Sort(arr);
            Console.WriteLine("Sorted array:");
            PrintArray(arr);
        }
    }
}
