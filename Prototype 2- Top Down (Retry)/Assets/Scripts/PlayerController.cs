using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 20.0f;
    public float hInput;
    public float vInput;
    public float xRange = 8.72f;
    public float yRange = 4.47f;
    
    public GameObject projectile;
    public Vector3 offset = new Vector3(0,1,0);
    
    // public float health;
    
    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
        // Create a wall on the -x side
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Create a wall on x side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + offset, projectile.transform.rotation);
        }
    }
}