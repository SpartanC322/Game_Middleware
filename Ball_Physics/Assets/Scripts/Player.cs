using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject ball;

    CharacterController characterController;

    private float speed = 12f;
    private float bulletSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ball = Resources.Load("ball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);



        //transform.position += new Vector3(0,-1,0) * Time.deltaTime;



        if (Input.GetButtonDown("Fire1"))
        {
            ball = Instantiate(ball, transform.position + (transform.forward * 2) + new Vector3(0,2,0), transform.rotation);

            var ba = ball.GetComponent<Ball>();
            ba.SetDirection(transform.forward.normalized);
            ba.SetSpeed(bulletSpeed);
            ba.changeGravity(100);

            ba.IncreaseAcceleration(transform.forward.normalized * bulletSpeed);
            
            //ba.IAmHere();
        }
    }
}
