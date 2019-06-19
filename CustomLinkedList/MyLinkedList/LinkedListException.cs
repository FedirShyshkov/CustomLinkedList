using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.MyLinkedList
{
    public class LinkedListException:Exception
    {
        public LinkedListException(string msg)
            :base(msg)
        { }
    }
}
