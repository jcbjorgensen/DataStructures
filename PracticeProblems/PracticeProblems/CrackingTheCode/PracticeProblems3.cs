using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.CrackingTheCode
{
    public class Stack<T>
    {
        private Node<T> _top;

        public T Top
        {
            get
            {
                if (_top == null) return default(T);
                return _top.Data;
            }
        }
        public Stack(){}

        public void Push(T item)
        {
            var n = new Node<T>(item);
            if (_top == null)
            {
                _top = n;
                return;
            }
            n.Next = _top;
            _top = n;
        }

        public T Pop()
        {
            if (_top == null) return default(T);
            var item = _top.Data;
            _top = _top.Next;
            return item;
        }
    }

    public class StackOfStacks<T>
    {
        private Stack<Stack<T>> _stacks;
        private int _capacity;
        private int _count;
        public StackOfStacks(int capacity)
        {
            _stacks = new Stack<Stack<T>>();
        }

        public void Push(T item)
        {
            if (_stacks.Top == null || _count == _capacity)
            {
                var stack = new Stack<T>();
                _stacks.Push(stack);
                stack.Push(item);
                _count = 0;
                return;
            }
            _stacks.Top.Push(item);
            _count++;
        }

        public T Pop()
        {
            if (_stacks.Top == null) return default(T);
            var top = _stacks.Top;
            var p = top.Pop();
            if (p == null) _stacks.Pop();
            return _stacks.Top == null ? default(T) : _stacks.Top.Pop();
        }
    }

    public class ArrayOfStacks<T>
    {
        private T[] _arr;
        private Stack<int> _freeEntries;
        private Stack<int> _stack0;
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        public ArrayOfStacks(T[] arr)
        {
            _arr = arr;
            _freeEntries = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                _freeEntries.Push(i);
            }

            _stack0 = new Stack<int>();
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        private void Push(T item, Stack<int> s)
        {
            int e;
            try
            {
                e = _freeEntries.Pop();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            s.Push(e);
            _arr[e] = item;
        }

        private T Pop(Stack<int> s)
        {
            var e = s.Pop();
            var item = _arr[e];
            _freeEntries.Push(e);
            return item;
        }

        public void Push0(T item)
        {
            Push(item,_stack0);
        }

        public T Pop0()
        {
            return Pop(_stack0);
        }

        public void Push1(T item)
        {
            Push(item, _stack1);
        }

        public T Pop1()
        {
            return Pop(_stack1);
        }

        public void Push2(T item)
        {
            Push(item, _stack2);
        }

        public T Pop2()
        {
            return Pop(_stack2);
        }
    }

    public class S
    {
        public string val;

        public S(string val)
        {
            this.val = val;
        }
    }

    public static class PracticeProblems3
    {


        public static void TestStackOfStacks()
        {
            //Base array 
            var s = new StackOfStacks<int>(3);
            for (int i = 0; i < 10; i++)
                s.Push(i);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(s.Pop());
            }
        }

        public static void TestArrayOfStacks()
        {
            //Base array 
            var arr = new S[10];
            var stack = new ArrayOfStacks<S>(arr);

            var a0 = new S("a0");
            var a1 = new S("a1");
            var a2 = new S("a2");
            var a3 = new S("a3");
            var b0 = new S("b0");
            var b1 = new S("b1");
            var b2 = new S("b2");
            var b3 = new S("b3");
            var c0 = new S("c0");
            var c1 = new S("c1");
            var c2 = new S("c2");
            var c3 = new S("c3");

            stack.Push0(a0);
            stack.Push1(b0);
            stack.Push2(c0);
            stack.Push0(a1);
            stack.Push0(a2);
            stack.Push0(a3);
            var b=stack.Pop1();
            stack.Push2(c1);
            stack.Push2(c2);
            stack.Push2(c3);
            var a = stack.Pop0();
            stack.Push1(b1);
            stack.Push1(b2);
            stack.Push1(b3);
        }
    }
}
