//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class B2_Item : MonoBehaviour
//{
//    B2PlayerManager playerMng;
//    RaycastHit2D hit;
//    B2ObjManager objMng;
//    Vector3 raycastDir = new Vector3(0, 0, 1);
//    Vector3 mousePos;
//    Camera mainCamera;
//    AnsCheck ansCheck;
//    public bool isSolved = false;
//    public bool isOpen = false;
//    public bool key1Picked = false;
//    public bool sword1Picked = false;
//    public bool sword2Picked = false;

//    void Start()
//    {
//        objMng = FindObjectOfType<B2ObjManager>();
//        playerMng = FindObjectOfType<B2PlayerManager>();
//        ansCheck = FindObjectOfType<AnsCheck>();
//        mainCamera = FindObjectOfType<Camera>();
//        hit = objMng.hit;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Mouse0))
//        {
//            mousePos = Input.mousePosition;
//            Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f);
//            hit = Physics2D.Raycast(mousePos, raycastDir, 10f);
//            //Debug.Log(hit.collider.tag);
//        }
//    }

//    public void ItemCheck()
//    {
//        if (hit.collider.tag == "Clock")
//        {
//            if (!isSolved)
//            {
//                objMng.clockUI.SetActive(true);
//                isOpen = true;
//            }
//            else
//            {
//                objMng.clockUI.SetActive(false);
//            }   
//        }
//        else if (hit.collider.tag == "Key1")
//        {
//            if (!key1Picked)
//            {
//                key1Picked = true;
//                objMng.key1Picked = true;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotSelected;
//            }
//            else
//            {
//                key1Picked = false;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotUnselected;
//            }
//        }
//        else if (hit.collider.tag == "Sword1")
//        {
//            if (!sword1Picked)
//            {
//                sword1Picked = true;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotSelected;
//            }
//            else
//            {
//                sword1Picked = false;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotUnselected;
//            }
//        }
//        else if (hit.collider.tag == "Sword2")
//        {
//            if (!sword2Picked)
//            {
//                sword2Picked = true;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotSelected;
//            }
//            else
//            {
//                sword2Picked = false;
//                this.transform.parent.GetComponent<Image>().sprite = objMng.slotUnselected;
//            }
//        }
//        /*
//        else if (hit.collider.tag == "Note")
//        {
//            objMng.noteUI.SetActive(true);
//            objMng.StartCoroutine(objMng.uiManager.LoadTextOneByOne(objMng.noteText.text, objMng.inputTextUI));
//        }*/
//    }
//}
