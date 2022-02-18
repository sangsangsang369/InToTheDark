using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCombination : MonoBehaviour
{
    B3Item b3Item;
    B3ItemManager b3ItemManager;
    B3ObjectManager b3ObjectManager;
    LabTableItemMng labTableItemMng;

    void Start()
    {
        b3Item = FindObjectOfType<B3Item>();
        b3ItemManager = FindObjectOfType<B3ItemManager>();
        b3ObjectManager = FindObjectOfType<B3ObjectManager>();
        labTableItemMng = FindObjectOfType<LabTableItemMng>(); 
    }

    //조합하기(버튼 오브젝트에 넣을 함수)
    public void GetResult()  
    {
        if (labTableItemMng.leftActive && labTableItemMng.rightActive) //재료 슬롯 둘 다 찼을 때
        {
            if (labTableItemMng.fruitActive && labTableItemMng.branchActive) //열매+나뭇가지
            {
                labTableItemMng.resultItem.transform.GetChild(0).GetComponent<Image>().sprite = labTableItemMng.fleshOneItemImg;  //살덩이1 이미지 넣어주기
                labTableItemMng.resultItem.transform.GetChild(0).gameObject.SetActive(true);  //결과물 슬롯 이미지 켜주기
                labTableItemMng.resultItem.transform.GetChild(0).gameObject.tag="FleshOne";  //결과물 슬롯 태그 바꿔주기 
                b3ItemManager.RemoveSlot("Fruit");  //열매 인벤에서 삭제
                b3ItemManager.RemoveSlot("Branch");  //나뭇가지 인벤에서 삭제
                labTableItemMng.resultItemActive = true;
            }
            else if (labTableItemMng.leafActive && labTableItemMng.treesapActive) //나뭇잎+수액
            {
                labTableItemMng.resultItem.transform.GetChild(0).GetComponent<Image>().sprite = labTableItemMng.leafpatternImg;
                labTableItemMng.resultItem.transform.GetChild(0).gameObject.SetActive(true);
                labTableItemMng.resultItem.transform.GetChild(0).gameObject.tag = "LeafPattern";
                b3ItemManager.RemoveSlot("Leaf");
                b3ItemManager.RemoveSlot("Treesap");
                labTableItemMng.resultItemActive = true;
            }
            else 
            {
                b3ObjectManager.labTableCombineUI.SetActive(true);  //조합 실패했을 때 뜨는 스크립트 띄워주기
                StartCoroutine(b3ObjectManager.uiManager.LoadTextOneByOne(b3ObjectManager.labTableCombineText.text, b3ObjectManager.inputTextUI));
                labTableItemMng.ResetLabTable(); //실험대 초기화
            }
            
        }
    }
}
