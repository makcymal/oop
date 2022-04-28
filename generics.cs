﻿namespace Generics
{
    public interface IList<T>
    {
        public void Insert(T value, int pos = 0);
        public void Remove(T value);
        public bool Find(T value);
        public T? Get(int pos = 0);
        public void Print();
    }

    public class Node<T>
    {
        public T data;
        public Node<T>? next;
        public Node(T value)
        {
            data = value;
        }
    }

    public class LinkedList<T> : IList<T>
    {
        Node<T>? head;
        int len = 0;

        public void Insert(T value, int pos=0)
        {
            if (len == 0)
            {
                head = new Node<T>(value);
                len++;
            }

            Node<T>? reqNode = head;
            for (int i = 0; i < pos && reqNode.next != null; i++)
                reqNode = reqNode.next;

            if (reqNode.next != null)
            {
                Node<T> newNode = new Node<T>(value);
                Node<T>? nextNode = reqNode.next;
                reqNode.next = newNode;
                newNode.next = nextNode;
                len++;
            }
        }

        public void Remove(T value)
        {
            if (len == 0)
                return;

            Node<T>? reqNode = head;
            for (int i = 0; i < len - 1 && !reqNode.next.data.Equals(value); i++)
                reqNode = reqNode.next;

            reqNode.next.next = reqNode.next;
            len--;
        }

        public bool Find(T value)
        {
            if (len == 0)
                return false;

            Node<T>? currNode = head;
            for (int i = 0; i < len; ++i)
                if (currNode.data.Equals(value))
                    return true;

            return false;
        }

        public T? Get(int pos=0)
        {
            if (pos >= len)
                return default;

            Node<T>? reqNode = head;
            for (int i = 0; i < pos && reqNode != null; i++)
                reqNode = reqNode.next;

            return reqNode.data;
        }

        public void Print()
        {
            Node<T>? reqNode = head;
            for (int i = 0; i < len; ++i)
            {
                Console.Write(reqNode.data);
                reqNode = reqNode.next;
            }
        }
    }


    public class ArrayList<T> : IList<T>
    {
        T[] array;
        int len, capacity;

        public ArrayList()
        {
            array = new object[100] as T[];
            len = 0;
            capacity = 100;
        }

        public void Insert(T value, int pos = 0)
        {
            if (len >= capacity * 0.7)
            {
                capacity = capacity * 2;
                Array.Resize(ref array, capacity);
            }

            for (int i = len; i > pos; --i)
                array[i] = array[i - 1];

            array[pos] = value;
            len++;
        }


        public void Remove(T value)
        {
            int i = 0;
            for (; i < len; ++i)
                if (array[i].Equals(value))
                    break;

            for (; i < len; ++i)
                array[i] = array[i + 1];
            len--;
        }

        public bool Find(T value)
        {
            for (int i = 0; i < len; ++i)
                if (array[i].Equals(value))
                    return true;
            return false;
        }

        public T? Get(int pos = 0)
        {
            return array[pos];
        }

        public void Print()
        {
            for (int i = 0; i < len; ++i)
                Console.Write(array[i]);
        }
    }
}
