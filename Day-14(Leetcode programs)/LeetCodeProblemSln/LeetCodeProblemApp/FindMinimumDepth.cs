using System;
using System.Threading.Tasks;

namespace LeetCodeProblemApp
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public Node Root;
        static int min = 100001;

        public BinaryTree()
        {
            Root = null;
        }

        public async Task Insert(int data)
        {
            Root = await InsertData(Root, data);
        }

        private async Task<Node> InsertData(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = await InsertData(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = await InsertData(root.Right, data);
            }

            return root;
        }

        public async Task FindMinDepth(Node root, int currentDepth)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left == null && root.Right == null)
            {
                if (currentDepth < min)
                {
                    min = currentDepth;
                }
            }

            currentDepth += 1;

            await FindMinDepth(root.Left, currentDepth);
            await FindMinDepth(root.Right, currentDepth);
        }

        public async Task PrintMinDepth()
        {
            await FindMinDepth(Root, 1);
            Console.WriteLine(min);
        }
    }

    class FindMinimumDepth
    {
        static async Task Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            await tree.Insert(3);
            await tree.Insert(12);
            await tree.Insert(4);
            await tree.Insert(10);
            await tree.Insert(2);
            await tree.Insert(8);
            await tree.Insert(5);
            await tree.Insert(9);
            await tree.Insert(6);

            await tree.PrintMinDepth();
        }
    }
}
