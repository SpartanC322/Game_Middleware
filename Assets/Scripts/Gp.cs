using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 parallel(Vector3 v, Vector3 n)
    {
        return Vector3.Dot(v, n) * n;
    }

    /// <summary>
    /// Returns the perpendicular component of v relative to n
    /// </summary>
    /// <param name="v">Vector to be split up</param>
    /// <param name="n">Unit Vector perpendicular to return</param>
    /// <returns></returns>
    public static Vector3 perpendicular(Vector3 v, Vector3 n)
    {
        return v - parallel(v, n);
    }
}
