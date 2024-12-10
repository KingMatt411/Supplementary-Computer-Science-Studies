# Space Complexity

### What is Space Complexity?

Space complexity measures the **amount of memory** an algorithm uses relative to the size of its input. It considers the following main ideas:

#### Fixed Space

**Definition**: Memory required for **the algorithm's constants and variables** that do not depend on the input size.

**Characteristics**:

* Includes variables like loop counters, pointers, or a fixed number of constants.
* Always occupies the same amount of memory, no matter the size of the input.

**Examples**:

* A single integer used to store a maximum value during a loop:

  ```csharp
  int max = arr[0];
  ```

* Constants used in calculations (e.g., $\pi$).

___

#### Variable Space

**Definition**: Memory that depends on the size of the input. This includes:

1. **The input data itself**.
2. **Additional memory allocated dynamically during processing** (e.g., arrays, lists, or other data structures created at runtime).

**Characteristics**:

* Grows or shrinks based on the input size.
* Covers everything tied to the input size, both input data and memory used to process it.

**Examples**:

* A dynamically allocated array:

  ```csharp
  int[] tempArray = new int[n];
  ```

* Input data directly stored in memory:

  ```csharp
  int[] input = {1, 2, 3, 4};
  ```

___

#### Auxiliary Space

**Definition**: Extra memory used by the algorithm (apart from the input data) to solve the problem. Auxiliary space is **a subset of variable space**, but explicitly excludes the input data.

**Examples**:

* Temporary storage during a merge sort:

  ```csharp
  int[] tempArray = new int[n];
  ```

* Recursive stack memory:

  ```csharp
  int Factorial(int n) {
      if (n == 0) return 1;
      return n * Factorial(n - 1);
  }
  ```

___

#### Input Space

**Definition**: The memory required to hold the raw input data provided to the algorithm. Input space is also **a subset of variable space**, but only includes the raw input data. It does not include the additional memory created for processing.

**Examples**:

* An array passed to a sorting function:

  ```csharp
  int[] input = {1, 5, 3, 2};
  ```

* Input values stored in memory for a computation.

___

#### Key Relationships

* **Variable Space = Input Space + Auxiliary Space**
* **Total Space Complexity = Fixed Space + Variable Space**

___

#### Summary Table

| Term                | Definition                                                   | Includes                                                     | Excludes                                                    |
| ------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ----------------------------------------------------------- |
| **Fixed Space**     | Memory for constants and algorithm-specific variables, regardless of input size. | Constants, counters, pointers.                               | Input data, dynamically allocated memory.                   |
| **Variable Space**  | Memory that depends on input size, including input data and memory dynamically generated to process it. | Input data + temporary data structures (arrays, lists, etc.). | Fixed constants and variables.                              |
| **Auxiliary Space** | Extra memory allocated dynamically, excluding input data itself. | Temporary structures (e.g., arrays, recursion stack).        | Input data.                                                 |
| **Input Space**     | Memory required to store the raw input data.                 | Raw input data.                                              | Algorithm-specific variables, dynamically generated memory. |

___

### Common Space Complexities

##### $O(1)$ - Constant Space

* The algorithm uses a fixed amount of space, regardless of input size.
* Example: Swapping two numbers or finding the maximum in an array without creating additional data structures.

##### $O(n)$ - Linear Space

* The memory usage grows linearly with the input size.
* Example: Storing all elements of an input array in a new array.

##### $O(\log n)$ - Logarithmic Space

* Often occurs in recursive algorithms, where recursion depth is proportional to $\log n$.
* Example: Binary search (the call stack stores $\log n$ recursive calls).

##### $O(n^2)$ - Quadratic Space

* Memory usage grows quadratically with the input size.
* Example: Creating a 2D matrix to store all pairwise distances in a graph.

___

### Analysing Space Complexities

#### Example 1: Iterative Algorithm ($O(1)$)

```csharp
int FindMax(int[] arr) {
    int max = arr[0]; // Fixed memory
    for (int i = 1; i < arr.Length; i++) {
        if (arr[i] > max) {
            max = arr[i];
        }
    }
    return max;
}
```

**Space Complexity**:

* Fixed variables (`max`, `i`): $O(1)$.
* No additional memory depends on the input size.
* Total: $O(1)$.

___

#### Example 2: Recursive Algorithm ($O(n)$)

```csharp
int Sum(int n) {
    if (n == 0) return 0;
    return n + Sum(n - 1);
}
```

**Space Complexity**:

* Each recursive call adds a frame to the call stack.
* For input $n$, there are $n + 1$ calls (including the base case).
* Total: $O(n)$.

___

#### Example 3: Using Extra Data Structures ($O(n)$)

```csharp
int[] ReverseArray(int[] arr) {
    int[] reversed = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++) {
        reversed[i] = arr[arr.Length - 1 - i];
    }
    return reversed;
}
```

**Space Complexity**:

* Input array: $O(n)$
* Output array: (`reversed`): $O(n)$
* Auxiliary variables (`i`): $O(1)$
* Total: $O(n)$