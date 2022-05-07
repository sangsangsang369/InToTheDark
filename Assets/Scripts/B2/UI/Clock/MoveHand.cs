using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public GameObject hourHand;
    RectTransform rectHour;
    SoundManager SM;
    public Camera mainCamera;
    Vector2 mousePos, centerPos;
    float newValue, newDist;
    [SerializeField] private GameObject clockCenter;
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
        centerPos = new Vector2(Screen.width/2, clockCenter.transform.position.y);
        //Debug.Log(clockCenter.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
            //Debug.Log(mousePos);
            //Debug.Log("x pos = " + mousePos.x);
            //Debug.Log("y pos = " + mousePos.y);
            newValue = GetAngle(centerPos, mousePos);
            newDist = GetVectorSize(centerPos, mousePos);
            

            if (newDist < 42000)
            {
                //Debug.Log("HOURangle : " + newValue);
                if((newValue > 45) && (newValue <= 75))
                {
                    //1시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -30.0f);
                    firstHour = true;
                }
                else if((newValue > 15) && (newValue <= 45))
                {
                    //2시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -60.0f);
                }
                else if((newValue > -15) && (newValue <= 15))
                {
                    //3시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -90);
                }
                else if((newValue > -45) && (newValue <= -15))
                {
                    //4시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -120.0f);
                }
                else if((newValue > -75) && (newValue <= -45))
                {
                    //5시
                    firstHour = false;
                    rectHour.localRotation = Quaternion.Euler(0, 0, -150.0f);
                    fourHour = true;
                }
                else if((newValue > -105) && (newValue <= -75))
                {
                    //6시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -180.0f);
                }
                else if((newValue > -135) && (newValue <= -105))
                {
                    //7시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -210.0f);
                }
                else if((newValue > -165) && (newValue <= -135))
                {
                    //8시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -240.0f);
                }
                else if(((newValue > -180) && (newValue <= -165)) || ((newValue <= 180) && (newValue > 165)))
                {
                    //9시
                    secHour = false;
                    firstHour = false;
                    fourHour = false;
                    rectHour.localRotation = Quaternion.Euler(0, 0, -270.0f);
                    thrHour = true;
                }
                else if((newValue > 135) && (newValue <= 165))
                {
                    //10시
                    thrHour = false;
                    firstHour = false;
                    fourHour = false;
                    rectHour.localRotation = Quaternion.Euler(0, 0, -300.0f);
                    secHour = true;
                }
                else if((newValue > 105) && (newValue <= 135))
                {
                    //11시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -330.0f);
                }
                else if((newValue > 75) && (newValue <= 105))
                {
                    //12시
                    rectHour.localRotation = Quaternion.Euler(0, 0, -360.0f);
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
