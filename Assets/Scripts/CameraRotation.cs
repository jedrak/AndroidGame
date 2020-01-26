using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{

    public Button left;
    public Button right;
    private int rot;
    private void Start()
    {
        rot = 0;
    }

    public IEnumerator cooldown(Button btn)
    {
        btn.interactable = false;
        yield return new WaitForSeconds(5.0f/(PlayerPrefs.GetInt("Nlvl")+1));
        btn.interactable = true;
    }
    public void RotateLeft()
    {
        //GetComponentInChildren<Animator>().SetTrigger("Left");
        //GetComponent<Animator>().ResetTrigger("Left");
        rot++;
        if (rot > 3) rot = 0;
        GetComponent<Animator>().SetInteger("Direction", rot);
        StartCoroutine("cooldown", left);
    }

    public void RotateRight()
    {
        rot--;
        if (rot < 0) rot = 3;
        GetComponent<Animator>().SetInteger("Direction", rot);
        StartCoroutine("cooldown", right);

    }

    public int getRot()
    {
        return rot;
    }
}