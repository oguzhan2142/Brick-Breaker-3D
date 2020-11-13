using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSound : MonoBehaviour
{


    [SerializeField] private Ball ball = null;
    private AudioSource source;

    [SerializeField] private AudioClip[] hitPlankSounds = null;
    [SerializeField] private AudioClip hitMetalSound = null;
    [SerializeField] private AudioClip coinSound = null;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Ball")
        {
            if (Skill.isGoldenPlankState)
            {
                source.clip = hitMetalSound;
                source.Play();
            }
            else
            {
                if (ball.ballState != Ball.BallState.FirstShoot)
                {
                    source.clip = hitPlankSounds[Random.Range(0, hitPlankSounds.Length)];
                    source.Play();
                }
            }
        }

        if (other.collider.tag == "CopperCoin" || other.collider.tag == "SilverCoin" || other.collider.tag == "GoldCoin")
        {
            source.clip = coinSound;
            source.Play();
        }
    }

}
