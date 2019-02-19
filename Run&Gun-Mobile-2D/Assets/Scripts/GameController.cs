﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector2 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public Text scoreText;
    public Text restartText;
    public Text newHighScoreText;
    public Text highScoreText;
    public Text gameOverText;

    public bool gameOver;
    private bool restart;
    private int score;

    public GameObject[] backGroundLayers;

    void Start()
    {

        gameOver = false;
        /*
        gameOver = false;
        restart = false;
        restartText.text = "";
        newHighScoreText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();*/
        StartCoroutine(SpawnWaves());
       // highScoreText.text = "Hiscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
         if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                // bool flag = Random.value();
                // if (flag)
                //{
                //
                //}
                Vector2 spawnPosition = new Vector2(spawnValues.x, spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
               GameObject clone = Instantiate(hazard, spawnPosition, spawnRotation);
              //  ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                foreach (GameObject enemy in backGroundLayers)
                {
                    enemy.gameObject.GetComponent<BGScroller>().enabled = false;
                }
               // backGroundLayers.BGScroller();
                restartText.text = "try again";
                restart = true;
                break;
            }
        }
    }

    /*
    void ReverseDirection(GameObject clone)
    {
        //Quaternion rot = transform.localRotation;
        //rot.eulerAngles = new Vector3(0.0f, curY, 0.0f);
        //transform.localRotation = rot;
        clone.transform.rotation.y = 0;
        clone.GetComponent<Mover>().speed = 0;
    }*/

        /*
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverText.text = "game over";
        gameOver = true;
        scoreText.text = "Score: " + score.ToString();

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Hiscore : " + score.ToString();
            newHighScoreText.text = "New High \nScore!";
        }
    }*/
}