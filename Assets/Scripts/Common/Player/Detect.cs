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
    public Camera mainCamera;

    SlotSelectionMng slotSelectMng;
    public Canvas canvas;
    GraphicRaycaster graphicRay;
    List<RaycastResult> results = new List<RaycastResult>();
    
    protected void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        uiManager = FindObjectOfType<UI>();
        
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        //canvas = FindObjectOfType<Canvas>();
        graphicRay = canvas.transform.GetComponent<GraphicRaycaster>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canvas == null)
            {
                canvas = FindObjectOfType<Canvas>();
                graphicRay = canvas.transform.GetComponent<GraphicRaycaster>();
            }
            if(!IsPointerOverUIObject())
            {
                int layerMask = (1 << LayerMask.NameToLayer("Object"));
                mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f); 
                hit = Physics2D.Raycast(mousePos, raycastDir, 10f, layerMask);
                Check();
            }
            
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
            //Debug.Log(g_hitObj);
            //인벤토리에 선택된 아이템이 존재할 때 && 선택된 아이템 말고 다른 곳 클릭했을 때 
            if(slotSelectMng.selectedItem && slotSelectMng.selectedItem != g_hitObj) 
            {
                //이미지 바꿔주고 값들 초기화
                slotSelectMng.selectedItem.transform.parent.GetComponent<Image>().sprite = slotSelectMng.unselectedSlotImg;
                slotSelectMng.selectedItem = null;
                slotSelectMng.usableItem = null;
                slotSelectMng.usableItems.Clear();  
                Destroy(slotSelectMng.itemNameText.gameObject);  //아이템 이름 텍스트 파괴 
            } 
        }
        results.Clear(); //다음 클릭을 위해 results 초기화 해주기(이거 꼭 해줘야됨)
    }

    //만약 포인터가 UI위에 있을때 true를 반환 아니면 false를 반환
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1;
    }
}
