using System;
using UnityEngine;

public class LinkedList {
    /*
     * Constructor:
     * [x]LinkedList() - Initializes the private fields
     * 
     * Private Fields: 
     * [x] Node head - Is a reference to the first node in the list
     * [x] int size - The current size of the list
     * 
     * Public Properties:
     * [x] Empty - If the list is empty 
     * [x] Count - How many items are in the list
     * [x] Indexer - Access data like an array
     * 
     * Methods:
     * [x] Add(int index, object o) - Add an item to the list at specified index
     * [x] Add(object o) - Add an item to the end of the list
     * [x] Remove(int index) - Remove the item in the list at specified index
     * [x] Clear() - Clear the list
     * [x] IndexOf(object o) - Gets the index of the item in the list, if not in list returns -1
     * [x] Contains(object o) - If the list contains an object
     * [x] Get(int index) - Gets item at specified index

     */

    public Node head;
    private int count;
    private Node end;

    public LinkedList() {
        this.head = null;
        this.count = 0;
    }

    public bool Empty {
        get { return this.count == 0; }
    }

    public int Count {
        get { return this.count; }
    }

    public object this[int index] {
        get { return this.Get(index); }
    }

    public GameObject Add(int index, GameObject o) {
        if (index < 0) {
            throw new ArgumentOutOfRangeException("Index: " + index);
        }
        if (index > count) {
            index = count;
        }

        Node current = this.head;

        if (this.Empty || index == 0) {
            this.head = new Node(o, this.head);
        }
        else {
            for (int i = 0; i < index - 1; i++) {
                current = current.Next;
            }

            current.Next = new Node(o, current.Next);
        }
        count++;

        return o;
    }

    public GameObject Last() {
        Node current = head;

        while(current.Next != null) {
            current = current.Next;
        }

        return current.SnakeNode;
    }

    public GameObject Add(GameObject o) {
        return this.Add(count, o);
    }

    public object Remove(int index) {
        if (index < 0) {
            throw new ArgumentOutOfRangeException("Index: " + index);
        }
        if (this.Empty) {
            return null;
        }
        if (index >= this.count) {
            index = count - 1;
        }

        Node current = this.head;
        object result = null;

        if (index == 0) {
            result = current.SnakeNode;
            this.head = current.Next;
        }
        else {
            for (int i = 0; i < index - 1; i++) {
                current = current.Next;
            }
            result = current.Next.SnakeNode;

            current.Next = current.Next.Next;
        }

        count--;

        return result;
    }

    public void Clear() {
        this.head = null;
        this.count = 0;
    }

    public int IndexOf(object o) {
        Node current = this.head;

        for (int i = 0; i < this.count; i++) {
            if (current.SnakeNode.Equals(o)) {
                return i;
            }
            current = current.Next;
        }

        return -1;
    }

    public bool Contains(object o) {
        return this.IndexOf(o) > -1;
    }

    public GameObject Get(int index) {
        if (index < 0) {
            throw new ArgumentOutOfRangeException("Index: " + index);
        }
        if (this.Empty) {
            return null;
        }
        if (index >= this.count) {
            index = this.count - 1;
        }

        Node current = this.head;

        for (int i = 0; i < index; i++) {
            current = current.Next;
        }

        return current.SnakeNode;
    }
}