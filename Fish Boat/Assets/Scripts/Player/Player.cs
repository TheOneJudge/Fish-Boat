using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    
    public int currentHealth = 100;
    public int maxHealth = 100;

    private int damageTaken = 10;

    public int killAmount;
    private float playerSpeed = 10.0f;
    private CharacterController controller;
    private Vector2 movementInput = Vector2.zero;

    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Bullet"))
        {
            currentHealth = currentHealth - damageTaken;
            Debug.Log("taken bullet");

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnemyKilled(int killCount)
    {
       Debug.Log(killCount);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(-movementInput.y, 0,movementInput.x );
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    private void onKillEventHandler(int killHandler)
    {
        this.killAmount += 1;
        
        Debug.Log("Kills Made: " + killAmount);

        // Perform actions based on the number of coins collected
        // For example:
        if (killAmount >= 10)
        {
            // Do something specific when 10 or more coins are collected
            Debug.Log("You have Won");
        }
    }
}
