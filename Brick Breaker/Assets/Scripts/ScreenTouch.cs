using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScreenTouch : MonoBehaviour
{


    private float maxDeltaY = Screen.height / 3;

    [SerializeField] private Plank plank = null;



    private float power;

    Vector3 first;
    Vector3 offset = Vector3.zero;
    Vector3 plankScreen = Vector3.zero;

    float witdh;
    private void Start()
    {
        witdh = (Camera.main.WorldToViewportPoint(plank.transform.position) - Camera.main.WorldToViewportPoint(plank.leftEnd.position)).x;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            first = Input.mousePosition;
            plankScreen = Camera.main.WorldToScreenPoint(plank.transform.position);
            // Sag sol kaydirma
            if (plank.movable)
            {
                offset = plank.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, plankScreen.z));
            }


        }

        if (Input.GetMouseButton(0))
        {
            Vector3 last = Input.mousePosition;

            // sag sol kaydirma
            if (plank.movable)
            {

                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, plankScreen.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

                Vector3 plankLeftEndScreen = Camera.main.WorldToScreenPoint(plank.leftEnd.position);
                Vector3 plankRightEndScreen = Camera.main.WorldToScreenPoint(plank.rightEnd.position);





                if (plankLeftEndScreen.x < 0)
                {


                    if (first.x > last.x)
                    {
                        return;
                    }
                }

                if (plankRightEndScreen.x > Screen.width)
                {
                    if (first.x < last.x)
                    {
                        return;
                    }
                }


                plank.transform.position = new Vector3(curPosition.x, plank.transform.position.y, plank.transform.position.z);




            }

        }




    }
}
