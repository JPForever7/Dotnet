using System;

namespace AboutList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> tail;
        private Node<T> head;

        public GenericList()
        {
            head = tail = null;
        }
        
        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> temp = head;
            while (temp.Next != null)
            {
                action(temp.Data);
                temp = temp.Next;
            }
            action(temp.Data);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> generic = new GenericList<int>();
            for(int i= 0;i<10;i++)
            {
                generic.Add(i);
            }

            Action<int> action = delegate (int item)
            {
                Console.WriteLine(item);
            };
            generic.ForEach(action);
                
        }
    }

}
