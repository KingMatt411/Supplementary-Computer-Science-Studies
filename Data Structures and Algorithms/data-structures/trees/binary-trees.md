# Binary Trees

### What is a Binary Tree?

A binary tree is a **hierarchical data structure** in which:

1. Each node has at most **two children**:
   * A **left child**.
   * A **right child**.
2. The topmost node is called the **root**.
3. Nodes without children are called **leaf nodes**.

___

### Key Terminology

1. **Node**: An element of the tree containing data and links to its children.
2. **Root**: The topmost node of the tree.
3. **Parent**: A node that has children.
4. **Child**: A node that descends from another node.
5. **Subtree**: The tree formed by a node and its descendants.
6. **Height**: The number of edges on the longest path from the root to a leaf.
7. **Depth**: The number of edges from the root to a given node.

___

### Binary Tree Representation

```csharp
public class TreeNode
{
    public int Data; // Value stored in the node
    public TreeNode? Left; // Reference to the left child
    public TreeNode? Right; // Reference to the right child
    
    public TreeNode(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}
```

#### Example Tree

```markdown
        1
       / \
      2   3
     / \
    4   5

```

This tree would be created as follows:

```csharp
TreeNode root = new TreeNode(1);
root.Left = new TreeNode(2);
root.Right = new TreeNode(3);
root.Left.Left = new TreeNode(4);
root.Left.Right = new TreeNode(5);
```

___

### Binary Tree Traversal

Traversal is the process of visiting all nodes in the tree in a specific order. Common traversal methods include:

##### 1. In-Order Traversal (Left, Root, Right)

* Visit the left subtree.
* Visit the root.
* Visit the right subtree.
* **Output for Example Tree**: `4, 2, 5, 1, 3`.

##### 2. Pre-Order Traversal (Root, Left, Right)

* Visit the root.
* Visit the left subtree.
* Visit the right subtree.
* **Output for Example Tree**: `1, 2, 4, 5, 3`.

##### 3. Post-Order Traversal (Left, Right, Root)

* Visit the left subtree.
* Visit the right subtree.
* Visit the root.
* **Output for Example Tree**: `4, 5, 2, 3, 1`

##### 4. Level-Order Traversal (Breadth-First Search)

* Visit nodes level by level (starting at the root).
* **Output for Example Tree**: `1, 2, 3, 4, 5`

___

### C# Implementation

```csharp
using System;
using System.Collections.Generic;

namespace DSAExercisesProject.Trees
{
    public class TreeNode
    {
        public int Data;
        public TreeNode? Left;
        public TreeNode? Right;
        
        public TreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
    
    public class BinaryTree
    {
        public TreeNode? Root;
        
        public BinaryTree()
        {
            Root = null;
        }
        
        // In-Order Traversal (Left, Root, Right)
        public void InOrderTraversal(TreeNode? node)
        {
            if (node == null) return;
            
            InOrderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InOrderTraversal(node.Right);
        }
        
        // Pre-Order Traversal (Root, Left, Right)
        public void PreOrderTraversal(TreeNode? node)
        {
            if (node == null) return;
            
            Console.Write(node.Data + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);                
        }
        
        // Post-Order Traversal (Left, Right, Root)
        public void PostOrderTraversal(TreeNode? node)
        {
            if (node == null) return;
            
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data + " ");
        }
    }
    
    
    
}
```











