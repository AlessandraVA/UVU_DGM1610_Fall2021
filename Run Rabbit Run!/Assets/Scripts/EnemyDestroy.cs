using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Rabbit")
        {
            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
           healthmanager.health -=1;
            
        }
    }
}
