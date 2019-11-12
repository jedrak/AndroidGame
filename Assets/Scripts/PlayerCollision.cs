using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GetComponent<PlayerInput>().speed = 0;
            FindObjectOfType<GameManager>().gameOver();
        }
    }
}
