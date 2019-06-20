using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.MyLinkedList
{
    public class MyDoubleLinkedList<T> : ICustomDoubleLinkedList<T>
    {
        private ICustomDoubleLinkedListNode<T> _first = null;
        private ICustomDoubleLinkedListNode<T> _last = null;
        private Type _customNodeType = null;
        private int _count;

        public MyDoubleLinkedList()
        {
        }
        internal MyDoubleLinkedList(Type customNodeType)
        {
            if (customNodeType.GetConstructor(new Type[] { GetType().GetGenericArguments()[0] }) == null)
            {
                throw new LinkedListException($"{customNodeType} is missing a required constructor for type {typeof(T)}");
            }
            _customNodeType = customNodeType;
        }

        public ICustomDoubleLinkedListNode<T> First
        {
            get
            {
                return _first;
            }
        }

        public ICustomDoubleLinkedListNode<T> Last
        {
            get
            {
                return _last;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
        }
        private ICustomDoubleLinkedListNode<T> createNode(T value)
        {
            ICustomDoubleLinkedListNode<T> newNode;
            if (_customNodeType != null)
            {
                newNode = (ICustomDoubleLinkedListNode<T>)Activator.CreateInstance(_customNodeType, new object[] { value });
            }
            else
            {
                newNode = new MyDoubleLinkedListNode<T>(value);
            }
            return newNode;
        }
        public void AddBefore(ICustomDoubleLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (ReferenceEquals(node, _first))
            {
                AddFirst(value);
                return;
            }

            var newNode = createNode(value);
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            newNode.Next = node;
            if (newNode.Previous != null)
            {
                newNode.Previous.Next = newNode;
            }
            _count++;
        }
        public void AddAfter(ICustomDoubleLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (ReferenceEquals(node, _last))
            {
                AddLast(value);
                return;
            }

            var newNode = createNode(value);
            newNode.Next = node.Next;
            node.Next = newNode;
            newNode.Previous = node;
            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }
            _count++;
        }
        public void AddFirst(T value)
        {
            var newNode = createNode(value);
            newNode.Next = _first;
            newNode.Previous = null;
            if (_first != null)
            {
                _first.Previous = newNode;
            }
            _first = newNode;
            if (_last == null)
            {
                _last = newNode;
            }
            _count++;
        }
        public void AddLast(T value)
        {
            var newNode = createNode(value);
            if (_first == null)
            {
                newNode.Previous = null;
                _first = newNode;
                _last = newNode;
                _count = 1;
                return;
            }
            _last.Next = newNode;
            newNode.Previous = _last;
            _last = newNode;
            _count++;
        }
        public void Clear()
        {
            _first = null;
            _last = null;
            _count = 0;
        }

        public ICustomDoubleLinkedListNode<T> Find(T value)
        {
            var current = _first;
            while(current != null)
            {
                if( value.Equals(current.Value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public ICustomDoubleLinkedListNode<T> FindLast(T value)
        {
            var current = _last;
            while (current != null)
            {
                if (value.Equals(current.Value))
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }
        public void Remove(T value)
        {
            var node = Find(value);
            if (node == null)
            {
                return;
            }
            if(node.Previous != null)
            {
                if(node.Next != null)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    _count--;
                    return;
                }
                node.Previous.Next = null;
                _last = node.Previous;
                _count--;
                return;
            }
            if(node.Next != null)
            {
                node.Next.Previous = null;
                _first = node.Next;
                _count--;
                return;
            }
            Clear();
        }
        public void RemoveFirst()
        {
            if(_first.Next != null)
            {
                _first = _first.Next;
                _first.Previous = null;
                _count--;
            } else
            {
                Clear();
            }
            
        }
        public void RemoveLast()
        {
            if (_last.Previous != null)
            {
                _last = _last.Previous;
                _last.Next = null;
                _count--;
            }
            else
            {
                Clear();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyDoubleLinkedListEnumerator<T>(this);
        }

        public IEnumerable<T> Reverse()
        {
            var enumerator = new MyDoubleLinkedListEnumerator<T>(this, true);
            while (enumerator.MoveNext() == true)
            {
                yield return enumerator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
