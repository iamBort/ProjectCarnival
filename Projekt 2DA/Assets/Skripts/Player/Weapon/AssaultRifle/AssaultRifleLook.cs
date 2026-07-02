using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleLook : MonoBehaviour
{
    private Transform aimTransform;
    GameObject aim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private int i = 5;



    public float scale = 1f;


    public void Awake()
    {
        aim = GameObject.Find("AssaultRifle");
        aimTransform = aim.GetComponent<Transform>();

    }

    private void Update()
    {
        GunHandling();
    }

    private void FixedUpdate()
    {
        Shoot();
    }

    private void GunHandling()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimlocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimlocalScale.y = -1f * scale;
            aimlocalScale.x = 1f * scale;
        }
        else
        {
            aimlocalScale.y = +1f * scale;
            aimlocalScale.x = 1f * scale;

        }

        aimTransform.localScale = aimlocalScale;
    }

    private void Shoot()
    {

        if (Input.GetMouseButton(0))
        {
            if (i==5) 
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                UtilsClass.ShakeCamera(.03f, .2f);
                i -= 5;
            }
            else
            {
                i++;
            }
        }
    }
}
