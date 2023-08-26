using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsrotation : MonoBehaviour
{
    public float RotateSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(0, 0 , RotateSpeed);
    }
}
