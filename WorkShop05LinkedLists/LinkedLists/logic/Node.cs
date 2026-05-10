using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists.logic
{
    internal class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }
}
