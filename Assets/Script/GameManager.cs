using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStart;
    public GameObject platformSpawner;

    [Header("Scores UI")]
    public Text scoreText;
    public Text bestText;
    public Text bestScoreText;
    public Text bestScoreUi;


    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text lastScoreText;

    [Header("UI Score Hide")]
    public GameObject bestscoreHide;
    public GameObject scoreTextHide;

    int score = 0;
    int bestScore = 0;
    bool countScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");    
        bestText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        //if(score > bestScore)
        //{
        //    Debug.Log("Enter in score");
        //    bestScoreUi.text = score.ToString();
        //}
    }   

    public void GameStart()
    {
        isGameStart = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        if (score > bestScore)
        {
            bestScore = score;
            Debug.Log("Enter in gameover "+ score + " " + bestScore);
            PlayerPrefs.SetInt("bestScore", score);
            bestScoreUi.text = bestScore.ToString();
        }

        countScore = false;
        gameOverPanel.SetActive(true);
        bestscoreHide.SetActive(false);
        scoreTextHide.SetActive(false);

        

        lastScoreText.text = score.ToString();
        platformSpawner.SetActive(false);
        
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            score++;
            if(score > bestScore)
            {
                scoreText.text = score.ToString();
                bestText.text = score.ToString();
                bestScoreUi.text = score.ToString();
            }
            else
            {
                bestScoreUi.text = bestScore.ToString();
                scoreText.text = score.ToString();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void exit()
    {
        Debug.Log("Enter in exit");
        Application.Quit();
    }

    public void restart()
    {
        Debug.Log("Enter in restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
