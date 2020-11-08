using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenPlank : Skill
{
    public const float GOLDENPLANK_COOLDOWN = 10;
    private const float TIME_FOR_GOLDEN_PLANK = 2F;

    [SerializeField] private Material normalMaterial = null;
    [SerializeField] private Material goldMaterial = null;
    private Renderer plankRenderer;

    private enum MaterialState { normal, stone };
    private MaterialState materialState;


    private float standTimer = 0;


    protected override void Start()
    {
        base.Start();
        plankRenderer = GameObject.FindWithTag("Plank").GetComponent<Renderer>();
        GetComponent<Button>().onClick.AddListener(use);
    }

    protected override void Update()
    {
        base.Update();


        if (materialState.Equals(MaterialState.normal) && !plankRenderer.material.Equals(normalMaterial))
        {
            plankRenderer.material = normalMaterial;
        }
        else if (materialState.Equals(MaterialState.stone) && !plankRenderer.material.Equals(goldMaterial))
        {
            plankRenderer.material = goldMaterial;
        }

        if (isGoldenPlankState)
        {
            standTimer += Time.deltaTime;
            if (standTimer > TIME_FOR_GOLDEN_PLANK)
            {
                materialState = MaterialState.normal;
                isGoldenPlankState = false;
                standTimer = 0;
            }
        }
    }


    public void use()
    {

        if (avaibleToUse)
        {
            materialState = MaterialState.stone;
            Skill.isGoldenPlankState = true;
            remainingCooldown = GOLDENPLANK_COOLDOWN;
        }
    }
}
