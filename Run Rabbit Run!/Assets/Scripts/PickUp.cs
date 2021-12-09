using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   public string pickupName;
   public int amount;

    //Get audio for pickup
   public AudioClip pickupSFX;

    public GameManager gameManager;

    void Update() 
    {
        transform.Rotate(Vector3.back * 20 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Reference Audio Source to play sound effect
        other.GetComponent<AudioSource>().PlayOneShot(pickupSFX);

        print("You picked up a " + pickupName);
        gameManager.hasKey = true;
        Destroy(gameObject);
    }
}
