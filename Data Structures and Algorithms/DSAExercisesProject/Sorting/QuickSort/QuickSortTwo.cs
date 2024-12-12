namespace DSAExercisesProject.Sorting.QuickSort;

public class QuickSortTwo
{
    private static void QuickSort(int[] arr, int lowerIndex, int upperIndex)
    {
        // Base Case: The array must contain more than one element
        if (lowerIndex < upperIndex)
        {
            /* The `Partition` method returns the index of the pivot element after it has been moved to its sorted
               index (position) within the array, logically partitioning the array. */
            int pivotIndex = Partition(arr, lowerIndex, upperIndex);
            
            /* The logical partitions of the array (from the lowest index to the current pivot element - 1, and from
               the pivot element + 1 to the highest index) are passed recursively to the `Sort` method, which then
               sorts the highest index elements in these logical subarrays, logically partitioning the subarrays,
               until the final 2-element arrays are sorted. */
            QuickSort(arr, lowerIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, upperIndex);

        }
    }

    private static int Partition(int[] arr, int lowerIndex, int upperIndex)
    {
        int insertionIndex = lowerIndex; /* The `insertionIndex` variable keeps track of the index at which to place
                                            the next element encountered that is less than or equal to the pivot
                                            element. It starts at the lower index of the array and is incremented
                                            whenever an element is moved to that index. */
        
        int pivotElement = arr[upperIndex]; /* The element at the upper index of the array (or logical subarray) is
                                               assigned as the pivot element, with which all other elements in the
                                               array (or logical subarray) will be compared and placed to the left of
                                               (if they are less than the pivot element, or placed to the right of (if
                                               they are greater than the pivot element). */

        for (int j = lowerIndex; j < upperIndex; j++) // Iterate through all elements in the array (or logical subarray)
        {
            if (arr[j] <= pivotElement)
            {
                Swap(arr, insertionIndex, j); /* If an element is encountered that is less than the pivot element,
                                                       it is moved to the left of the pivot element (to the current 
                                                       insertion index. */
                insertionIndex++; // The insertion index is incremented after an element has been placed at this index.

            }
        }

        Swap(arr, upperIndex, insertionIndex); /* Once all the elements that are less than the pivot element have been
                                                  moved to the left of the array (or logical subarray), the pivot
                                                  element then gets placed at the insertion index so that all the
                                                  elements to the left of it are less than it, and all the elements to
                                                  the right of it are greater than it. */

        return insertionIndex;
    }

    private static void Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    public static void RunTests()
    {
        int[] testArray = new int[] { 2, 7, 4, 9, 5, 1, 6, 0, 3, 8 };
        Console.WriteLine("Unsorted: " + string.Join(",", testArray));
        QuickSort(testArray, 0, testArray.Length - 1);
        Console.WriteLine("Sorted: " + string.Join(",", testArray));
    }
}