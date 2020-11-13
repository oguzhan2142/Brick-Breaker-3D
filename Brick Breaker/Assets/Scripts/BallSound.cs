using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{

    [SerializeField] private AudioClip fireballSound = null;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();   
        source.loop = true; 
        source.clip = fireballSound;
    }

    void Update()
    {
        if (Skill.isFireballState)
        {
            
            if (!source.isPlaying)
            {
                source.Play();
            }

        }else if (source.isPlaying)
        {
            
            source.Stop();
        }
    }
}
