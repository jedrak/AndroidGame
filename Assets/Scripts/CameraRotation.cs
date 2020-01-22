using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private int rot;
    private void Start()
    {
        rot = 0;
    }
    public void RotateLeft()
    {
        //GetComponentInChildren<Animator>().SetTrigger("Left");
        //GetComponent<Animator>().ResetTrigger("Left");
        rot++;
        if (rot > 3) rot = 0;
        GetComponent<Animator>().SetInteger("Direction", rot);
    }

    public void RotateRight()
    {
        rot--;
        if (rot < 0) rot = 3;
        GetComponent<Animator>().SetInteger("Direction", rot);
    }

    public int getRot()
    {
        return rot;
    }
}