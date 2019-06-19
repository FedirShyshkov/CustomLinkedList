using System;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.Tests.Stubs
{
    public class StubNode<T> : ICustomDoubleLinkedListNode<T>
    {
        private T _value;
        private ICustomDoubleLinkedListNode<T> _previous = null;
        private ICustomDoubleLinkedListNode<T> _next = null;
        public StubNode()
        {
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public ICustomDoubleLinkedListNode<T> Previous
        {
            get
            {
                return _previous;
            }
            set
            {
                _previous = value;
            }
        }

        public ICustomDoubleLinkedListNode<T> Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
    }
}
