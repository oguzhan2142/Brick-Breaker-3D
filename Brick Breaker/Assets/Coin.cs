using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public static int GOLD_COIN_VALUE = 50;
    public static int SILVER_COIN_VALUE = 30;
    public static int COPPER_COIN_VALUE = 10;

    private const float SPEED = 1f;

    void Update()
    {
        var pos = transform.position;
        pos.y -= Time.deltaTime * SPEED;
        transform.position = pos;

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision other)
    {



        if (other.collider.tag == "Plank")
        {
            if (tag == "GoldCoin")
            {
                GameManager.budged += GOLD_COIN_VALUE;
            }
            else if (tag == "SilverCoin")
            {
                GameManager.budged += SILVER_COIN_VALUE;
            }
            else if (tag == "CopperCoin")
            {
                GameManager.budged += COPPER_COIN_VALUE;
            }
            Destroy(gameObject);
        }


        if (other.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }



}
