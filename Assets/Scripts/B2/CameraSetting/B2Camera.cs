using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class B2Camera : CameraScript
{
    //bool OutGallery = true; // 지하 2층 갤러리 나가면

    new void Start()
    {
        base.Start();
        player.currRoom = "B2_Hallway";
    }

    void Update()
    {
        CameraSetting();
    }

    public override void CameraSetting()
    {
        if (player.currRoom == "B2_Hallway")
        {
            CameraLimit(-28.8f, 28.8f);
        }
        else if (player.currRoom == "B2_Cabinet")
        {
            CameraLimit(-38.4f, -28.6f);
        }
        else if (player.currRoom == "B2_Gallery")
        {
            CameraLimit(-4.065f, 0.55f);
        }
    }

    // private void CameraLimit(float bottomLimit, float topLimit)
    // {
    //     if (mainCharacter.transform.position.x <= bottomLimit || mainCharacter.transform.position.x >= topLimit)
    //     {
    //         if (switchCamera == false)
    //         {
    //             switchCamera = true;
    //             if (this.transform.position.x <= bottomLimit) // 왼쪽 끝 넘어가면
    //             {
    //                 this.transform.SetParent(cameraParent.transform);
    //                 this.transform.position = new Vector3(bottomLimit, this.transform.position.y, -10); // 왼쪽 끝으로 카메라 위치 재조정
    //                 this.transform.localScale = new Vector3(0.7f, 0.7f, 1);
    //             }
    //             else if (this.transform.position.x >= topLimit) // 오른쪽 끝 넘어가면
    //             {
    //                 this.transform.SetParent(cameraParent.transform);
    //                 this.transform.position = new Vector3(topLimit, this.transform.position.y, -10); // 오른쪽 끝으로 카메라 위치 재조정
    //                 this.transform.localScale = new Vector3(0.7f, 0.7f, 1);
    //             }
    //         }
    //     }
    //     else
    //     {
    //         if (switchCamera == true)
    //         {
    //             switchCamera = false;
    //             this.transform.SetParent(mainCharacter.transform); // 카메라의 Parent를 player로 다시 바꿔줌
    //             playerCamera.transform.localPosition = new Vector3(0, this.transform.localPosition.y, -10);
    //             this.transform.localScale = new Vector3(1, 1, 1);
    //         }
    //     }
    // }
}

