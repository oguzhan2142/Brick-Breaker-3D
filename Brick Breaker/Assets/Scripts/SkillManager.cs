using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    [SerializeField] private Transform skillsTransform = null;

    [SerializeField] private GameObject goldenGroundButton = null;
    [SerializeField] private GameObject goldenPlankButton = null;
    [SerializeField] private GameObject fireballButton = null;



    [SerializeField] private GameObject skillSelectPanel = null;

    void Start()
    {
        Instantiate(fireballButton, skillsTransform, false);
        Instantiate(goldenGroundButton, skillsTransform, false);
        Instantiate(goldenPlankButton, skillsTransform, false);
    }





    public void skillSelectButton()
    {
        if (skillSelectPanel.activeInHierarchy)
        {
            skillSelectPanel.SetActive(false);
            Time.timeScale = 1;


        }
        else
        {
            skillSelectPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
