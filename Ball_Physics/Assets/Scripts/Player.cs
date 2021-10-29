using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject ball;
    private CharacterController characterController;
    private Camera cam;
    private float speed = 12f;
    private float bulletSpeed = 300f;

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
            var bl = Instantiate(ball, cam.transform.position + (cam.transform.forward * 2), cam.transform.rotation);

            var ba = bl.GetComponent<Ball>();

            ba.setAcceleration(transform.forward.normalized * bulletSpeed);

            Destroy(bl.gameObject, 2);
        }
    }
}
