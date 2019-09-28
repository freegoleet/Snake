using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Snake : MonoBehaviour {
    LinkedList tailList = new LinkedList();
    

    bool ate = false;
    Vector2 dir = Vector2.right;
    public GameObject tailPrefab;
    public static int Score;

    Vector2 currentHeadPosition;
    Vector2 tailLastPosition;

    [SerializeField]
    public float snakeUpdateSpeed = 0.1f;

    void Start() {
        tailList.Add(GameObject.Find("Head"));
    }

    void Update() {
        if (Time.time > snakeUpdateSpeed) {
            snakeUpdateSpeed = Time.time + 0.1f;
            Move();
        }

        if (Input.GetKey(KeyCode.RightArrow) && (dir != -Vector2.right)) dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow) && (dir != Vector2.right)) dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow) && (dir != -Vector2.up)) dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow) && (dir != Vector2.up)) dir = -Vector2.up;
    }

    void Move() {
        currentHeadPosition = transform.position;
        transform.Translate(dir);


        if (ate == true) {
            GameObject newTailNode = (GameObject)Instantiate(tailPrefab, currentHeadPosition, Quaternion.identity);

            tailList.Add(1, newTailNode);
            ate = false;
            
        }

        if (tailList.Count > 1) {
            

            tailList.Last().transform.position = currentHeadPosition;

            tailList.Add(1, tailList.Last());
            tailList.Remove(tailList.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Food") {
            ate = true;

            Destroy(collision.gameObject);
            Debug.Log("food embraces you");
            Score += 1;
        }

        if (collision.gameObject.tag == "Wall") {
            snakeUpdateSpeed = 1000.0f; // Setting it to 0 seems to have no effect.
            Debug.Log("death embraces you");

            SpawnFood.spawnFood = false;
        }
    }
}