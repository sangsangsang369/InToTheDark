using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FruitMng : MonoBehaviour
{
    public GameObject[] fruits;
    DataManager data;
    SaveDataClass saveData;

    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;

        fruits= GetChildren(this.gameObject);  //TreeroomFruit에 있는 열매 오브젝트를 배열로
        if(saveData.isFruitPicked)
        {
            fruits[saveData.fruitNum].SetActive(false);
        }
    }

    public GameObject[] GetChildren(GameObject parent) //게임오브젝트의 자식들 배열로 만드는 함수
    {
        GameObject[] children = new GameObject[parent.transform.childCount];

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
}
