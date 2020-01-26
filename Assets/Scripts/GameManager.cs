using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject startPage;
    public GameObject gamePage; 
    public GameObject gameOverPage;
    public GameObject player;
    public GameObject spawners;

    public Text scoreText;
    public Text gameOverScoreText;

    enum PageState
    {
        Game,
        Start,
        GameOver
    }

    private int[] score;
    bool _gameOver = false;

    private void Start()
    {

        score = new int[4];
        //GetComponentInChildren<ObstacleSpawner>().enabled = false;
        SetPageState(PageState.Start);
        //scoreText.text = "Score:\n" + "N: " + score[0].ToString() + "\n" + "E: " + score[1].ToString() + "\n" + "S: " + score[2].ToString() + "\n" + "W: " + score[3].ToString(); ;
        
    }

    public int getWholeScore()
    {
        return score[0] + score[1] + score[2] + score[3];
    }
    private void Awake()
    {
        Instance = this;
    }



    public void gameOver()
    {
        _gameOver = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (getWholeScore() > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", getWholeScore());
        }
        PlayerPrefs.SetInt("N", score[0] + PlayerPrefs.GetInt("N"));
        PlayerPrefs.SetInt("E", score[1] + PlayerPrefs.GetInt("E"));
        PlayerPrefs.SetInt("S", score[2] + PlayerPrefs.GetInt("S"));
        PlayerPrefs.SetInt("W", score[3] + PlayerPrefs.GetInt("W"));
        SetPageState(PageState.GameOver);
        gameOverScoreText.text = "Score: " + getWholeScore().ToString();
        spawners.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadUpgrade()
    {
        SceneManager.LoadScene("UpgradeScene");
    }
    public void Score(int dir)
    {
        if(!_gameOver)
        {
            score[dir] += PlayerPrefs.GetInt("Elvl")+1;
            scoreText.text = "Score:\n" + "N: " + score[0].ToString() + "\n" + "E: " + score[1].ToString() + "\n" + "S: " + score[2].ToString() + "\n" + "W: " + score[3].ToString();
        }
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.Game:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                gamePage.SetActive(true);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                gamePage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                gamePage.SetActive(false);
                break;
        }
    }
    public void StartGame()
    {
        SetPageState(PageState.Game);
        spawners.SetActive(true);
        Transform t = GetComponentInChildren<CameraRotation>().transform;
        Instantiate(player, new Vector3(0.0f, 10, -13), Quaternion.Euler(90.0f, 0.0f, 0.0f), t);
    }

}
