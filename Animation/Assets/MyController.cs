using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour
{
    Animator newAnimation;
    float velocity = 0;
    public float acceleration = 0.1f, deceleration = 0.1f, turn = 0;

    public GameObject hand;

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
        bool drawPistol = Input.GetKeyDown(KeyCode.R);

        if (forwardPress && velocity < 1)
        {
            newAnimation.SetBool("Walk", true);
        }

        if (!forwardPress)
        {
            newAnimation.SetBool("Walk", false);
        }

        if (turnLeft && forwardPress && velocity > 0)
        {
            turn -= 1 * Time.deltaTime;
        }

        if (turnRight && forwardPress && velocity > 0)
        {
            turn += 1 * Time.deltaTime;
        }

        if (!turnLeft && !turnRight)
        {
            turn = 0;
        }

        if (runPress && forwardPress)
        {
            velocity += acceleration * Time.deltaTime;
        }

        if (!runPress)
        {
            velocity -= deceleration * Time.deltaTime;
        }

        if (velocity < 0)
        {
            velocity = 0;
        }

        if (velocity > 0.2f && !stop)
        {
            velocity = 0.2f;
        }

        if (drawPistol)
        {
            newAnimation.SetBool("Pistol_Drawn", true);

            GameObject gun = Instantiate(Resources.Load("Pistol")) as GameObject;

            gun.transform.localScale = new Vector3(10,10,10);

            //GameObject hand = GameObject.Find("Base HumanRArmPalm");

            //Instantiate(gun,hand.transform.position,hand.transform.rotation);

            gun.transform.SetParent(hand.transform, false);

            //if(drawPistol && newAnimation.GetBool("Pistol_Drawn") == true)
            //{
            //    newAnimation.SetBool("Pistol_Drawn", false);
            //}
        }

        newAnimation.SetFloat("Turn", turn);
        newAnimation.SetFloat("Velocity", velocity);
    }
}
