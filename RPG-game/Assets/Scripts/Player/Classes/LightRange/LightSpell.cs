using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{
    public float timeToDestroy = 5;
    public LightRange parent;

    void Awake()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<EnemyHealth>()) other.gameObject.GetComponent<EnemyHealth>().TakeDamage(parent.damage, parent.gameObject);
        Destroy(this.gameObject);
    }
}
