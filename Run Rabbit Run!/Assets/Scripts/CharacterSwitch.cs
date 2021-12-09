using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{

    private bool facingRight = true;
    private Rigidbody2D rb;
    private float moveInput;



    void FixedUpdate()
    {
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == false && moveInput >0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
