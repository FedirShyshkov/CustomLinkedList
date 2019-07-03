using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomLinkedList.MyLinkedList;

namespace CustomLinkedListManualTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom List");
            var list = new DoubleLinkedList<int>();
            
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddLast(3);
            list.AddBefore(list.Last, 10);
            list.AddAfter(list.First, 20);
            foreach(var element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine(" -------------- ");
            foreach (var element in list.Reverse())
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine(" -------------- ");
            Console.WriteLine("Removing element with value 10");
            list.Remove(10);
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine(" -------------- ");
            Console.WriteLine("Removing first and last elements");
            list.RemoveLast();
            list.RemoveFirst();
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine(" -------------- ");
            Console.WriteLine("Normal List");
            var list2 = new LinkedList<int>();
            list2.AddFirst(1);
            list2.AddFirst(2);
            list2.AddLast(3);
            list2.AddBefore(list2.Last, 10);
            list2.AddAfter(list2.First, 20);
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(" -------------- ");
            foreach (var element in list2.Reverse())
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list2.Count}");

            Console.WriteLine(" -------------- ");

            Console.WriteLine("Removing element with value 10");
            list2.Remove(10);
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list2.Count}");

            Console.WriteLine("Removing first and last elements");
            list2.RemoveLast();
            list2.RemoveFirst();
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Count: {list2.Count}");

            Console.ReadKey();                       
        }
    }
}
