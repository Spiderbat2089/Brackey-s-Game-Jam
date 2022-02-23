using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : Physics
{
    [SerializeField]float maxSpeed;
    [SerializeField]int jumpPower;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        //If the player presses "Jump" and we're grounded, set the velocity to a jump power value
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }

        //flip the player 
        if (targetVelocity.x < -0.1)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (targetVelocity.x > .01)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
