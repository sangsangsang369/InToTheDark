using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnterB4Lab : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject labObj;
    public GameObject hallwayObj;
    public Light2D globalLight;
    Player player;
    DataManager data;
    SaveDataClass saveData;
    FloorTxt Ft;  
    SlotSelectionMng slotSelectMng;
    UI uiManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        Ft = FindObjectOfType<FloorTxt>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        uiManager = FindObjectOfType<UI>();
    }

    public void EnterLab()
    {
        if(!uiManager.nowTexting)
        {
            slotSelectMng.UnselectSlot(FindObjectOfType<CardKey>().gameObject);
            hallwayObj.SetActive(false);
            labObj.SetActive(true);
            globalLight.intensity = 0.66f;
            saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4Lab];
            player.currRoom = "B4_Lab";
            saveData.currFloor = "B4";
            saveData.currRoomPos = "수상한 실험실";
            data.Save();
            Ft.PosUI();
            playerObj.transform.position = new Vector2(1.5f, -0.83f);
        }
    }
}
