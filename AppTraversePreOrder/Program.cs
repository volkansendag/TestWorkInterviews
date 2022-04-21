using System;
using System.Collections.Generic;

namespace AppTraversePreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BinaryTree binaryTree = new BinaryTree();

            var arr = new string[] { "4", "1", "5", "2", "#", "#", "#" };

            foreach (var i in arr)
            {
                if(i!= "#")
                binaryTree.Add(int.Parse(i));
            }

            var val = binaryTree.TraversePreOrder(binaryTree.Root, null);
            Console.WriteLine(string.Join(" ",val));
        }

        class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; }
        }

        class BinaryTree
        {
            public Node Root { get; set; }

            public bool Add(int value)
            {
                Node before = null, after = this.Root;

                while (after != null)
                {
                    before = after;
                    if (value < after.Data) //Is new node in left tree? 
                        after = after.LeftNode;
                    else if (value > after.Data) //Is new node in right tree?
                        after = after.RightNode;
                    else
                    {
                        //Exist same value
                        return false;
                    }
                }

                Node newNode = new Node();
                newNode.Data = value;

                if (this.Root == null)//Tree ise empty
                    this.Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }

                return true;
            }


            private Node Remove(Node parent, int key)
            {
                if (parent == null) return parent;

                if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
                else if (key > parent.Data)
                    parent.RightNode = Remove(parent.RightNode, key);

                // if value is same as parent's value, then this is the node to be deleted  
                else
                {
                    // node with only one child or no child  
                    if (parent.LeftNode == null)
                        return parent.RightNode;
                    else if (parent.RightNode == null)
                        return parent.LeftNode;

                    // node with two children: Get the inorder successor (smallest in the right subtree)  
                    parent.Data = MinValue(parent.RightNode);

                    // Delete the inorder successor  
                    parent.RightNode = Remove(parent.RightNode, parent.Data);
                }

                return parent;
            }

            private int MinValue(Node node)
            {
                int minv = node.Data;

                while (node.LeftNode != null)
                {
                    minv = node.LeftNode.Data;
                    node = node.LeftNode;
                }

                return minv;
            }

            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;
                    if (value < parent.Data)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }

            private int GetTreeDepth(Node parent)
            {
                return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
            }

            public List<int> TraversePreOrder(Node parent, List<int> arr = null)
            {
                if(arr == null)
                {
                    arr = new List<int>();
                }

                if (parent != null)
                {
                    arr.Add(parent.Data);

                    if (arr.Count > 0)
                    {
                        TraversePreOrder(parent.LeftNode, arr);
                        TraversePreOrder(parent.RightNode, arr);
                    }
                }

                return arr;
            }

        }
    }
}
