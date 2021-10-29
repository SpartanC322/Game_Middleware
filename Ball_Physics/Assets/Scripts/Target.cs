using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Plane
{
    private int points = 1;
    private Vector3 rotationDirection;
    private float durationTime;
    //private float angle;

    public int getPoints()
    {
        return points;
    }

    void Start()
    {
        rotationDirection -= transform.forward;
        durationTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //When target is hit
    public void hitTarget()
    {
        //angle = Time.deltaTime * durationTime;
        //transform.Rotate(rotationDirection * smooth);

        //transform.rotation *= Quaternion.AngleAxis(-angle, Vector3.left);

        //transform.rotation = new Quaternion(-180,0,0,0);

        transform.localEulerAngles = rotationDirection * 180;

        //transform.Rotate(Time.deltaTime * 300, 0, 0);
    }

    //Reduces points for hitting target after the first time to prevent multiple hits
    public void emptyPoints()
    {
        points = 0;
    }
}