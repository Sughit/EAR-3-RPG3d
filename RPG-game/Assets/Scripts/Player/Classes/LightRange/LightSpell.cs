using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public float speed = 5;
    Vector3 aim;
    Rigidbody rb;

    void Awake()
    {
        Camera cam = Camera.main;
        rb=GetComponent<Rigidbody>();
 
        aim = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(aim);
    }

    void Update()
    {
        rb.AddRelativeForce(-transform.forward * speed);
    }
}
