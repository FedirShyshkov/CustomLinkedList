using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.MyLinkedList
{
    public class MyDoubleLinkedList<T, K> : ICustomDoubleLinkedList<T, K> where K:ICustomDoubleLinkedListNode<T>
    {
        private ICustomDoubleLinkedListNode<T> _first = null;
        private ICustomDoubleLinkedListNode<T> _last = null;
        private int _count;

        public MyDoubleLinkedList()
        {
            if (typeof(K).GetConstructor(new Type[] { GetType().GetGenericArguments()[0] }) == null)
            {
                throw new Exception($"{typeof(K)} is missing a required constructor for type {typeof(T)}");
            }
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

        public void AddBefore(ICustomDoubleLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            ICustomDoubleLinkedListNode<T> newNode = (ICustomDoubleLinkedListNode<T>)Activator.CreateInstance(typeof(K), new object[] { value });

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
            ICustomDoubleLinkedListNode<T> newNode = (ICustomDoubleLinkedListNode<T>)Activator.CreateInstance(typeof(K), new object[] { value });
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
            ICustomDoubleLinkedListNode<T> newNode = (ICustomDoubleLinkedListNode<T>)Activator.CreateInstance(typeof(K), new object[] { value });
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
            ICustomDoubleLinkedListNode<T> newNode = (ICustomDoubleLinkedListNode<T>)Activator.CreateInstance(typeof(K), new object[] { value });
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
            return new MyDoubleLinkedListEnumerator<T, K>(this);
        }

        public IEnumerable<T> Reverse()
        {
            var enumerator = new MyDoubleLinkedListEnumerator<T, K>(this, true);
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
