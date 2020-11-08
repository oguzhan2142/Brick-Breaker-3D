using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    [SerializeField] private Transform skillsTransform = null;

    [SerializeField] private GameObject goldenGroundButton = null;
    [SerializeField] private GameObject goldenPlankButton = null;
    [SerializeField] private GameObject fireballButton = null;


    void Start()
    {
        Instantiate(fireballButton, skillsTransform, false);
        Instantiate(goldenGroundButton, skillsTransform, false);
        Instantiate(goldenPlankButton, skillsTransform, false);
    }




   

    // public void flameState()
    // {
    //     if (flameStandAvaible)
    //     {
    //         ball.materialState = Ball.MaterialState.flame;
    //         isFlameState = true;
    //         flameRemainingCooldown = FLAMESTATE_COOLDOWN;
    //     }
    // }

    // public void ground()
    // {
    //     if (groundStandAvaible)
    //     {
    //         groundRemainingCooldown = GROUND_COOLDOWN;
    //         isGroundState = true;
    //     }
    // }
}
