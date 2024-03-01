using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private float time;
    private float scoreTimer = 10f;
    private float score;
    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentScore;

    public GameObject canvaUI;
    
    public int scorePerS = 6;
    private int seconds;
    private int minutes;
    private float highScore;

    public bool isPlaying;

    private void Start()
    {
        LoadHighScore();
        highScoreText.text = highScore.ToString();
    }

    void Update()
    {
        if (isPlaying)
        {
            time += Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);
            timeText.text = string.Format("{00:00} : {1:00}", minutes, seconds);
            AddPoint();
        }
        else
        {
            DisplayHighScore();
            SaveHighScore();
        }
    }
    void AddPoint()
    {
        score += Time.deltaTime * scorePerS;
        scoreTimer -= Time.deltaTime;
        
        if (scoreTimer <= 0)
        {
            score += 100;
            scoreTimer = 10f;
        }
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
    void DisplayHighScore()
    {
        canvaUI.transform.DOMoveY(350, 1f, snapping: false);
        currentScore.text = Mathf.FloorToInt(score).ToString();

        if (score > highScore)
        {
            highScore = Mathf.FloorToInt(score);
            highScoreText.text = highScore.ToString();
        }
    }
    
    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(highScore));
        PlayerPrefs.Save();
    }
    
    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
