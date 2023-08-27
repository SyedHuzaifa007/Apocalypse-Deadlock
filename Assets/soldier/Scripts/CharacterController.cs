using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator animator;

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
                animator.SetTrigger("Death");
            }
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
            animator.SetBool("Run", isMovingForward);
            animator.SetBool("Run", isMovingBackward);
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
