using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraParent; //player가 아닌 다른 Parent = GameObjects
    public GameObject mainCharacter; //player
    public GameObject playerCamera;
    [SerializeField]protected bool switchCamera = false; //true일 경우 좌,우 끝에 도달, false일 경우 끝에 도달하지 않은 상태
    protected Player player;
    protected DataManager data;
    protected SaveDataClass saveData;

    protected void Start()
    {
        player = FindObjectOfType<Player>();
        data = DataManager.singleTon;
        saveData = data.saveData;
    }

    public virtual void CameraSetting()
    {
        Debug.Log("CameraSetting");
    }

    protected void CameraLimit(float bottomLimit, float topLimit)
    {
        if (mainCharacter.transform.position.x <= bottomLimit || mainCharacter.transform.position.x >= topLimit)
        {
            if (switchCamera == false)
            {
                switchCamera = true;
                if (this.transform.position.x <= bottomLimit) // 왼쪽 끝 넘어가면
                {
                    this.transform.SetParent(cameraParent.transform);
                    this.transform.position = new Vector3(bottomLimit, this.transform.position.y, -10); // 왼쪽 끝으로 카메라 위치 재조정
                    this.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                }
                else if (this.transform.position.x >= topLimit) // 오른쪽 끝 넘어가면
                {
                    this.transform.SetParent(cameraParent.transform);
                    this.transform.position = new Vector3(topLimit, this.transform.position.y, -10); // 오른쪽 끝으로 카메라 위치 재조정
                    this.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                }
            }
        }
        else
        {
            switchCamera = false;
            this.transform.SetParent(mainCharacter.transform); // 카메라의 Parent를 player로 다시 바꿔줌
            playerCamera.transform.localPosition = new Vector3(0, this.transform.localPosition.y, -10);
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
