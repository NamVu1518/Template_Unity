using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SinglyLinkedList<T>
{
    public Node<T> head;

    public SinglyLinkedList()
    {
        head = null;
    }

    public Node<T> Head
    {
        get { return head; }
    }

    public int Count()
    {
        int count = 0;
        Node<T> node = head;

        while(node != null)
        {
            count++;
            node = node.next;
        }

        return count;
    }

    public void AddHead(T data)
    {
        if (head == null)
        {
            head = new Node<T>(data);
        }
        else
        {
            Node<T> node = new Node<T>(data);
            node.next = head;
            head = node;
        }
    }

    public void AddTail(T data)
    {
        if (head == null)
        {
            head = new Node<T>(data);
        }
        else
        {
            Node<T> node = head;    

            while(node.next != null)
            {
                node = node.next;
            }
            node.next = new Node<T>(data);
        }
    }

    public void AddAt(T data, int index)
    {
        if (head == null)
        {
            AddHead(data);
        }
        else if(index > Count() - 1) {
            AddTail(data);
        }
        else
        {
            Node<T> node = head;
            int count = 0;

            while (node.next != null && count != index - 1)
            {
                count++;
                node = node.next;
            }

            Node<T> newNode = new Node<T>(data);
            newNode.next = node.next;
            node.next = newNode;
        }
    }

    public T GetAt(int index)
    {
        if (index > Count() - 1 || index < 0)
        {
            throw new IndexOutOfRangeException("Index was out of range");
        }

        Node<T> node = head;
        int count = 0;

        while (node != null && count != index)
        {
            count++;
            node = node.next;
        }

        return node.data;
    }

    public Node<T> GetNodeAt(int index)
    {
        if (index > Count() - 1 || index < 0)
        {
            throw new IndexOutOfRangeException("Index was out of range");
        }

        Node<T> node = head;
        int count = 0;

        while (node != null && count != index)
        {
            count++;
            node = node.next;
        }

        return node;
    }

    public void RemoveAll()
    {
        head = null;
    }

    public void RemoveTail()
    {
        Node<T> node = GetNodeAt(Count() - 2);
        node.next = null;
    } 

    public void RemoveHead()
    {
        head = head.next;
    }

    public T RemoveGet(int index)
    {
        if (index > Count() - 1 || index < 0)
        {
            throw new IndexOutOfRangeException("Index was out of range");
        }
        
        T data = GetNodeAt(index).data;
        RemoveAt(index);

        return data;
    }

    public void RemoveAt(int index)
    {
        if (index > Count() - 1 || index < 0)
        {
            throw new IndexOutOfRangeException("Index was out of range");
        }

        if (index == 0)
        {
            RemoveHead();
            return;
        }
        else if (index == Count() - 1)
        {
            RemoveTail();
        }
        else
        {
            Node<T> pre = null;
            Node<T> cur = head;
            Node<T> next = null;

            int count = 0;

            while (count < index)
            {
                count++;
                pre = cur;
                cur = cur.next;
            }

            next = cur.next;
            pre.next = next;
        }
    }

    public void RemoveNode(Node<T> node)
    {
        Node<T> newNode = head;

        if (newNode == node)
        {
            RemoveHead();
            return;
        }

        Node<T> preNode = null;

        while (newNode.next != null && node != newNode)
        {
            preNode = newNode;
            newNode = newNode.next;
        }

        preNode.next = newNode.next;
    }

    public void RemoveNode(T data)
    {
        Node<T> newNode = head;

        if (ReferenceEquals(data, newNode.data))
        {
            RemoveHead();
            return;
        }

        Node<T> preNode = null;

        while (newNode.next != null && !ReferenceEquals(data, newNode.data))
        {
            preNode = newNode;
            newNode = newNode.next;
        }

        preNode.next = newNode.next;
    }

    public void Reverse()
    {
        Node<T> pre = null;
        Node<T> cur = null;
        
        while (head != null)
        {
            cur = head;
            head = head.next;
            cur.next = pre;
            pre = cur;
        }

        head = cur;
    }

    public T[] ToArray()
    {
        T[] arr = new T[Count()];
        Node<T> cur = head;

        for (int i = 0; i < Count(); i++)
        {
            arr[i] = cur.data;
            cur = cur.next;
        }

        return arr;
    }

    public List<T> Tolist()
    {
        List<T> list = new List<T>();
        Node<T> cur = head;

        for (int i = 0; i < Count(); i++)
        {
            list.Add(cur.data);
            cur = cur.next;
        }

        return list;
    }
}

public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T value) 
    { 
        data = value;
        next = null;
    }
}
