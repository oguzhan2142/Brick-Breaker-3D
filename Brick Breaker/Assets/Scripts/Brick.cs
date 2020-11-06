using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{



    void Update()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

}
