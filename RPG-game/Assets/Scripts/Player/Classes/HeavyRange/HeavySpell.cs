using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySpell : MonoBehaviour
{
    public HeavyRange parent;
    public float range=1;
    public GameObject explosionParticle;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Player") 
        {
            ShakeCamera.shake = true;
            foreach(Collider col in Physics.OverlapSphere(transform.position, range))
            {
                if(col.gameObject.GetComponent<EnemyHealth>()) 
                {
                    col.gameObject.GetComponent<EnemyHealth>().TakeDamage(parent.damage);
                    Debug.Log("Lovit");
                }
            }
            Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
