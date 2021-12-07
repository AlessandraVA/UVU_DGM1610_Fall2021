using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float speed = 25.0f;
    public float turnSpeed = 50.0f;
    public float hInput;
    public float vInput;
    public float xRange = 10.45f;
    public float yRange = 4.62f;
    
    public GameObject projectile;
    public Vector3 offset = new Vector3(0,1,0);

    private LayerMask layerMask;
    private Rigidbody2D rigidbody2d;
    public float moveSpeed;
    public float jumpforce;
    private BoxCollider2D boxCollider2d;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;

    // Awake is called after all objects are installed. Called in randomized order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();           //will look for a component on the GameObject of the Rigidbody 2D type
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
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
       

        moveDirection = Input.GetAxis("Horizontal");
        // Animate
        if(moveDirection > 0 && facingRight)
        {
            FlipCharacter();
        }
        else if(moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);        // Movement

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Collect"))
       {
           print("We have collected a carrot to defeat the enemy!");
           Destroy(collision.gameObject);
       }
    }

    private void FlipCharacter()
    {
        facingRight = facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
