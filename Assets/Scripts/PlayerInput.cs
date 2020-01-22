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
        debug.text = "L: " + camera.getLeft() + " R: " + camera.getRight() + transform.rotation.eulerAngles +" "+ startTouchPosition + " " + endTouchPosition; 
        if (Mathf.Sign(_rb.velocity.x) != Mathf.Sign(Input.acceleration.x))
        {
            if(transform.rotation.eulerAngles.y == 0)
            {
                _rb.AddForce(new Vector3(2 * speed * Input.acceleration.x, 0, 0));
            }
            else if(transform.rotation.eulerAngles.y == 180)
            {
                _rb.AddForce(new Vector3(-2 * speed * Input.acceleration.x, 0, 0));
            }
            else if(transform.rotation.eulerAngles.y == 90)
            {
                _rb.AddForce(new Vector3(0, 0, -2 * speed * Input.acceleration.x));
                //debug.text = " tu jestem";
            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                _rb.AddForce(new Vector3(0, 0, 2 * speed * Input.acceleration.x));
            }

        }
        else
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                _rb.AddForce(new Vector3(speed * Input.acceleration.x, 0, 0));
            }
            else if (transform.rotation.eulerAngles.y == 180)
            {
                _rb.AddForce(new Vector3(-speed * Input.acceleration.x, 0, 0));
            }
            else if (transform.rotation.eulerAngles.y == 90)
            {
                _rb.AddForce(new Vector3(0, 0, -speed * Input.acceleration.x));

            }
            else if (transform.rotation.eulerAngles.y == 270)
            {
                _rb.AddForce(new Vector3(0, 0, speed * Input.acceleration.x));
            }

        }



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            {
                //playerAnimator.SetTrigger("TurnLeft");
                camera.RotateLeft();
            }


            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 1.75f)
            {
                //playerAnimator.SetTrigger("TurnRight");
                camera.RotateRight();
            }

        }
    }
}
