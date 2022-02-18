using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtnMng : MonoBehaviour
{
    B3InventoryMng b3inventoryMng;
    LabTableItemManager labtableMng;
    

    void Start()
    {
        b3inventoryMng = FindObjectOfType<B3InventoryMng>();
        labtableMng = FindObjectOfType<LabTableItemManager>();
    }

    //실험대 닫으면 실험대 위에 있는 아이템들 인벤토리에 자동으로 들어오게
    public void ResetLabTable()
    {
        labtableMng.UnselectMaterial_Left();
        labtableMng.UnselectMaterial_Right();
        labtableMng.GetResultItem();
        b3inventoryMng.RevertInvenSlotBtn_LT();
    }
}
