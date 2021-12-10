using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Means the player is dead
        if(currentHealth <= 0);
    }

}
