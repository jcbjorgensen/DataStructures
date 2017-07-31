using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeProblems.Quora;

namespace PracticeProblems.Quora
{

    public class Tree
    {
        public int Item;
        public Tree Left;
        public Tree Right;
    }

    public static class TreeOperationsTest
    {
        public static void TreeTest()
        {
            Tree tree = null;

            var numbers = new[] {3, 4, 5, 1, 3, 8, 7};

            for (int i = 0; i < numbers.Length; i++)
                TreeOperations.Insert(ref tree,numbers[i]);

            var lst = new List<int>();
            TreeOperations.InOrderTraversal(tree,lst);
            var result1 = TreeOperations.Search(tree, 8);
            var result0 = TreeOperations.Search(tree,6);

            List<int> lstReverse = new List<int>();
            TreeOperations.ReverseOrderTraversal(tree, lstReverse);

            List<int> stackNumbers = new List<int>();
            TreeOperations.StackBasedInOrderTraversal(tree, stackNumbers);

            List<int> stackReverseNumbers = new List<int>();
            TreeOperations.StackBasedReverseOrderTraversal(tree, stackReverseNumbers);

        }
    }

    public static class TreeOperations
    {
        public static void Insert(ref Tree tree, int item)
        {
            if (tree == null)
            {
                tree = new Tree {Item = item};
                return;
            }

            if (tree.Item < item)
                Insert(ref tree.Right, item);
            else
                Insert(ref tree.Left, item);
        }

        public static bool Search(Tree tree, int item)
        {
            if (tree == null) return false;
            if (tree.Item == item) return true;
            if (tree.Item < item) return Search(tree.Right, item);
            return Search(tree.Left, item);
        }

        public static void InOrderTraversal(Tree tree,List<int> numbers)
        {
            if(tree == null) return;
            InOrderTraversal(tree.Left, numbers);
            numbers.Add(tree.Item);
            InOrderTraversal(tree.Right, numbers);
        }

        public static void ReverseOrderTraversal(Tree tree, List<int> numbers)
        {
            if (tree == null) return;
            ReverseOrderTraversal(tree.Right, numbers);
            numbers.Add(tree.Item);
            ReverseOrderTraversal(tree.Left, numbers);
        }

        public static void StackBasedInOrderTraversal(Tree tree, List<int> numbers)
        {
            var stack = new Stack<Tree>();
            var curr = tree;

            while (stack.Count != 0 || curr != null)
            {
                if (curr !=null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Peek();
                    numbers.Add(curr.Item);
                    stack.Pop();
                    curr = curr.Right;
                }
            }
        }

        //public static void ShiftLeftRightLevelOrder(Tree tree, List<int> numbers)
        //{
        //    var leftQueue = new Queue<Tree>();
        //    var rightQueue = new Queue<Tree>();
        //
        //    var curr = tree;
        //
        //    while (true)
        //    {
        //        //Process left 
        //        if (curr.Right)
        //        {
        //            
        //        }
        //
        //        //Process right 
        //        if (curr != null)
        //        {
        //            stack.Push(curr);
        //            curr = curr.Left;
        //        }
        //        else
        //        {
        //            curr = stack.Peek();
        //            numbers.Add(curr.Item);
        //            stack.Pop();
        //            curr = curr.Right;
        //        }
        //    }
        //}


        public static void StackBasedReverseOrderTraversal(Tree tree, List<int> numbers)
        {
            var stack = new Stack<Tree>();
            var curr = tree;

            while (stack.Count != 0 || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Right;
                }
                else
                {
                    curr = stack.Peek();
                    numbers.Add(curr.Item);
                    stack.Pop();
                    curr = curr.Left;
                }
            }
        }

    }
}
