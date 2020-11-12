using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHome : MaterialSelector
{

    public const string KEY = "Block";

    private Renderer[] renderers;


    protected override void Start()
    {
        base.Start();
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void rightBtn()
    {
        increaseIndex();
        anim.Play("GoRight");
    }

    public void leftBtn()
    {
        decreaseIndex();
        anim.Play("GoLeft");
    }

    void Update()
    {
        PlayerPrefs.SetInt(KEY, index);
    }
    public override void changeMaterial()
    {
        foreach (var rend in renderers)
        {
            rend.material = materials[index];
        }

    }
}
