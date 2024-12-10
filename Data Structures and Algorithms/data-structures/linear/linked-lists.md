# Linked Lists

### What is a Linked List?

A linked list is a **collection of nodes**, where each node contains:

1. **Data**: The value stored in the node.
2. **Pointer**: A reference to the next node (and sometimes the previous node).

Each node in a linked list can be considered a **data structure of its own** as it encapsulates multiple fields: typically a **data field** (which holds the actual value) and a reference or pointer field (which points to the next node). These components make a node a **composite structure**, meaning it contains multiple elements of potentially different types.

### Types of Linked Lists

1. **Singly Linked List**: Each node points to the next node.
2. **Doubly Linked List**: Each node points to both the next and previous nodes.
3. **Circular Linked List**: The last node points back to the first node.

### Key Operations and Complexities

| Operation           | Description                       | Time Complexity               |
| ------------------- | --------------------------------- | ----------------------------- |
| **Access by index** | Requires traversal from the head. | $O(n)$                        |
| **Search**          | Find an element.                  | $O(n)$                        |
| **Insert at head**  | Add a new node at the beginning.  | $O(1)$                        |
| **Insert at tail**  | Add a new node at the end.        | $O(n)$ (without tail pointer) |
| **Delete by value** | Traverse and delete the node.     | $O(n)$                        |

### Advantages of Linked Lists

* **Dynamic Size**: Can grow or shrink as needed.
* **Efficient Insert/Delete**: No shifting required.

### Disadvantages

* **Slow Access**: No indexing, must traverse nodes sequentially.
* **Extra Memory**: Requires storage for pointers.

### Example in C#

```csharp
class Node {
    public int Data;
    public Node Next;
    
    public Node(int data) {
        this.Data = data;
        this.Next = null;
    }
}

class LinkedList {
    public Node Head;
    
    public void Add(int data) {
        Node newNode = new Node(data);
        if (Head == null) {
            Head = newNode;
        } else {
            Node temp = Head;
            while (temp.Head != null) {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }
    
    public void PrintList() {
        Node temp = Head;
        while (temp != null) {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
    }
}
```



### Comparison Between Linked Lists and Dynamic Arrays

The concept of a linked list may at first appear similar to a dynamic array, however, there are several key differences.

#### <u>Structure</u>

* **Dynamic Array**:
  * A dynamic array stores elements contiguously (sequentially) in memory. When a dynamic array is created, it is allocated memory for a specific number of elements (its capacity). When the dynamic array exceeds its current **capacity** (i.e., the number of elements added exceeds the allocated memory):
    1. A new, larger block of memory is allocated (typically larger than the current capacity).
    2. Existing elements are copied into the newly allocated memory.
    3. The old memory is released.

  * Dynamic arrays have a **growth factor** which determines how much the capacity increases when the array resizes. For example, if the initial capacity is 10 and the growth factor is 2, when the 11th element is added, the capacity increases to 20.

* **Linked List**:
  * Linked lists do not store nodes contiguously in memory. This means that adding an additional node does not require copying the entire data structure (linked list) to ensure an incrementing sequence of memory locations.

#### <u>Memory Usage</u>

* **Dynamic Array**:
  * Uses less memory overhead as there are no pointers.

* **Linked List**:
  * Requires less memory for pointers, which can lead to higher memory usage compared to dynamic arrays.

  * Memory is allocated on demand for each node, so it doesn't need to know the size in advance.

#### <u>Access Time</u>

* **Dynamic Array**:
  * **Random access**: Can directly access any element using an index ($O(1)$ time complexity).

  * Faster lookups compared to linked lists.

* **Linked List**:
  * **Sequential access**: Accessing and element requires traversing from the head to the desired node ($O(n)$ time complexity for search).
  * Cannot perform direct indexing (e.g., `list[5]` is not possible).

#### <u>Insertion and Deletion</u>

* **Dynamic Array**:

  * Insertion and deletion are expensive in terms of when elements need to be shifted ($O(n)$ in the worst case).
  * Resizing (during insertion when the array is full) involves allocating a new array and copying elements ($O(n)$ for resizing).

* **Linked List**:

  Insertion or deletion are **efficient ($O(1)$ if the node reference is known)**.

  * **Singly Linked List**:
    * At the **beginning**:
      * Inserting a node at the beginning is always $O(1)$ because you can update the `head` pointer and set the new node's `next` to the current head.
      * Deleting the first node is also $O(1)$ because you simply move the `head` pointer to the next node.
    * At the **end**:
      * Adding at the end is not efficient ($O(n)$) unless you have a reference to the last node. Without a reference, you need to traverse the list to find the tail. With the reference, you simply update the reference from the previous last node to the new last node, and the linked list object reference to the new last node.
      * Deleting the last node is not efficient ($O(n)$) because, in a singly linked list, you must traverse the list to find the node just before the tail (to update its `next` to `null`).
  * **Doubly Linked List**:
    * Inserting or deleting at the end becomes $O(1)$ if the list maintains a tail pointer. You can directly access the last node without traversal.
    * Deleting any node is efficient if the node reference is known because you can update both the `prev` and `next` pointers in $O(1)$, while in a singly linked list you would need to traverse the list to find the node before the one you were deleting.

#### <u>Resizing</u>

* **Dynamic Array**:
  * Requires resizing (allocating new memory and copying elements) when capacity is exceeded or when shrinking the array.
* **Linked List**:
  * No resizing is necessary since nodes are allocated individually.
  * Size can grow or shrink dynamically with no overhead of reallocation.

#### <u>Cache Performance</u>

* **Dynamic Array**:
  * Good cache locality since elements are stored in contiguous memory.
  * Better performance for iterating through elements.
* **Linked List**:
  * Poor cache locality as nodes are scattered across memory.
  * Accessing elements may involve following pointers to different memory locations, leading to higher latency.

#### <u>Use Cases</u>

* **Dynamic Array**:
  * Suitable for scenarios requiring **fast random access** and when the **number of elements is relatively stable**.
* **Linked Lists**:
  * Ideal for scenarios where frequent insertion and deletion operations are required.
  * Useful in implementing stacks, queues, or when memory constraints do not favour contiguous allocation.

#### <u>Summary Table</u>

| Feature                | Linked List                         | Dynamic Array                    |
| ---------------------- | ----------------------------------- | -------------------------------- |
| **Structure**          | Nodes with pointers                 | Contiguous memory                |
| **Memory Usage**       | Higher (pointers)                   | Lower (no pointers)              |
| **Access Time**        | $O(n)$                              | $O(1)$ (random access)           |
| **Insertion/Deletion** | Efficient ($O(1)$ if node is known) | Expensive ($O(n)$ due to shifts) |
| **Resizing**           | Not needed                          | Required when full               |
| **Cache Performance**  | Poor                                | Good                             |
| **Use Cases**          | **Frequent insertions/deletions**   | **Fast random access**           |

___

#### <u>Key Takeaway</u>

* Use a **linked list** if you need flexibility in size, frequent insertions/deletions, and are less concerned about memory overhead or access time.
* Use a **dynamic array** if you need fast random access and perform fewer insertions/deletions.
