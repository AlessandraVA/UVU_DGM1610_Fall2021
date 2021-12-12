using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   public float topBound = 1;
   

    // Update is called once per frame
    void Update()
    {
        // Should have named it different, but this is for the missles that are being launched, once at a distant lenght it will disappear.
        if(transform.position.y > topBound)
        {
            // when the bullet flies it disappears instead of going on forever.
            Destroy(gameObject);
        }
    }
   
    
}
