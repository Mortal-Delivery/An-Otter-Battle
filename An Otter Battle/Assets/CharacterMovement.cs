using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float rotationSpeed = 150f; // Adjust this for turning speed
    public float jumpHeight = 2.2f;
    public float gravity = -20.0f;
    public float groundCheckRadius = 0.1f; // Adjust this based on your character's size
    public LayerMask groundLayer; // Assign the ground layer in the Inspector


    private CharacterController controller;
    private Vector3 playerVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is grounded

        // Calculate movement direction based on user input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));

        // Calculate rotation based on horizontal input
        Vector3 rotation = Vector3.zero;
        if (horizontalInput != 0)
        {
            rotation = Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime;
        }

        // Apply rotation
        transform.Rotate(rotation);
        

        // Apply movement speed
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        bool isGrounded = IsPlayerGrounded();

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private bool IsPlayerGrounded()
    {
        // Create a sphere at the player's feet position to check for ground collisions
        Vector3 sphereCenter = transform.position - (Vector3.up * (controller.height / 2 - controller.radius));
        return Physics.CheckSphere(sphereCenter, groundCheckRadius, groundLayer);
    }
}