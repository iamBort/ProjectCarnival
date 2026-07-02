using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Gold gold;
    public WeaponSwitching weapons;
    public Player health;
    public Button ShotgunButton;
    public Button AssultRifleButton;

    public void ShotGunBuy()
    {
        if (gold.gold >= 500)
        {
            weapons.Shotgun = true;
            ShotgunButton.gameObject.SetActive(false);
            gold.SumGold(-500);
            Debug.Log("1");
        }
    }


    public void AssaultRifleBuy()
    {
        if (gold.gold >= 1000) 
        {
            weapons.AssaultRifle = true;
            AssultRifleButton.gameObject.SetActive(false);
            gold.SumGold(-1000);
            Debug.Log("2");
        }
    }

    public void HealBuy()
    {
        if (health.CurrentHealth != 100)
        {
            if (gold.gold >= 100)
            {
                health.SetHealth(100);
                gold.SumGold(-100);
                Debug.Log("heal");
            }
        }
        else
        {
            Debug.Log("100 6ivot; u6 je");
        }
    }

}
