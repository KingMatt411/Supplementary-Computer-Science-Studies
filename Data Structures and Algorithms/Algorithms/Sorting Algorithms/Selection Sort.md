# Selection Sort

### Concept

Selection Sort is a comparison-based algorithm. Instead of "bubbling" larger elements up the array indexes by swapping elements in pairs, Selection Sort involves finding the smallest element in each iteration (smallest element in the first iteration, then second smallest in the second iteration, and so on) and moving it to its correct position (i.e., to a lower index in the array).

___

### How It Works

1. Mark the first element (`0`) as being the smallest (by assigning its index to `smallestIndex` variable).
2. Iterate through each remaining element in the array, comparing each element's value to the current minimum value. If the element being iterated over is smaller, assign the new lowest value to the `smallestIndex` variable.
3. Once you reach the end of the array (and the index of its smallest element has been assigned to `smallestIndex`), swap the places of the current "smallest" element and the new (actual) smallest element.
4. In each iteration, start from the next index, as any previous indexes have already been assigned the correct smallest values.

___

### Implementation in C#

```csharp
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
    }  
}
```

___

### Analysis

#### Time Complexity

* **Best Case**: $O(n^2)$ (still loops through all pairs).
* **Worst Case**: $O(n^2)$.
* **Average Case**: $O(n^2)$

#### Space Complexity

* $O(1)$: Selection sort is **in-place**, meaning it does not require extra memory.

