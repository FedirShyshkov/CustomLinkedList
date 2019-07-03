using System;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.Tests.Stubs
{
    public class StubNode<T> : ICustomDoubleLinkedListNode<T>
    {
        public T Value { get; set; }

        public ICustomDoubleLinkedListNode<T> Previous { get; set; }

        public ICustomDoubleLinkedListNode<T> Next { get; set; }
    }
}
