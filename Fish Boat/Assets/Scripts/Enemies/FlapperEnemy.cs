using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlapperEnemy : ENEMY
{
    private int damageTaken = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("collison");
            Health = Health - damageTaken;
            if (Health <= 0)
            {
                this.onDeath();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Perform actions specific to objects with the "Obstacle" tag
            Debug.Log("Collided with an obstacle!");
            // Add code here to handle collision with an obstacle
        }



    }

    public override void onDeath()
    {
        base.onDeath();
        Debug.Log("flappy has died");
    }
}
