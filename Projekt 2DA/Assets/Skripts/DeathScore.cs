using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScore : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highScore;
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        highScore = PlayerPrefs.GetInt("highScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "HighScore: " + score.ToString();
        }
        else
        {
            highScoreText.text = "HighScore: " + highScore.ToString();
        }

        scoreText.text = "Score: " + score.ToString();
    }
}
