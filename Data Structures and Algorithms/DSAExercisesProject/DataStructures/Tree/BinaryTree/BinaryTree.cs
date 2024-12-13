namespace DSAExercisesProject.DataStructures.Tree.BinaryTree
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
        private void InOrderTraversal(TreeNode? node)
        {
            if (node == null) return;

            InOrderTraversal(node.Left);
            Console.Write(node.Data + " ");
            InOrderTraversal(node.Right);
        }

        // Pre-Order Traversal (Root, Left, Right)
        private void PreOrderTraversal(TreeNode? node)
        {
            if (node == null) return;

            Console.Write(node.Data + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        // Post-Order Traversal (Left, Right, Root)
        private void PostOrderTraversal(TreeNode? node)
        {
            if (node == null) return;

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Data + " ");
        }

        private void LevelOrderTraversal(TreeNode? node)
        {
            if (node == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                Console.Write(current.Data + " ");

                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }
        }

        public static void RunExercises()
        {
            BinaryTree tree = new BinaryTree();

            tree.Root = new TreeNode(1)
            {
                Left = new TreeNode(2),
                Right = new TreeNode(3)
            };
            tree.Root.Left.Left = new TreeNode(4);
            tree.Root.Left.Right = new TreeNode(5);

            Console.WriteLine("In-Order Traversal:");
            tree.InOrderTraversal(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Pre-Order Traversal:");
            tree.PreOrderTraversal(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Post-Order Traversal");
            tree.PostOrderTraversal(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Level-Order Traversal");
            tree.LevelOrderTraversal(tree.Root);
            Console.WriteLine();
        }
    }
}