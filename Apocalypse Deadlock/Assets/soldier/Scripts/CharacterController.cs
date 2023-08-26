using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 180.0f;  // Rotation speed in degrees per second

    public float health = 100.0f;  // Initial health value

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            // Play death animation
            if (animator != null)
            {
                animator.SetBool("Death", true);
            }

            // Optionally, you might want to disable further movement and input processing here.
            return;
        }

        // Movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0.0f, 0.0f, verticalInput);
        moveDirection.Normalize();
        Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveVelocity);

        // Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0.0f)
        {
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

        // Animation
        if (animator != null)
        {
            bool isMovingForward = verticalInput > 0.0f;
            bool isMovingBackward = verticalInput < 0.0f;
            animator.SetBool("Forward", isMovingForward);
            animator.SetBool("Backward", isMovingBackward);
        }
    }
}
