using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;

    // connecting to rb
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //moving the player
    private void FixedUpdate()
    {
        rigidBody.position = rigidBody.position + new Vector2(movement.x, movement.y) * moveSpeed * Time.deltaTime; 
    }

    private void Update()
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    //taking player input
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
