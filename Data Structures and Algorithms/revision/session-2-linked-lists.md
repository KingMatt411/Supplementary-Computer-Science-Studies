### **Session 2: Linked Lists**

### **1. Singly Linked List Basics**

#### **Quiz Questions**

1. **Conceptual Understanding**:

   - What is a singly linked list, and how does it differ from an array?

     **A singly linked list is a collection that contains a series of nodes, where each node contains a data value and a pointer to the next node in the linked list. "Singly linked" means that any given node only contains a pointer to the next node, not a previous node or any other node in the linked list. It differs from an array in that memory is dynamically allocated when adding new nodes, by creating the object and updating the reference/pointer from the previous object to point to the new object. This is possible because nodes are not stored sequentially in memory, like they are in an array. In an array, adding an element is not technically possible if the array is at capacity, so what is done instead is a new array with a larger capacity is created, the contents of the original array are copied into the new array along with the new element. In a dynamic array, this is done under the hood, creating the illusion or impression of a resizeable array.**

   - Why would you use a linked list instead of an array in a program?

     **A linked list would perform better than an array if nodes will be frequently inserted or deleted, as this will not involve any need for copying, reducing time complexity.**

2. **Memory Allocation**:

   - How is memory allocated for a linked list?

     **Memory is allocated for a linked list by creating new node objects dynamically. The pointer in the previous node is updated to point to the new one when it is created.**

   - Why does a linked list require extra memory compared to an array?

     **A linked list requires extra memory compared to an array because every node in the linked list also contains a pointer to the next node, and if it is a doubly linked list, then also a pointer to the previous node.**

3. **Time Complexity**:

   - What is the time complexity of:

     - Inserting a node at the beginning of a singly linked list?

       **$O(1)$ because all that is done is creating the node and updating the pointer to it in the main `LinkedList<T>` object.**

     - Accessing the n-th element in a singly linked list?

       **$O(n)$ because it is necessary to traverse all the nodes in the linked list up to this element to get its location.**

     - Deleting the last node from a singly linked list?

       **$O(n)$ because the entire linked list would need to be traversed to reach the last node (unless a tail pointer was maintained, in which cause the time complexity would be $O(1)$).**

       

------

### **2. Singly Linked List Operations**

#### **Practical Task**: Implement the following methods for a singly linked list:

1. Insert a node at the **beginning**.
2. Insert a node at the **end**.
3. Delete a node by **value**.
4. Reverse a singly linked list in place.

------

### **3. Doubly Linked List Basics**

#### **Quiz Questions**

1. **Conceptual Understanding**:
   - What additional pointer does a doubly linked list have compared to a singly linked list?
   - What operations are more efficient in a doubly linked list compared to a singly linked list?
2. **Memory Overhead**:
   - Why does a doubly linked list require more memory than a singly linked list?
3. **Use Cases**:
   - Name a real-world scenario where a doubly linked list would be more appropriate than a singly linked list.

------

### **4. Doubly Linked List Operations**

#### **Practical Task**: Implement the following methods for a doubly linked list:

1. Insert a node after a given node.
2. Delete the last node from the list.
3. Traverse the list in reverse order.

------

### **5. Advanced Linked List Problems**

#### **Quiz Questions**

1. **Cycle Detection**:
   - Describe an algorithm to detect a cycle in a linked list. What is its time complexity?
   - How would you modify the algorithm to find the starting node of the cycle?
2. **Merging Two Sorted Linked Lists**:
   - Write an algorithm to merge two sorted linked lists into one sorted linked list. What is its time complexity?

------

### **Bonus Problem**

**Problem**:

- Write a function that:
  - Detects if two singly linked lists intersect.
  - If they intersect, returns the intersecting node.

**Hint**: Use the lengths of the lists to align the starting points.