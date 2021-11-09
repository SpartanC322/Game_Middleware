using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject ball;
    private CharacterController characterController;
    private Camera cam;
    private float speed = 12;
    private float bulletSpeed = 300;
    private Vector3 Acceleration;
    private enum fire_state
    { 
        small,
        big,
        triple,
        quint
    }
    private fire_state state;
    private float mass, radius;
    private int ballNum;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = FindObjectOfType<Camera>();
        ball = Resources.Load("ball") as GameObject;
        state = fire_state.small;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Acceleration = transform.forward.normalized * bulletSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //transform.position += new Vector3(0,-1,0) * Time.deltaTime;

        switch (state)
        {
            case fire_state.small:
                mass = 1;
                ballNum = 1;
                break;
            case fire_state.big:
                mass = 5;
                ballNum = 1;
                break;
            case fire_state.triple:
                mass = 1;
                ballNum = 3;
                break;
            case fire_state.quint:
                mass = 1;
                ballNum = 5;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            state = fire_state.small;
            print("Fire state set to small");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            state = fire_state.big;
            print("Fire state set to big");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            state = fire_state.triple;
            print("Fire state set to triple");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            state = fire_state.quint;
            print("Fire state set to quint\nWARNING: BREAKS EVERYTHING");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletSpeed = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bulletSpeed = 300;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //var bl = Instantiate(ball, cam.transform.position + (cam.transform.forward * 2), cam.transform.rotation);

            //var ba = bl.GetComponent<Ball>();

            //ba.setAcceleration(transform.forward.normalized * bulletSpeed);

            //Destroy(bl.gameObject, 2);

            for (int i = 0; i < ballNum; i++)
            {
                print(state.ToString());
                var bl = Instantiate(ball, cam.transform.position + (cam.transform.forward * 2) + (transform.right + new Vector3(i,i,i)), cam.transform.rotation);
                var ba = bl.GetComponent<Ball>();
                mass *= (i + 1);
                ba.setMass(mass);
                radius = mass / 2;
                ba.setRadius(radius);
                ba.transform.localScale = new Vector3(mass,mass,mass);
                ba.setAcceleration(Acceleration/mass);
                Destroy(bl.gameObject, 2);
            }
        }
    }
}