using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour 
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotSpeed = 360;
    private Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        GetInput();
        Look();

        if(Input.GetKey(KeyCode.T))
        {
            ExpManager.instance.AddExp(50);
        }
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void GetInput() 
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() 
    {
        if (input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed * Time.deltaTime);
    }

    private void Move() 
    {
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
    }
}
