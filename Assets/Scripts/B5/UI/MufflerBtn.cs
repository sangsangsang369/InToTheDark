using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MufflerBtn : MonoBehaviour
{
    B5_UIManager uiManager;
    MonsterBro monsterBro;
    public GameObject textUI;
    public GameObject textsUI;
    public List<Text> muffTexts;
    public List<Text> newsTexts;
    public Text inputTextUI, inputText2UI;
    SoundManager inst;
    public AudioClip endingBGM2;
    public GameObject newsScene1;
    public List<GameObject> covers;
    public GameObject cover;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<B5_UIManager>();
        monsterBro  = FindObjectOfType<MonsterBro>();
        inst = SoundManager.inst;
    }

    public void Clicked(){
        textUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(muffTexts, inputTextUI,2));
        //이형체 애니메이션 불러오기
        //검은화면
        Invoke("PlayOnBGM", 15f);
    }

    public void PlayOnBGM(){
        inst.PlayBGM(endingBGM2);
        PlayNewsEnding();
    }

    public void PlayNewsEnding(){
        newsScene1.SetActive(true);
        Invoke("PlayNext", 12f);
    }

    void PlayNext(){
        newsScene1.GetComponent<Animator>().SetTrigger("ZoomOut");
        Invoke("OnScpt", 10f);
    }

    public void OnScpt(){
        textsUI.SetActive(true);
        StartCoroutine(uiManager.LoadTexts(newsTexts, inputText2UI,3));
        cover.SetActive(true);
        StartCoroutine(MakeDark());
    }

    IEnumerator MakeDark()
    {
        float fadeCount = 0; //투명도(알파값) 초기 설정
        while (fadeCount < 1.0f) //알파값 255가 될 때까지
        {
            fadeCount += 0.15f;
            yield return new WaitForSeconds(0.1f);
            for(int i = 0; i < 4; i++){
                covers[i].GetComponent<Image>().color = new Color(0, 0, 0, fadeCount);
            }
        }
    }
}
