﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankHome : MaterialSelector
{
    public const string KEY = "Plank";

    protected override void Start()
    {
        base.Start();
        index = PlayerPrefs.GetInt(KEY);
        changeMaterial();
    }


    void Update()
    {
        PlayerPrefs.SetInt(KEY, index);
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
}
