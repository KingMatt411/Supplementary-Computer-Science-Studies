# Quick Sort

### Concept

Quick Sort is a **Divide and Conquer** algorithm that sorts an array by:

1. Selecting a **pivot** element.
2. Partitioning the array so that:
   * Elements smaller than the pivot are placed to its left.
   * Elements greater than the pivot are placed to its right.
3. Recursively applying the same process to the left and right subarrays.

___

### How It Works

1. **Pick a Pivot**:
   * Select any element as the pivot (commonly the last, first, or middle element).
2. **Partition**:
   * Rearrange the array such that:
     * All elements less than the pivot are on the left.
     * All elements greater than the pivot are on the right.
     * The pivot is placed in its correct sorted position.
3. **Recursively Sort**:
   * Apply the same steps to the left and right partitions.

___

### Implementation in C#

```csharp
namespace DSAExercisesProject.Sorting.QuickSort;

public class QuickSortTwo
{
    private static void QuickSort(int[] arr, int lowerIndex, int upperIndex)
    {
        // Base Case: The array must contain more than one element
        if (lowerIndex < upperIndex)
        {
            /* The `Partition` method returns the index of the pivot element after it has been moved to its                  sorted index (position) within the array, logically partitioning the array. */
           int pivotIndex = Partition(arr, lowerIndex, upperIndex);
            
            /* The logical partitions of the array (from the lowest index to the current pivot element - 1,                  and from the pivot element + 1 to the highest index) are passed recursively to the `Sort`                    method, which then sorts the highest index elements in these logical subarrays, logically                    partitioning the subarrays, until the final 2-element arrays are sorted. */
            QuickSort(arr, lowerIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, upperIndex);

        }
    }

    private static int Partition(int[] arr, int lowerIndex, int upperIndex)
    {
        int insertionIndex = lowerIndex; /* The `insertionIndex` variable keeps track of the index at which   											  to place the next element encountered that is less than or equal 											   to the pivot element. It starts at the lower index of the array 												and is incremented whenever an element is moved to that index. */
        
        int pivotElement = arr[upperIndex]; /* The element at the upper index of the array (or logical 													   subarray) is assigned as the pivot element, with which all 												   other elements in the array (or logical subarray) will be 												   compared and placed to the left of (if they are less than the 												pivot element, or placed to the right of (if they are greater 												 than the pivot element). */

        for (int j = lowerIndex; j < upperIndex; j++) // Iterate through all elements in the array (or                                                                logical subarray)
        {
            if (arr[j] <= pivotElement)
            {
                Swap(arr, insertionIndex, j); /* If an element is encountered that is less than the pivot                              						   element, it is moved to the left of the pivot element (to 												  the current insertion index. */
                
                insertionIndex++; // The insertion index is incremented after an element has been placed at 									 this index.
            }
        }

        Swap(arr, upperIndex, insertionIndex); /* Once all the elements that are less than the pivot element 												   have been moved to the left of the array (or logical 													  subarray), the pivot element then gets placed at the 														  insertion index so that all the elements to the left of it 												   are less than it, and all the elements to the right of it 												   are greater than it. */

        return insertionIndex;
    }

    private static void Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
}
```

___

### Analysis

#### Time Complexity

* **Best Case**: $O(n \log n)$
  * The array is evenly split into two partitions at every level.
* **Worst Case**: $O(n^2)$
  * Occurs when the pivot is always the smallest or largest element in every subarray (e.g., a sorted or reverse-sorted array).
* **Average Case**: $O(n \log n)$.

#### Space Complexity

* $O(\log n)$: Due to recursive calls.

___

### Advantages

1. **Efficient for Large Datasets**:
   * Outperforms Merge Sort in practice due to fewer memory overheads.
2. **In-Place Sorting**:
   * Requires no additional memory, unlike Merge Sort.

___

### Disadvantages

1. **Worst-Case Time Complexity**:
   * $O(n^2)$ when the pivot is poorly chosen.
2. **Not Stable**:
   * Equal elements may not retain their relative order.















