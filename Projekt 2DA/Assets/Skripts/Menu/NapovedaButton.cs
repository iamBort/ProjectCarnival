using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NapovedaButton : MonoBehaviour
{
    public void ClickZpet()
    {
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("gold", 0);
        PlayerPrefs.SetInt("score", 0);

        SceneManager.LoadScene("Menu");
    }
}
