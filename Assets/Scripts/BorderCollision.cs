﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            //GetComponent<GameManager>().Score();

            GameManager.Instance.Score((int)transform.parent.rotation.eulerAngles.y/90);

        }
    }
}
