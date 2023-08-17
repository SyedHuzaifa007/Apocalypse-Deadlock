using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float followRange = 100.0f;
    public float attackRange = 2.0f;
    public float fleeRange = 10.0f;
    public float rotationSpeed = 10.0f;
    public Transform tower;
    public Transform police;
    public Animator animator;

    private Vector3 destination;

    void Start()
    {
        destination = tower.position;
    }

    void Update()
    {
        float distanceToTower = Vector3.Distance(transform.position, tower.position);
        float distanceToPolice = Vector3.Distance(transform.position, police.position);

        // Rotate away from obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            Vector3 newDirection = Vector3.Reflect(transform.forward, hit.normal);
            Quaternion targetRotation = Quaternion.LookRotation(newDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        if (distanceToPolice < fleeRange)
        {
            Vector3 directionFromPolice = (transform.position - police.position).normalized;
            Vector3 destinationFromPolice = transform.position + directionFromPolice * 2.0f;
            destination = destinationFromPolice + (tower.position - destinationFromPolice).normalized * 3.0f;
        }
        else if (distanceToTower < followRange)
        {
            destination = tower.position;

            if (distanceToTower <= attackRange)
            {
                // Play attack animation and set IsAttacking parameter
                if (animator != null)
                {
                    animator.SetBool("attack", true);
                }
            }
            else
            {
                // Reset attack animation
                if (animator != null)
                {
                    animator.SetBool("attack", false);
                }
            }
        }

        // Move towards the destination
        MoveTowardsDestination();
    }

    void MoveTowardsDestination()
    {
        Vector3 directionToDestination = (destination - transform.position).normalized;
        transform.Translate(directionToDestination * moveSpeed * Time.deltaTime, Space.World);
    }
}
