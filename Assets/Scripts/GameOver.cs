using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Snake Alive;
    public float restartDelay;
    public static bool ableToRestartGame = false;

    Animator anim;
    float restartTimer;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
   
    void Update() {
        if(Snake.Alive == false) {
            anim.SetTrigger("GameOver");

            foreach(GameObject FoodPrefab in SpawnFood.foodList) {
                Destroy(FoodPrefab);
            }

            restartTimer += Time.deltaTime;
            ableToRestartGame = true;

            if(ableToRestartGame == true) {
                if (Input.anyKey) {
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}
