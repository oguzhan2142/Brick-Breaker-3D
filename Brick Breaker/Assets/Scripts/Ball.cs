﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    private const float MAX_MAGNITUTE = 200;
    private const float SLOW_TIMESCALE_MODE = 0.3f;
    private const float MINIMUM_MAGNITUTE_FOR_AIR_STATE = 0.1F;
    private const int BRICK_LAYER = 10;
    public const float MAX_POWER = 3;
    private const float MAX_SPEED = 5f;
    private const float LINE_LENGTH = 2.7f;

    public Rigidbody rb = null;
    [SerializeField] private Plank plank = null;
    [SerializeField] private Material flameMaterial = null;
    [SerializeField] private Material normalMaterial = null;
    [SerializeField] private GameObject fireObject = null;

    public enum BallState { FirstShoot, OnAir }
    public BallState ballState;

    public enum MaterialState { normal, flame };
    public MaterialState materialState;

    public bool mouseDown = false;


    private float power = 0;
    private Vector3 hitVector;
    private float dirMagnitute;

    private Camera cam;
    private Renderer ren;

    private Block currentBlock = null;

    [SerializeField] LineRenderer lineRenderer = null;

    private Vector3 lastFrameVelocity;

    private Vector3 screenPosition;
    private void Awake()
    {
        ballState = BallState.FirstShoot;
        cam = Camera.main;

    }

    private void Start()
    {
        rb.velocity = Vector3.zero;
        ren = GetComponent<Renderer>();
        materialState = MaterialState.normal;
        currentBlock = GameObject.FindWithTag("Block").GetComponent<Block>();
    }



    private void Update()
    {
        if (ballState == BallState.FirstShoot)
        {
            plank.movable = false;
            currentBlock.movable = false;
        }
        else if (ballState == BallState.OnAir)
        {
            plank.movable = true;
            if (!currentBlock.movable)
            {
                currentBlock.movable = true;
            }
        }


        if (!Plank.isDead)
        {
            slowTimeWhenBallFalling();
        }


        updateMaterial();

        updateBallState();

        speedCheck();

        uppperBoundCheck();

        if (ballState == Ball.BallState.FirstShoot && mouseDown)
        {
            calculateHitVector();
            drawLine();
        }

        if (Skills.isFlameState)
        {
            rb.velocity = rb.velocity.normalized * MAX_SPEED;
        }

        leftRightBoundCheck();
        lastFrameVelocity = rb.velocity;
    }


    private void slowTimeWhenBallFalling()
    {
        if (!Skills.isGroundState)
        {
            if (rb.velocity.y < 0)
            {
                if (transform.position.y < plank.transform.position.y)
                {
                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = SLOW_TIMESCALE_MODE;
                    }
                }
            }
        }
        else
        {
            if (Time.timeScale == SLOW_TIMESCALE_MODE)
            {
                Time.timeScale = 1;
            }

        }
    }

    private void calculateHitVector()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 ball2D = cam.WorldToScreenPoint(transform.position);
        Vector3 dir = -mousePos + ball2D;
        dirMagnitute = dir.magnitude;
        Vector3 dirNormalized = dir.normalized;
        power = dirMagnitute / MAX_MAGNITUTE * MAX_POWER;
        hitVector = new Vector3(dirNormalized.x, dirNormalized.y, 0) * power;
    }

    private void drawLine()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, (hitVector.normalized * LINE_LENGTH) + transform.position);
    }

    private void updateMaterial()
    {
        if (materialState.Equals(MaterialState.normal) && !ren.material.Equals(normalMaterial))
        {
            ren.material = normalMaterial;
            fireObject.SetActive(false);
        }
        else if (materialState.Equals(MaterialState.flame) && !ren.material.Equals(flameMaterial))
        {
            ren.material = flameMaterial;
            fireObject.SetActive(true);

        }
    }

    private void leftRightBoundCheck()
    {
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0)
        {
            rb.velocity = new Vector3(Mathf.Abs(rb.velocity.x), rb.velocity.y, rb.velocity.z);
        }
        if (screenPosition.x > Screen.width)
        {
            rb.velocity = new Vector3(-Mathf.Abs(rb.velocity.x), rb.velocity.y, rb.velocity.z);
        }
    }

    private void speedCheck()
    {
        if (rb.velocity.magnitude > MAX_SPEED)
        {
            rb.velocity = rb.velocity.normalized * MAX_SPEED;
        }
    }

    private void uppperBoundCheck()
    {
        if (currentBlock)
        {

            if (transform.position.y > currentBlock.topOfBlocksTransform.position.y)
            {
                rb.velocity = new Vector3(rb.velocity.x, -Mathf.Abs(rb.velocity.y), rb.velocity.z);
                materialState = MaterialState.normal;
                Skills.isFlameState = false;
            }
        }
        else
        {
            currentBlock = GameObject.FindWithTag("Block").GetComponent<Block>();
        }
    }

    private void updateBallState()
    {
        if (rb.velocity.magnitude > MINIMUM_MAGNITUTE_FOR_AIR_STATE)
        {
            ballState = BallState.OnAir;
        }
        else
        {
            ballState = BallState.FirstShoot;
        }
    }

    private void OnMouseDown()
    {
        if (ballState == BallState.FirstShoot)
        {
            mouseDown = true;
        }
    }

    private void OnMouseUp()
    {
        if (ballState == BallState.FirstShoot)
        {
            mouseDown = false;
            lineRenderer.positionCount = 0;
            rb.AddForce(hitVector, ForceMode.Impulse);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (Plank.isDead)
        {
            return;
        }
        if (other.collider.tag == "Ground")
        {
            // plank.transform.position = new Vector3(0, plank.transform.position.y, plank.transform.position.z);
            // transform.position = new Vector3(plank.transform.position.x, plank.transform.position.y, plank.transform.position.z);
            // rb.velocity = Vector3.zero;
            // ballState = BallState.FirstShoot;


            if (Skills.isGroundState)
            {

                reflect(other.contacts[0].normal);
                Skills.isGroundState = false;
            }
            else
            {
                rb.useGravity = true;
                plank.die();
            }



        }



        if (other.collider.tag == "BrickPart")
        {

            other.collider.gameObject.layer = BRICK_LAYER;
            other.collider.attachedRigidbody.isKinematic = false;

            if (Skills.isFlameState)
            {
                rb.velocity = lastFrameVelocity;
            }
            else
            {
                reflect(other.contacts[0].normal);
            }
        }


        if (other.collider.tag == "SideWall")
        {
            reflect(other.contacts[0].normal);
        }

        if (other.collider.tag == "Plank" && ballState != BallState.FirstShoot)
        {
            // rb.AddForce(other.impulse * PLANK_HIT_COEFICIENT, ForceMode.Impulse);
            reflect(other.contacts[0].normal);
        }

    }


    private void reflect(Vector3 normal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, normal);
        rb.velocity = direction * Mathf.Max(speed, 10);
    }
}