using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMin : MonoBehaviour
{
    public GameObject minuteHand;
    RectTransform rectMin;
    SoundManager SM;
    public Camera mainCamera;
    Vector3 mousePos;
    public bool firstMin = false;
    public bool secMin = false;
    public bool thrMin = false;
    public bool fourMin = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        rectMin = minuteHand.GetComponent<RectTransform>();
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
            if (((mousePos.x > 935) && (mousePos.x < 984)) && ((mousePos.y > 635) && (mousePos.y < 722)))
            {
                //0.0 00분
                secMin = false;
                fourMin = false;
                rectMin.rotation = Quaternion.Euler(0, 0, 90.0f);
                firstMin = true;
                thrMin = true;
            }
            else if (((mousePos.x > 1000) && (mousePos.x < 1045)) && ((mousePos.y > 645) && (mousePos.y <706)))
            {
                // 0.5
                rectMin.rotation = Quaternion.Euler(0, 0, 75.0f);
            }
            else if (((mousePos.x > 1042) && (mousePos.x < 1090)) && ((mousePos.y > 618) && (mousePos.y < 687)))
            {
                // 1.0
                rectMin.rotation = Quaternion.Euler(0, 0, 60.0f);
            }
            else if (((mousePos.x > 1085) && (mousePos.x < 1150)) && ((mousePos.y > 585) && (mousePos.y < 647)))
            {
                // 1.5
                rectMin.rotation = Quaternion.Euler(0, 0, 45.0f);
            }
            else if (((mousePos.x > 1127) && (mousePos.x < 1190)) && ((mousePos.y > 555) && (mousePos.y < 600)))
            {
                // 2.0
                rectMin.rotation = Quaternion.Euler(0, 0, 30.0f);
            }
            else if (((mousePos.x > 1152) && (mousePos.x < 1208)) && ((mousePos.y > 507) && (mousePos.y < 556)))
            {
                // 2.5
                rectMin.rotation = Quaternion.Euler(0, 0, 15.0f);
            }
            else if (((mousePos.x > 1161) && (mousePos.x < 1231)) && ((mousePos.y > 441) && (mousePos.y < 470)))
            {
                // 3.0
                rectMin.rotation = Quaternion.Euler(0, 0, 0.0f);
            }
            else if (((mousePos.x > 1162) && (mousePos.x < 1208)) && ((mousePos.y > 389) && (mousePos.y < 435)))
            {
                // 3.5
                rectMin.rotation = Quaternion.Euler(0, 0, -15.0f);
            }
            else if (((mousePos.x > 1132) && (mousePos.x < 1186)) && ((mousePos.y > 325) && (mousePos.y < 378)))
            {
                // 4.0
                rectMin.rotation = Quaternion.Euler(0, 0, -30.0f);
            }
            else if (((mousePos.x > 1084) && (mousePos.x < 1156)) && ((mousePos.y > 280) && (mousePos.y < 325)))
            {
                // 4.5
                rectMin.rotation = Quaternion.Euler(0, 0, -45.0f);
            }
            else if (((mousePos.x > 1050) && (mousePos.x < 1195)) && ((mousePos.y > 237) && (mousePos.y < 281)))
            {
                // 5.0
                rectMin.rotation = Quaternion.Euler(0, 0, -60.0f);
            }
            else if (((mousePos.x > 1003) && (mousePos.x < 1043)) && ((mousePos.y > 205) && (mousePos.y < 271)))
            {
                // 5.5
                rectMin.rotation = Quaternion.Euler(0, 0, -75.0f);
            }
            else if (((mousePos.x > 940) && (mousePos.x < 975)) && ((mousePos.y > 188) && (mousePos.y < 255)))
            {
                // 6.0 30분
                firstMin = false;
                thrMin = false;
                fourMin = true;
                rectMin.rotation = Quaternion.Euler(0, 0, -90.0f);
                secMin = true;
            }
            else if (((mousePos.x > 892) && (mousePos.x < 917)) && ((mousePos.y > 218) && (mousePos.y < 270)))
            {
                // 6.5
                rectMin.rotation = Quaternion.Euler(0, 0, -105.0f);
            }
            else if (((mousePos.x > 805) && (mousePos.x < 880)) && ((mousePos.y > 233) && (mousePos.y < 286)))
            {
                // 7.0
                rectMin.rotation = Quaternion.Euler(0, 0, -120.0f);
            }
            else if (((mousePos.x > 777) && (mousePos.x < 832)) && ((mousePos.y > 272) && (mousePos.y < 318)))
            {
                // 7.5
                rectMin.rotation = Quaternion.Euler(0, 0, -135.0f);
            }
            else if (((mousePos.x > 730) && (mousePos.x < 799)) && ((mousePos.y > 327) && (mousePos.y < 375)))
            {
                // 8.0
                rectMin.rotation = Quaternion.Euler(0, 0, -150.0f);
            }
            else if (((mousePos.x > 709) && (mousePos.x < 770)) && ((mousePos.y > 390) && (mousePos.y < 429)))
            {
                // 8.5
                rectMin.rotation = Quaternion.Euler(0, 0, -165.0f);
            }
            else if (((mousePos.x > 699) && (mousePos.x < 755)) && ((mousePos.y > 430) && (mousePos.y < 486)))
            {
                // 9.0
                rectMin.rotation = Quaternion.Euler(0, 0, -180.0f);
            }
            else if (((mousePos.x > 703) && (mousePos.x < 779)) && ((mousePos.y > 486) && (mousePos.y < 534)))
            {
                // 9.5
                rectMin.rotation = Quaternion.Euler(0, 0, 165.0f);
            }
            else if (((mousePos.x > 734) && (mousePos.x < 790)) && ((mousePos.y > 554) && (mousePos.y < 597)))
            {
                // 10.0
                rectMin.rotation = Quaternion.Euler(0, 0, 150.0f);
            }
            else if (((mousePos.x > 775) && (mousePos.x < 831)) && ((mousePos.y > 593) && (mousePos.y < 645)))
            {
                // 10.5
                rectMin.rotation = Quaternion.Euler(0, 0, 135.0f);
            }
            else if (((mousePos.x > 817) && (mousePos.x < 875)) && ((mousePos.y > 618) && (mousePos.y < 680)))
            {
                // 11.0
                rectMin.rotation = Quaternion.Euler(0, 0, 120.0f);
            }
            else if (((mousePos.x > 877) && (mousePos.x < 920)) && ((mousePos.y > 642) && (mousePos.y < 711)))
            {
                // 11.5
                rectMin.rotation = Quaternion.Euler(0, 0, 105.0f);
            }
        }
    }
}
