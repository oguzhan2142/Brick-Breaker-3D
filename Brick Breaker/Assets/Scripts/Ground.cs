using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField] private Material normalMat = null;
    [SerializeField] private Material skillMat = null;


    private Renderer ren;


    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        ren = GetComponent<Renderer>();
    }


    void Update()
    {
        if (Skill.isGoldenGroundState)
        {
            if (!ren.material.Equals(skillMat))
            {
                ren.material = skillMat;
            }
        }
        else
        {
            if (!ren.material.Equals(normalMat))
            {
                ren.material = normalMat;
            }
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ball" && Skill.isGoldenGroundState)
        {
            source.Play();
        }

    }
}
