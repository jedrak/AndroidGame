using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeSceneManager : MonoBehaviour
{
    public Text scoreTxt;
    private void Start()
    {
        scoreTxt.text = "Score: \n"
                           + " N: " + PlayerPrefs.GetInt("N") + "\n"
                           + " E: " + PlayerPrefs.GetInt("E") + "\n"
                           + " S: " + PlayerPrefs.GetInt("S") + "\n"
                           + " W: " + PlayerPrefs.GetInt("W");
    }

    public void LoadBack()
    {
        SceneManager.LoadScene("MainScene");
    }
}
