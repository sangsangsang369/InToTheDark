using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : UI
{
    [HideInInspector] public int numOfClicked = 0;
    [HideInInspector] public bool isUnlocked = false;
    public GameObject note;
    public GameObject noteUI;
    public Text noteText;
    public Text cardkeyNameText;
    public GameObject cardImage;
    public List<Text> cardkeyTexts;
    bool isFirstGB = true;
    InventoryMng inventoryMng;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMng = FindObjectOfType<InventoryMng>();
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
                        cardkeyNameText.text = "";
                        cardImage.GetComponent<Image>().enabled = false;
                    }
                    else if(textOrder == 1)
                    {
                        cardkeyNameText.text = "B2 카드키";
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
        for(int i = 0; i < 8; i++)
        {
            while(nowTexting)
            {
                yield return null;
            }

            for(int j = 0; j < 8; j++)
            {
                
                if(textOrder == j)
                {
                    if(textOrder == 0)
                    {
                        nameText.text = "금테가 둘러진 책";
                    }
                    else if(textOrder == 1)
                    {
                        nameText.text = "";
                        illust.SetActive(false);
                    }
                    else if(textOrder == 2)
                    {
                        if(isFirstGB)
                        {
                            inventoryMng.AddToInventory(note, 0.1f);
                        }
                        nameText.text = "책에서 발견된 쪽지";
                        illust.GetComponent<Image>().sprite = letterImage;
                        illust.SetActive(true);
                    }
                    else if(textOrder == 3)
                    {
                        nameText.text = "금테가 둘러진 책";
                        illust.GetComponent<Image>().sprite = bookImage;
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
        }
        textOrder = 0;
    }
}
