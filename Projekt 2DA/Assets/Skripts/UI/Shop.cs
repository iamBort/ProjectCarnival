using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public WaveSpawnerLvl2 spawner;
    public GameObject shopWindow;
    private bool inside = false;

    void Start()
    {
        shopWindow.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !spawner.spawnWave)
        {
            shopWindow.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopWindow.gameObject.SetActive(false);
        }
    }
}
