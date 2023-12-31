using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;

    void Awake()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}
