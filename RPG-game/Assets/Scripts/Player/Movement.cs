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
    public bool isCameraRotating = false; 
    float angle =1f;
    Vector3 input, moveDir;
    float vInput, hInput;
    public Animator anim;
    public static bool canMove;

    
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
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        Vector3 forwardRel = vInput * camForward;
        Vector3 rightRel = hInput * camRight;

        moveDir = forwardRel + rightRel;

















    }

    private void Look() 
    {
        if (input ==Vector3.zero) 
        {
            anim.SetBool("mers", false);
            return;
        }
        else
        {
            anim.SetBool("mers", true);
        }
        var rot = Quaternion.LookRotation(moveDir.ToIso(), Vector3.up);
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
        for(int i =0;i<45;i++)
        {
            angle= 1.0f;
            yield return new WaitForSeconds(0.001f);
            cam.transform.Rotate(0,angle,0,Space.World);
        }     
    }
    IEnumerator RotationMinus()
    {
        for(int i=0;i<45;i++)
        {
            angle= 1.0f;
            yield return new WaitForSeconds(0.001f);
            cam.transform.Rotate(0,-angle,0,Space.World);
        }     
    }

}
