using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3PlayerMng : MonoBehaviour
{
    public bool doorToTreeroom, doorToPianoroom, treeroomToHW, pianoroomToHW, doorToB4, candle, statue, fruit, branch, treesap, leaf, creatureOnCeiling, labTable;
    public float speed;
    //public Vector3 raycastDir; //레이저 방향
    public bool isOnHallway = true; //첨에 복도에 있음
    public bool isOnTreeroom = false; //트리룸off
    public bool isOnPianoroom = false; //피아노룸off
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
        if (col.gameObject.tag == "DoorToTreeroom")
        {
            doorToTreeroom = true;
        }
        if (col.gameObject.tag == "DoorToPianoroom")
        {
            doorToPianoroom = true;
        }
        if (col.gameObject.tag == "TreeroomToHW")
        {
            treeroomToHW = true;
        }
        if (col.gameObject.tag == "PianoroomToHW")
        {
            pianoroomToHW = true;
        }
        if (col.gameObject.tag == "DoorToB4")
        {
            doorToB4 = true;
        }

        if (col.gameObject.tag == "Candle")
        {
            candle = true;
        }
        if (col.gameObject.tag == "Statue")
        {
            statue = true;
        }
        if (col.gameObject.tag == "Fruit")
        {
            fruit = true;
        }
        if (col.gameObject.tag == "Branch")
        {
            branch = true;
        }
        if (col.gameObject.tag == "Treesap")
        {
            treesap = true;
        }
        if (col.gameObject.tag == "Leaf")
        {
            leaf = true;
        }
        if (col.gameObject.tag == "CreatureOnCeiling")
        {
            creatureOnCeiling = true;
        }
        if (col.gameObject.tag == "LabTable")
        {
            labTable = true;
        }
        col.transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorToTreeroom")
        {
            doorToTreeroom = false;
        }
        if (col.gameObject.tag == "DoorToPianoroom")
        {
            doorToPianoroom = false;
        }
        if (col.gameObject.tag == "TreeroomToHW")
        {
            treeroomToHW = false;
        }
        if (col.gameObject.tag == "PianoroomToHW")
        {
            pianoroomToHW = false;
        }
        if (col.gameObject.tag == "DoorToB4")
        {
            doorToB4 = false;
        }

        if (col.gameObject.tag == "Candle")
        {
            candle = false;
        }
        if (col.gameObject.tag == "Statue")
        {
            statue = false;
        }
        if (col.gameObject.tag == "Fruit")
        {
            fruit = false;
        }
        if (col.gameObject.tag == "Branch")
        {
            branch = false;
        }
        if (col.gameObject.tag == "Treesap")
        {
            treesap = false;
        }
        if (col.gameObject.tag == "Leaf")
        {
            leaf = false;
        }
        if (col.gameObject.tag == "CreatureOnCeiling")
        {
            creatureOnCeiling = false;
        }
        if (col.gameObject.tag == "LabTable")
        {
            labTable = false;
        }
        col.transform.GetChild(0).gameObject.SetActive(false);
    }
}

