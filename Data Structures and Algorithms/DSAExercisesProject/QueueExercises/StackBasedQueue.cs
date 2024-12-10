namespace QueueExercises;
using System;
using System.Collections.Generic;

class StackBasedQueue<T> {

    private Stack<T> _tempStack = new Stack<T>();
    private Stack<T> _mainStack = new Stack<T>();

    public T Dequeue() {

        if (_mainStack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
            return default;
        }

        return _mainStack.Pop();
    }

    public void Enqueue(T item)
    {
        if (_mainStack.Count == _mainStack.Capacity)
        {
            Console.WriteLine("Stack is full.");
            return;
        }
        while (_mainStack.Count != 0)
        {
            _tempStack.Push(_mainStack.Pop());
        }

        _mainStack.Push(item);
        while (_tempStack.Count != 0)
        {
            _mainStack.Push(_tempStack.Pop());
        }
    }
}
