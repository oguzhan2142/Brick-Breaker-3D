﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using TMPro;
using System;
public class HomeScene : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoresText = null;
    [SerializeField] private GameObject highScoresPanel = null;

    public void startGame()
    {
        Time.timeScale = 1;
        Plank.isDead = false;
        GameManager.score = 0;
        GameManager.level = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void highestScores()
    {

        SaveScore save = new SaveScore();
        List<int> scores = save.getHighScores();

        StringBuilder sb = new StringBuilder();

        var index = 1;
        foreach (var item in scores)
        {
            sb.Append(index + ". " + item + "\n");
            index++;
        }
        highScoresPanel.SetActive(true);
        scoresText.text = sb.ToString();

    }

    public void settings()
    {

    }


    public void quit()
    {
        Application.Quit();
    }

    public void closeHighScorePanel()
    {
        highScoresPanel.SetActive(false);
    }


}