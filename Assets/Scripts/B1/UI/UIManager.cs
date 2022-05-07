using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : UI
{
    DataManager data;
    SaveDataClass saveData;

    [HideInInspector] public bool isUnlocked;
    public GameObject note;
    public GameObject cardkeyScrpt;
    public GameObject goldenBookScrpt;
    public Sprite textBaseWithout;
    public Sprite textBase;
    public Text cardkeyNameText;
    public GameObject cardImage;
    public List<Text> cardkeyTexts;
    bool isFirstGB;
    InventoryMng inventoryMng;
    SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        isUnlocked = saveData.isUnlocked;
        isFirstGB = saveData.isFirstGB;

        inventoryMng = FindObjectOfType<InventoryMng>();
        sound = SoundManager.inst;
    }

    public IEnumerator LoadCardkeyTexts()
    {
        yield return null;
        for(int i = 0; i < 2; i++)
        {
            while(nowTexting)
            {
                yield return null;
            }
            for(int j = 0; j < 2; j++)
            {
                if(textOrder == j)
                {
                    if(textOrder == 0)
                    {
                        sound.EffectPlay(sound.dropEffect);
                        cardkeyScrpt.GetComponent<Image>().sprite = textBaseWithout;
                        cardkeyNameText.text = "";
                        cardImage.GetComponent<Image>().enabled = false;
                    }
                    else if(textOrder == 1)
                    {
                        sound.EffectPlay(sound.getItemEffect);
                        cardkeyScrpt.GetComponent<Image>().sprite = textBase;
                        cardkeyNameText.text = "카드키";
                        cardImage.GetComponent<Image>().enabled = true;
                    }
                    StartCoroutine(LoadTextOneByOne(cardkeyTexts[j].text, inputTextUI));
                }
            }
            textOrder++;
        }
        textOrder = 0;
    }

    public IEnumerator LoadGoldenBookText(List<Text> texts, Text inputTextUI, Text nameText, GameObject illust, Sprite bookImage, Sprite letterImage)
    {
        yield return null;
        for(int i = 0; i < 9; i++)
        {
            while(nowTexting)
            {
                yield return null;
            }

            for(int j = 0; j < 9; j++)
            {
                
                if(textOrder == j)
                {
                    if(textOrder == 0)
                    {
                        nameText.text = "금테가 둘러진 책";
                        sound.EffectPlay(sound.bookSelectEffect);
                    }
                    else if(textOrder == 1)
                    {
                        sound.EffectPlay(sound.turnPaperEffect);
                        nameText.text = "";
                        //여기서 텍스트 베이스 바꿔주고
                        goldenBookScrpt.GetComponent<Image>().sprite = textBaseWithout;
                        illust.SetActive(false);
                    }
                    else if(textOrder == 2)
                    {
                        if(isFirstGB)
                        {
                            inventoryMng.AddToInventory(note, 0.1f, ItemClass.ItemPrefabOrder.Note);
                            sound.EffectPlay(sound.getItemEffect);
                        }
                        nameText.text = "책에서 발견된 쪽지";
                        //다시 텍스트 베이스 바꿔주고
                        goldenBookScrpt.GetComponent<Image>().sprite = textBase;
                        illust.GetComponent<Image>().sprite = letterImage;
                        illust.GetComponent<Image>().SetNativeSize();
                        illust.SetActive(true);
                    }
                    else if(textOrder == 3)
                    {
                        nameText.text = "금테가 둘러진 책";
                        illust.GetComponent<Image>().sprite = bookImage;
                        illust.GetComponent<Image>().SetNativeSize();
                    }

                    if(isFirstGB)
                    {
                        StartCoroutine(LoadTextOneByOne(texts[j].text, inputTextUI));
                    }
                    else
                    {
                        if(j != 0 && j != 1 && j != 2)
                        {
                            StartCoroutine(LoadTextOneByOne(texts[j].text, inputTextUI));
                        }
                    }
                }
            }
            textOrder++;
        }

        if(isFirstGB)
        {
            isFirstGB = false;
            saveData.isFirstGB = false;
            data.Save();
        }
        textOrder = 0;
    }
}
