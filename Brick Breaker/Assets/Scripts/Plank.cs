using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plank : MonoBehaviour
{

    private const float DELTA_BLOODINESS = 0.2F;
    private const float MAX_BLOODINESS = 1;
    private const float TIME_FOR_RECOVER = 3F;

    public static bool isDead = false;
    public bool movable;
    [SerializeField] private Image bloodyBackground = null;

    [SerializeField] private GameManager gameManager = null;
    private float bloodiness = 0;

    public Transform leftEnd = null;
    public Transform rightEnd = null;


    private float timer = 0;



    private void Update()
    {
        var color = bloodyBackground.color;
        color.a = bloodiness;
        bloodyBackground.color = color;





        if (bloodiness > 0)
        {
            timer += Time.deltaTime;
        }


        if (timer > TIME_FOR_RECOVER && bloodiness > 0)
        {
            bloodiness -= DELTA_BLOODINESS;

            timer = 0;
        }

    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Ball")
        {

            // Vector3 force = new Vector3(other.relativeVelocity.x, -other.relativeVelocity.y, other.relativeVelocity.z);
            // other.collider.GetComponent<Rigidbody>().AddForce(force * shootPower);

        }


        if (other.collider.tag == "BrickPart")
        {

            if (Skills.isStoneStand || isDead)
                return;

            bloodiness += DELTA_BLOODINESS;

            if (bloodiness >= MAX_BLOODINESS)
            {
                bloodiness = MAX_BLOODINESS;
                die();
            }

        }

    }


    public void die()
    {
        gameManager.openGameOverMenu();
        SaveScore save = new SaveScore();

        save.saveScore(GameManager.score);
        isDead = true;
        movable = false;

        Time.timeScale = 1;
    }


}
