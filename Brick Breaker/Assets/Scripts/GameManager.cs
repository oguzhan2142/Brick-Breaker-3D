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

    public Transform startingTransform = null;
    public static int score = 0;
    public static int level = 1;

    public TextMeshProUGUI gameOverScoreText = null;
    public static int budged = 40;

    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject gameOverMenu = null;
    [SerializeField] private GameObject blockPrefab = null;
    [SerializeField] private GameObject settingsMenu = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private TextMeshProUGUI budgedText = null;


    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelText.text = "Level " + level.ToString();
        levelText.GetComponent<Animation>().Play();
        Time.timeScale = 1;
    }


    void Update()
    {
        budgedText.text = budged.ToString();
    }


    public void instantiateBlock()
    {

        level++;
        levelText.text = "Level " + level.ToString();
        levelText.GetComponent<Animation>().Play();
        audioSource.Play();
        BLOCK_SPEED = BLOCK_SPEED * BLOCK_SPEED_INCREASE_RATE;
        Instantiate(blockPrefab, startingTransform.position, startingTransform.rotation);
        
    }


    public void openGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        gameOverScoreText.text = score.ToString();
    }

    public void openSettings()
    {
        settingsMenu.SetActive(true);

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
