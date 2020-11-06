using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPart : MonoBehaviour
{

    private const float EXPLOTION_RADIUS = 5F;


    [SerializeField] private GameObject cellPrefab = null;



    void Update()
    {

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }

    }


    void OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Ground" || other.collider.tag == "Plank" || other.collider.tag == "SideWall")
        {

            Destroy(gameObject);
            GameObject cell = Instantiate(cellPrefab, transform.position, transform.rotation);

            float explotionForce = other.impulse.magnitude;
            Rigidbody[] rigidbodies = cell.GetComponentsInChildren<Rigidbody>();
            foreach (var item in rigidbodies)
            {
                item.AddExplosionForce(explotionForce, transform.position, EXPLOTION_RADIUS);
            }

        }
    }

    void OnDestroy()
    {
        GameManager.score++;
    }
}
