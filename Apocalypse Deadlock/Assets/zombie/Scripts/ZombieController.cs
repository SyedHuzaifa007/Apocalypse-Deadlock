using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float attackRange = 2.0f;
    public Animator animator;

    private GameObject[] obstacles;
    private GameObject targetObstacle;
    private Vector3 destination;

    void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        FindClosestObstacle();
    }

    void Update()
    {
        if (targetObstacle == null)
        {
            FindClosestObstacle();
        }

        if (targetObstacle != null)
        {
            destination = targetObstacle.transform.position;
            float distanceToObstacle = Vector3.Distance(transform.position, destination);

            if (distanceToObstacle <= attackRange)
            {
                // Play attack animation and set IsAttacking parameter
                if (animator != null)
                {
                    animator.SetBool("attack", true);
                }
                // Destroy the obstacle
                Destroy(targetObstacle);
                targetObstacle = null;
            }
            else
            {
                // Move towards the current obstacle
                Vector3 directionToDestination = (destination - transform.position).normalized;
                Vector3 newPosition = transform.position + directionToDestination * moveSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
        }
    }

    void FindClosestObstacle()
    {
        float closestDistance = Mathf.Infinity;
        foreach (var obstacle in obstacles)
        {
            float distance = Vector3.Distance(transform.position, obstacle.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetObstacle = obstacle;
            }
        }
    }
}