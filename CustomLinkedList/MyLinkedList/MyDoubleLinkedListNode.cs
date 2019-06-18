using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.MyLinkedList
{
    public class MyDoubleLinkedListNode<T>
    {
        private T _value;
        private MyDoubleLinkedListNode<T> _previous = null;
        private MyDoubleLinkedListNode<T> _next = null;
        public MyDoubleLinkedListNode(T data)
        {
            _value = data;
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set {
                _value = value;
            }
        }

        public MyDoubleLinkedListNode<T> Previous
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

        public MyDoubleLinkedListNode<T> Next
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
