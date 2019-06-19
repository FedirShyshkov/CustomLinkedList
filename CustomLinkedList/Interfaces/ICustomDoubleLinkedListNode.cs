using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Interfaces
{
    public interface ICustomDoubleLinkedListNode<T>
    {
        T Value { get; set; }
        ICustomDoubleLinkedListNode<T> Previous { get; set; }
        ICustomDoubleLinkedListNode<T> Next { get; set; }
    }
}
