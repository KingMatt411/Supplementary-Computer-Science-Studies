using System.Collections.Concurrent;

namespace DSAExercisesProject.Sorting.QuickSort;

public class QuickSort
{
    private static void Sort(int[] arr, int low, int high)
    {
        if (low < high) // Base Case: The array contains more than one element.
        {
            // Partition the array and get the pivot index
            int pivotIndex = Partition(arr, low, high);
            
            // Recursively sort elements before the pivot
            Sort(arr, low, pivotIndex - 1);
            
            // Recursively sort elements after the pivot
            Sort(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // The rightmost element of the array (highest index) will be the pivot
        Console.WriteLine($"Choosing pivot with value of {pivot} from indices {low} to {high}");
        PrintArray(arr);

        int i = low - 1; /* `i` is used to track the position (index) where the next smaller or equal element
                               (relative to the pivot) should be placed. Starting `i` at `low - 1` ensures that
                               when you find the first element less than or equal to the pivot, incrementing `i`
                               will set it to `low`, which is the correct position for that element.
                             
                               When `low` is `0`, `i` starts at `-1`. This is safe because the first time an element
                               less than or equal to the pivot is found, `i` is incremented to `0`. */

        for (int j = low; j < high; j++) /* Iterate through the elements in the subarray (logical section of the
                                            main array, there is no actual copying of arrays). Each element is
                                            compared with the pivot element. */
        
        {
            if (arr[j] <= pivot)
            {
                i++; // Increment the index where an element that is smaller than the pivot value should be moved to.
                Swap(arr, i, j); /* Swap the places of the elements at indices `i` and `j`, so that the
                                                element that was found at index `j` and evaluated to be lower than
                                                the pivot value is moved to index `i`, which is to the left of the
                                                pivot element. */
                Console.WriteLine($"Swapped {arr[i]} and {arr[j]}.");
                PrintArray(arr);
            }
        }
        
        /* Once all the elements in the (logical) subarray have been iterated through, the pivot element should be
           placed after the last smallest element. */
        Swap(arr, ++i, high);
        Console.WriteLine($"Placed pivot ({pivot}) at position ({i}): ");
        PrintArray(arr);

        return i; // Return the index of the pivot element
    }

    private static void Swap(int[] arr, int index1, int index2)
    {
        if (index1 == index2) return;
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    private static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(",", arr));
    }

    public static void RunTests()
    {
        int[] array = { 8, 3, 1, 7, 0, 10, 2 };
        Console.WriteLine("Original Array:");
        PrintArray(array);

        Sort(array, 0, array.Length - 1);

        Console.WriteLine("\nSorted Array:");
        PrintArray(array);
    }
    
}