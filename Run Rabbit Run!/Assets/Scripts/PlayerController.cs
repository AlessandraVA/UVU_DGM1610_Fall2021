using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Basic movement
     public float speed = 25.0f;
    public float turnSpeed = 50.0f;
    public float hInput;
    public float vInput;
    public float xRange = 10.45f;
    public float yRange = 4.62f;
    
    public GameObject projectile;
    public Transform launcher;
    public Vector3 offset = new Vector3(0,1,0);

    //Key mechanics
    public Transform keyFollowPoint;
    public Key followingKey;

    // Audio source and sounds to play
    public AudioClip shootSFX;
   private AudioSource audioSource;

    private Rigidbody2D rb;
    public float jumpForce;
    private float moveInput;
    

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // Awake is called after all objects are installed. Called in randomized order
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        // Player can move left to right
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }




    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxisRaw("Horizontal");
       vInput = Input.GetAxisRaw("Vertical");

       transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
       transform.Translate(Vector3.up * speed * vInput *Time.deltaTime);
       // The -x side of the wall
       if(transform.position.x < -xRange)
       {
           transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
       }
       // The x side of the wall
       if(transform.position.x > xRange)
       {
           transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
       }
       if(transform.position.y > yRange)
       {
           transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
       }
       if(transform.position.y < -yRange)
       {
           transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
       }
       if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
        }

        // Jump from the ground up
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        // Jumping mechanics
        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    void Shoot()
    {
        //Play shoot sound effect
        audioSource.PlayOneShot(shootSFX);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player touches the carrots in the game, it will say "".
        if(collision.CompareTag("Collect"))
        {
            print("We have collected a carrot to defeat the enemy!");
            Destroy(collision.gameObject);

        }
    }

}
