using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSound : MonoBehaviour
{


    [SerializeField] private Ball ball = null;
    private AudioSource source;

    [SerializeField] private AudioClip[] hitPlankSounds = null;
    [SerializeField] private AudioClip hitMetalSound = null;


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
    }

}
