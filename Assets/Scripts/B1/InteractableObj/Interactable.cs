using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected PlayerMng playerMng;
    protected B2PlayerManager B2PlayerMng;
    protected B3PlayerMng B3playerMng;
    public RaycastHit2D hit;
    Vector3 raycastDir = new Vector3(0, 0, 1);
    Vector3 mousePos;
    public Camera mainCamera;

    // Start is called before the first frame update
    protected void Start()
    {
        playerMng = FindObjectOfType<PlayerMng>();
        B2PlayerMng = FindObjectOfType<B2PlayerManager>();
        B3playerMng = FindObjectOfType<B3PlayerMng>();
        mainCamera = FindObjectOfType<Camera>();
    }

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(mousePos, new Vector3(0, 0, 10), Color.red, 0.5f); 
            hit = Physics2D.Raycast(mousePos, raycastDir, 10f);
            //Debug.Log("interactable " + hit.collider.tag);
        }
    }
}
