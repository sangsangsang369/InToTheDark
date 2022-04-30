using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public GameObject hourHand;
    RectTransform rectHour;
    SoundManager SM;
    public Camera mainCamera;
    Vector3 mousePos;
    public bool firstHour = false;
    public bool secHour = false;
    public bool thrHour = false;
    public bool fourHour = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        rectHour = hourHand.GetComponent<RectTransform>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("x pos = " + mousePos.x);
            //Debug.Log("y pos = " + mousePos.y);
            //SM.moveClockEffectPlay();
            if (((mousePos.x > 930) && (mousePos.x < 980)) && ((mousePos.y > 487) && (mousePos.y < 630)))
            {
                //12시
                rectHour.rotation = Quaternion.Euler(0, 0, 90.0f);
            }
            else if (((mousePos.x > 990) && (mousePos.x < 1060)) && ((mousePos.y > 494) && (mousePos.y < 600)))
            {
                // 1시
                fourHour = false;
                rectHour.rotation = Quaternion.Euler(0, 0, 60.0f);
                firstHour = true;
            }
            else if (((mousePos.x > 990.5) && (mousePos.x < 1115)) && ((mousePos.y > 481) && (mousePos.y < 550)))
            {
                // 2시
                rectHour.rotation = Quaternion.Euler(0, 0, 30.0f);
            }
            else if (((mousePos.x > 999) && (mousePos.x < 1147)) && ((mousePos.y > 422) && (mousePos.y < 480)))
            {
                // 3시
                rectHour.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (((mousePos.x > 996) && (mousePos.x < 1120)) && ((mousePos.y > 366) && (mousePos.y < 445)))
            {
                // 4시
                rectHour.rotation = Quaternion.Euler(0, 0, -30.0f);
            }
            else if (((mousePos.x > 985) && (mousePos.x < 1150)) && ((mousePos.y > 309) && (mousePos.y < 425)))
            {
                // 5시
                firstHour = false;
                rectHour.rotation = Quaternion.Euler(0, 0, -60.0f);
                fourHour = true;
            }
            else if (((mousePos.x > 943) && (mousePos.x < 981)) && ((mousePos.y > 292) && (mousePos.y < 422)))
            {
                // 6시
                rectHour.rotation = Quaternion.Euler(0, 0, -90.0f);
            }
            else if (((mousePos.x > 849) && (mousePos.x < 945)) && ((mousePos.y > 292) && (mousePos.y < 429)))
            {
                // 7시
                rectHour.rotation = Quaternion.Euler(0, 0, -120.0f);
            }
            else if (((mousePos.x > 806) && (mousePos.x < 930)) && ((mousePos.y > 365) && (mousePos.y < 445)))
            {
                // 8시
                rectHour.rotation = Quaternion.Euler(0, 0, -150.0f);
            }
            else if (((mousePos.x > 777) && (mousePos.x < 915)) && ((mousePos.y > 425) && (mousePos.y < 465)))
            {
                // 9시
                secHour = false;
                firstHour = false;
                fourHour = false;
                rectHour.rotation = Quaternion.Euler(0, 0, -180.0f);
                thrHour = true;
            }
            else if (((mousePos.x > 806) && (mousePos.x < 915)) && ((mousePos.y > 472) && (mousePos.y < 582)))
            {
                // 10시
                thrHour = false;
                firstHour = false;
                fourHour = false;
                rectHour.rotation = Quaternion.Euler(0, 0, 150.0f);
                secHour = true;
            }
            else if (((mousePos.x > 873) && (mousePos.x < 935)) && ((mousePos.y > 490) && (mousePos.y < 610)))
            {
                // 11시
                rectHour.rotation = Quaternion.Euler(0, 0, 120.0f);
            }
        }
    }
}
