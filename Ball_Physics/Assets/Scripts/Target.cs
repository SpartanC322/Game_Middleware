using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Plane
{
    public Vector3 rotationDirection;
    public float durationTime;
    private float smooth;

    public void Start()
    {
        rotationDirection = new Vector3(1,0,0);
        durationTime = 150;
    }
    public void hitTarget()
    {
        //smooth = Time.deltaTime * durationTime;
        //transform.Rotate(rotationDirection * smooth);
        
        GetComponent<Target>().enabled = false;

        transform.rotation = new Quaternion(180, 0, 0, 0);
    }
}