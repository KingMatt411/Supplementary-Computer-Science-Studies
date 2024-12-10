# Time Complexity and Big O Notation

Big O notation is used to describe the **worst-case performance** of an algorithm in terms of time (execution speed) and space (memory usage). It helps us understand how the algorithm will scale as the input size increases.

### Common Big O Notations

#### $O(1)$ - Constant Time

**What It Means**:

* The algorithm's **runtime is the same** regardless of the input size ($n$). That is, it always takes the same amount of time to execute, regardless of how large or small the input is.

**Example**: Accessing an element in an array by index:

```csharp
int GetFirstElement(int[] arr, int index) {
    return arr[index]; // Always takes the same time.
}
```

**Why It's Efficient**:

* O(1) (constant time) is the **fastest possible time complexity**.
* Operations like **array indexing** or **fixed bit-width arithmetic** (e.g., addition, multiplication) fall under this category because they don't depend on the size of the data.

**Real-World Analogy**:

* Retrieving a book from a specific shelf in a library when you already know the shelf number.

___

#### $O(\log n)$ - Logarithmic Time

**What It Means**:

* The runtime grows **logarithmically** with the input size. For every doubling of the input size, the algorithm only adds a constant number of extra steps.
* Common in **divide-and-conquer algorithms**, where input is repeatedly halved.

**Example**: Binary Search:

```csharp
int BinarySearch(int[] arr, int target) {
    int left = 0, right = arr.Length - 1;
    while(left <= right) {
        int mid = (left + right) / 2;
        if (arr[mid] == target) return mid;
        else if (arr[mid] < target) left = mid + 1;
        else right = mid - 1;        
    }
    return -1;
}
```

**Why It's Efficient**:

* Scales well for large inputs because the problem size shrinks exponentially with each step.

* Example:

  ​	Input size $n = 1,000,000$

  ​	Steps needed: $\log_2(1,000,000) \approx 20$

**Real-World Analogy**:

* Searching for a word in a dictionary by opening it in the middle, deciding which half to continue searching in, and repeating.

___

#### $O(n)$ - Linear Time

**What It Means**:

* The runtime grows **linearly** with the input size. If the input size doubles, the runtime also doubles.

**Example**: Traversing an array:

```csharp
void PrintElements(int[] arr) {
    for (int i = 0; i < arr.Length; i++) {
        Console.WriteLine(arr[i]);
    }
}
```

**Why It's Efficient**:

* While slower than $O(1)$ and $O(\log n)$, it's still manageable for most practical input sizes.
* The algorithm processes each input element exactly once.

**Real-World Analogy**:

* Scanning all books on a single shelf to find a single book.

___

#### $O(n \log n)$ - Quasilinear Time

**What It Means**:

* The runtime grows proportional to $n \cdot \log n$.
* Common in **efficient sorting algorithms** like Merge Sort or Quick Sort (average case).

**Example**: Merge Sort:

```csharp
void MergeSort(int[] arr) {
    // Divide the array into halves, recursively sort them, and merge.
    // Each merge step takes linear time, and the depth of recursion is log n.
}
```

**Why It's Efficient**:

* Although slightly slower than $O(n)$ (linear time), it is significantly faster than $O(n^2)$ (quadratic time) for large inputs.
* Example: Sorting 1,000,000 items would take about $1,000,000 \cdot 20 = 20,000,000$ steps.

**Real-World Analogy**:

* Organising a shuffled deck of cards by repeatedly dividing it into smaller groups, sorting them, and merging them back together.

___

#### $O(n^2)$ - Quadratic Time

**What It Means**:

* The runtime grows **quadratically** with the input size. If the input size doubles, the runtime becomes four times larger.
* Often caused by **nested loops**.

**Example**: Printing all pairs in an array:

```csharp
void PrintPairs(int[] arr) {
    for (int i = 0; i < arr.Length; i++) {
        for (int j = 0; j < arr.Length; j++) {
            Console.WriteLine($"{arr[i]}, {arr[j]}");
        }
    }
}
```

