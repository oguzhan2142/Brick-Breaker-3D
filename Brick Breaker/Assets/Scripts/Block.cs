using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{


    [SerializeField] private Transform bricksTransform = null;

    public bool movable = false;
    public Transform topOfBlocksTransform = null;


    private GameManager gameManager;
    private Plank plank;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        plank = GameObject.Find("Plank").GetComponent<Plank>();
    }


    void Update()
    {
        if (movable)
        {
            transform.Translate(Vector3.down * GameManager.BLOCK_SPEED * Time.deltaTime);
        }


        if (transform.position.y < plank.transform.position.y)
        {
            plank.die();
        }

        if (bricksTransform.childCount == 0)
        {
            gameManager.instantiateBlock();
            Destroy(gameObject);
        }

    }






}
