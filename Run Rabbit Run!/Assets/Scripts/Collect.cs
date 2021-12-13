using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collect : MonoBehaviour
{
   public int collectValue = 10;

   // Start is called before the first frame update
   void Start()
   {
       
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.CompareTag("Player"))
       {
           ScoreManager.instance.ChangeScore(collectValue);
       }


   }
}
