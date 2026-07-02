using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void SumScore(int FScore)
    {
        score += FScore;

        scoreText.text = score.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
