using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal GameObject ball;
    internal CharacterController characterController;
    internal Camera cam;
    internal float speed = 12f;
    internal float bulletSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
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
            ball = Instantiate(ball, cam.transform.position + (cam.transform.forward * 2), cam.transform.rotation);

            var ba = ball.GetComponent<Ball>();
            ba.SetSpeed(bulletSpeed);
            ba.changeGravity(100);

            ba.setAcceleration(transform.forward.normalized * bulletSpeed);
        }
    }
}
