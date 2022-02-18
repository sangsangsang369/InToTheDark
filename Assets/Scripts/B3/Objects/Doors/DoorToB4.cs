using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorToB4 : Object
{
    public GameObject doorToB4_noEnterUI, doorToB4_EnterUI;
    public Text doorToB4_noEnterText, doorToB4_EnterText;
    public Text inputTextUI;
    B3UIManager uiManager;
    B3InventoryMng b3inventoryMng;
    SlotSelectionMng slotSelectMng;

    int doorOpenCount = 0;
    public GameObject creature;

    void Start()
    {
        uiManager = FindObjectOfType<B3UIManager>();
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
    }

    public override void ObjectFunction()
    {
        //투명한 액체 선택 안 됐을 때 && 문 열린 적 없을 때
        if(slotSelectMng.usableItem != "liquidSelected" && doorOpenCount == 0) 
        {
            doorToB4_noEnterUI.SetActive(true); //들어갈 수 없다는 텍스트 출력
            StartCoroutine(uiManager.LoadTextOneByOne(doorToB4_noEnterText.text, inputTextUI));
        }
        //투명한 액체 선택 됐을 때 && 문 열린 적 없을 때
        else if(slotSelectMng.usableItem == "liquidSelected" && doorOpenCount == 0)
        {
            doorToB4_EnterUI.SetActive(true); //문 열렸다는 텍스트 출력
            StartCoroutine(uiManager.LoadTextOneByOne(doorToB4_EnterText.text, inputTextUI));
            doorOpenCount++; //문 열린 횟수++
            creature.SetActive(false); //문에 붙은 이형체 꺼주기
            //slotSelectMng.UseSelectItem(); //투명한 액체 사용 && 파괴
        }
    }
}
