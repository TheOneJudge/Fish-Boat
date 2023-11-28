using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlapperEnemy : ENEMY
{
    private int damageTaken = 100;

    public UnityEvent deathEvent;
    private void OnCollisionEnter(Collision collision)
    {
        Health = Health - damageTaken;
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("collison");
            
            
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Perform actions specific to objects with the "Obstacle" tag
            Debug.Log("Collided with an obstacle!");
            // Add code here to handle collision with an obstacle
        }

        if (Health <= 0)
        {
            this.onDeath();
            deathEvent.Invoke();
        }

    }

    public override void onDeath()
    {
        base.onDeath();
        Debug.Log("flappy has died");
    }
}
