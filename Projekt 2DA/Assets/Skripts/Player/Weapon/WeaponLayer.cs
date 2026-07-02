using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLayer : MonoBehaviour
{

    public SpriteRenderer renderer;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        if (angle >= 1 && angle <= 180)
        {
            renderer.sortingOrder = 9;
        }
        else
        {
            renderer.sortingOrder = 11;
        }
        
    }
}
