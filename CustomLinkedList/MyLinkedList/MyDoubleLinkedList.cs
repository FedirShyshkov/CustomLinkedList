using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.MyLinkedList
{
    public class MyDoubleLinkedList<T, K> : ICustomDoubleLinkedList<T> where K:ICustomDoubleLinkedListNode<T>, new()
    {
        public ICustomDoubleLinkedListNode<T> First { get; set; }

        public ICustomDoubleLinkedListNode<T> Last { get; set; }
        
        public int Count { get; set; }
        
        private ICustomDoubleLinkedListNode<T> createNode(T value)
        {
            ICustomDoubleLinkedListNode<T> newNode = new K();
            newNode.Value = value;            
            return newNode;
        }

        public void AddBefore(ICustomDoubleLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (ReferenceEquals(node, First))
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
            Count++;
        }
        public void AddAfter(ICustomDoubleLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (ReferenceEquals(node, Last))
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
            Count++;
        }
        public void AddFirst(T value)
        {
            var newNode = createNode(value);
            newNode.Next = First;
            newNode.Previous = null;
            if (First != null)
            {
                First.Previous = newNode;
            }
            First = newNode;
            if (Last == null)
            {
                Last = newNode;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            var newNode = createNode(value);
            if (First == null)
            {
                newNode.Previous = null;
                First = newNode;
                Last = newNode;
                Count = 1;
                return;
            }
            Last.Next = newNode;
            newNode.Previous = Last;
            Last = newNode;
            Count++;
        }
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public ICustomDoubleLinkedListNode<T> Find(T value)
        {
            var current = First;
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
            var current = Last;
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
                    Count--;
                    return;
                }
                node.Previous.Next = null;
                Last = node.Previous;
                Count--;
                return;
            }
            if(node.Next != null)
            {
                node.Next.Previous = null;
                First = node.Next;
                Count--;
                return;
            }
            Clear();
        }
        public void RemoveFirst()
        {
            if( First.Next != null)
            {
                First = First.Next;
                First.Previous = null;
                Count--;
            } else
            {
                Clear();
            }
            
        }
        public void RemoveLast()
        {
            if (Last.Previous != null)
            {
                Last = Last.Previous;
                Last.Next = null;
                Count--;
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
