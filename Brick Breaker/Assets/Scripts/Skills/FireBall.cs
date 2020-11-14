using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : Skill
{

    protected override void Start()
    {
        base.Start();


        GetComponent<Button>().onClick.AddListener(useSkill);
    }

    protected override void Update()
    {
        base.Update();

        if (isFireballState)
        {
            ball.materialState = Ball.MaterialState.flame;
        }
        else
        {
            ball.materialState = Ball.MaterialState.normal;
        }
        if (ball.rb.velocity != Vector3.zero)
        {
            float angle = Mathf.Atan2(ball.rb.velocity.y, ball.rb.velocity.x) * Mathf.Rad2Deg;
            ball.fireObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (isFireballState)
        {
            ball.fireObject.SetActive(true);
        }
        else
        {
            ball.fireObject.SetActive(false);
        }

    }

    public void useSkill()
    {

        if (!isBudgedEnough())
            return;


        if (avaibleToUse)
        {
            ball.materialState = Ball.MaterialState.flame;
            Skill.isFireballState = true;
            remainingCooldown = cooldown;
        }
    }
}
