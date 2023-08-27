using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y > 5 || transform.position.z < 130 || transform.position.y < 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("collided: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("enemy hit");
        }
        Destroy(gameObject);
    }
}
