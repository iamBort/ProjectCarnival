using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Damage = 25;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Trigger") 
        {
            if (hitInfo.tag != "Player")
            {
                Enemy enemy = hitInfo.GetComponent<Enemy>();

                if (enemy)
                {
                    enemy.TakeDamage(Damage);
                }

                Destroy(gameObject);
            }
        }
    }
}
