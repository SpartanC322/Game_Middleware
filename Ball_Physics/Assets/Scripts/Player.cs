using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject ball;

    private float moveSpeed = 2.0f;
    //float mouseSpeed = 100.0f; //how fast the object should rotate
    public GameObject character;

    CharacterController characterController;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ball = Resources.Load("ball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.left * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += Vector3.forward * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= Vector3.forward * speed * Time.deltaTime;
        //}

        //Mouse begin

        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * mouseSpeed);

        //var horizontal = Input.GetAxis("Horizontal");
        //var vertical = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime));

        //Mouse end

        if (characterController.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= moveSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Instantiate(ball, transform.position + new Vector3(0,0,2) , transform.rotation);
            Ball ba = ball.GetComponent<Ball>();
            //ba.IAmHere();
        }
    }
}
