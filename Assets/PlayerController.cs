using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 50f;
    public float fireDelta = 0.25F;

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
        moveHorizontal *= Time.deltaTime;

        if(transform.position.x <= minMaxValue.x)
        {
            transform.position = new Vector3(minMaxValue.x, 0, 0);
        }
        if (transform.position.x >= minMaxValue.y)
        {
            transform.position = new Vector3(minMaxValue.y, 0, 0);
        }
        transform.Translate(moveHorizontal, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
