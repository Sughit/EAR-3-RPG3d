using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour 
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotSpeed = 360;
    public GameObject cam;
    public GameObject player;
    public bool isCameraRotating = false; 
    public float angle =1f;
    Vector3 input;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("camParent");
    }

    private void Update() 
    {

        CameraRotate();
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
        input = new Vector3 (Input.GetAxisRaw("Horizontal"),0 ,Input.GetAxisRaw("Vertical"));

    }

    private void Look() 
    {
        if (input ==Vector3.zero) return;
        var rot = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotSpeed * Time.deltaTime);
    }

    private void Move() 
    {
            rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);

    }

    public void CameraRotate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RotationPlus());
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(RotationMinus());
        }
    }

    IEnumerator RotationPlus()
    {
        for(int i =0;i<90;i++)
        {
            angle= 1.0f;
            yield return new WaitForSeconds(0.001f);
            cam.transform.Rotate(0,angle,0,Space.World);
        }     
    }
    IEnumerator RotationMinus()
    {
        for(int i=0;i<90;i++)
        {
            angle= 1.0f;
            yield return new WaitForSeconds(0.001f);
            cam.transform.Rotate(0,-angle,0,Space.World);
        }     
    }

}
