using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<Ball> allSpheres;
    public List<Plane> allPlanes;
    public List<Target> allTargets;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        allPlanes = FindObjectsOfType<Plane>().ToList();
        allTargets = FindObjectsOfType<Target>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        allSpheres = FindObjectsOfType<Ball>().ToList();

        for (int i = 0; i < allSpheres.Count;i++)
        {
            Ball firstSphere = allSpheres[i];
            for (int j = i + 1; j < allSpheres.Count;j++)
            {
                Ball secondSphere = allSpheres[j];

                if (firstSphere.CollidesWith(secondSphere))
                {
                    ResolveCollision(firstSphere, secondSphere);

                    //Debug.Log("Sphere collision");
                }
            }

            foreach (Plane p in allPlanes)
            {
                if (firstSphere.CollidesWith(p))
                {
                    ResolveCollision(firstSphere, p);

                    //score++;

                    //Debug.Log("Score: " + score);

                    //Debug.Log("Plane Collision");
                }
            }

            foreach (Target t in allTargets)
            {
                if (firstSphere.CollidesWith(t))
                {
                    ResolveCollision(firstSphere, t);

                    t.hitTarget();

                    score++;

                    Debug.Log("Score: " + score);
                }
            }
        }
    }

    private void ResolveCollision(Ball firstSphere, Plane p)
    {
        //Version 1
        //transform.position -=  velocity * Time.deltaTime;


        //float overlap = radius - pl.distanceTo(transform.position);
        //transform.position += overlap * pl.normal;

        Vector3 v_s, v_c;

        v_s = Gp.perpendicular(firstSphere.velocity, p.normal);

        v_c = Gp.parallel(firstSphere.velocity, p.normal);

        float time_r = (firstSphere.radius - p.distanceTo(transform.position)) / v_c.magnitude;

        transform.position += firstSphere.velocity * time_r;



        firstSphere.velocity = v_s - (v_c * firstSphere.CoR);


        transform.position -= firstSphere.velocity * time_r;

        //velocity = -velocity * CoR;//Coeficient of Restitution
    }

    private static void ResolveCollision(Ball firstSphere, Ball secondSphere)
    {
        //Debug.Log("collided");

        Vector3 distanceNorm = (secondSphere.transform.position - firstSphere.transform.position).normalized;

        Vector3 v_s, v_c, v_s2, v_c2;

        v_s = Gp.perpendicular(firstSphere.velocity, distanceNorm);

        v_c = Gp.parallel(firstSphere.velocity, distanceNorm);


        v_s2 = Gp.perpendicular(secondSphere.velocity, distanceNorm);

        v_c2 = Gp.parallel(secondSphere.velocity, distanceNorm);


        v_c = (((firstSphere.mass - secondSphere.mass) / (firstSphere.mass + secondSphere.mass)) * v_c) + (((secondSphere.mass * 2) / (firstSphere.mass + secondSphere.mass)) * v_c2);

        v_c2 = (((secondSphere.mass - firstSphere.mass) / (firstSphere.mass + secondSphere.mass)) * v_c2) + (((firstSphere.mass * 2) / (firstSphere.mass + secondSphere.mass)) * v_c);

        firstSphere.velocity = v_s + (v_c * firstSphere.CoR);

        secondSphere.velocity = v_s2 + (v_c2 * firstSphere.CoR);
    }
}
