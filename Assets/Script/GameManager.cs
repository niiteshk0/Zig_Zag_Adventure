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
    public Text daimondText;
    public Text starText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text lastScoreText;

    int score = 0;
    int totalDaimond;
    int totalStar;
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
        //Total daimond
        //totalDaimond = PlayerPrefs.GetInt("totalDaimond");
        //daimondText.text = totalDaimond.ToString();

        ////Total star
        //totalStar = PlayerPrefs.GetInt("totalStar");
        //starText.text = totalStar.ToString();
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
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
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

    public void getStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", newStar);
        starText.text = newStar.ToString();
    }
    public void getDaimond()
    {
        int newDaimond = totalDaimond++;
        PlayerPrefs.SetInt("totalDaimond", newDaimond);
        daimondText.text = newDaimond.ToString();
    }


}
