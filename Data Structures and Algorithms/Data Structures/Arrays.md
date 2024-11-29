# Arrays

### What is an Array?

An **array** is a collection of elements stored at contiguous memory locations. Each element is accessed using its index.

### Key Operations and Complexities

| Operation           | Description                                    | Time Complexity |
| ------------------- | ---------------------------------------------- | --------------- |
| **Access**          | Retrieve an element by index.                  | $O(1)$          |
| **Search**          | Find an element (linear search).               | $O(n)$          |
| **Insert at end**   | Add an element at the end (if space allows).   | $O(1)$          |
| **Insert at index** | Shift elements and insert at a specific index. | $O(n)$          |
| **Delete at index** | Shift elements after removing.                 | $O(n)$          |

### Advantages of Arrays

* **Fast Access**: Constant time access using an index.
* **Simple Implementation**:  Easy to understand and use.

### Disadvantages of Arrays

* **Fixed Size**: Requires knowing the size in advance (in static arrays).
* **Costly Insert/Delete**: Involves shifting elements.

### Example in C#

```csharp
int[] arr = { 1, 2, 3, 4, 5 };

// Access
Console.WriteLine(arr[2]); // Output: 3

// Insert (at end)
int[] newArr = new int[arr.Length + 1];
Array.Copy(arr, newArr, arr.Length); // The `length` parameter specifies the number of elements to copy from the source array
newArr[arr.Length] = 6;

// Delete (at index 2)
for (int i = 2; i < arr.Length - 1; i++) {
    arr[i] = arr[i + 1];
}
```