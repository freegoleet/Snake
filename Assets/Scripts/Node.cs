using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node {
    /* Constructor:
        * [x] Node(object data, Node next)
        * 
        * Private Fields:
        * object data - contain the data of the node, what we wanna store in the list
        * Node next - reference to the next node in the list
        * 
        * Public Properties:
        * [x] Data - get/set the data field
        * [x] Next - get/set the next field
         
        */

    private GameObject snakeNode;
    private Node next;

    public Node(GameObject snakeNode, Node next) {
        this.snakeNode = snakeNode;
        this.next = next;
    }

    public GameObject SnakeNode {
        get { return this.snakeNode; }
        set { this.snakeNode = value; }
    }

    public Node Next {
        get { return this.next; }
        set { this.next = value; }
    }
}
