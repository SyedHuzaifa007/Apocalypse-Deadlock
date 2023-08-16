using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection);
        
        // Animation
        if (animator != null)
        {
            // Set animation parameters based on movement direction
            bool isMovingForward = verticalInput > 0.0f;
            bool isMovingBackward = verticalInput < 0.0f;
            
            animator.SetBool("Forward", isMovingForward);
            animator.SetBool("Backward", isMovingBackward);
        }
    }
}