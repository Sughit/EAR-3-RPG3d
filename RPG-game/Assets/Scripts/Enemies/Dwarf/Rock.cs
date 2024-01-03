using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dwarf")
        {
            other.gameObject.GetComponent<Dwarf>().Invoke("SearchAnotherStone", 1f);
            Debug.Log("Ar trebui sa o reseteze");
        }
    }
    
}
