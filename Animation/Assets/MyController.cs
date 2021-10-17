using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : MonoBehaviour
{
    Animator NewAnimation;
    // Start is called before the first frame update
    void Start()
    {
        NewAnimation = gameObject.GetComponent<Animator>();
       //  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            NewAnimation.SetBool("Run", true);
        }
    }
}
