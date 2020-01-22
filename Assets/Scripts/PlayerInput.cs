using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed;
    public TMPro.TextMeshProUGUI debug;
    [SerializeField]
    private CameraRotation camera;
    private Rigidbody _rb;
    private float lastInput;
    private bool _playerMoved;
    private Vector2 startTouchPosition, endTouchPosition;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMoved = false;
        playerAnimator = GetComponent<Animator>();
        camera = GetComponentInParent<CameraRotation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        debug.text = transform.rotation.eulerAngles + " " + camera.getRot();
        if (Mathf.Sign(_rb.velocity.x) != Mathf.Sign(Input.acceleration.x))
        {
            if(transform.rotation.eulerAngles.y == 0)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                _rb.AddForce(new Vector3(2 * speed * Input.acceleration.x, 0, 0));
            }
            else if(transform.rotation.eulerAngles.y == 180)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                _rb.AddForce(new Vector3(-2 * speed * Input.acceleration.x, 0, 0));
            }
            else if(transform.rotation.eulerAngles.y == 90)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                _rb.AddForce(new Vector3(0, 0, -2 * speed * Input.acceleration.x));
                //debug.text = " tu jestem";
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                _rb.AddForce(new Vector3(0, 0, 2 * speed * Input.acceleration.x));
            }

        }
        else
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                _rb.AddForce(new Vector3(speed * Input.acceleration.x, 0, 0));
            }
            else if (transform.rotation.eulerAngles.y == 180) 
            { 
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                _rb.AddForce(new Vector3(-speed * Input.acceleration.x, 0, 0));
            }
            else if (transform.rotation.eulerAngles.y == 90)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                _rb.AddForce(new Vector3(0, 0, -speed * Input.acceleration.x));

            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                _rb.AddForce(new Vector3(0, 0, speed * Input.acceleration.x));
            }

        }
    }
}
