using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = Resources.Load("ball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Instantiate(ball, transform.position + new Vector3(0,0,2) , transform.rotation);
            Ball ba = ball.GetComponent<Ball>();
            //ba.IAmHere();
        }
    }
}
