using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 velocity, acceleration, center;

    float radius, CoR, mass;

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

        center = transform.position;

        acceleration = 9.8f * new Vector3(0,-1,0);

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;

        if(pl.distanceTo(transform.position) < radius)
        {

            //Version 1
            //transform.position -=  velocity * Time.deltaTime;


            //float overlap = radius - pl.distanceTo(transform.position);
            //transform.position += overlap * pl.normal;

            Vector3 v_s, v_c;

            v_s = Gp.perpendicular(velocity, pl.normal);

            v_c = Gp.parallel(velocity, pl.normal);

            float time_r = (radius - pl.distanceTo(transform.position)) / v_c.magnitude;

            transform.position -= velocity * time_r;

            

            velocity = v_s - (v_c * CoR);


            transform.position += velocity * time_r;

            //velocity = -velocity * CoR;//Coeficient of Restitution


        }

       if(Vector3.Distance(transform.position, bl.transform.position) <= radius + bl.radius)
        {
            //Debug.Log("collided");

            Vector3 distanceNorm = (bl.center - center).normalized;

            Vector3 v_s, v_c, v_s2, v_c2;

            v_s = Gp.perpendicular(velocity, distanceNorm);

            v_c = Gp.parallel(velocity, distanceNorm);


            v_s2 = Gp.perpendicular(bl.velocity, distanceNorm);

            v_c2 = Gp.parallel(bl.velocity, distanceNorm);


            v_c = (((mass - bl.mass) / (mass + bl.mass)) * v_c) + (((bl.mass * 2) / (mass + bl.mass)) * v_c2);

            v_c2 = (((bl.mass - mass) / (mass + bl.mass)) * v_c2) + (((mass * 2) / (mass + bl.mass)) * v_c);

            velocity = v_s + (v_c * CoR);

            bl.velocity = v_s2 + (v_c2 * CoR);
        }
    }


}
