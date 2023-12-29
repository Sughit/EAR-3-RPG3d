using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySpell : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Player") 
        {
            ShakeCamera.shake = true;
            Destroy(this.gameObject);
        }
    }
}
