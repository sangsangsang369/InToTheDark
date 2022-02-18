using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상은 주석..^^
public class PlayerMng : MonoBehaviour
{
    public bool doorToLib, doorToHW, muffler, letter, pattern, goldenBook, book1, book2, book3, table, candle, statue, note;
    public float speed;
    //public Vector3 raycastDir; //레이저 방향
    public bool isOnHallway = true;
    //public bool[] boolList;
    //public string[] tagList;

    // void Start()
    // {
    //     boolList = new bool[]{doorToLib, doorToHW, muffler, letter, pattern, goldenBook, book1, book2, book3, table};
    //     tagList = new string[]{"DoorToLib", "DoorToHW", "Muffler", "Letter", "Pattern", "GoldenBook", "Book1", "Book2", "Book3", "Table"};
    // }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*for(int i = 0; i < boolList.Length; i++)
        {
            if(col.gameObject.tag == tagList[i])
            {
                boolList[i] = true;
                Debug.Log(tagList[i]);
                Debug.Log(boolList[i]);
            }
        }*/
        if(col.gameObject.tag == "DoorToLib")
        {
            doorToLib = true;
        }
        if(col.gameObject.tag == "DoorToHW")
        {
            doorToHW = true;
        }
        if(col.gameObject.tag == "Muffler")
        {
            muffler = true;
        }
        if(col.gameObject.tag == "Letter")
        {
            letter = true;
        }
        if(col.gameObject.tag == "Pattern")
        {
            pattern = true;
        }
        if(col.gameObject.tag == "GoldenBook")
        {
            goldenBook = true;
        }
        if(col.gameObject.tag == "Book1")
        {
            book1 = true;
        }
        if(col.gameObject.tag == "Book2")
        {
            book2 = true;
        }
        if(col.gameObject.tag == "Book3")
        {
            book3 = true;
        }
        if(col.gameObject.tag == "Table")
        {
            table = true;
        }
        if(col.gameObject.tag == "Candle")
        {
            candle = true;
        }
        if(col.gameObject.tag == "Statue")
        {
            statue = true;
        }
        if(col.gameObject.tag == "Note")
        {
            note = true;
        }
        
        col.transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "DoorToLib")
        {
            doorToLib = false;
        }
        if(col.gameObject.tag == "DoorToHW")
        {
            doorToHW = false;
        }
        if(col.gameObject.tag == "Muffler")
        {
            muffler = false;
        }
        if(col.gameObject.tag == "Letter")
        {
            letter = false;
        }
        if(col.gameObject.tag == "Pattern")
        {
            pattern = false;
        }
        if(col.gameObject.tag == "GoldenBook")
        {
            goldenBook = false;
        }
        if(col.gameObject.tag == "Book1")
        {
            book1 = false;
        }
        if(col.gameObject.tag == "Book2")
        {
            book2 = false;
        }
        if(col.gameObject.tag == "Book3")
        {
            book3 = false;
        }
        if(col.gameObject.tag == "Table")
        {
            table = false;
        }
        if(col.gameObject.tag == "Candle")
        {
            candle = false;
        }
        if(col.gameObject.tag == "Statue")
        {
            statue = false;
        }
        if(col.gameObject.tag == "Note")
        {
            note = false;
        }
        
        col.transform.GetChild(0).gameObject.SetActive(false);
    }
}
