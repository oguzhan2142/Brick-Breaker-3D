using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static string SAVE_FILE_NAME = "saves.txt";
    private const float BLOCK_SPEED_INCREASE_RATE = 1.2F;

    public static float BLOCK_SPEED = 0.05F;

    public static int score = 0;
    public static int level = 1;

    public TextMeshProUGUI gameOverScoreText = null;

    [SerializeField] private GameObject skillExplanationPanel = null;
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private GameObject blockPrefab = null;
    [SerializeField] private Transform startingTransform = null;
    [SerializeField] private Text levelText = null;




    void Start()
    {
        levelText.text = "Level " + level.ToString();
        levelText.GetComponent<Animation>().Play();
        Time.timeScale = 1;
    }



    void Update()
    {
        if (skillExplanationPanel.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                skillExplanationPanel.SetActive(false);
            }
        }
    }


    public void openSkillInfos()
    {

        if (skillExplanationPanel.activeInHierarchy)
        {
            skillExplanationPanel.SetActive(false);
            Time.timeScale = 1;

        }
        else
        {
            skillExplanationPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void instantiateBlock()
    {
        level++;
        levelText.text = "Level " + level.ToString();
        levelText.GetComponent<Animation>().Play();
        BLOCK_SPEED = BLOCK_SPEED * BLOCK_SPEED_INCREASE_RATE;
        Instantiate(blockPrefab, startingTransform.position, startingTransform.rotation);
    }


    public void openGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = score.ToString();
    }


    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    private void pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }


    public void retryBtn()
    {
        Plank.isDead = false;
        GameManager.score = 0;
        GameManager.level = 1;

        SceneManager.LoadScene("GameScene");
    }


    public void homeBtn()
    {
        SceneManager.LoadScene("HomeScene");
    }



    public void menuButton()
    {


        if (Time.timeScale == 1)
        {
            pause();
        }
        else if (Time.timeScale == 0)
        {
            resume();
        }

    }

    public void quitButton()
    {
        Application.Quit();
    }





}
