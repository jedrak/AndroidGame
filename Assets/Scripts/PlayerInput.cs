using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Input.acceleration);
        Debug.DrawLine(transform.position, Input.acceleration, Color.cyan);
        rb.AddForce(Quaternion.Euler(90, 0, 0) * Input.acceleration);
    }
}
