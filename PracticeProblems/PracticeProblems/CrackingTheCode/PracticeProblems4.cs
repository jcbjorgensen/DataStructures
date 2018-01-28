using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;

namespace PracticeProblems.CrackingTheCode
{
    public static class PracticeProblems4
    {
        public static void TestTreeCreate()
        {
            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8,9};
            var depth = (int) Math.Log(arr.Length, 2);
            var counter = 0;
            var n = Create(arr, depth, ref counter);
            
        }

        public static TreeNode<int> Create(int[] arr, int depth, ref int counter)
        {
            if (counter > arr.Length - 1) return null;
            if (depth == 0) return new TreeNode<int> {Data = arr[counter++]};

            var left = counter < arr.Length - 1 ? Create(arr, depth - 1, ref counter) : null;
            var n = new TreeNode<int> {Data = arr[counter++]};
            n.Left = left;

            var right = counter<arr.Length ? Create(arr, depth - 1, ref counter) : null;
            n.Right = right;
            return n;
        }

        public static void TestDepthFirstSearch()
        {
            var g = TestQuickGraph();

            var v1 = g.Vertices.Single(v=> v.Data ==1);
            var v6 = g.Vertices.Single(v => v.Data == 6);

            var isV1v6Connected = Found(v1, v6, new HashSet<Vertex>(), g);

            var v7 = g.Vertices.Single(v => v.Data == 7);
            var v2 = g.Vertices.Single(v => v.Data == 2);

            var isV7v2Connected = Found(v7, v2, new HashSet<Vertex>(), g);
        }

        public static bool Found(Vertex current, Vertex target, HashSet<Vertex> visited, 
            AdjacencyGraph<Vertex, Edge<Vertex>> g)
        {
            if (current == target) return true;
            if (visited.Contains(current)) return false;

            visited.Add(current);
            var edges = g.OutEdges(current);

            foreach (var edge in edges)
            {
                if (Found(edge.Target, target, visited, g))
                    return true;
            }
            return false;
        }

        public static QuickGraph.AdjacencyGraph<Vertex, Edge<Vertex>> TestQuickGraph()
        {

            var graph = new AdjacencyGraph<Vertex,Edge<Vertex>>();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph.AddVerticesAndEdge(new Edge<Vertex>(v1,v2));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v1,v3));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v3,v4));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v3,v5));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v4,v5));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v4,v6));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v4,v7));
            graph.AddVerticesAndEdge(new Edge<Vertex>(v7,v3));
            

            return graph;
        }

        public static void TestInOrderTraversal()
        {
            var root = TestTree();

            Action<int> process = Console.WriteLine;
            InOrder(root,process);
            Console.WriteLine();
            PreOrder(root, process);
            Console.WriteLine();
            PostOrder(root, process);
            Console.WriteLine();
        }

        private static GraphNode<int> TestGraph()
        {
            var n1 = new GraphNode<int>() {Data = 1};
            var n2 = new GraphNode<int>() {Data = 2};
            var n3 = new GraphNode<int>() {Data = 3};
            var n4 = new GraphNode<int>() {Data = 4};
            var n5 = new GraphNode<int>() {Data = 5};
            var n6 = new GraphNode<int>() {Data = 6};
            
            n1.ConnectedNodes.Add(n2);
            n1.ConnectedNodes.Add(n3);
            n3.ConnectedNodes.Add(n4);
            n3.ConnectedNodes.Add(n5);
            n4.ConnectedNodes.Add(n5);
            n4.ConnectedNodes.Add(n6);

            return n1;
        }


        private static TreeNode<int> TestTree()
        {
            var depth = 4;
            Func<int, int> left = i => i * 10+1;
            Func<int, int> right = i => i * 10 + 2;
            var root = new TreeNode<int> {Data = 1};
            CreateNodes(root,0,depth,left,right);
            return root;
        }

        private static void CreateNodes<T>(TreeNode<T> n, int depth, int maxDepth, 
            Func<T,T> leftData, Func<T,T> rightData)
        {
            if(depth>=maxDepth-1) return;
            n.Left = new TreeNode<T> {Data = leftData(n.Data)};
            n.Right = new TreeNode<T> {Data = rightData(n.Data)};
            CreateNodes<T>(n.Left,depth+1, maxDepth, leftData,rightData);
            CreateNodes<T>(n.Right,depth+1, maxDepth, leftData,rightData);
        }

        public static void InOrder<T>(TreeNode<T> n, Action<T> process)
        {
            if(n ==null) return;
            InOrder(n.Left, process);
            process(n.Data);
            InOrder(n.Right,process);
        }

        public static void PreOrder<T>(TreeNode<T> n, Action<T> process)
        {
            if (n == null) return;
            process(n.Data);
            PreOrder(n.Left, process);
            PreOrder(n.Right, process);
        }

        public static void PostOrder<T>(TreeNode<T> n, Action<T> process)
        {
            if (n == null) return;
            PostOrder(n.Left, process);
            PostOrder(n.Right, process);
            process(n.Data);
        }

    }

    public class TreeNode<T>
    {
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public T Data;
    }


    public class Vertex
    {
        public int Data;
        public Vertex(int data)
        {
            Data = data;
        }


    }

    public class GraphNode<T>
    {
        public readonly List<GraphNode<T>> ConnectedNodes;
        public T Data;

        public GraphNode()
        {
            ConnectedNodes = new List<GraphNode<T>>();
        }
    }


}
