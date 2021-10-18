using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour
{
    Animator newAnimation;
    float velocity = 0;
    public float acceleration = 0.1f, deceleration = 0.1f;

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

        if (forwardPress && velocity < 1)
        {
            newAnimation.SetBool("Walk", true);
            
        }
        
        if (!forwardPress)
        {
            newAnimation.SetBool("Walk", false);
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
        
        if(velocity > 0.1f)
        {
            velocity = 0.1f;
        }

        newAnimation.SetFloat("Velocity", velocity);
    }
}
