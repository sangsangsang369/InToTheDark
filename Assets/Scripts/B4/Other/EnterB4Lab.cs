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
    SoundManager inst;
    FloorTxt Ft;  
    SlotSelectionMng slotSelectMng;
    UI uiManager;
    SceneLoadManager sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;
        Ft = FindObjectOfType<FloorTxt>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        uiManager = FindObjectOfType<UI>();
        sceneLoader = SceneLoadManager.instance;
    }

    public void EnterLab()
    {
        if(!uiManager.nowTexting)
        {
            sceneLoader.LoadRoom();
            Invoke("LoadLab", 0.5f);
        }
    }

    void LoadLab()
    {
        inst.monsterWalkingSource.volume = 0;
        slotSelectMng.UnselectSlot(FindObjectOfType<CardKey>().gameObject);
        hallwayObj.SetActive(false);
        labObj.SetActive(true);
        globalLight.intensity = 0.66f;
        saveData.playerXstartPoint = saveData.playerXstartPoints[(int)SaveDataClass.playerStartPoint.B4Lab];
        player.currRoom = "B4_Lab";
        saveData.currFloor = "B4";
        saveData.currRoomPos = "수상한 실험실";
        FindObjectOfType<B4MapLoader>().LoadB4Map();
        data.Save();
        Ft.PosUI();
        inst.monsterWalkingSource.clip = null;
        inst.monsterGrowlingSource.clip = null;
        inst.playerHeartBeatSource.clip = null;
        playerObj.transform.position = new Vector2(1.5f, -0.83f);
    }
}
