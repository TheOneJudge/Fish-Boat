using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwimmerEnemy : ENEMY
{
    private int damageTaken = 100;

    public UnityEvent deathEvent;
    
    public ParticleSystem vfxParticleSystem;

    public void PlayVFX()
    {
        if (vfxParticleSystem != null)
        {
            // Check if the Particle System is not already playing
            if (!vfxParticleSystem.isPlaying)
            {
                // Play the Particle System
                vfxParticleSystem.Play();
            }
        }
        else
        {
            Debug.LogWarning("Particle System reference not set!");
        }
    }
    
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
            PlayVFX();
        }

    }

    public override void onDeath()
    {
        base.onDeath();
        Debug.Log("flappy has died");
    }
}
