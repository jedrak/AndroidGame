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

    public Text scoreText;
    public Text gameOverScoreText;

    enum PageState
    {
        Game,
        Start,
        GameOver
    }

    int score = 0;
    bool _gameOver = false;

    private void Start()
    {
        GetComponent<ObstacleSpawner>().enabled = false;
        SetPageState(PageState.Start);
        scoreText.text = "Score:\n0";
        
    }

    private void Awake()
    {
        Instance = this;
    }

    public void gameOver()
    {
        _gameOver = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        SetPageState(PageState.GameOver);
        gameOverScoreText.text = "Score: " + score.ToString();
        GetComponent<ObstacleSpawner>().enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Score()
    {
        if(!_gameOver)
        {
            score++;
            scoreText.text = "Score:\n" + score.ToString();
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
        GetComponent<ObstacleSpawner>().enabled = true;
        Instantiate(player, new Vector3(0.0f, 10, -14), Quaternion.Euler(-90.0f, 0.0f, 90.0f), transform);
    }

}
