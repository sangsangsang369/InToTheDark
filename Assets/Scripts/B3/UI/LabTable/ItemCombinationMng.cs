using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCombinationMng : MonoBehaviour
{
    B3UIManager uiManager;
    LabTableItemManager labtableMng;
    PianoMng pianoMng;
    //아이템 프리펩들 넣어주기
    public GameObject fleshOneItem, patternLeafItem, fleshTwoItem, liquidItem; 
    public bool flesh1Made = false;
    public bool patternLeafMade = false;

    DataManager data;
    SaveDataClass saveData;
    SlotSelectionMng slotSelectMng;
    SoundManager sound;


    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;

        uiManager = FindObjectOfType<B3UIManager>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
        pianoMng = FindObjectOfType<PianoMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();

    }

    //조합하기 버튼에 붙어서 조합 실행하는 함수
    public void GetResult()  
    {
        //재료 슬롯 둘다 차있으면
        if (labtableMng.leftActive && labtableMng.rightActive)
        {
            //열매 + 나뭇가지
            if(labtableMng.itemActive["fruitActive"] 
                && labtableMng.itemActive["branchActive"])
            {
                GameObject fleshOne = Instantiate(fleshOneItem, labtableMng.resultItem.transform); //결과슬롯 자식으로 살덩어리1 생성
                saveData.itemList.Add(new ItemClass(ItemClass.ItemPrefabOrder.Flesh1));
                data.Save();
                labtableMng.SetItemSize_Btn(fleshOne); //크기 조정하고 아이템 버튼컴포넌트 꺼주기
                labtableMng.DestroyMaterials_ResetActive(ItemClass.ItemPrefabOrder.Fruit, ItemClass.ItemPrefabOrder.Branch); //재료 아이템 파괴하고 아이템 활성화 다 false로
                labtableMng.resultItemActive = true; //결과슬롯 활성화
                labtableMng.itemActive["fleshOneActive"] = true; //살덩어리1 활성화   
                flesh1Made = true;

                slotSelectMng.itemName = "살덩어리1";
                slotSelectMng.ResultItemNamePopUp(); 

                sound.EffectPlay(sound.getItemEffect);

            } 
            //나뭇잎 + 수액
            else if(labtableMng.itemActive["leafActive"] 
                && labtableMng.itemActive["treesapActive"])
            {
                GameObject patternLeaf = Instantiate(patternLeafItem, labtableMng.resultItem.transform); 
                saveData.itemList.Add(new ItemClass(ItemClass.ItemPrefabOrder.PatternLeaf));
                data.Save();
                labtableMng.SetItemSize_Btn(patternLeaf);
                labtableMng.DestroyMaterials_ResetActive(ItemClass.ItemPrefabOrder.Leaf, ItemClass.ItemPrefabOrder.Sap);
                labtableMng.resultItemActive = true;
                labtableMng.itemActive["patternLeafActive"] = true; //무늬 나뭇잎 활성화
                patternLeafMade = true;

                slotSelectMng.itemName = "무늬가 생긴 잎";
                slotSelectMng.ResultItemNamePopUp();

                sound.EffectPlay(sound.getItemEffect);
            }
            //살덩어리1 + 진액
            else if(labtableMng.itemActive["fleshOneActive"] 
                && labtableMng.itemActive["monsterExtractActive"])
            {
                GameObject fleshTwo = Instantiate(fleshTwoItem, labtableMng.resultItem.transform);
                saveData.itemList.Add(new ItemClass(ItemClass.ItemPrefabOrder.Flesh2));
                data.Save();
                labtableMng.SetItemSize_Btn(fleshTwo);
                labtableMng.DestroyMaterials_ResetActive(ItemClass.ItemPrefabOrder.Flesh1, ItemClass.ItemPrefabOrder.MonsterEssence);
                labtableMng.resultItemActive = true;
                labtableMng.itemActive["fleshTwoActive"] = true; //살덩어리2 활성화
                flesh1Made = false;

                slotSelectMng.itemName = "살덩어리2";
                slotSelectMng.ResultItemNamePopUp();
                sound.EffectPlay(sound.getItemEffect);
                
                //진액 인벤토리에서 파괴되었으니 피아노 콜라이더 켜주기 
                pianoMng.pianoObj.GetComponent<BoxCollider2D>().enabled = true;
                pianoMng.monsterExtractinInventory = false;
                saveData.monsterExtractinInventory = false;
                data.Save();
            }
            //살덩어리2 + 무늬 나뭇잎
            else if(labtableMng.itemActive["fleshTwoActive"] 
                && labtableMng.itemActive["patternLeafActive"])
            {
                GameObject liquid = Instantiate(liquidItem, labtableMng.resultItem.transform);
                saveData.itemList.Add(new ItemClass(ItemClass.ItemPrefabOrder.Liquid));
                data.Save();
                labtableMng.SetItemSize_Btn(liquid);
                labtableMng.DestroyMaterials_ResetActive(ItemClass.ItemPrefabOrder.Flesh2, ItemClass.ItemPrefabOrder.PatternLeaf);
                labtableMng.resultItemActive = true;
                labtableMng.itemActive["liquidActive"] = true; //투명한 액체 활성화
                patternLeafMade = false;

                slotSelectMng.itemName = "투명한 액체";
                slotSelectMng.ResultItemNamePopUp();
        
                sound.EffectPlay(sound.getItemEffect);
            }
            //조합 실패했을 때
            else
            {
                uiManager.wrongCombineUI.SetActive(true);  //조합 실패했을 때 뜨는 스크립트 띄워주기
                StartCoroutine(uiManager.LoadTextOneByOne(uiManager.wrongCombineText.text, uiManager.inputTextUI));
                labtableMng.UnselectMaterial_Left();
                labtableMng.UnselectMaterial_Right();
            }
        }
    }
}
