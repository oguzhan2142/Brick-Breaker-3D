using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenGround : Skill
{

    private const float TIME_FOR_GOLDEN_GROUND = 2F;

    private Renderer groundRenderer = null;

    private enum MaterialState { normal, stone };
    private MaterialState materialState;

    [SerializeField] private Material normalMaterial = null;
    [SerializeField] private Material goldMaterial = null;

    private float standTimer = 0;

    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Start()
    {
        base.Start();
    
        groundRenderer = GameObject.FindWithTag("Ground").GetComponent<Renderer>();
        GetComponent<Button>().onClick.AddListener(use);
    }

    protected override void Update()
    {
        base.Update();

        if (materialState.Equals(MaterialState.normal) && !groundRenderer.material.Equals(normalMaterial))
        {
            groundRenderer.material = normalMaterial;
        }
        else if (materialState.Equals(MaterialState.stone) && !groundRenderer.material.Equals(goldMaterial))
        {
            groundRenderer.material = goldMaterial;
        }

        if (isGoldenGroundState)
        {
            standTimer += Time.deltaTime;
            if (standTimer > TIME_FOR_GOLDEN_GROUND)
            {
                materialState = MaterialState.normal;
                isGoldenGroundState = false;
                standTimer = 0;
            }
        }

    }


    public void use()
    {

        if (avaibleToUse)
        {
            materialState = MaterialState.stone;
            Skill.isGoldenGroundState = true;
            remainingCooldown = cooldown;
        }
    }
}
