using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSelectPanel : MonoBehaviour
{

    [SerializeField] private Transform pendingSkillsPanel = null;
    [SerializeField] private GameObject selectedSkillButtonPrefab = null;
    [SerializeField] private Transform allSkillsPanel = null;

    [SerializeField] private TextMeshProUGUI cooldownInfoText = null;
    [SerializeField] private TextMeshProUGUI explanationText = null;

    [HideInInspector] public Skill selectedSkill = null;
    [SerializeField] private Transform currentSkillsContainer = null;
    

    void Start()
    {
        allSkillsPanel.GetChild(0).GetComponent<SkillButton>().onClick();
    }


    private void Update()
    {
        if (!gameObject.activeInHierarchy)
            return;

        if (selectedSkill == null)
        {
            allSkillsPanel.GetChild(0).GetComponent<SkillButton>().onClick();
        }


        explanationText.text = selectedSkill.explanation;
        cooldownInfoText.text = selectedSkill.cooldown.ToString();
    }

   

   


    public void addSkill()
    {

        foreach (Transform skill in pendingSkillsPanel.transform)
        {

            if (skill.GetComponent<SelectedSkillButton>().skill.GetType().Equals(selectedSkill.GetType()))
            {
                return;
            }
        }


        if (pendingSkillsPanel.transform.childCount < 2)
        {

            GameObject btn = Instantiate(selectedSkillButtonPrefab, pendingSkillsPanel.transform, false);
            btn.GetComponent<SelectedSkillButton>().skill = selectedSkill;
            btn.GetComponent<Image>().sprite = selectedSkill.sprite;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                Destroy(btn.gameObject);
            });
        }
    }

    public void disableAllSelectedImages()
    {
        foreach (Transform btn in allSkillsPanel)
        {
            btn.GetComponent<SkillButton>().selectedImage.SetActive(false);
        }
    }
}
