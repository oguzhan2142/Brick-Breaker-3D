using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSelectPanel : MonoBehaviour
{

    [SerializeField] private GameObject selectedSkillsPanel = null;
    [SerializeField] private GameObject selectedSkillButtonPrefab = null;
    [SerializeField] private Transform allSkillsPanel = null;

    [SerializeField] private TextMeshProUGUI cooldownInfoText = null;
    [SerializeField] private TextMeshProUGUI explanationText = null;

    [HideInInspector] public Skill selectedSkill = null;

    void Start()
    {
        allSkillsPanel.GetChild(0).GetComponent<SkillButton>().onClick();
    }


    private void Update()
    {
        explanationText.text = selectedSkill.explanation;
        cooldownInfoText.text = selectedSkill.cooldown.ToString();
    }

    public void disableAllSelectedImages()
    {
        foreach (Transform btn in allSkillsPanel)
        {
            btn.GetComponent<SkillButton>().selectedImage.SetActive(false);
        }
    }
}
