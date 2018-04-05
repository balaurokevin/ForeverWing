using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 5f;

    private float enemyHealth;
    private int enemyValue = 2;

    private Rigidbody rb;
    private BulletController bulletController = new BulletController();
    private GameController gameController;
    private Renderer render;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(270, 0, 180));
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        enemyHealth = Random.Range(5, 20);
        if(enemyHealth <= 10)
        {
            render.material.color = Color.red;
        }
        else if (enemyHealth <= 15)
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
        Death();
        rb.velocity = Vector3.back * enemySpeed;
        rb.rotation = Quaternion.Euler(new Vector3(270, 0, 180));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            enemyHealth -= bulletController.bulletDamage;
        }
    }

    public void Death()
    {
        if (enemyHealth <= 0)
        {
            gameController.AddScore(enemyValue);
            Destroy(this.gameObject);
        }
    }
}
