using System.Collections;
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

    private IEnumerator FoodTimer() {
        while (spawnFood == true) { // Todo: The timer/wait that started before Death should not finish.
            yield return new WaitForSeconds(2);
            Spawn();
        }
    }

    private void Start() {
        StartCoroutine(FoodTimer());
    }

    void Spawn() { // Todo: Food should not be able to spawn inside the snake.
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);

        int y = (int)Random.Range(borderBottom.position.y + 1, borderTop.position.y - 1);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
