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

















