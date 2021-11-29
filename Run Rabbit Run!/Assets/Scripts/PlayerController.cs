using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        if(transform.position.y >= 2)
        {
            // Y axis barrier for the player
            transform.position = new Vector3(transform.position.x, 2, 0);
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
    
    private void FlipCharacter()
    {
        facingRight = facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
