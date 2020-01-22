using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public void RotateLeft()
    {
        //GetComponentInChildren<Animator>().SetTrigger("Left");
        //GetComponent<Animator>().ResetTrigger("Left");
        GetComponent<Animator>().SetTrigger("Left");
    }

    public void RotateRight()
    {
        //GetComponent<Animator>().ResetTrigger("Right");
        GetComponent<Animator>().SetTrigger("Right");
    }

    public bool getLeft()
    {
        return GetComponent<Animator>().GetBool("Left");
    }

    public bool getRight()
    {
        return GetComponent<Animator>().GetBool("Right");
    }
}
