using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public float destructionRadius = 2.0f;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, destructionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Obstacle"))
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }
}