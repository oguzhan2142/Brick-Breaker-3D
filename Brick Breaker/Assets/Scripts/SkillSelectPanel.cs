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
    [SerializeField] private TextMeshProUGUI costText = null;
    [SerializeField] private Transform currentSkills = null;

    [HideInInspector] public Skill selectedSkill = null;


    void Start()
    {
        allSkillsPanel.GetChild(0).GetComponent<SkillButton>().onClick();
    }


    void OnEnable()
    {
        if (!SkillManager.CHANGES_PENDING)
        {
            destroyPendingSkills();
            createPendingSkills();
        }
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
        costText.text = selectedSkill.cost.ToString() + " birim";
        cooldownInfoText.text = selectedSkill.cooldown.ToString() + " sn";
    }


    private void createPendingSkills()
    {

        foreach (Transform currentSkill in currentSkills)
        {
            instantiateSelectedSkillBtn(currentSkill.GetComponent<Skill>());
        }

    }



    private void destroyPendingSkills()
    {
        foreach (Transform item in pendingSkillsPanel)
        {
            Destroy(item.gameObject);
        }
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
            instantiateSelectedSkillBtn(selectedSkill);
            SkillManager.CHANGES_PENDING = true;
        }
    }

    private void instantiateSelectedSkillBtn(Skill skill)
    {
        GameObject btn = Instantiate(selectedSkillButtonPrefab, pendingSkillsPanel.transform, false);
        btn.GetComponent<SelectedSkillButton>().skill = skill;
        btn.GetComponent<Image>().sprite = skill.sprite;
        btn.GetComponent<Button>().onClick.AddListener(() =>
        {
            Destroy(btn.gameObject);
            SkillManager.CHANGES_PENDING = true;
        });
    }

    public void disableAllSelectedImages()
    {
        foreach (Transform btn in allSkillsPanel)
        {
            btn.GetComponent<SkillButton>().selectedImage.SetActive(false);
        }
    }
}
