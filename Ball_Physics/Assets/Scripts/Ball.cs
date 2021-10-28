using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    internal Vector3 velocity, acceleration, gravity;
    internal float radius, CoR, mass, gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0,-1f,0);

        gravityModifier = 1;

        mass = 1;

        radius = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.position, bl.transform.position));

        acceleration += 9.8f * ((gravity / gravityModifier));

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }

    public void setAcceleration(Vector3 accelerate)
    {
        acceleration += accelerate;
    }

    public void changeGravity(float grav)
    {
        gravityModifier = grav;
    }
    
    internal bool CollidesWith(Ball bl)
    {
        return Vector3.Distance(transform.position, bl.transform.position) <= radius + bl.radius;
    }

    internal bool CollidesWith(Plane p)
    {
        return p.distanceTo(transform.position) < radius;
    }

    internal bool CollidesWith(Target t)
    {
        return t.distanceTo(transform.position) < radius;
    }
}
