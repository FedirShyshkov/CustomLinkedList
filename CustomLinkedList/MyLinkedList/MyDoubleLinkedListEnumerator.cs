using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CustomLinkedList.Interfaces;

namespace CustomLinkedList.MyLinkedList
{
    internal class MyDoubleLinkedListEnumerator<T> : IEnumerator<T>
    {
        private ICustomDoubleLinkedListNode<T> _currentNode;
        private ICustomDoubleLinkedList<T> _currentList;
        private bool _isReversed = false;
        public MyDoubleLinkedListEnumerator(ICustomDoubleLinkedList<T> currentList)
        {
            _currentList = currentList;
        }
        public MyDoubleLinkedListEnumerator(ICustomDoubleLinkedList<T> currentList, bool isReversed):this(currentList)
        {
            _isReversed = isReversed;
        }
        public T Current
        {
            get
            {
                return _currentNode.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _currentNode.Value;
            }
        }
        public void Dispose()
        {
            _currentList = null;
            _currentNode = null;
        }

        public bool MoveNext()
        {
            if(_currentNode == null)
            {
                if (_isReversed)
                {
                    _currentNode = _currentList.Last;
                }
                else
                {
                    _currentNode = _currentList.First;
                }
                return true;
            }
            if (_isReversed)
            {
                _currentNode = _currentNode.Previous;
            }
            else
            {
                _currentNode = _currentNode.Next;
            }
            if(_currentNode == null)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _currentNode = null;
        }
    }
}
