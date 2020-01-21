using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    private float lastInput;
    private bool _playerMoved;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMoved = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //debug.text = Input.acceleration.ToString();
        if (Mathf.Sign(_rb.velocity.x) != Mathf.Sign(Input.acceleration.x))
        {
            _rb.AddForce(new Vector3(2 * speed * Input.acceleration.x, 0, 0));
        }
        else
        {
            _rb.AddForce(new Vector3(Input.acceleration.x * speed, 0.0f, 0.0f));
        }
    }
}
