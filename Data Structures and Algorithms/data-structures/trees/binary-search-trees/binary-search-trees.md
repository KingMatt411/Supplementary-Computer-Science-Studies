# Binary Search Trees (BSTs)

A Binary Search Tree (BST) is a specialised form of a binary tree where each node follows the **binary search property**:

1. All nodes in the **left subtree** have values **less than the root**.
2. All nodes in the **right subtree** have values **greater than the root**.
3. Both the left and right subtrees must also be BSTs.

___

### Properties of a BST

1. **In-Order Traversal** of a BST produces elements in **sorted order**.
2. Search, insertion, and deletion operations are efficient when the tree is **balanced**.
3. **Time Complexity**:
   * Best/Average Case (Balanced Tree): $O(\log n)$.
   * Worst Case (Degenerate Tree): $O(n)$, when the tree becomes a linked list.

___

### Balanced Trees

A binary tree is considered **balanced** when:

1. The height of the left and right subtrees of each node differs by at most **1**.
2. Both the left and right subtrees are also balanced.

##### Why is Balance Important?

* In a balanced tree, the number of levels (or height) is minimised.
* This ensures that operations like **search**, **insertion**, and **deletion** are efficient, with a time complexity of $O(\log n)$.

##### Example of a Balanced Tree

For the following tree:

```
        10
       /  \
      5    20
     / \   /
    3   7 15
```

* The height of the left subtree (rooted at `5`) it 2.
* The height of the right subtree (rooted at `20`) is 2.
* The difference is $|2 - 2| = 0$, so the tree is balanced.

##### Height

* The **height** refers to the number of steps to the deepest leaf node and includes the starting node (e.g., `5` or `20` in this case).
* The height of a balanced tree is approximately $\log_2(n)$, where $n$ is the number of nodes.

___

### Degenerate Trees

A binary tree is considered **degenerate** (or **pathological**) when:

1. Every node has only **one child**, resulting in a tree that resembles a linked list.
2. The height of the tree is **equal to the number of nodes** ($O(n)$).

##### Why are Degenerate Trees Problematic?

* In a degenerate tree, operations like search, insertion, and deletion degrade to $O(n)$ time complexity, similar to a linked list.
  * This defeats the purpose of using a binary search tree for efficient operations.

##### Example of a Degenerate Tree

For the following tree:

```
    10
      \
      20
        \
        30
          \
          40
```

* The tree is essentially a linked list.
* The height is $4$, which equals the number of nodes.

___

### Comparison of Balanced vs. Degenerate Trees

| Property            | Balanced Tree            | Degenerate Tree                 |
| ------------------- | ------------------------ | ------------------------------- |
| **Height**          | $\log_2(n)$              | $n$                             |
| **Time Complexity** | $O(\log n)$              | $O(n)$                          |
| **Structure**       | Compact and bushy        | Linear (like a linked list)     |
| **Efficiency**      | Optimised for operations | Poor performance for operations |