**Why It's Inefficient**:

* Suitable only for small inputs, as runtime grows rapidly with larger input sizes.
* Example: For $n = 1000$, you would perform $1,000,000$ iterations.

**Real-World Analogy**:

* Comparing every student in a class with every other student to determine who has the same birthday.

___

#### $O(2^n)$ - Exponential Time

**What It Means**:

* The runtime doubles with every additional input element.
* Often seen in **recursive algorithms** that solve all possible combinations without optimisation.

**Example**: Solving the Travelling Salesman Problem (TSP) via brute force:

```csharp
void SolveTSP(int[] cities) {
    // Explore every possible route (n! routes).
}
```

> The Travelling Salesman Problem (TSP) seeks the shortest possible route that visits every point in a set of locations just once. It is highly applicable in the logistics sector, particularly in route planning and optimisation for delivery services. TSP solving algorithms help to reduce travel costs and time.

**Why It's Inefficient**:

* Quickly becomes impractical for large inputs. For $n = 20$, the runtime is $2^{20} = 1,048,576$ steps.

**Real-World Analogy**:

* Trying every possible combination of keys on a piano to find the correct melody.

___

#### $O(n!)$ - Factorial Time

**What It Means**:

* The runtime grows **factorially** with the input size. For $n = 5$, it performs $5 \times 4 \times 3 \times 2 \times 1 = 120$ operations.
* Seen in problems that require generating **all permutations** (arrangements or orderings).

**Example**: Generating all permutations of a set:

```csharp
void GeneratePermutations(int[] arr) {
    // Generate all possible arrangements of the array elements.
}
```

**Why It's Extremely Inefficient**:

* Becomes unusable even for moderately sized inputs.
* Example: For $n = 10$, $n! = 3,628,800$.

**Real-World Analogy**:

* Listing all possible seating arrangements for 10 people at a table.

___

#### Summary Table

| Big O         | Description      | Efficiency     | Real-World Analogy                                |
| ------------- | ---------------- | -------------- | ------------------------------------------------- |
| $O(1)$        | Constant time    | Excellent      | Picking a book from a specific shelf.             |
| $O(\log n)$   | Logarithmic time | Very efficient | Searching for a word in a dictionary.             |
| $O(n)$        | Linear time      | Good           | Scanning all books on a shelf.                    |
| $O(n \log n)$ | Quasilinear time | Efficient      | Sorting a shuffled deck by dividing and merging.  |
| $O(n^2)$      | Quadratic time   | Poor           | Comparing every student with every other student. |
| $O(2^n)$      | Exponential time | Very poor      | Trying all combinations of keys on a piano.       |
| $O(n!)$       | Factorial time   | Extremely poor | Listing all seating arrangements for 10 people.   |

___

### Examples

#### Analysing the Time Complexity of a Simple Loop

```csharp
for (int i = 0; i < n; i++) {
    Console.WriteLine(i);
}
```

* The loop runs from `0` to `n - 1`, so it executes **n times**.
* The complexity is $O(n)$ (linear time complexity).

#### Nested Loops

```csharp
for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        Console.WriteLine(i + j);
    }
}
```

* The outer loop runs **n** times.
* For each iteration of the outer loop, the inner loop runs **n** times.
* Total iterations: **n * n = n²**.
* The complexity is $O(n^2)$.

#### Recursion Example

```csharp
int Factorial(int n) {
    if (n == 0) return 1;
    return n * Factorial(n - 1);
}
```

* For `Factorial(5)`, the function calls itself 5 times.
* Each call does constant work.
* Total complexity: $O(n)$ (linear time complexity).

*Note that this recursion factorial function differs from factorial complexity, where the time complexity is equal to the factorial of the input. Factorial time complexity appears in problems that involve generating permutations or trying all combinations, not in the calculations of $n!$* itself.*



