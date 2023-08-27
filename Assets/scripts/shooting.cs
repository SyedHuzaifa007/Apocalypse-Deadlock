using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gunBarrel; // Gun barrel's Transform
    public GameObject bulletPrefab; // Prefab of the bullet object
    public float bulletForce = 10f; // Force to apply to the bullet

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your desired input
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(gunBarrel.forward * bulletForce, ForceMode.Impulse);
    }
}
