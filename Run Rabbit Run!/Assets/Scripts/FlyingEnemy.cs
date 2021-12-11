using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{ //Used Unity: Flying Enemy (Root Game) as a reference
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        return;
        if(chase==true)
            Chase();
        else
        {
            // Go to the starting point
            ReturnStartPoint();
        }
        Flip();
    }
    // Makes the enemy chase the player
    private void Chase()
    {
        transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
    }
    // When the player is back at the starting point, then the enemy will go back to its starting point
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    // Causes the enemy to flip where it is looking wherever the player is going
    private void Flip()
    {
        if(transform.position.x>player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
        {
            transform.rotation = Quaternion.Euler(0, 180,0);
        }
        
    }
}
