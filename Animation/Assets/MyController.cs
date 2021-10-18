using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour
{
    Animator newAnimation;
    float velocity = 0;
    public float acceleration = 0.1f, deceleration = 0.1f, turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        newAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool runPress = Input.GetKey(KeyCode.LeftShift);
        bool stop = Input.GetKey(KeyCode.Q);
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);

        if (forwardPress && velocity < 1)
        {
            newAnimation.SetBool("Walk", true);
        }
        
        if (!forwardPress)
        {
            newAnimation.SetBool("Walk", false);
        }

        if(turnLeft)
        {
            turn -= acceleration * Time.deltaTime;
        }

        if(turnRight)
        {
            turn += acceleration * Time.deltaTime;
        }

        if (runPress && forwardPress)
        {
            velocity += acceleration * Time.deltaTime;
        }

        if(!runPress)
        {
            velocity -= deceleration * Time.deltaTime;
        }

        if(velocity < 0)
        {
            velocity = 0;
        }
        
        if(velocity > 0.2f && !stop)
        {
            velocity = 0.2f;
        }

        newAnimation.SetFloat("Turn", turn);
        newAnimation.SetFloat("Velocity", velocity);
    }
}
