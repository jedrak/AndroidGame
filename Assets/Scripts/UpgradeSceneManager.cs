using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeSceneManager : MonoBehaviour
{
    public Text scoreTxt;
    public List<Button> buttons;
    public List<Text> texts;
    private void Start()
    {
        scoreTxt.text = "Score: \n"
                           + " N: " + PlayerPrefs.GetInt("N") + "\n"
                           + " E: " + PlayerPrefs.GetInt("E") + "\n"
                           + " S: " + PlayerPrefs.GetInt("S") + "\n"
                           + " W: " + PlayerPrefs.GetInt("W");
        texts[0].text = "cooldown " + PlayerPrefs.GetInt("Nlvl") + "\n" + (PlayerPrefs.GetInt("Nlvl") * 100 + 100).ToString();
        texts[1].text = "multiscore " + PlayerPrefs.GetInt("Elvl") + "\n" + (PlayerPrefs.GetInt("Elvl") * 100 + 100).ToString();
        texts[2].text = "small islands " + PlayerPrefs.GetInt("Slvl") + "\n" + (PlayerPrefs.GetInt("Slvl") * 100 + 100).ToString();
        texts[3].text = "slow " + PlayerPrefs.GetInt("Wlvl") + "\n" + (PlayerPrefs.GetInt("Wlvl") * 100 + 100).ToString();
    }


    private void Update()
    {
        buttons[0].interactable = PlayerPrefs.GetInt("N") >= PlayerPrefs.GetInt("Nlvl") * 100 + 100;
        buttons[1].interactable = PlayerPrefs.GetInt("E") >= PlayerPrefs.GetInt("Elvl") * 100 + 100;
        buttons[2].interactable = PlayerPrefs.GetInt("S") >= PlayerPrefs.GetInt("Slvl") * 100 + 100;
        buttons[3].interactable = PlayerPrefs.GetInt("W") >= PlayerPrefs.GetInt("Wlvl") * 100 + 100;
        Debug.Log(PlayerPrefs.GetInt("Slvl") * 100 + 100);
    }


    public void addMoney()
    {
        PlayerPrefs.SetInt("N", PlayerPrefs.GetInt("N") + 100);
        PlayerPrefs.SetInt("E", PlayerPrefs.GetInt("E") + 100);
        PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") + 100);
        PlayerPrefs.SetInt("W", PlayerPrefs.GetInt("W") + 100);
        scoreTxt.text = "Score: \n"
                           + " N: " + PlayerPrefs.GetInt("N") + "\n"
                           + " E: " + PlayerPrefs.GetInt("E") + "\n"
                           + " S: " + PlayerPrefs.GetInt("S") + "\n"
                           + " W: " + PlayerPrefs.GetInt("W");

    }

    public void buyUpgrade(int w)
    {
        switch (w)
        {
            case 0:
                PlayerPrefs.SetInt("N", PlayerPrefs.GetInt("N") - (100 * PlayerPrefs.GetInt("Nlvl")+100));
                PlayerPrefs.SetInt("Nlvl", PlayerPrefs.GetInt("Nlvl") + 1);
                texts[0].text = "cooldown " + PlayerPrefs.GetInt("Nlvl") + "\n" + (PlayerPrefs.GetInt("Nlvl")*100 +100).ToString();
            break;
            case 1:
                PlayerPrefs.SetInt("E", PlayerPrefs.GetInt("E") - (100 * PlayerPrefs.GetInt("Elvl") + 100));
                PlayerPrefs.SetInt("Elvl", PlayerPrefs.GetInt("Elvl") + 1);
                texts[1].text = "multiscore " + PlayerPrefs.GetInt("Elvl") + "\n" + (PlayerPrefs.GetInt("Elvl") * 100 + 100).ToString();
            break;
            case 2:
                PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") - (100 * PlayerPrefs.GetInt("Slvl") + 100));
                PlayerPrefs.SetInt("Slvl", PlayerPrefs.GetInt("Slvl") + 1);
                texts[2].text = "small islands " + PlayerPrefs.GetInt("Slvl") + "\n" + (PlayerPrefs.GetInt("Slvl") * 100 + 100).ToString();
            break;
            case 3:
                PlayerPrefs.SetInt("W", PlayerPrefs.GetInt("W") - (100 * PlayerPrefs.GetInt("Wlvl") + 100));
                PlayerPrefs.SetInt("Wlvl", PlayerPrefs.GetInt("Wlvl") + 1);
                texts[3].text = "slow " + PlayerPrefs.GetInt("Wlvl") + "\n" + (PlayerPrefs.GetInt("Wlvl")*100 +100).ToString();
            break;
        }
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
