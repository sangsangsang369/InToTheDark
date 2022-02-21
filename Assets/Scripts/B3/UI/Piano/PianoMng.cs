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
    [HideInInspector]
    public bool monsterExtractinInventory;
    B3UIManager uiManager;    
    InventoryMng inventoryMng; 



    private void Start() 
    {
        uiManager = FindObjectOfType<B3UIManager>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void CompareKeys(GameObject key)
    { 
        key.GetComponent<PianoKey>().KeyFunction(); //음 입력받음
        int i = KeyInputsList.Count -1;
        if(KeyInputsList[i] == AnswerList[i])
        {
            if(i == 9) //정답일 때
            {
                PianoUI.SetActive(false); //피아노 UI 켜지면 자동으로 피아노 Obj 콜라이더 꺼짐(피아노 Obj 콜라이더 꺼진 상태로)
                KeyInputsList.Clear(); //음 입력 초기화

                PianoQuizSolvedUI.SetActive(true); //정답 맞췄다는 텍스트 나옴
                StartCoroutine(uiManager.LoadTextOneByOne(PianoQuizSolvedText.text, inputTextUI));

                inventoryMng.AddToInventory(monsterExtractItem); //진액 인벤토리에 들어오게
                monsterExtractinInventory = true; //나중에 실험대에서 진액 없어지면 얘 false로 바꿔주기
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
}
