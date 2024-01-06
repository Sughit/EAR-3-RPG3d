using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintScript : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    Quaternion rot;
    public GameObject prefab;
    public bool canPlace = true;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer < 32 && other.gameObject.layer != 7) canPlace =false;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer < 32 && other.gameObject.layer != 7) canPlace =true;
    }

    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, 5000.0f, (1 << 7)))
        {
            transform.position = hit.point;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, 5000.0f, (1 << 7)))
        {
            Debug.Log("Primul merge");
            transform.position = hit.point;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 10, transform.rotation.eulerAngles.z);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 10, transform.rotation.eulerAngles.z);
        }
        transform.rotation = rot;
        
        if(Input.GetMouseButton(1) && canPlace)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
