using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraHomeScene : MonoBehaviour
{
    public void cameraAnimationEvent()
    {
        SceneManager.LoadScene("GameScene");
    }
}
