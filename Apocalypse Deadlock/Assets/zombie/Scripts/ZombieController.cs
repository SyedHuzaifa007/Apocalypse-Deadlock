using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float attackRange = 2.0f;
    public Animator animator;

    private GameObject[] shields;
    private GameObject[] police;
    private GameObject tower;
    private GameObject currentTarget;

    private Vector3 destination;

    private enum AttackTarget
    {
        Shield,
        Police,
        Tower
    }

    private AttackTarget currentAttackTarget = AttackTarget.Shield;

    void Start()
    {
        shields = GameObject.FindGameObjectsWithTag("Shield");
        police = GameObject.FindGameObjectsWithTag("Police");
        tower = GameObject.FindGameObjectWithTag("Tower");
        FindNextTarget();
    }

    void Update()
    {
        if (currentTarget == null)
        {
            FindNextTarget();
        }

        if (currentTarget != null)
        {
            destination = currentTarget.transform.position;
            float distanceToTarget = Vector3.Distance(transform.position, destination);

            if (distanceToTarget <= attackRange)
            {
                // Set IsAttacking parameter for animation
                if (animator != null)
                {
                    animator.SetBool("attack", true);
                }

                // Destroy the target
                Destroy(currentTarget);
                currentTarget = null;

                // Find the next target
                FindNextTarget();
            }
            else
            {
                // Set IsAttacking parameter for animation
                if (animator != null)
                {
                    animator.SetBool("attack", false);
                }

                // Move towards the current target
                Vector3 directionToDestination = (destination - transform.position).normalized;
                Vector3 newPosition = transform.position + directionToDestination * moveSpeed * Time.deltaTime;
                transform.position = newPosition;
            }
        }
    }

    void FindNextTarget()
    {
        if (currentAttackTarget == AttackTarget.Shield)
        {
            if (shields.Length > 0)
            {
                currentTarget = shields[0];
                currentAttackTarget = AttackTarget.Police;
            }
            else
            {
                currentAttackTarget = AttackTarget.Police;
            }
        }
        else if (currentAttackTarget == AttackTarget.Police)
        {
            if (police.Length > 0)
            {
                currentTarget = police[0];
                currentAttackTarget = AttackTarget.Tower;
            }
            else
            {
                currentAttackTarget = AttackTarget.Tower;
            }
        }
        else if (currentAttackTarget == AttackTarget.Tower)
        {
            currentTarget = tower;
        }
    }
}
