using UnityEngine.UI;
using UnityEngine;

public class scoreText : MonoBehaviour
{
    public Text score;

    // Update is called once per frame
    void Update()
    {
        score.text = Snake.Score.ToString();
    }
}
