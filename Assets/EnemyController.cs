using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 5f;
    private float enemyHealth;

    private Rigidbody rb;
    private BulletController bulletController = new BulletController();
    private Renderer render;

    private float gameTime;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    private void Start()
    {
        enemyHealth = Random.Range(1, 15);
        if(enemyHealth <= 5)
        {
            render.material.color = Color.red;
        }
        else if (enemyHealth <= 10)
        {
            render.material.color = Color.blue;
        }
        else
        {
            render.material.color = Color.green;
        }
    }

    private void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);   
        }
        
        rb.velocity = Vector3.back * enemySpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            enemyHealth -= bulletController.bulletDamage;
        }
    }

    private void IncreaseThroughTime()
    {

    }
}
