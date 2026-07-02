using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Gold GSave;
    public Score SSave;
    public Player playerHealth;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GSave.SaveGold();
            SSave.SaveScore();
            playerHealth.SaveHealth();

            SceneManager.LoadScene(4);
        }
    }
}
