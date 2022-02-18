//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class B2_ItemManager : MonoBehaviour
//{
//    public Sprite clockitemImg, sword1ItemImg, key1ItemImg, sword2ItemImg;
//    public List<GameObject> inventoryList;
//    public List<GameObject> slotList;
//    public List<bool> filledCheck;

//    // Start is called before the first frame update
//    void Start()
//    {
//        for (int i = 0; i < 6; i++)
//        {
//            slotList.Add(inventoryList[0].transform.GetChild(i).gameObject);
//        }
//        for (int i = 0; i < slotList.Count; i++)
//        {
//            filledCheck.Add(false);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public GameObject CheckSlot(Sprite itemImage)
//    {
//        Debug.Log("checkSlot");
//        for (int i = 0; i < slotList.Count; i++)
//        {
//            if (!filledCheck[i])
//            {
//                filledCheck[i] = true;
//                slotList[i].transform.GetChild(0).GetComponent<Image>().sprite = itemImage;
//                slotList[i].transform.GetChild(0).gameObject.SetActive(true);
//                return slotList[i].transform.GetChild(0).gameObject;
//            }
//        }
//        return null;
//    }
//}
