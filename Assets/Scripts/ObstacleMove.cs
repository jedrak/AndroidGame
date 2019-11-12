using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0.0f, -speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(0.0f, -speed);
    }
}
