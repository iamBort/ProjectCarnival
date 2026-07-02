using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    //public Gold gold;

    public HealthBar healthBar;
    public Score score;

    public void Start()
    {
        CurrentHealth = PlayerPrefs.GetInt("health", 100);
        healthBar.SetMaxHealth(MaxHealth, CurrentHealth);
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            PlayerTakeDamage(25);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);

        Debug.Log("Hráč byl zasažen");

        if (CurrentHealth <= 0)
        {
            Debug.Log("Hra skončila, zemřel jsi");
            score.SaveScore();
            Destroy(gameObject);
            SceneManager.LoadScene("DeathScene");
        }
    }

    public void SaveHealth()
    {
        PlayerPrefs.SetInt("health", CurrentHealth);
    }

    public void SetHealth(int health)
    {
        CurrentHealth = health;
        healthBar.SetMaxHealth(MaxHealth, CurrentHealth);
    }
}
