﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{

    public Skill skill;
    private SkillSelectPanel skillSelectPanel;


    [HideInInspector] public GameObject selectedImage = null;

    void Start()
    {
        skillSelectPanel = GameObject.FindObjectOfType<SkillSelectPanel>();
        selectedImage = transform.Find("SelectedImage").gameObject;

        GetComponent<Button>().onClick.AddListener(onClick);
    }



    public void onClick()
    {
        if (skillSelectPanel == null)
        {
            skillSelectPanel = GameObject.FindObjectOfType<SkillSelectPanel>();
        }
        skillSelectPanel.disableAllSelectedImages();
        selectedImage.SetActive(true);
        skillSelectPanel.selectedSkill = this.skill;
    }
}