using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   public float topBound = 1;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
    
}
