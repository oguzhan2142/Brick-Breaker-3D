using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCamera : MonoBehaviour
{



    void Start()
    {
        GetComponent<Animation>().Play("MainCameraGameScene");
    }


}
