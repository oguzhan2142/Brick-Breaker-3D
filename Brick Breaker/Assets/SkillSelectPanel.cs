using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectPanel : MonoBehaviour
{

    [SerializeField] private GameObject selectedSkillsPanel = null;
    [SerializeField] private GameObject selectedSkillButtonPrefab = null;
    [SerializeField] private Transform allSkillsPanel = null;



    void Start()
    {

    }



    public void disableAllSelectedImages()
    {
        foreach (Transform btn in allSkillsPanel)
        {
            btn.GetComponent<SkillButton>().selectedImage.SetActive(false);
        }
    }
}
