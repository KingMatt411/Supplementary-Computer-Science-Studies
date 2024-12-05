# Queues

### What is a Queue?

A queue is a **linear data structure** that follows the **First In, First Out** (FIFO) principle:

* The first element added to the queue is the first one to be removed.
* Think of a line of people waiting for a bus: the first person in line gets on the bus first.

### Operations in a Queue

| Operation   | Description                                    | Time Complexity |
| ----------- | ---------------------------------------------- | --------------- |
| **Enqueue** | Add an element to the end of the queue.        | $O(1)$          |
| **Dequeue** | Remove an element from the front of the queue. | $O(1)$          |
| **Peek**    | View the front element without removing it.    | $O(1)$          |
| **IsEmpty** | Check if the queue is empty.                   | $O(1)$          |

### Types of Queues

1. **Simple Queue (or Linear Queue**):

   * Basic queue structure where elements are added to the rear and removed from the front.

2. **Circular Queue**:

   * When the rear of the queue reaches the last index of the array and there is free space at the beginning of the array, the rear "wraps around" to the first index. This reuse of space helps avoid memory wastage.

     By using the "freed-up" space from dequeue operations, a circular queue efficiently utilises the array's fixed size. For example:

     * **Enqueue Operations**
       1. Add `10`: `[10, _, _, _, _]`
       2. Add `20`: `[10, 20, _, _, _]`
       3. Add `30`: `[10, 20, 30, _, _]`
     * **Dequeue Operations**
       1. Remove `10`: `[_, 20, 30, _, _]`
     * **More Enqueue Operations**:
       1. Add `40`: `[_, 20, 30, 40, _]`
       2. Add `50`: `[_, 20, 30, 40, 50]`

     * **Wrap-Around**: The rear moves to the start of the array:
       1. Add `60`: `[60, 20, 30, 40, 50]`

     The wrap-around mechanism ensures the queue can use all space effectively, without requiring resizing or wasting memory.

3. **Priority Queue**:

   * Elements are dequeued based on priority rather than the order they were enqueued.

4. **Dequeue (Double-Ended Queue)**:

   * Elements can be added or removed from both ends.

### Implementing a Queue

#### Array-Based Queue (Fixed-Size)

```csharp
using System;

namespace QueueImplementation;

class Queue {
  
  private int[] elements;
  private int front; // Index of the front element
  private int rear; // Index of the rear element
  private int maxSize; // Maximum capacity of the queue
  private int count; // Number of elements in the queue
  
  public Queue(int size) {
    maxSize = size;
    elements = new int[size];
    front = 0;
    rear = -1;
    count = 0;
  }
  
  // Enqueue: Add an element to the rear
  public void Enqueue(int value)
  {
    if (count == maxSize)
    {
      Console.WriteLine("Queue Overflow! Cannot add more elements.");
      return;
    }
    rear = (rear + 1) % maxSize; // Wrap around using modulo for circular behaviour
    elements[rear] = value;
    count++;
  }
  
  // Dequeue: Remove and return the front element
  public int Dequeue()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Queue Underflow! Cannot remove elements.");
      return -1;
    }
    int value = elements[front];
    front = (front + 1) % maxSize; // Move front forward
  }
  
  // Peek: Return the front element without removing it
  public int Peek()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Queue is empty! Nothing to peek.");
      return -1;
    }
    return elements[front];
  }
  
  // IsEmpty: Check if the queue is empty
  public bool IsEmpty()
  {
    return count == 0;
  }
  
  // PrintQueue: Display all elements in the queue
  public void PrintQueue()
  {
    if (IsEmpty())
    {
      Console.WriteLine("Queue is empty!");
      return;
    }
    
    Console.Write("Queue elements: ");
    for (int i = 0; i < count; i++)
    {
      int index = (front + i) % maxSize; // Handle wrapping
      Console.Write(elements[index] + " ");
    }
    Console.WriteLine();
  }
}
```



#### Built-In `Queue<T>` in C#

C# provides a built-in `Queue<T>` class in the `System.Generic.Collections` namespace. It simplifies queue operations.

```csharp
using System;
using System.Collections.Generic;

class Program
{
  Queue<int> queue = new Queue<int>();
  
  // Enqueue elements
  queue.Enqueue(10);
  queue.Enqueue(20);
  queue.Enqueue(30);
  Console.WriteLine("Queue after enqueue: " + string.Join(",", queue));
  
  // Peek front element
  Console.WriteLine("Front element: " + queue.Peek());
  
  // Dequeue elements
  Console.WriteLine("Dequeued: " + queue.Dequeue());
  Console.WriteLine("Queue after dequeue: " + string.Join(",", queue));
  
  // Check if the queue is empty
  Console.WriteLine("Is the queue empty? " + (queue.Count == 0));
}
```



















