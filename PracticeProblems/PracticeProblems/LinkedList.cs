using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class Data
    {
        public int I;
    }

    public class List
    {
        public Data Data;
        public List Next;

        public List() { }
        public List(Data data)
        {
            Data = data;
        }
       
    }

    public static class LinkedListOperations
    {
        public static void Insert(ref List head, Data element)
        {
            var list = new List() { Data = element, Next = head};
            head = list;
        }

        public static void Print(List lst)
        {
            var element = lst;
            while (element != null)
            {
                Console.WriteLine(element.Data.I);
                element = element.Next;
            }
        }
    }

    public static class LinkedListTests
    {
        public static void InsertTest()
        {
            var data0 = new Data { I = 0 };
            var data1 = new Data { I = 1 };

            var list = new List(data0);

            LinkedListOperations.Insert(ref list, data1);
            LinkedListOperations.Print(list);
        }
    }
}
