using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : Object
{
    public UI uiManager;
    public InventoryMng inventoryMng;
    //public Cabinet3 clockcabinet;
    public GameObject clockPanel;
    public GameObject prefabUI;
    public AnsCheck ansCheck;
    SlotSelectionMng slotSelectMng;
    SoundManager SM;
    public GameObject clockTipUI;
    public List<Text> clockText;
    public Text inputTextUI;
    public GameObject mainTutorialPanel;

    public List<GameObject> TutorialsPanels;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UI>();
        inventoryMng = FindObjectOfType<InventoryMng>();
        slotSelectMng = FindObjectOfType<SlotSelectionMng>();
        
        ansCheck = FindObjectOfType<AnsCheck>();
        SM = SoundManager.inst;
    }

    // Update is called once per frame
    public void UseClock()
    {
        if (prefabUI.transform.parent == this.transform)
        {
            prefabUI.transform.SetParent(this.transform.parent.parent.parent.parent, false);
        }
        if (slotSelectMng.selectedItem != this.gameObject)
        {
            slotSelectMng.itemName = "회중시계";
            slotSelectMng.SelectSlot(this.gameObject);
        }
        else
        {
            SM.EffectPlay(SM.pocketwatchEffect);
            // Image[] inventroyImgs = uiManager.inventoryUI.GetComponents<Image>();
            // for(int i = 0; i < inventroyImgs.Length; i++){
            //     inventroyImgs[i].color = new Color(255, 255, 255, 0);
            // }
            
            // Image[] btnImgs = uiManager.buttonsUI.GetComponents<Image>();
            // for(int i = 0; i < btnImgs.Length; i++){
            //     btnImgs[i].color = new Color(255, 255, 255, 0);
            // }
            clockPanel.SetActive(true);
            clockTipUI.SetActive(true);
            mainTutorialPanel.SetActive(true);
            StartCoroutine(uiManager.LoadClockTutorialTexts(clockText, inputTextUI, 5, TutorialsPanels));
        }
    }

    public void SetUI(){
        // uiManager.inventoryUI.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        // uiManager.buttonsUI.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    }

}
