### **Topic 1: Big O Notation**

#### **Quiz Questions**

1. **Concept**:

   - What does Big O measure, and why is it important in algorithm analysis?

     **Big O can measure both time and space complexity, specifically the relationship between inputs and the time taken or space (memory) occupied to solve them.**

   - Name the time complexities for the following scenarios:

     - Iterating through a list once.

       **Linear time complexity.**

     - A nested loop where the inner loop iterates through the entire list for each iteration of the outer loop.

       **Quadratic time complexity.**

     - A binary search algorithm.

       **Logarithmic time complexity (assuming you mean searching a binary search tree).**

2. **Complexity Assessment**: Analyze the time complexity of the following code:

   ```
   csharpCopy codefor (int i = 0; i < n; i++) {
       for (int j = i; j < n; j++) {
           Console.WriteLine(i + j);
       }
   }
   ```

   **Quadratic time complexity, because for each value in the input, the number of iterations is equal to the total number of input values.**

1. **Space Complexity**:

   - Explain the difference between fixed space, input space, and auxiliary space in an algorithm.

     **Fixed space refers to the space used by constants in the algorithm itself, for example, in an algorithm that calculates the area of a circle, the value of $\pi$ would occupy fixed space (e.g., a double). Input space refers to the space occupied by the raw, literal input data itself, excluding any copies made of the data. Auxiliary space refers to space that is used by the algorithm processing the input data, for example, by making copies of the data as is done in a Merge Sort.**

   - What is the space complexity of a recursive Fibonacci function?

     **For any integer input, the space used would be equal to the integer plus the previous integer in the sequence. This would probably very quickly exceed even `long long` types. While this was not discussed earlier, if such a space complexity exists, then I would say *exponential* space complexity.**

------

### **Topic 2: Arrays**

#### **Quiz Questions**

1. **Basics**:

   - What is the difference between arrays and linked lists in terms of:

     - Memory allocation.

       **Memory must be allocated when an array is created and cannot be changed (i.e., it is immutable), due to the need for it to be sequential. If the capacity of an array needs to be exceeded, all the elements of the array must be copied into a new array with a greater capacity. This process is done automatically in dynamic arrays, giving the illusion/impression of a resizeable array, but in reality, no array changes in size, an existing array of static length is being copied and a new one created under the hood.**

       **For linked lists, memory is able to be allocated dynamically for new nodes without needing to "resize" the linked list. It is limited only by the amount of free physical RAM on the system (including swap memory). This is because nodes are not stored sequentially, rather each node is a data structure containing a pointer/reference to the next node (or next and previous nodes in a doubly linked list). The presence of pointer/s does, however, require extra memory compared to element in an array. A linked list is preferred when frequent adding and removing of elements is expected, and memory usage is less of a concern.**

     - Access time complexity.

       **Access time complexity is $O(n)$ in the worst case, since accessing elements typically requires traversal from the head, that is, the first node in the linked list. The exception is accessing the first node, for which the address is known, or the last node if a tail pointer was stored in the linked list. Access time can be optimised if it is known whether the element needing to be accessed is closer to the head or the tail in a linked list that maintains a tail pointer.**

2. **Insertion and Deletion**:

   - If you have an array of size 

     $n=5$:

     ```
     [1, 2, 3, 4, 5]
     ```

     - How would you insert the value `6` at index `2`?

       **`arr[2] = 6;` if you are overwriting the existing element. This would have a time complexity of $O(1)$. If you are inserting it and keeping the element that was previously at index `2`, you would need to do the following:**

       ```csharp
       int[] arr = { 1, 2, 3, 4, 5 };
       int[] newArr = new int[arr.Length + 1];
       Array.Copy(arr, 0, newArr, 0, 2);
       newArr[2] = 6;
       Array.Copy(arr, 2, newArr, 3, arr.Length - 2);
       ```

       

     - What is the time complexity of this operation?

       **Linear time complexity because each input element is being copied.**

     - How would you delete the value at index `4`?

       **Technically you could simply shift all the elements after index 4 one place to the left (actually in this case just set it to a default value), if the array doesn't need to be resized. However, if resizing is required, then you would need to copy the array and reduce its length by 1, like this:**

       ```csharp
       int[] arr = { 1, 2, 3, 4, 5 };
       int newArr[] = new int[arr.Length - 1];
       Array.Copy(arr, 0, newArr, 0, 4);
       ```

       

3. **Advanced**:

   - Implement a function in pseudocode to reverse an array in place.

     Yeah I'm not a fan of pseudocode so I'm going to use C#:

     ```csharp
     void ReverseArray(T[] arr)
     {
         int leftIndex = 0;
         int rightIndex = arr.Length - 1;
     
         while (leftIndex < rightIndex)
         {
             T temp = arr[leftIndex];
             arr[leftIndex] = arr[rightIndex];
             arr[rightIndex] = temp;
             
             leftIndex++;
             rightIndex--;
         }
     }
     
     ```

------

### **Topic 3: Strings**

#### **Quiz Questions**

1. **Basic Operations**:

   - What is the time complexity of checking if a string is a palindrome? Why?

     **Linear time complexity, because it compares the start and end indexes of the string (a character array) repeatedly while they increment and decrement respectively until the middle of the array is reached.**

2. **Manipulation**:

   - Given the string `"hello"`, write the steps to reverse it using a stack.

     ```csharp
     private static string ReverseString(string input)
     {
         Stack<char> stack = new Stack<char>();
         string output = string.Empty;
     
         foreach (char i in input)
         {
             stack.Push(i);
         }
     
         while (stack.Count > 0)
         {
             output += stack.Pop();
         }
     
         return output;
     }
     ```

3. **Algorithms**:

   - Describe an algorithm to find the first non-repeating character in a string. What would be its time complexity?

     **I'm assuming you mean not a consecutively repeating character, for example, in the string "aabbcd", 'c' would be the first non-repeating character. If so, then it would be linear in the worst case, as there may not be any non-repeating characters, but every character would need to be checked. On the other hand, you could use some kind of `count` method for every character and return the lowest, which could technically have constant time, although it probably would still be less efficient except for very odd, uncommon strings.**

------

### **Bonus Problem**

Integrate all three topics:

- Problem

  : Write a function that:

  - Takes an array of strings as input.
  - Checks if each string in the array is a palindrome.
  - Returns a new array of booleans, where `true` represents a palindrome and `false` otherwise.

  **I have done this using two methods as putting all this into a single method would not be a separation of concerns and would be bad code management/organisation. By the way, the reason all these methods are `static` is because I can't be bothered instantiating objects repeatedly while testing them when I compile and run the program, since this feels like it would be taking time and attention away from the main focus.**

  ```csharp
      private static bool IsPalindrome(string str)
      {
          int firstIndex = 0;
          int lastIndex = str.Length - 1;
  
          while (firstIndex < lastIndex)
          {
              if (str[firstIndex] != str[lastIndex]) return false;
          }
  
          return true;
      }
  
      private static bool[] AreStringsPalindromes(string[] strings)
      {
          bool[] results = new bool[strings.Length];
  
          for (int i = 0; i < strings.Length; i++)
          {
              results[i] = IsPalindrome(strings[i]);
          }
  
          return results;
      }
  ```

  