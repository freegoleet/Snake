using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderRight;
    public Transform borderLeft;

    public static bool spawnFood = true;

    [SerializeField]
    public static float spawnRepeatRate = 10f;

    private IEnumerator Countdown2() {
        while (spawnFood == true) {
            yield return new WaitForSeconds(2); // Wait 2 seconds
            Spawn();
        }
    }

    private void Start() {
        StartCoroutine(Countdown2());
    }

    void Spawn() {
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);

        int y = (int)Random.Range(borderBottom.position.y + 1, borderTop.position.y - 1);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
