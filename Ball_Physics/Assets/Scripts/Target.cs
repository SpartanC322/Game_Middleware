using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Plane
{
    private int points = 1;
    private Vector3 rotationDirection;
    private float durationTime;
    //private float angle;

    //internal Vector3 point
    //{
    //    get { return transform.position; }
    //    set { transform.position = value; }
    //}

    //public Vector3 normal
    //{
    //    get { return transform.up; }
    //    set { transform.up = value; }
    //}

    public int getPoints()
    {
        return points;
    }

    void Start()
    {
        rotationDirection = new Vector3(1, 0, 0);
        durationTime = 1000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public float distanceTo(Vector3 v)
    //{
    //    Vector3 vtop = point - v;

    //    return Gp.parallel(vtop, normal).magnitude;
    //}

    //When target is hit
    public void hitTarget()
    {
        //angle = Time.deltaTime * durationTime;
        //transform.Rotate(rotationDirection * smooth);

        //transform.rotation *= Quaternion.AngleAxis(-angle, Vector3.left);

        transform.rotation = new Quaternion(180, 0, 0, 0);

        //transform.Rotate(Time.deltaTime * 300, 0, 0);
    }

    //Reduces points for hitting target after the first time
    public void emptyPoints()
    {
        points = 0;
    }
}