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

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text lastScoreText;

    int score = 0;
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
        countScore = false;
        gameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        platformSpawner.SetActive(false);
        
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    public void exit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
