using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static int GOLD_COIN_VALUE = 50;
    public static int SILVER_COIN_VALUE = 30;
    public static int COPPER_COIN_VALUE = 10;

    private const float VERTICAL_SPEED = 1f;
    private const float HORIZONTAL_SPEED = 0.2F;

    private Transform plank;


    private GameManager gameManager;

    void Start()
    {
        plank = GameObject.FindGameObjectWithTag("Plank").transform;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        var pos = transform.position;

        float directionSign;


        if (pos.x > plank.position.x)
        {
            directionSign = -1;
        }
        else if (pos.x < plank.position.x)
        {
            directionSign = 1;
        }
        else
        {
            directionSign = 0;
        }

        pos.y -= Time.deltaTime * VERTICAL_SPEED;
        pos.x += directionSign * Time.deltaTime * HORIZONTAL_SPEED;


        transform.position = pos;

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision other)
    {


        var screenPos = Camera.main.WorldToScreenPoint(plank.transform.position);


        if (other.collider.tag == "Plank")
        {
            if (tag == "GoldCoin")
            {
                GameManager.budged += GOLD_COIN_VALUE;
                gameManager.openPopupPanel(screenPos, GOLD_COIN_VALUE, Color.green);
            }
            else if (tag == "SilverCoin")
            {
                GameManager.budged += SILVER_COIN_VALUE;
                gameManager.openPopupPanel(screenPos, SILVER_COIN_VALUE, Color.green);
            }
            else if (tag == "CopperCoin")
            {
                GameManager.budged += COPPER_COIN_VALUE;
                gameManager.openPopupPanel(screenPos, COPPER_COIN_VALUE, Color.green);
            }

            Destroy(gameObject);
        }


        if (other.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }



}
