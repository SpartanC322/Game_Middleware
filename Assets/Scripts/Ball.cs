using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    internal Vector3 velocity, acceleration;

    internal float radius, CoR, mass;

    Plane pl;

    public Ball bl;
    
    // Start is called before the first frame update
    void Start()
    {

        mass = 1;

        radius = 0.5f;

        CoR = 0.6f;//Coeficient of Restitution

        pl = FindObjectOfType<Plane>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Vector3.Distance(transform.position, bl.transform.position));
        acceleration = 9.8f * new Vector3(0, -1, 10);

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }
    
    internal bool CollidesWith(Ball bl)
    {
        return Vector3.Distance(transform.position, bl.transform.position) <= radius + bl.radius;
    }

    internal bool CollidesWith(Plane p)
    {
        return p.distanceTo(transform.position) < radius;
    }

    //public void IAmHere()
    //{
    //    Debug.Log("Hi");
    //}
}
