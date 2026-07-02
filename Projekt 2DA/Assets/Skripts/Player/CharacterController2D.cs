using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class CharacterController2D : MonoBehaviour 
{
    public float move_speed = 60f;
    private Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    public Animator animator;



    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;


        Vector3 aimlocalScale = Vector3.one;

        float moveX = 0f;
        float moveY = 0f;
        bool right = false;
        bool left = false;
        bool back = false;
        bool front = false;


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
            if (angle >= -45 && angle <= 45)
            {
                right = true;
            }
            else if (angle >= 45 && angle <= 135)
            {
                front = true;
            }
            else if (angle <= -45 && angle >= -135)
            {
                back = true;
            }
            else
            {
                left = true;
            }
        }



        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
            if (angle >= -45 && angle <= 45)
            {
                right = true;
            }
            else if (angle >= 45 && angle <= 135)
            {
                front = true;
            }
            else if (angle <= -45 && angle >= -135)
            {
                back = true;
            }
            else
            {
                left = true;
            }
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            if (angle >= -45 && angle <= 45)
            {
                right = true;
            }
            else if (angle >= 45 && angle <= 135)
            {
                front = true;
            }
            else if (angle <= -45 && angle >= -135)
            {
                back = true;
            }
            else
            {
                left = true;
            }
        }



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
            if (angle >= -45 && angle <= 45)
            {
                right = true;
            }
            else if (angle >= 45 && angle <= 135)
            {
                front = true;
            }
            else if (angle <= -45 && angle >= -135)
            {
                back = true;
            }
            else
            {
                left = true;
            }
        }

        animator.SetBool("Back", back);
        animator.SetBool("Right", right);
        animator.SetBool("Left", left);
        animator.SetBool("Front", front);

        moveDir = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * move_speed;
    }
}
