using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;
    public Rigidbody2D rb;
    public int Damage = 25;
    private GameObject go;
    private Gold gold;
    private Score score;

    public void Start()
    {
        go = GameObject.Find("GameHandler");
        gold = (Gold)go.GetComponent(typeof(Gold));
        score = (Score)go.GetComponent(typeof(Score));
    }

    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        Health -= damage;
        
        if(Health <= 0)
        {
            Debug.Log("Downer zabit");
            Destroy(gameObject);

            gold.SumGold(9);
            score.SumScore(50);
        }
    }
}
