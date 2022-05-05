using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    //영광의 첫 플레이
    public bool isFirstPlay;
    public bool isGameEnded;

    public enum playerStartPoint
    {
        B1rightDoor, B1Library, B2leftDoor, B2CabinetRoom, B2Gallery, B2rightDoor, B3leftDoor, 
        B3TreeRoom, B3Pianoroom, B3rightDoor, B4leftDoor, B4Chapel, B4Lab, B4rightDoor, B5leftDoor
    }

    //플레이어 위치 정보
    public float[] playerXstartPoints = {30.7f, 7.1f, -32.5f, -31.4f, 7.2f, 29.6f, -32.5f, 10.82f, -1.34f, 18f, -32.5f, -10.94f, 1.48f, 15.7f, 3.5f};
    public float playerXstartPoint;
    public string currFloor;
    public string currRoomPos;
    
    // 사운드
    public float volume1, volume2;

    //인벤토리 및 아이템
    public List<ItemClass> itemList;

    //지하 1층
    public bool isFirstGB;
    public bool isUnlocked;
    public bool isDiaryClicked;

    public bool isMufflerPicked;
    public bool isLetterPicked;

    //지하 2층
    public bool keyUsed;
    public bool alreadyOpen;
    public bool playPuzzleOnce;
    public bool isB3DoorOpened;
    public bool OnB2CandleOnce;
    public bool playB2StatueOnce;
    public bool ReB2;
    public bool s1On, s2On;

    //지하 3층
    public bool isB3ReEntered;
    public bool OnB3CandleOnce;
    public bool playB3StatueOnce;
    public bool isPianoMemoGained;
    public bool monsterExtractinInventory; 
    public bool isLabTableReEntered;
    public bool isB4DoorOpened;

    public bool isTreesapPicked;
    public bool isBranchPicked;
    public bool isLeafPicked;
    public bool isFruitPicked;
    public int fruitNum;


    //지하 4층
    public bool isB4ReEntered;
    public bool isDaggerPicked;
    public bool isJewelGained;
    public bool isB4LockUnlocked;
    public bool isB5DoorOpened;
    public bool isMonsterAppeared;

    public SaveDataClass()
    {
        isFirstPlay = true;
        isGameEnded = false;
        
        //플레이어 위치
        playerXstartPoint = -35f;
        currFloor = "B1";
        currRoomPos = "복도";

        volume1 = 1;
        volume2 = 1;

        //인벤토리 및 아이템
        itemList = new List<ItemClass>();

        //지하 1층
        isFirstGB = true;
        isUnlocked = false;
        isDiaryClicked = false;

        isMufflerPicked = false;
        isLetterPicked = false;

        //지하 2층
        keyUsed = false;
        alreadyOpen = false;
        playPuzzleOnce = false;
        isB3DoorOpened = false;
        OnB2CandleOnce = false;
        playB2StatueOnce = false;
        ReB2 = false;
        s1On = false;
        s2On = false;

        //지하 3층
        isB3ReEntered = false;
        OnB3CandleOnce = false;
        playB3StatueOnce = false;
        isPianoMemoGained = false;
        isLabTableReEntered = false;
        monsterExtractinInventory = false; //이거 좀 봐야할 듯
        isB4DoorOpened = false;

        isTreesapPicked = false;
        isBranchPicked = false;
        isLeafPicked = false;
        isFruitPicked = false;
        fruitNum = 5;

        //지하 4층
        isB4ReEntered = false;
        isDaggerPicked = false;
        isJewelGained = false;
        isB4LockUnlocked = false;
        isB5DoorOpened = false;
        isMonsterAppeared = false;
    }
}
