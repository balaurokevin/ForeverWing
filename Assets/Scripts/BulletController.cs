﻿using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletSpeed;
    public float bulletDamage = 2.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        rb.rotation = Quaternion.Euler(Vector3.right * 90);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * bulletSpeed; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
