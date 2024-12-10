# Bubble Sort

#### Concept

* Bubble sort is a **simple comparison-based sorting algorithm**.
* It repeatedly steps through an array, compares adjacent elements, and swaps them if they are in the wrong order.
* The largest elements "bubble up" to the end of the list in each iteration.

___

#### Algorithm

1. Start from the first element and compare it with the next.
2. If the current element is greater than the next, swap them.
3. Move to the next pair (which will include the greater of the last pair) and repeat the process until the end of the array.
4. After each pass, the largest unsorted element is placed at its correct position at the end of the sequence.
5. Repeat the process for the remaining unsorted portion of the array until the array is sorted.

___

#### Implementation in C#

```csharp
using System;

class BubbleSort
{
    public static void Sort(int[] arr)
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
}

public static void Main(string[] args)
{
    int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
    Console.WriteLine("Original Array: " + string.Join(",", arr));
    
    Sort(arr);
    
    Console.WriteLine("Sorted Array: " + string.Join(",", arr));
}
```

___

#### Key Observations

##### Time Complexity

* **Best Case**: $O(n)$ (linear time), when the array is already sorted, and no swaps are needed.
* **Worst Case**: $O(n^2)$ (quadratic time), when the array is sorted in reverse order.
* **Average Case**: $O(n^2)$ (quadratic time).

##### Space Complexity

$O(1)$: Bubble sort is **in-place**, meaning it does not use extra memory for sorting.

##### Optimisation

If no swaps are made during a pass, the array is already sorted, and you can break early. This can be achieved by adding a `swapped` flag, as seen below:

```csharp
public static void Sort(int[] arr)
{
    int n = arr.Length;
    bool swapped;
    
    for (int i = 0; i < n - 1; i++)
    {
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
        if (!swapped) break;
    }
}
```

___

#### How Bubble Sort Works

1. **Highest Number to Highest Index**: Each pair is iterated over, and the largest number in the sequence bubbles up to the highest index (unless it was there already). Some other numbers may bubble up to a point, but will stop once they are compared with a number that is larger than them.
2. **Highest Index Omitted Omitted from Next Iteration**: In the next iteration, since the highest index already contains the largest number, it is omitted from the loop. The process repeats, moving the second highest number to the second highest index (and possibly bubbling some other elements before the second highest number).
3. **Remaining Iterations**: This process keeps repeating until only the first and second elements in the sequence are left to be compared with one another.
4. **`swapped` Flag**: If no swaps are made during a pass, the algorithm terminates early. For an already sorted array, this reduces complexity to $O(n)$. Without the `swapped` flag, Bubble Sort is inefficient for sorted arrays because it still performs redundant comparisons.