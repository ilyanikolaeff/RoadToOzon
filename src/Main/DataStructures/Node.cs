using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DataStructures
{
    internal class Node<T>
    {
        public T Value { get; set; }

        public Node<T>? Next { get; set; }

        public Node(T value, Node<T>? next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
