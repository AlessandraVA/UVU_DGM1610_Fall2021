using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpforce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;

    // Awake is called after all objects are installed. Called in randomized order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();           //will look for a component on the GameObject of the Rigidbody 2D type
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    
    private void FlipCharacter()
    {
        facingRight = facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
