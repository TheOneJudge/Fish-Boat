using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    
    private float playerSpeed = 10.0f;
    private CharacterController controller;
    private Vector2 movementInput = Vector2.zero;


    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(movementInput.x, 0, -movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
