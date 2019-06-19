using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Interfaces
{
    public interface ICustomDoubleLinkedList<T, K>:IEnumerable<T> where K:ICustomDoubleLinkedListNode<T>
    {
        ICustomDoubleLinkedListNode<T> First { get; }
        ICustomDoubleLinkedListNode<T> Last { get; }
        int Count { get; }
        void AddBefore(ICustomDoubleLinkedListNode<T> node, T value);
        void AddAfter(ICustomDoubleLinkedListNode<T> node, T value);
        ICustomDoubleLinkedListNode<T> Find(T value);
        ICustomDoubleLinkedListNode<T> FindLast(T value);
        void Remove(T value);
        void RemoveFirst();
        void Clear();
        void RemoveLast();
        IEnumerable<T> Reverse();
    }
}
