using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float rotSpeed = 360;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(player == null) player = GameObject.FindWithTag("Player");
        if(player != null) MoveToTarget(player.transform.position);
    }

    void MoveToTarget(Vector3 target)
    {
        var targetDir = target - transform.position;
        var newDir = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        rb.MovePosition(transform.position + target * speed * Time.deltaTime);
    }
}
