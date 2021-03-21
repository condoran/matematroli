using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float shootSpeed = 5f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
