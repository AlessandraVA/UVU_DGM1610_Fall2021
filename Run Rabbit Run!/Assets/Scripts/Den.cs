using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Den : MonoBehaviour
{
    public GameManager gameManager;
   
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player") && gameManager.hasKey)
       {
           print("You unlocked the Rabbit's Den with the keys");
           gameManager.isDoorLocked = false;
       }
       else
       {
           print("The Rabbit's Den is locked. You cannot escape! Oh No!");
       }
   }
}
