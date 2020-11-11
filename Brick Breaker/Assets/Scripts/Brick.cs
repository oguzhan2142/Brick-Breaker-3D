using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{

    private const int COPPER_CHANCE = 50;
    private const int SILVER_CHANCE = 30;
    private const int GOLD_CHANCE = 10;

    [SerializeField] private GameObject[] coinPrefabs = null;

    void Update()
    {
        if (transform.childCount == 0 )
        {

            int random = Random.Range(0, 50);

            if (random < GOLD_CHANCE)
            {
                Instantiate(coinPrefabs[0], transform.position, coinPrefabs[0].transform.rotation);
            }
            else if (random < SILVER_CHANCE)
            {
                
                Instantiate(coinPrefabs[1], transform.position, coinPrefabs[1].transform.rotation);
            }
            else if (random < GOLD_CHANCE)
            {
                Instantiate(coinPrefabs[2], transform.position, coinPrefabs[2].transform.rotation);
            }

            Destroy(gameObject);
        }
    }

}
