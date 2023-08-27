using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsscript : MonoBehaviour
{
    public float RotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, RotateSpeed, 0);
    }
}
