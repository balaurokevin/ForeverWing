using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float fireDelta = 0.25F;
    public float tilt = 5f;

    public Vector2 minMaxValue;
    public GameObject projectile;
    public Transform spawnBullet;

    private float moveHorizontal;
    private float nextFire = 0.25F;
    private float myTime = 0.0F;

    private GameObject newProjectile;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        myTime += Time.deltaTime;
        if (Input.GetButton("Jump") && myTime > nextFire)
        {      
            nextFire = myTime + fireDelta;          
            newProjectile = Instantiate(projectile, spawnBullet.position, spawnBullet.rotation) as GameObject;
        
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.velocity = movement * speed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, minMaxValue.x, minMaxValue.y),
            0.0f,
            0.0f
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
