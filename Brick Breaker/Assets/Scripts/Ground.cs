using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    [SerializeField] private Material normalMat = null;
    [SerializeField] private Material skillMat = null;


    private Renderer ren;


    void Start()
    {
        ren = GetComponent<Renderer>();
    }


    void Update()
    {
        if (Skills.isGroundState)
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
}
