using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public Transform towerHead;
    public Transform firePoint;
    public float detectionRange = 10f;
    public GameObject projectilePrefab;
    public float fireRate = 2f;

    private Transform target;
    private float fireCooldown = 0f;

    void Update()
    {
        FindNearestTarget();

        if (target != null)
        {
            RotateTowerHead();

            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
            }

            fireCooldown -= Time.deltaTime;
        }
    }

    void FindNearestTarget()
    {
        Collider[] zombies = Physics.OverlapSphere(transform.position, detectionRange, LayerMask.GetMask("Zombies"));

        float closestDistance = Mathf.Infinity;
        Transform closestZombie = null;

        foreach (Collider zombie in zombies)
        {
            float distanceToZombie = Vector3.Distance(transform.position, zombie.transform.position);
            if (distanceToZombie < closestDistance)
            {
                closestDistance = distanceToZombie;
                closestZombie = zombie.transform;
            }
        }

        target = closestZombie;
    }

    void RotateTowerHead()
    {
        Vector3 targetDirection = target.position - towerHead.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
    
        // Rotate only around the y-axis (vertical axis) to aim the tower head
        Quaternion yOnlyRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        towerHead.rotation = Quaternion.Slerp(towerHead.rotation, yOnlyRotation, Time.deltaTime);
    }


    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        // Apply force or velocity to the projectile here
    }
}