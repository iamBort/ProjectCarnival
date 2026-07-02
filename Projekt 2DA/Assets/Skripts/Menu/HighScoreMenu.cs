using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text text;

    void Start()
    {
        int score = PlayerPrefs.GetInt("highScore",  0);
        text.text = score.ToString();
    }

}
