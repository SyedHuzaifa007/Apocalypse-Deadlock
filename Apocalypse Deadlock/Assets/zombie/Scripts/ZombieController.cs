using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float detectionRange = 10.0f;

    private Transform target; // The police character to follow
    private Vector3 randomTargetPosition; // Random position for wandering
    private bool isFollowing = false; // Whether the zombie is following the target

    void Start()
    {
        // Find the police character's transform
        target = GameObject.FindGameObjectWithTag("Police").transform;

        // Start with a random target position for wandering
        randomTargetPosition = GenerateRandomPosition();
    }

    void Update()
    {
        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the police character is within the detection range
        if (distanceToTarget <= detectionRange)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
            MoveRandomly();
        }

        // Move towards the target if following
        if (isFollowing)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            transform.Translate(directionToTarget * moveSpeed * Time.deltaTime);
        }
    }

    void MoveRandomly()
    {
        // Move towards the random target position
        Vector3 directionToRandomTarget = (randomTargetPosition - transform.position).normalized;
        transform.Translate(directionToRandomTarget * moveSpeed * Time.deltaTime);

        // If the zombie is close to the random target position, generate a new one
        if (Vector3.Distance(transform.position, randomTargetPosition) < 1.0f)
        {
            randomTargetPosition = GenerateRandomPosition();
        }
    }

    Vector3 GenerateRandomPosition()
    {
        // Generate a random position within a range around the current position
        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        return randomPosition;
    }
}
