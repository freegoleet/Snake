using UnityEngine.UI;
using UnityEngine;

public class scoreText : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = Snake.Score.ToString();
    }
}
