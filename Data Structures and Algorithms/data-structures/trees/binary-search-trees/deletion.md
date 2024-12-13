# Binary Search Tree (BST) Deletion

Deletion in a Binary Search Tree is more complex than insertion or search because it requires maintaining the **binary search tree property** after removing a node.

___

### Deletion Cases

#### Case 1: The Node is a Leaf (No Children)

* Simply remove the node.

* Example:

  ```
      50
     /  \
    30   70
   / \
  20  40
  ```

  Deleting `20` (a leaf) results in:

  ```
      50
     /  \
    30   70
     \
     40
  ```

#### Case 2: The Node Has One Child

* Remove the node and link its parent directly to its child.

* Example:

  ```
      50
     /  \
    30   70
   /
  20
  ```

  Deleting `30` (with one child) results in:

  ```
      50
     /  \
    20   70
  ```

#### Case 3: The Node Has Two Children

* Replace the node with:

  1. Its **in-order successor** (smallest value in its right subtree),

     or

  2. Its **in-order predecessor** (largest value in its left subtree).

* Delete the successor or predecessor node recursively.

* Example:

  ```
      50
     /  \
    30   70
        /  \
       60   80
  ```

  Deleting `50` (with two children) using its **in-order successor** (`60`) results in:

  ```
      60
     /  \
    30   70
          \
          80
  ```

___

### Implementation in C#

```csharp
public class BinarySearchTree
{
    public TreeNode? Root;
    
    public BinarySearchTree()
    {
        Root = null;
    }
    
    // Delete a node from the BST
    public void Delete(int value)
    {
        Root = DeleteRecursively(Root, value);
    }
    
    private TreeNode? DeleteRecursively(TreeNode? node, int value)
    {
        if (node == null) return null; // Base case: Node not found
        
        if (value < node.Data)
        {
            // Traverse the left subtree
            node.Left = DeleteRecursively(node.Left, value);
        }
        else if (value < node.Data)
        {
            // Traverse the right subtree
            node.Right = DeleteRecursively(node.Right, value);
        }
        else
        {
            // ***NODE FOUND***
            
            // Case 1: No children (leaf node)
            if (node.Left == null && node.Right == null) return null;
            
            // Case 2: One child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            
            // Case 3: Two children
            // Replace with in-order successor (smallest value in the right subtree)
            TreeNode successor = FindMin(node.Right);
            node.Data = successor.Data;// Copy the successor's value
            node.Right = DeleteRecursively(node.Right, successor.Data); // Delete the successor
        }
        
        return node;        
    }
    
    // Helper method to find the smallest value in a subtree
    private TreeNode FindMin(TreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        
        return node;
    }
    
    // In-Order Traversal (for testing)
    public void InOrderTraversal(TreeNode? node)
    {
        if (node == null) return;
        
        InOrderTraversal(node.Left);
        Console.Write(node.Data + " ");
        InOrderTraversal(node.Right);
    }
}
```























