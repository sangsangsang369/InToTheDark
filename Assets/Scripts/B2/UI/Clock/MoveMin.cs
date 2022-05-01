using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMin : MonoBehaviour
{
    public GameObject minuteHand;
    RectTransform rectMin;
    SoundManager SM;
    public Camera mainCamera;
    Vector2 mousePos, centerPos;
    float newValue, newDist;
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
        centerPos = new Vector2(962.94f, 459.49f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            //mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("x pos = " + mousePos.x);
            //Debug.Log("y pos = " + mousePos.y);
            newValue = GetAngle(centerPos, mousePos);
            //Debug.Log("angle : " + newValue);
            newDist = GetVectorSize(centerPos, mousePos);
            //Debug.Log("dist : " + newDist);

            //SM.moveClockEffectPlay();
            if ((newDist > 38000) && (newDist < 150000))
            {
                if ((newValue > 82.5) && (newValue <= 97.5))
                {
                    //0.0 00분
                    secMin = false;
                    fourMin = false;
                    rectMin.rotation = Quaternion.Euler(0, 0, 90.0f);
                    firstMin = true;
                    thrMin = true;
                }
                else if ((newValue > 67.5) && (newValue <= 82.5))
                {
                    // 0.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 75.0f);
                }
                else if ((newValue > 52.5) && (newValue <= 67.5))
                {
                    // 1.0
                    rectMin.rotation = Quaternion.Euler(0, 0, 60.0f);
                }
                else if ((newValue > 37.5) && (newValue <= 52.5))
                {
                    // 1.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 45.0f);
                }
                else if ((newValue > 22.5) && (newValue <= 37.5))
                {
                    // 2.0
                    rectMin.rotation = Quaternion.Euler(0, 0, 30.0f);
                }
                else if ((newValue > 7.5) && (newValue <= 22.5))
                {
                    // 2.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 15.0f);
                }
                else if ((newValue > -7.5) && (newValue <= 7.5))
                {
                    // 3.0
                    rectMin.rotation = Quaternion.Euler(0, 0, 0.0f);
                }
                else if ((newValue > -22.5) && (newValue <= -7.5))
                {
                    // 3.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -15.0f);
                }
                else if ((newValue > -37.5) && (newValue <= -22.5))
                {
                    // 4.0
                    rectMin.rotation = Quaternion.Euler(0, 0, -30.0f);
                }
                else if ((newValue > -52.5) && (newValue <= -37.5))
                {
                    // 4.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -45.0f);
                }
                else if ((newValue > -67.5) && (newValue <= -52.5))
                {
                    // 5.0
                    rectMin.rotation = Quaternion.Euler(0, 0, -60.0f);
                }
                else if ((newValue > -82.5) && (newValue <= -67.5))
                {
                    // 5.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -75.0f);
                }
                else if ((newValue > -97.5) && (newValue <= -82.5))
                {
                    // 6.0 30분
                    firstMin = false;
                    thrMin = false;
                    fourMin = true;
                    rectMin.rotation = Quaternion.Euler(0, 0, -90.0f);
                    secMin = true;
                }
                else if ((newValue > -112.5) && (newValue <= -97.5))
                {
                    // 6.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -105.0f);
                }
                else if ((newValue > -127.5) && (newValue <= -112.5))
                {
                    // 7.0
                    rectMin.rotation = Quaternion.Euler(0, 0, -120.0f);
                }
                else if ((newValue > -142.5) && (newValue <= -127.5))
                {
                    // 7.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -135.0f);
                }
                else if ((newValue > -157.5) && (newValue <= -142.5))
                {
                    // 8.0
                    rectMin.rotation = Quaternion.Euler(0, 0, -150.0f);
                }
                else if ((newValue > -172.5) && (newValue <= -157.5))
                {
                    // 8.5
                    rectMin.rotation = Quaternion.Euler(0, 0, -165.0f);
                }
                else if (((newValue > -180) && (newValue <= -172.5)) || (newValue > 172.5) && (newValue < 180))
                {
                    // 9.0
                    rectMin.rotation = Quaternion.Euler(0, 0, -180.0f);
                }
                else if ((newValue > 157.5) && (newValue <= 172.5))
                {
                    // 9.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 165.0f);
                }
                else if ((newValue > 142.5) && (newValue <= 157.5))
                {
                    // 10.0
                    rectMin.rotation = Quaternion.Euler(0, 0, 150.0f);
                }
                else if ((newValue > 127.5) && (newValue <= 142.5))
                {
                    // 10.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 135.0f);
                }
                else if ((newValue > 112.5) && (newValue <= 127.5))
                {
                    // 11.0
                    rectMin.rotation = Quaternion.Euler(0, 0, 120.0f);
                }
                else if ((newValue > 97.5) && (newValue <= 112.5))
                {
                    // 11.5
                    rectMin.rotation = Quaternion.Euler(0, 0, 105.0f);
                }
            }
            
        }
    }
    float GetAngle(Vector2 center, Vector2 target)
    {
        Vector2 v2 = target - center;
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }

    float GetVectorSize(Vector2 center, Vector2 target)
    {
        Vector2 TtoC = target - center;
        float dist = Vector2.SqrMagnitude(TtoC);

        return dist;
    }
}
