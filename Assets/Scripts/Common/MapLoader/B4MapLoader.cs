using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class B4MapLoader : MonoBehaviour
{
    [SerializeField] GameObject B4Hallway;
    [SerializeField] GameObject B4Chapel;
    [SerializeField] GameObject B4Lab;
    DataManager data;
    SaveDataClass saveData;
    SoundManager inst;
    public Light2D globalLight;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject brokenCapsule;
    [SerializeField] private GameObject lockImage;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        inst = SoundManager.inst;

        LoadB4Map();
    }

    public void LoadB4Map()
    {
        if(saveData.currRoomPos == "이형체의 복도")
        {
            B4Hallway.SetActive(true);
            B4Chapel.SetActive(false);
            B4Lab.SetActive(false);
        }
        else if(saveData.currRoomPos == "예배당")
        {
            B4Hallway.SetActive(false);
            B4Chapel.SetActive(true);
            B4Lab.SetActive(false);
        }
        else if(saveData.currRoomPos == "수상한 실험실")
        {
            globalLight.intensity = 0.66f;
            B4Hallway.SetActive(false);
            B4Chapel.SetActive(false);
            B4Lab.SetActive(true);
            inst.monsterWalkingSource.volume = 0;
            if(saveData.isB4LockUnlocked)
            {
                lockImage.SetActive(false);
                monster.SetActive(true);
                monster.GetComponent<Animator>().speed = 0f;
                brokenCapsule.SetActive(true);
            }
        }
    }
}
