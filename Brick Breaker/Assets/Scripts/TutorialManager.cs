using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    bool tutorialFinished = false;
    [SerializeField] private GameObject skillExplanationPanel = null;
    [SerializeField] private GameObject[] tutorialPanels = null;
    [SerializeField] private Ball ball = null;

    int hasPlayed;
    int tutorialIndex = 0;

    float cooldownAfterBallLaunched = 1f;
    Vector3 ballLastVelocity;
    void Start()
    {


        hasPlayed = PlayerPrefs.GetInt("HasPlayed");

        if (hasPlayed == 0)
        {
            PlayerPrefs.SetInt("HasPlayed", 1);
            gameObject.SetActive(true);
        }
        else
        {
            // Not First Time
            gameObject.SetActive(false);
        }
    }

    void Update()
    {

        
        


        if (hasPlayed == 0)
        {
            updatePanelsActiviness();

            if (!tutorialFinished)
            {
                updateTutorial();
            }
        }


    }

    private void updatePanelsActiviness()
    {
        if (tutorialIndex >= tutorialPanels.Length)
        {
            tutorialFinished = true;
        }

        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialPanels[i].SetActive(true);
                if (i == 2)
                {
                    skillExplanationPanel.SetActive(true);
                }
            }
            else
            {
                tutorialPanels[i].SetActive(false);
                if (i == 2)
                {
                    skillExplanationPanel.SetActive(false);
                }
            }
        }
    }

    private void updateTutorial()
    {

        if (tutorialIndex == 0)
        {


            if (Input.GetMouseButton(0))
            {
                tutorialPanels[tutorialIndex].SetActive(false);
            }
            if (!tutorialPanels[tutorialIndex].GetComponent<Animation>().isPlaying)
            {
                tutorialPanels[tutorialIndex].GetComponent<Animation>().Play();
            }
            if (ball.ballState != Ball.BallState.FirstShoot)
            {
                tutorialIndex++;

            }

        }


        if (tutorialIndex == 1)
        {
            ball.ballState = Ball.BallState.OnAir;
            if (cooldownAfterBallLaunched <= 0)
            {
                if (!ball.rb.velocity.Equals(Vector3.zero))
                {
                    ballLastVelocity = ball.rb.velocity;
                }
                ball.rb.velocity = Vector3.zero;
            }
            else
            {
                cooldownAfterBallLaunched -= Time.deltaTime;
            }

            if (cooldownAfterBallLaunched > 0)
            {
                tutorialPanels[1].SetActive(false);
                return;
            }
            if (!tutorialPanels[tutorialIndex].GetComponent<Animation>().isPlaying)
            {
                tutorialPanels[tutorialIndex].GetComponent<Animation>().Play();
            }
            if (Input.GetMouseButtonUp(0))
            {

                if (Input.mousePosition.x < Screen.width / 4 || Input.mousePosition.x > Screen.width / 4 * 3)
                {

                    tutorialIndex++;
                    ball.rb.velocity = ballLastVelocity;
                }
            }
        }


        if (tutorialIndex == 2)
        {

            if (!ball.rb.velocity.Equals(Vector3.zero))
            {
                ballLastVelocity = ball.rb.velocity;
            }
            ball.rb.velocity = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                tutorialIndex++;
                ball.rb.velocity = ballLastVelocity;
            }

        }
    }



}
