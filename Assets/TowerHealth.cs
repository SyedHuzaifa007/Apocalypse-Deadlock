using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    [HideInInspector] public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyObstaclesWithTag("Obstacle");
            Destroy(gameObject);
        }
    }

    private void DestroyObstaclesWithTag(string tag)
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }
}