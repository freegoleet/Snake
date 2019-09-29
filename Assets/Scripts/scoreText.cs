using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = Snake.Score.ToString();
    }
}
