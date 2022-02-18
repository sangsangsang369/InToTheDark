using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockObject : MonoBehaviour
{
    LockerWithLock lockerWithLock;
    RedJewel redJewel;
    InventoryMng inventoryMng;
    [SerializeField] private GameObject lockHole;
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject lockUIObj;
    [SerializeField] private GameObject researchRecord;

    // Start is called before the first frame update
    void Start()
    {
        redJewel = FindObjectOfType<RedJewel>();
        lockerWithLock = FindObjectOfType<LockerWithLock>();
        inventoryMng = FindObjectOfType<InventoryMng>();
    }

    public void Unlock()
    {
        if(redJewel.isJewelOnHand)
        {
            Color color = lockHole.GetComponent<Image>().color;
            color.a = 1f;
            lockHole.GetComponent<Image>().color = color;
            inventoryMng.RemoveFromInventory(redJewel.gameObject);
            Invoke("AfterUnlocked", 2f);
        }
    }

    private void AfterUnlocked()
    {
        researchRecord.SetActive(true);
        lockerWithLock.isUnlocked = true;
        lockObj.SetActive(false);
        lockUIObj.SetActive(false);
    }
}
