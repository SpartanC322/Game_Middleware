using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Plane
{
    private int points = 1;
    private Vector3 rotationDirection;
    private float durationTime;
    private float angle;

    public int getPoints()
    {
        return points;
    }

    void Start()
    {
        durationTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //When target is hit
    public void hitTarget()
    {
        angle = durationTime;
        angle = Mathf.Clamp(angle,90,90) * Time.deltaTime;
        transform.Rotate(new Vector3(1,0,0) * angle);

        //transform.rotation *= Quaternion.AngleAxis(-angle, Vector3.left);

        //transform.rotation = new Quaternion(-180,0,0,0);

        //transform.Rotate(Time.deltaTime * 300, 0, 0);
    }

    //Reduces points for hitting target after the first time to prevent multiple hits
    public void emptyPoints()
    {
        points = 0;
    }
}