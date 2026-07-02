using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ClickPokracovat()
    {
        
    }

    public void ClickNovaHra()
    {
        SceneManager.LoadScene("Hra");
    }

    public void ClickNapoveda()
    {
        SceneManager.LoadScene("Napoveda");
    }

    public void ClickKonec()
    {
        Application.Quit();
    }
}
