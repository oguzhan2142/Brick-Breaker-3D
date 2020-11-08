using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{


    public static bool isGoldenPlankState = false;
    public static bool isFireballState = false;
    public static bool isGoldenGroundState = false;

    protected Ball ball = null;

    [SerializeField] private GameObject statePanel = null;
    [SerializeField] private Text cooldownText = null;
    private Button skillButton = null;

    protected float remainingCooldown = 0;
    public bool avaibleToUse = true;

    protected virtual void Start()
    {
        skillButton = GetComponent<Button>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        statePanel.SetActive(false);
    }


    protected virtual void Update()
    {
        if (remainingCooldown > 0)
        {
            avaibleToUse = false;
        }
        else
        {
            avaibleToUse = true;
        }

        if (!avaibleToUse)
        {

            if (skillButton.interactable)
            {
                skillButton.interactable = false;
            }

            if (!statePanel.activeInHierarchy)
            {
                statePanel.SetActive(true);
            }

            remainingCooldown -= Time.deltaTime;

            cooldownText.text = ((int)remainingCooldown).ToString();

        }
        else
        {
            if (!skillButton.interactable)
            {
                skillButton.interactable = true;
            }
            if (statePanel.activeInHierarchy)
            {
                statePanel.SetActive(false);
            }
        }

        if (ball.ballState == Ball.BallState.FirstShoot)
        {
            skillButton.interactable = false;
        }
    }



}
