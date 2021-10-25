using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //GameObject ball;

    public CharacterController characterController;

    private float speed = 12f;



    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        //ball = Resources.Load("ball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    Instantiate(ball, transform.position + new Vector3(0,0,2) , transform.rotation);
        //    Ball ba = ball.GetComponent<Ball>();
        //    //ba.IAmHere();
        //}
    }
}
