# Insertion Sort

### Concept

Insertion Sort is a comparison-based sorting algorithm that works similarly to how you might sort playing cards in your hand.

1. Start with the first element (consider it sorted).
2. Pick the next element and insert it into its correct position in the **sorted portion** of the array. This is done by moving it to the left of the array until it is in the correct ascending order with the other elements (or leaving it where it was if it was already higher than the highest element at the top of the sorted portion), and moving on to the next element, until every element in the array has been sorted.
3. Repeat for all remaining elements.

*The term "sorted portion" refers to the portion of the array that is sorted, not a separate array.*

___

### How It Works

1. Divide the array into two parts:
   * **Sorted portion** (initially just the first element).
   * **Unsorted portion**.
2. Pick the first element from the unsorted portion.
3. Shift elements in the sorted portion to make space for the picked element if needed.
4. Insert the picked element into its correct position in the sorted portion.
5. Repeat until the entire array is sorted.

___

### Implementation in C#

```csharp
using System;

namespace Exercises.InsertionSort
{
    class InsertionSort
    {
        public static void Sort(int[] arr)
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
    }
}
```

___

### Analysis

#### Time Complexity

* **Best Case**: $O(n)$ (when the array is already sorted).
  * Only one comparison per element is needed, and no shifts occur.
* **Worst Case**: $O(n^2)$: (when the array is reverse sorted).
  * Each element requires shifting all previous elements.
* **Average Case**: $O(n^2)$.

#### Space Complexity

* $O(1)$: Insertion sort is an **in-place** algorithm.

___

### Advantages

1. Efficient for **small** or **nearly sorted** datasets.
2. Simple to implement and understand.
3. No additional memory is required (in-place).

___

### Disadvantages

1. Inefficient for large datasets due to $O(n^2)$ complexity.
2. Not as fast as divide-and-conquer algorithms (e.g., Merge Sort, Quick Sort).