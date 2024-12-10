# Stacks

### What is a Stack?

A stack is a **linear data structure** that follows the **Last In, First Out (LIFO)** principle. This means:

* The last element you added to the stack is the first one removed.

* Think of a stack of plates: the last plate you put on top is the first one you take off.

  When you add (push) a new plate, it goes on top, and when you remove (pop) a plate, you take the topmost one first.

### Key Operations

* `Push`: Add an element to the top of the stack.
* `Pop`: Remove the top element from the stack.
* `Peek`: Look at the top element without removing it.
* `IsEmpty`: Check if the stack is empty.

### Applications

* Undo/redo functionality in text editors.
* Backtracking problems (e.g., mazes, recursive function calls).
* Evaluating mathematical expressions,.

___

### Implementing Stacks

##### Manual Implementation:

* Stacks can be implemented manually using:

  * **Arrays** (fixed-size stack).

  * **Linked List** (dynamic-size stack).


##### Predefined Classes

* The `Stack<T>` class in from the `System.Collections.Generic` namespace is commonly used in C#. It implements the `<IEnumerable<T>` interface and is given the following definition:
  * "Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type".

#### Example: Implementing a Stack Using an Array

```csharp
using System;

namespace StackImplementation;

class Stack {
  
  private int[] elements;
  private int top;
  private int maxSize;
  
  public Stack(int size) {
    maxSize = size;
    elements = new int[size];
    top = -1; // Indicates the stack is empty
  }
  
  // Push: Add an element to the stack
  public void Push(int value) {
    if (top == maxSize - 1) {
      Console.WriteLine("Stack Overflow! Cannot push more elements.");
      return;
    }
    elements[++top] = value;
  }
  
  // Pop: Remove and return the top element
  public int Pop() {
    if (IsEmpty()) {
      Console.WriteLine("Stack Underflow! Cannot pop from an empty stack.");
      return -1;
    }
    return elements[top--];
  }
  
  // Peek: Return the top element without removing it
  public int Peek() {
    if (IsEmpty()) {
      Console.WriteLine("Stack is empty! No elements to peek.");
      return -1;
    }
    return elements[top];
  }
  
  // IsEmpty: Check if the stack is empty
  public bool IsEmpty() {
    return top == -1;
  }
  
  // Print: Display the stack contents
  public void PrintStack() {
    if (IsEmpty()) {
      Console.WriteLine("Stack is empty!");
      return
    }
    
    Console.Write("Stack elements: ");
    for (int i = 0; i <= top; i++) {
      Console.Write(elements[i] + " ");
    }
    Console.WriteLine();
  }
}
```

#### Internal Implementation of C# `Stack<T>`

**The `Stack<T>` class uses a dynamically sized array to store its elements internally.**

* The time complexity for `Push` and `Pop` operations is $O(1)$ on average. However, resizing the array during a `Push` operation takes $O(n)$ time, where `n` is the number of elements in the stack, because of the copying step. This happens infrequently, so the amortised cost remains $O(1)$.
* Access to the top element (`Peek`) is $O(1)$.
* The internal array is private and managed by methods like `Push`, `Pop`, `Peek`, and `EnsureCapacity` (for resizing).

##### Why Have a `Stack<T>` Class at All?

Since the `Stack<T>` class simply uses an array internally, you may wonder why the class is needed at all rather than interacting directly with the arra. There are several reasons for this:

* **Expressing Intent**: A `Stack<T>` represents a Last-In-First-Out (LIFO) collection. This makes your intent clear when you use it in code.
* **Behavioural Guarantees**: A stack provides specific guarantees.
  * **Controlled Access**: Only the top element can be inspected or removed (`Peek` and `Pop`), reinforcing the LIFO principle.
  * **No Arbitrary Access**: Unlike a `List<T>`, you cannot index into a `Stack<T>` or modify elements arbitrarily, ensuring a consistent usage pattern.
* **Abstraction and Encapsulation**: The `Stack<T>` class abstracts away the details of how the data is stored (internally it's a dynamic array) and provides a focused API that matches the stack's conceptual model.













