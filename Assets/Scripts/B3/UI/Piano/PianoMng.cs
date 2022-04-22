using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoMng : MonoBehaviour
{
    static List<string> AnswerList = new List<string> 
    {"Ra", "Do_h", "Ra_h", "Sol_h", "Si", "Do_h", "Fa", "Re", "Sol", "Do"};
    public List<string> KeyInputsList = new List<string>();
    public GameObject PianoUI;
    public GameObject pianoMemoUI; 
    public GameObject pianoObj;
    public GameObject PianoQuizSolvedUI;
    public Text PianoQuizSolvedText;
    public Text inputTextUI;
    public GameObject monsterExtractItem;
    B3UIManager uiManager;    
    InventoryMng inventoryMng; 

    DataManager data;
    SaveDataClass saveData;
    public bool monsterExtractinInventory;
    SaveAlarm saveAlarm;
    SoundManager sound;
    AudioSource gooAudioSource;
   

    private void Start() 
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        monsterExtractinInventory = saveData.monsterExtractinInventory;
        gooAudioSource = GetComponent<AudioSource>();

        //진액 인벤토리에 있으면
        //피아노 콜라이더 꺼주기
        if(monsterExtractinInventory)
        {
            pianoObj.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            pianoObj.GetComponent<BoxCollider2D>().enabled = true;
        }

        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        saveAlarm = FindObjectOfType<SaveAlarm>();
    }

    public void CompareKeys(GameObject key)
    { 
        key.GetComponent<PianoKey>().KeyFunction(); //음 입력받음
        int i = KeyInputsList.Count -1;
        if(KeyInputsList[i] == AnswerList[i])
        {
            if(i == 9) //정답일 때
            {
                //sound.EffectPlay(sound.gooEffect);
                GooEffectPlay();
                PianoUI.SetActive(false); //피아노 UI 켜지면 자동으로 피아노 Obj 콜라이더 꺼짐(피아노 Obj 콜라이더 꺼진 상태로)
                KeyInputsList.Clear(); //음 입력 초기화
                //정답 맞췄다는 텍스트 나옴
                PianoQuizSolvedUI.SetActive(true); 
                StartCoroutine(uiManager.LoadTextOneByOne(PianoQuizSolvedText.text, inputTextUI));
                //진액 획득
                inventoryMng.AddToInventory(monsterExtractItem, 0.4f, ItemClass.ItemPrefabOrder.MonsterEssence); //진액 인벤토리에 들어오게
                monsterExtractinInventory = true; //나중에 실험대에서 진액 없어지면 얘 false로 바꿔주기
                saveData.monsterExtractinInventory = true;
                data.Save();
                saveAlarm.SaveAlarmPopUp();
            }
        }
        //음 틀렸을 때
        else if(KeyInputsList[i] != AnswerList[i])
        {
            KeyInputsList.Clear();
            //이형체 괴성 나오게
        }
    }

    public void InputClear()
    {
        KeyInputsList.Clear();
    }

    public void PianoObjColliderOn() //ui끄면 콜라이더 다시 켜주기
    {
        pianoObj.GetComponent<BoxCollider2D>().enabled = true;
    }

    void GooEffectPlay()
    {
        gooAudioSource.Play();
    }
}
