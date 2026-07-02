using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLook : MonoBehaviour
{
    private Transform aimTransform;
    GameObject aim;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    private int i;



    public float scale = 1f;


    public void Awake()
    {
        aim = GameObject.Find("Shotgun");
        aimTransform = aim.GetComponent<Transform>();
        i = 40;
    }

    private void Update()
    {
        if (i != 40)
        {
            i++;
        }

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
            if (i == 40)
            {
                Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

                UtilsClass.ShakeCamera(0.05f, .2f);
                i = i - 40;
            }
        }
    }
}
