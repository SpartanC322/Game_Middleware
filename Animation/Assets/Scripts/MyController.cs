using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour
{
    Animator newAnimation;
    float velocity = 0;
    public float acceleration = 0.1f, deceleration = 0.1f, turn = 0;
    public Transform lookAtThis;

    public bool ikActive = false;

    GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        newAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool runPress = Input.GetKey(KeyCode.LeftShift);
        bool stop = Input.GetKey(KeyCode.Q);
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);
        bool drawPistol = Input.GetKeyDown(KeyCode.R);
        bool attack = Input.GetKeyDown(KeyCode.Mouse0);
        bool stopAttack = Input.GetKeyDown(KeyCode.Mouse1);
        bool handshake = Input.GetKeyDown(KeyCode.Space);

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

        if (drawPistol && newAnimation.GetBool("Pistol_Drawn") == false)
        {
            newAnimation.SetBool("Pistol_Drawn", true);

            GameObject gun = Instantiate(Resources.Load("Pistol")) as GameObject;

            gun.transform.localScale = new Vector3(10,10,10);
            
            gun.transform.Rotate(360,-300,0,Space.Self);

            GameObject hand = GameObject.Find("Base HumanLArmPalm");

            //Instantiate(gun,hand.transform.position,hand.transform.rotation);

            gun.transform.SetParent(hand.transform, false);
            gun.transform.position += new Vector3(0,-0.1f,-0.04f);
        }

        //if (drawPistol && newAnimation.GetBool("Pistol_Drawn") == true)
        //{
        //    newAnimation.SetBool("Pistol_Drawn", false);
        //}

        if (attack)
        {
            newAnimation.SetBool("Attacking", true);
        }

        if (stopAttack)
        {
            newAnimation.SetBool("Attacking", false);
        }

        if (handshake)
        {
            newAnimation.SetBool("Handshake", true);
        }

        newAnimation.SetFloat("Turn", turn);
        newAnimation.SetFloat("Velocity", velocity);
        OnAnimatorIK();
    }

    private void OnAnimatorIK()
    {
        if (ikActive == true)
        {
            if (lookAtThis != null)
            {
                newAnimation.SetLookAtWeight(1);
                newAnimation.SetLookAtPosition(lookAtThis.position);
            }
        }
    }
}
