using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    [SerializeField] private Collider[] enemies;


    public int bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemies = Physics.OverlapSphere(transform.position, 30);
        foreach (Collider collider in enemies)
        {
            if (collider.gameObject.CompareTag("enemy"))
            {
                Debug.Log("enemy");
                transform.LookAt(collider.transform.position);
                FireBullet(collider.transform);
                //while (collider.gameObject != null)
                //{

                //}
            }
        }
    }

    public void FireBullet(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletPrefab.transform.rotation);
        //bullet.transform.LookAt(target.position);
        Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();

        bulletrb.AddForce((target.transform.position - bullet.transform.position) * bulletSpeed, ForceMode.Impulse);

    }
}
