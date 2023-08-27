using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            TowerHealth towerHealth = other.GetComponent<TowerHealth>();
            if (towerHealth != null)
            {
                towerHealth.TakeDamage(damage);
            }
        }
    }
}