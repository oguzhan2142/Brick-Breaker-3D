using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHome : MaterialSelector
{

    public const string KEY = "Ball";

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
