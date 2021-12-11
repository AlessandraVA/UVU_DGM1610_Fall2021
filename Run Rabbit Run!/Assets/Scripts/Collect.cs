using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
   public int collectValue = 10;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.CompareTag("Player"))
       {
           ScoreManager.instance.ChangeScore(collectValue);
       }
   }
}
