namespace Exercises.InsertionSort;

public class InsertionSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i]; // The starting element
            int j = i - 1; // The element below the starting one

            while (j >= 0 && arr[j] > key) // While `j` is a positive integer (valid array index) and the element at
                                           // index `j` is greater than the one after it
            {
                arr[j + 1] = arr[j]; // Move the larger element up into the position of the one previously above it
                j--; // Decrement `j` to check if the next element down is also larger than this small encountered
                     // element
            }

            arr[j + 1] = key;
        }
    }
}