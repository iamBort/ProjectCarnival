using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Text interactText;
    private bool inside = false;
    public WaveSpawnerLvl2 spawner;

    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if(inside && Input.GetKeyDown(KeyCode.E) && !spawner.spawnWave)
        {
            spawner.spawnWave = true;
            Debug.Log("interact");
            interactText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !spawner.spawnWave)
        {
            interactText.gameObject.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactText.gameObject.SetActive(false);
            inside = false;
        }
    }
}
