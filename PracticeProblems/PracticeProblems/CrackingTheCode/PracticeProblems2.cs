using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.CrackingTheCode
{
    public static class PracticeProblems2
    {
        public static void Tests()
        {

            var a = CreateLinkedList(new[] { 1, 2, 3 });
            var b = CreateLinkedList(new[] { 1, 3 });
            var c = Add(a, b, 0);
            c.Print();

            var head = CreateLinkedList(new [] {3,3,3,4,5,5});
            head.Print();

            head.Print();

            var node = NthToLastNode(head, 4);

            RemoveDuplicates(head);
            head.Print();

        
        }


        public static Node<int> Add(Node<int> a, Node<int> b, int carry)
        {
            int ad = 0;
            int bd = 0;
            Node<int> aNext = null;
            Node<int> bNext = null;
            if (a == null && b == null) return null;
            if (a != null)
            {
                ad = a.Data;
                aNext = a.Next;
            }
            if (b != null)
            {
                bd = b.Data;
                bNext = b.Next;
            }
            var sum = ad + bd+carry;
            var n = new Node<int>(sum % 10) {Next = Add(aNext, bNext, sum / 10)};
            return n;
        }

        public static void Remove<T>(ref Node<T> n)
        {
            if(n == null) return;
            n = n.Next;
        }

        public static Node<T> NthToLastNode<T>(Node<T> head, int n)
        {
            if(head == null) return null;

            int k = 0;
            var node = head;
            while (node != null)
            {
                k++;
                node = node.Next;
            }

            if (n > k) return null;
            var m = k - n-1;
            k = 0;
            node = head;

            while (k<m)
            {
                node = node.Next;
                k++;
            }
            return node;
        }

        public static void RemoveDuplicates<T>(Node<T> head)
        {
            if (head == null) return;
            var h = new HashSet<T> {head.Data};
            var n = head;
            while (n.Next != null)
            {
                if (h.Contains(n.Next.Data))
                {
                    n.Next = n.Next.Next;
                    continue;
                }
                h.Add(n.Next.Data);
                n = n.Next;
            }
        }

        public static Node<int> CreateLinkedList(int[] a)
        {
            var head = new Node<int>(a[0]);
            var n = head;
            for (var index = 1; index < a.Length; index++)
            {
                n.Next = new Node<int>(a[index]);
                n = n.Next;
            }
            return head;
        }

        public static Node<int> CreateLinkedList()
        {
            var head = new Node<int>(1);
            head.AddToTail(2);
            head.AddToTail(3);
            head.AddToTail(3);
            head.AddToTail(3);
            head.AddToTail(4);
            head.AddToTail(5);
            head.AddToTail(5);
            head.AddToTail(5);
            head.AddToTail(5);

            return head;
        }
    }
}
