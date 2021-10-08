using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Vector3 point 
    { 
        get { return transform.position; }
        set { transform.position = value; } 
    }

    public Vector3 normal
    {
        get { return transform.up; }
        set { transform.up = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        point = new Vector3(1, 1, 1);
        normal = (new Vector3(0, 3, 1)).normalized;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float distanceTo(Vector3 v)
    {
        Vector3 vtop = point - v;

        return Gp.parallel(vtop, normal).magnitude;
    }
}
