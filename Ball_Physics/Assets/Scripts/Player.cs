using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject ball;

    public float moveSpeed = 20.0f;
    public float turnSpeed = 100.0f;
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ball = Resources.Load("ball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += transform.forward * Time.deltaTime * moveSpeed;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= transform.right * Time.deltaTime * moveSpeed;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += transform.right * Time.deltaTime * moveSpeed;
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(0, Time.deltaTime * turnSpeed, 0);
        //}
        //else if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(0, Time.deltaTime * -turnSpeed, 0);
        //}

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Instantiate(ball, transform.position + new Vector3(0,0,2) , transform.rotation);
            Ball ba = ball.GetComponent<Ball>();
            //ba.IAmHere();
        }
    }
}
