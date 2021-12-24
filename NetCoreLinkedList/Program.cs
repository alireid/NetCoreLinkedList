using System;

namespace NetCoreLinkedList
{
    class Node<Type> : LinkedList<Type>
    { 
        public Type value;
        public Node(Type value) { this.value = value; }
    }
    class LinkedList<Type>
    {
        Node<Type> next;

        // Previous method
        protected LinkedList<Type> Previous(Type x)
        {
            LinkedList<Type> p = this;   
            for (; p.next != null; p = p.next)
                if (p.next.value.Equals(x))
                    return p;               
            return p;                   
        }

        // Contain method
        public bool Contain(Type x)
        {
            return Previous(x).next != null ? true : false;
        }

        // Add method
        public bool Add(Type x)
        {
            LinkedList<Type> p = Previous(x);
            if (p.next != null)           
                return false;
            p.next = new Node<Type>(x);
            return true;
        }

        // Delete method
        public bool Delete(Type x)
        {
            LinkedList<Type> p = Previous(x);
            if (p.next == null)
                return false;
            p.next = p.next.next;
            return true;
        }

        // Print method
        public void Print()
        {
            Console.Write("List: ");
            for (Node<Type> node = next; node != null; node = node.next)
                Console.Write(node.value.ToString() + " ");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            // Empty list
            if (!linkedList.Contain(0))
            {
                Console.WriteLine("0 is not exist.");
            }

            linkedList.Print();

            linkedList.Add(0); // Add to empty list
            linkedList.Add(1);
            linkedList.Add(2); // attach to tail
            linkedList.Add(2); // duplicate add, 2 is tail.

            // Find existed element which is head
            if (linkedList.Contain(0))
            {
                Console.WriteLine("0 exists");
            }

            linkedList.Print();
            linkedList.Delete(0);   // Delete head
            linkedList.Delete(2);   // Delete tail

            // Delete non-exist element
            if (!linkedList.Delete(0))
            {
                Console.WriteLine("0 does not exist.");
            }
            linkedList.Print();
            Console.ReadLine();
        }
    }
}