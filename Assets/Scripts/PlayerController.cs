using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float fireDelta;

    public Vector2 minMaxValue;
    public GameObject projectile;
    public GameObject explosionParticle;
    public Transform spawnBullet;

    private float moveHorizontal;
    private float nextFire = 0.25F;
    private float myTime = 0.0F;

    private bool isDead;
    private bool hasExploded = false;

    public AudioSource[] audio;

    private GameObject newProjectile;
    private Rigidbody rb;
    private GameController gameController;

    private AudioSource bulletAudio;
    private AudioSource explosionAudio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponents<AudioSource>();
    }

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        
        bulletAudio = audio[0];
        explosionAudio = audio[1];
        
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        isDead = false;
       
        transform.rotation = Quaternion.Euler(Vector3.right * -90f);
    }

    void Update()
    {
        myTime += Time.deltaTime;
        if (Input.GetButton("Jump") && myTime > nextFire)
        {      
            nextFire = myTime + fireDelta;
            
            bulletAudio.Play();
            newProjectile = Instantiate(projectile, spawnBullet.position, spawnBullet.rotation) as GameObject;
            
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
        if (isDead)
        {
            
        }
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minMaxValue.x, minMaxValue.y), 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            explosionAudio.Play();
            
            Destroy(gameObject,1.2f);

            gameController.GameOver();
            Invoke("Explode", 0f);
            isDead = true;
        }
    }
    private void Explode()
    {
        GameObject p = Instantiate(explosionParticle, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Destroy(p, 2f);
    }
}
