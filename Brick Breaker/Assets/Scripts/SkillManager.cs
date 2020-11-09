using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    public static bool CHANGES_PENDING = false;


    [SerializeField] private Transform skillsTransform = null;
    [SerializeField] private GameObject[] skillButtonPrefabs = null;
    [SerializeField] private GameObject skillSelectPanel = null;
    [SerializeField] private Transform pendingSkillsContainer = null;
    [SerializeField] private GameObject pendingBackground = null;

    void Start()
    {
        Instantiate(skillButtonPrefabs[0], skillsTransform, false);
        Instantiate(skillButtonPrefabs[3], skillsTransform, false);
    }


    private void Update()
    {
        if (areTherePendingSkills())
        {
            pendingBackground.SetActive(false);
        }
        else
        {
            pendingBackground.SetActive(true);
        }
    }
    private bool areTherePendingSkills()
    {

        foreach (Transform pending in pendingSkillsContainer)
        {

            if (pendingSkillsContainer.childCount == 0)
            {
                return false;
            }

            bool contains = false;
            foreach (Transform current in skillsTransform)
            {
                if (pending.GetComponent<SelectedSkillButton>().skill.GetType().Equals(current.GetComponent<Skill>().GetType()))
                {
                    contains = true;
                }
            }
            if (!contains)
            {
                return false;
            }
        }

        return true;
    }


    public void syncCurrentSkillsWithPending()
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

        // Degisiklikler bitti
        CHANGES_PENDING = false;
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
