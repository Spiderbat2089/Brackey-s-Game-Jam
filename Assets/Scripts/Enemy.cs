using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Physics
{

    [SerializeField]float maxSpeed;
    int direction = 1;


    RaycastHit2D rightWallCast;
    RaycastHit2D leftWallCast;
    RaycastHit2D rightEdgeCast;
    RaycastHit2D leftEdgeCast;
    [SerializeField]int castLength;
    [SerializeField] LayerMask CastLayerMask;
    [SerializeField] Vector2 castOffset;



    // Update is called once per frame
    void Update()
    {

        targetVelocity = new Vector2(maxSpeed * direction, 0);


        //check for right wall
        rightWallCast = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, castLength, CastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * castLength, Color.red);
        if(rightWallCast.collider != null)
        {
            direction = -1;
        }
        //check for left wall
        leftWallCast = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, castLength, CastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * castLength, Color.red);
        if (leftWallCast.collider != null)
        {
            direction = 1;
        }

        //checks for right edge
        rightEdgeCast = Physics2D.Raycast(new Vector2(transform.position.x + castOffset.x, transform.position.y + castOffset.y), Vector2.down, castLength);
        Debug.DrawRay(new Vector2(transform.position.x + castOffset.x, transform.position.y + castOffset.y), Vector2.down * castLength, Color.red);
        if (rightEdgeCast.collider == null)
        {
            direction = -1;
        }



        //Checks for left edge
        leftEdgeCast = Physics2D.Raycast(new Vector2(transform.position.x - castOffset.x, transform.position.y + castOffset.y), Vector2.down, castLength);
        Debug.DrawRay(new Vector2(transform.position.x - castOffset.x, transform.position.y + castOffset.y), Vector2.down * castLength, Color.blue);
        if (leftEdgeCast.collider == null)
        {
            direction = 1;
        }
    }
}   
