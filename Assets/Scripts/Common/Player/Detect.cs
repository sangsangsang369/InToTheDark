using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Detect : MonoBehaviour
{
    RaycastHit2D hit;
    UI uiManager;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos;
    Camera mainCamera;

    SlotSelectionMng slotSelectMng;
    Canvas canvas;
    GraphicRaycaster graphicRay;
    List<RaycastResult> results = new List<RaycastResult>();
    
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        uiManager = FindObjectOfType<UI>();
        
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        canvas = FindObjectOfType<Canvas>();
        graphicRay = canvas.transform.GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f); 
            hit = Physics2D.Raycast(mousePos, raycastDir, 10f);
            Check();
              //그래픽 레이캐스트 세팅
            var g_RayPosition = new PointerEventData(null);
            g_RayPosition.position = Input.mousePosition;
            graphicRay.Raycast(g_RayPosition, results);
            Check_GraphicRay();        
        }
    }

    void Check()
    {
        if(hit && hit.collider.GetComponent<Object>())
        {
            Object obj = hit.collider.GetComponent<Object>();
            if(obj.enabled && !uiManager.nowTexting)
            { 
                obj.ObjectFunction(); 
            }
        }
    }
    //각 씬에서 하이라키 창의 Canvas 바로 밑에 RayTargetedCanvas 꼭 생성해주세요!!(B3꺼 복붙해주세요!!)
    void Check_GraphicRay()
    {
        if(results.Count>0)
        {
            //클릭했을 때 그래픽레이가 닿은 최상위 오브젝트
            GameObject g_hitObj = results[0].gameObject;
            Debug.Log(g_hitObj);
            //인벤토리에 선택된 아이템이 존재할 때 && 선택된 아이템 말고 다른 곳 클릭했을 때 
            if(slotSelectMng.selectedItem && slotSelectMng.selectedItem != g_hitObj) 
            {
                //이미지 바꿔주고 값들 초기화
                slotSelectMng.selectedItem.transform.parent.GetComponent<Image>().sprite = slotSelectMng.unselectedSlotImg;
                slotSelectMng.selectedItem = null;
                slotSelectMng.usableItem = null;
                slotSelectMng.usableItems.Clear();       
            } 
        }
        results.Clear(); //다음 클릭을 위해 results 초기화 해주기(이거 꼭 해줘야됨)
    }
}
