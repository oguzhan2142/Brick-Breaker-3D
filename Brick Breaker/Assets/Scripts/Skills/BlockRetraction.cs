using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockRetraction : Skill
{

    private const float RISE_AMOUNT = 1.5F;

    private GameManager gameManager;

    protected override void Start()
    {
        base.Start();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        GetComponent<Button>().onClick.AddListener(use);
    }

    protected override void Update()
    {
        base.Update();
    }



    private void use()
    {
        GameObject currentBlock = GameObject.FindGameObjectWithTag("Block");

        if (avaibleToUse && currentBlock != null)
        {

            var Y = currentBlock.transform.position.y;

            if (RISE_AMOUNT + Y > gameManager.startingTransform.position.y)
            {
                Y = gameManager.startingTransform.position.y;
            }
            else
            {
                Y = RISE_AMOUNT + Y;
            }


            currentBlock.transform.position = new Vector3(currentBlock.transform.position.x, Y, currentBlock.transform.position.z);
            remainingCooldown = cooldown;
        }
    }
}
