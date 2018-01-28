using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.CrackingTheCode
{
    public class Node<T>
    {
        public Node<T> Next;
        public T Data;

        public Node(T data)
        {
            Data = data;
        }

        public void AddToTail(T data)
        {
            var n = this;
            while (n.Next != null)
            {
                n = n.Next;
            }
            var end = new Node<T>(data);
            n.Next = end;
        }

        public void Print()
        {
            var n = this;
            do
            {
                Console.WriteLine(n.Data);
                n = n.Next;
            } while (n != null);
        }
    }
}
