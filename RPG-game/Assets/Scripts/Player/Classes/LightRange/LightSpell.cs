using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public float timeToDestroy = 5;

    void Awake()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
