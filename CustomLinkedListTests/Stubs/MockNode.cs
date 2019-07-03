using System;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.Tests.Stubs
{
    public class MockNode<T> : ICustomDoubleLinkedListNode<T>
    {
        public static int counter = 0;
        public int creationValue;        

        public T Value { get; set; }

        public ICustomDoubleLinkedListNode<T> Previous { get; set; }        

        public ICustomDoubleLinkedListNode<T> Next { get; set; }

        public MockNode()
        {
            counter++;
            creationValue = counter;
        }

    }
}
