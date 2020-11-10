using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    private const float TIME_TO_MOVEMENT_ANIM = 3F;


    [SerializeField] private GameObject[] tutorialPanels = null;
    [SerializeField] private Ball ball = null;
    [SerializeField] private Transform horizontalLine = null;

    private float noMovementTimer = 0;

    void Start()
    {

        float y = GameObject.FindObjectOfType<ScreenTouch>().controlBoundY;
        var pos = horizontalLine.transform.position;
        pos.y = y;
        horizontalLine.transform.position = pos;

    }

    void Update()
    {
        if (ball.ballState == Ball.BallState.FirstShoot)
        {
            noMovementTimer += Time.deltaTime;

            if (noMovementTimer > TIME_TO_MOVEMENT_ANIM)
            {
                tutorialPanels[0].SetActive(true);
                if (!tutorialPanels[0].GetComponent<Animation>().isPlaying)
                {
                    tutorialPanels[0].GetComponent<Animation>().Play();
                }
            }
        }
        else
        {
            tutorialPanels[0].SetActive(false);
        }

    }

}
