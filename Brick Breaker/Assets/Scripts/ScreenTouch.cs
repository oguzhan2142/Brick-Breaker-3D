using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScreenTouch : MonoBehaviour
{


    private float maxDeltaY = Screen.height / 3;

    [SerializeField] private Plank plank = null;

    private float speed = 15f;


    [SerializeField] private Transform skillsPanel = null;

    public float controlBoundY;

    void Start()
    {
        Vector3[] corners = new Vector3[4];
        skillsPanel.GetComponent<RectTransform>().GetWorldCorners(corners);

        controlBoundY = corners[3].y;
    }


    void Update()
    {

        if (Input.GetMouseButton(0))
        {


            if (Input.mousePosition.y > controlBoundY)
                return;

            if (!plank.movable)
                return;

            Vector3 plankScreen = Camera.main.WorldToScreenPoint(plank.transform.position);

            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, plankScreen.y, plankScreen.z));
            // lerp and set the position of the current object to that of the touch, but smoothly over time.
            plank.transform.position = Vector3.Lerp(plank.transform.position, touchedPos, Time.deltaTime * speed);
        }



    }

    // private void oldControls()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // Sag sol kaydirma
    //         if (plank.movable)
    //         {
    //             plankScreen = Camera.main.WorldToScreenPoint(plank.transform.position);
    //             offset = plank.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, plankScreen.z));
    //         }
    //     }
    //     if (Input.GetMouseButton(0))
    //     {

    //         // sag sol kaydirma
    //         if (plank.movable)
    //         {
    //             Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, plankScreen.z);

    //             Vector3 worldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);

    //             Vector3 curPosition = worldPoint + offset;

    //             plank.transform.position = new Vector3(curPosition.x * sensivity, plank.transform.position.y, plank.transform.position.z);

    //         }

    //     }
    // }



    // private void goToTouchedPos()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         plankScreen = Camera.main.WorldToScreenPoint(plank.transform.position);
    //         Vector3 input = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, plankScreen.z));

    //         destination = new Vector3(input.x, yPos, zPos);

    //     }

    //     plank.transform.position = Vector3.MoveTowards(plank.transform.position, destination, speed * Time.deltaTime);
    // }






}
