using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    [SerializeField] private Transform skillsTransform = null;


    [SerializeField] private GameObject[] skillButtonPrefabs = null;


    [SerializeField] private GameObject skillSelectPanel = null;
    [SerializeField] private Transform pendingSkillsContainer = null;

    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            updatePendingSkills();
        }
    }

    public void updatePendingSkills()
    {

        //   Mevcut skilleri panelden silelim-skills

        foreach (Transform item in skillsTransform)
        {
            Destroy(item.gameObject);
        }

        // Bekleyen degisiklikleri ekleyelim-pendingSkillsContainer

        foreach (Transform selectedSkill in pendingSkillsContainer)
        {

            foreach (GameObject skillBtnPrefab in skillButtonPrefabs)
            {
                if (selectedSkill.GetComponent<SelectedSkillButton>().skill.GetType().Equals(skillBtnPrefab.GetComponent<Skill>().GetType()))
                {
                    Instantiate(skillBtnPrefab, skillsTransform, false);
                    break;
                }
            }


        }


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
