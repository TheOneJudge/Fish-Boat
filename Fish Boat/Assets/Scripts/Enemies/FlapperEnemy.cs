using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlapperEnemy : ENEMY
{
    private int damageTaken = 50;

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


        if (collision.gameObject.CompareTag("Bullet"))
        {
            Health = Health - damageTaken;
            Debug.Log("taken bullet");

            if (Health <= 0)
            {
                this.onDeath();
                deathEvent.Invoke();
                PlayVFX();
            }
        }

    }

    public override void onDeath()
    {
        base.onDeath();
        Debug.Log("Swimmer has died");
    }
}
