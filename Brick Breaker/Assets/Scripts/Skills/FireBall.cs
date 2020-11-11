using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : Skill
{

    private Transform fireTransform = null;



    protected override void Start()
    {
        base.Start();


        fireTransform = ball.transform.Find("Fire");
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
            fireTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
