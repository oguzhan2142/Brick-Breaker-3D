using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MaterialSelector : MonoBehaviour
{

    [SerializeField] protected Material[] materials = null;
    protected Renderer ren = null;
    protected Animation anim = null;

    protected int index = 0;

    [SerializeField] private Transform arrows = null;

    protected virtual void Start()
    {
        ren = GetComponent<Renderer>();
        anim = GetComponent<Animation>();


        var screen = Camera.main.WorldToScreenPoint(transform.position);



        arrows.transform.position = screen;

    }


    protected void comeFromLeftAnim()
    {
        anim.Play("ComeFromLeft");
    }

    protected void comeFromRightAnim()
    {
        anim.Play("ComeFromRight");
    }

    public virtual void changeMaterial()
    {
        ren.material = materials[index];
    }

    protected void increaseIndex()
    {
        index++;
        if (index > materials.Length - 1)
            index = materials.Length - 1;
    }

    protected void decreaseIndex()
    {
        index--;
        if (index < 0)
            index = 0;
    }


}
