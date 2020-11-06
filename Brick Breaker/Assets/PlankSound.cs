using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankSound : MonoBehaviour
{

    private AudioSource source;

    [SerializeField] private AudioClip[] hitPlankSounds = null;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Ball")
        {



            source.clip = hitPlankSounds[Random.Range(0, hitPlankSounds.Length)];

            source.Play();
        }
    }

}
