using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartOrderMng : MonoBehaviour
{
    DataManager data;
    SaveDataClass saveData;
    SoundManager sound;

    //정답 : 팔 안쪽 → 손등 → 손가락 → 손바닥 → 손가락 → 팔등
    UI uiManager;
    InventoryMng inventoryMng;
    Hands hands;
    [SerializeField] private GameObject redJewel;
    [SerializeField] private GameObject wrongUI;
    [SerializeField] private GameObject correctUI;
    [SerializeField] private Text wrongText;
    [SerializeField] private Text correctText;
    [SerializeField] private Text inputTextUI;
    [SerializeField] private string[] answer;
    public List<string> answerSheet = new List<string>();
    private bool isCorrect = false;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        sound = SoundManager.inst;
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        hands = FindObjectOfType<Hands>();
        answer = new string[6] {"InsideArm", "BackHand", "Finger", "Palm", "Finger", "OutsideArm"};
    }

    public void CheckOrder()
    {
        for(int i = 0; i < 6; i++)
        {
            if(answer[i] != answerSheet[i])
            {
                wrongUI.SetActive(true);
                StartCoroutine(uiManager.LoadTextOneByOne(wrongText.text, inputTextUI));
                sound.EffectPlay(sound.handsScreamEffect);
                hands.GetComponent<Animator>().SetTrigger("ShakeTrigger");
                answerSheet = new List<string>();
                isCorrect = false;
                break;
            }
            else
            {
                isCorrect = true;
            }
        }
        
        if(isCorrect)
        {
            sound.EffectPlay(sound.getItemEffect);
            correctUI.SetActive(true);
            uiManager.StartCoroutine(uiManager.LoadTextOneByOne(correctText.text, inputTextUI));
            inventoryMng.AddToInventory(redJewel, 0.2f, ItemClass.ItemPrefabOrder.RedJewel);
            hands.isJewelGained = true;
            saveData.isJewelGained = true;
            this.gameObject.SetActive(false);
            data.Save();
        }
    }
}
