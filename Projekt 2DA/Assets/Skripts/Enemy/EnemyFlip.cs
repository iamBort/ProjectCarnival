using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFlip : MonoBehaviour
{
    public AIPath aiSPath;
    public SpriteRenderer render;

    // Update is called once per frame
    public void Update()
    {

        render.flipX = false;

        if (aiSPath.desiredVelocity.x >= 0.01f)
        {
            render.flipX = false;

        }
        else if (aiSPath.desiredVelocity.x <= -0.01f) 
        {
            render.flipX = true;
        
        }

       
    }
}
