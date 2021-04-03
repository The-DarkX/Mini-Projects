using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{

    public float destroyDelay = 2.0f;
    private void Start()
    {
        Destroy(gameObject, destroyDelay) ;
    }
    
}
