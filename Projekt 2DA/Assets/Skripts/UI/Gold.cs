using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int gold;
    public Text goldText;

    void Start()
    {
        gold = PlayerPrefs.GetInt("gold", 0);
        goldText.text = PlayerPrefs.GetInt("gold", 0).ToString();
    }

    public void SumGold(int FGold)
    {
        gold += FGold;

        goldText.text = gold.ToString();
    }
    
    public void SaveGold()
    {
        PlayerPrefs.SetInt("gold", gold);
    }
}
