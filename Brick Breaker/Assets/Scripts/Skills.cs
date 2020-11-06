using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{

    private const float TIME_FOR_STONE_STAND = 2F;
    private const float STONESTAND_COOLDOWN = 10;
    private const float FLAMESTATE_COOLDOWN = 20;
    private const float GROUND_COOLDOWN = 40;



    [SerializeField] private GameObject fireStatePanel = null;
    [SerializeField] private GameObject stoneStatepanel = null;
    [SerializeField] private GameObject groundStatepanel = null;

    [SerializeField] private Text flameCooldownText = null;
    [SerializeField] private Text stoneCooldownText = null;
    [SerializeField] private Text groundCooldownText = null;
    [SerializeField] private Button stoneSkillButton = null;
    [SerializeField] private Button flameSkillButton = null;
    [SerializeField] private Button groundSkillButton = null;
    [SerializeField] private Material normalMaterial = null;
    [SerializeField] private Material stoneMaterial = null;
    [SerializeField] private Transform flameTransform = null;
    [SerializeField] private Ball ball = null;


    private enum MaterialState { normal, stone };
    private MaterialState materialState;

    private Renderer ren;

    private float stoneStandTimer = 0;


    private bool stoneStandAvaible = true;
    private bool flameStandAvaible = true;
    private bool groundStandAvaible = true;

    private float stoneRemainingCooldown = 0;
    private float flameRemainingCooldown = 0;
    private float groundRemainingCooldown = 0;

    public static bool isStoneStand = false;
    public static bool isFlameState = false;
    public static bool isGroundState = false;

    void Start()
    {
        materialState = MaterialState.normal;
        ren = GetComponent<Renderer>();
    }


    void Update()
    {
        NewMethod(ref stoneRemainingCooldown, stoneStandAvaible, stoneSkillButton, stoneStatepanel, stoneCooldownText);
        NewMethod(ref flameRemainingCooldown, flameStandAvaible, flameSkillButton, fireStatePanel, flameCooldownText);
        NewMethod(ref groundRemainingCooldown, groundStandAvaible, groundSkillButton, groundStatepanel, groundCooldownText);



        if (materialState.Equals(MaterialState.normal) && !ren.material.Equals(normalMaterial))
        {
            ren.material = normalMaterial;
        }
        else if (materialState.Equals(MaterialState.stone) && !ren.material.Equals(stoneMaterial))
        {
            ren.material = stoneMaterial;
        }


        if (isFlameState)
        {
            ball.materialState = Ball.MaterialState.flame;
        }
        else
        {
            ball.materialState = Ball.MaterialState.normal;

        }

        if (isStoneStand)
        {
            stoneStandTimer += Time.deltaTime;
            if (stoneStandTimer > TIME_FOR_STONE_STAND)
            {
                materialState = MaterialState.normal;
                isStoneStand = false;
                stoneStandTimer = 0;
            }

        }



        if (ball.rb.velocity != Vector3.zero)
        {

            float angle = Mathf.Atan2(ball.rb.velocity.y, ball.rb.velocity.x) * Mathf.Rad2Deg;
            flameTransform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

    }

    private void NewMethod(ref float cooldown, bool avaible, Button skillButton, GameObject statePanel, Text cooldownText)
    {

        if (cooldown > 0)
        {

            avaible = false;
        }
        else
        {

            avaible = true;
        }

        if (!avaible)
        {

            if (skillButton.interactable)
            {
                skillButton.interactable = false;
            }

            if (!statePanel.activeInHierarchy)
            {
                statePanel.SetActive(true);
            }

            cooldown = cooldown - Time.deltaTime;

            cooldownText.text = ((int)cooldown).ToString();

        }
        else
        {
            if (!skillButton.interactable)
            {
                skillButton.interactable = true;
            }
            if (statePanel.activeInHierarchy)
            {
                statePanel.SetActive(false);
            }
        }

        if (ball.ballState == Ball.BallState.FirstShoot)
        {
            skillButton.interactable = false;
        }
    }

    public void stoneStand()
    {

        if (stoneStandAvaible)
        {

            materialState = MaterialState.stone;
            isStoneStand = true;
            stoneRemainingCooldown = STONESTAND_COOLDOWN;
        }
    }

    public void flameState()
    {
        if (flameStandAvaible)
        {
            ball.materialState = Ball.MaterialState.flame;
            isFlameState = true;
            flameRemainingCooldown = FLAMESTATE_COOLDOWN;
        }
    }

    public void ground()
    {
        if (groundStandAvaible)
        {
            groundRemainingCooldown = GROUND_COOLDOWN;
            isGroundState = true;
        }
    }
}
