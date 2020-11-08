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


    public void addSkill()
    {
        if (selectedSkillsPanel.transform.childCount < 3)
        {

            GameObject btn = Instantiate(selectedSkillButtonPrefab, selectedSkillsPanel.transform, false);
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
