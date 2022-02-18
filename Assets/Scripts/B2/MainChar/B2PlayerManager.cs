using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2PlayerManager : MonoBehaviour
{
    //public bool doorToCabinet, doorToGallery, cabinetToHW, galleryToHW, doorToB3, cabinet1, cabinet2, cabinet3, cabinet4, cabinet5, body, candle, statue, statueSp, statue1Pz, statue2Pz, statue3Pz, statue4Pz, frame1, frame2, frame3, frame4, poetry;
    //public float speed;
    //public Vector3 raycastDir; //레이저 방향
    //public bool isOnB2Hallway = true;
    //public bool isOnB2Cabinet = false;
    //public bool isOnB2Gallery = false;
    ////public bool[] boolList;
    //public string[] tagList;

    // void Start()
    // {
    //     boolList = new bool[]{doorToLib, doorToHW, muffler, letter, pattern, goldenBook, book1, book2, book3, table};
    //     tagList = new string[]{"DoorToLib", "DoorToHW", "Muffler", "Letter", "Pattern", "GoldenBook", "Book1", "Book2", "Book3", "Table"};
    // }

    //void OnTriggerEnter2D(Collider2D col)
    //{
        /*for(int i = 0; i < boolList.Length; i++)
        {
            if(col.gameObject.tag == tagList[i])
            {
                boolList[i] = true;
                Debug.Log(tagList[i]);
                Debug.Log(boolList[i]);
            }
        }*/
    //    if (col.gameObject.tag == "DoorToCabinet")
    //    {
    //        doorToCabinet = true;
    //    }
    //    if (col.gameObject.tag == "DoorToGallery")
    //    {
    //        doorToGallery = true;
    //    }
    //    if (col.gameObject.tag == "CabinetToHW")
    //    {
    //        cabinetToHW = true;
    //    }
    //    if (col.gameObject.tag == "GalleryToHW")
    //    {
    //        galleryToHW = true;
    //    }
    //    if (col.gameObject.tag == "Cabinet1")
    //    {
    //        cabinet1 = true;
    //    }
    //    if(col.gameObject.tag == "Cabinet2")
    //    {
    //        cabinet2 = true;
    //    }
    //    if(col.gameObject.tag == "Cabinet3")
    //    {
    //        cabinet3 = true;
    //    }
    //    if (col.gameObject.tag == "Cabinet4")
    //    {
    //        cabinet4 = true;
    //    }
    //    if (col.gameObject.tag == "Cabinet5")
    //    {
    //        cabinet5 = true;
    //    }
    //    if (col.gameObject.tag == "Body")
    //    {
    //        body = true;
    //    }
    //    if (col.gameObject.tag == "Candle")
    //    {
    //        candle = true;
    //    }
    //    if (col.gameObject.tag == "Statue")
    //    {
    //        statue = true;
    //    }
    //    if (col.gameObject.tag == "StatueSp")
    //    {
    //        statueSp = true;
    //    }
    //    /*
    //    if (col.gameObject.tag == "StatuePz")
    //    {
    //        statue1Pz = true;
    //        statue2Pz = true;
    //        statue3Pz = true;
    //        statue4Pz = true;
    //    }*/
    //    if (col.gameObject.name == "B2_Hallway_Statue(1)")
    //    {
    //        statue1Pz = true;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(2)")
    //    {
    //        statue2Pz = true;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(3)")
    //    {
    //        statue3Pz = true;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(4)")
    //    {
    //        statue4Pz = true;
    //    }
    //    if (col.gameObject.name == "B2_Frame1")
    //    {
    //        frame1 = true;
    //    }
    //    if (col.gameObject.name == "B2_Frame2")
    //    {
    //        frame2 = true;
    //    }
    //    if (col.gameObject.name == "B2_Frame3")
    //    {
    //        frame3 = true;
    //    }
    //    if (col.gameObject.name == "B2_Frame4")
    //    {
    //        frame4 = true;
    //    }
    //    if (col.gameObject.name == "B2_Poetry")
    //    {
    //        poetry = true;
    //    }
    //    if (col.gameObject.tag == "DoorToB3")
    //    {
    //        doorToB3 = true;
    //    }
    //    col.transform.GetChild(0).gameObject.SetActive(true);
    //    Debug.Log(col.gameObject.name);
    //}

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "DoorToCabinet")
    //    {
    //        doorToCabinet = false;
    //    }
    //    if (col.gameObject.tag == "DoorToGallery")
    //    {
    //        doorToGallery = false;
    //    }
    //    if (col.gameObject.tag == "CabinetToHW")
    //    {
    //        cabinetToHW = false;
    //    }
    //    if (col.gameObject.tag == "GalleryToHW")
    //    {
    //        galleryToHW = false;
    //    }
    //    if (col.gameObject.tag == "Cabinet1")
    //    {
    //        cabinet1 = false;
    //    }
    //    if (col.gameObject.tag == "Cabinet2")
    //    {
    //        cabinet2 = false;
    //    }
    //    if (col.gameObject.tag == "Cabinet3")
    //    {
    //        cabinet3 = false;
    //    }
    //    if (col.gameObject.tag == "Cabinet4")
    //    {
    //        cabinet4 = false;
    //    }
    //    if (col.gameObject.tag == "Cabinet5")
    //    {
    //        cabinet5 = false;
    //    }
    //    if (col.gameObject.tag == "Body")
    //    {
    //        body = false;
    //    }
    //    if (col.gameObject.tag == "Candle")
    //    {
    //        candle = false;
    //    }
    //    if (col.gameObject.tag == "Statue")
    //    {
    //        statue = false;
    //    }
    //    if (col.gameObject.tag == "StatueSp")
    //    {
    //        statueSp = false;
    //    }
    //    if (col.gameObject.name == "B2_Frame1")
    //    {
    //        frame1 = false;
    //    }
    //    if (col.gameObject.name == "B2_Frame2")
    //    {
    //        frame2 = false;
    //    }
    //    if (col.gameObject.name == "B2_Frame3")
    //    {
    //        frame3 = false;
    //    }
    //    if (col.gameObject.name == "B2_Frame4")
    //    {
    //        frame4 = false;
    //    }
    //    if (col.gameObject.name == "B2_Poetry")
    //    {
    //        poetry = false;
    //    }
    //    /*
    //    if (col.gameObject.tag == "StatuePz")
    //    {
    //        statue1Pz = false;
    //        statue2Pz = false;
    //        statue3Pz = false;
    //        statue4Pz = false;
    //    }*/
    //    if (col.gameObject.name == "B2_Hallway_Statue(1)")
    //    {
    //        statue1Pz = false;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(2)")
    //    {
    //        statue2Pz = false;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(3)")
    //    {
    //        statue3Pz = false;
    //    }
    //    if (col.gameObject.name == "B2_Hallway_Statue(4)")
    //    {
    //        statue4Pz = false;
    //    }
    //    if (col.gameObject.tag == "DoorToB3")
    //    {
    //        doorToB3 = false;
    //    }
    //    col.transform.GetChild(0).gameObject.SetActive(false);
    //}
}
