using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UI : MonoBehaviour
{
    public bool nowTexting;
    public int textOrder = 0;
    public Text inputTextUI;
    [HideInInspector] public int numOfClicked = 0;

    // Start is called before the first frame update
    void Start()
    {
        nowTexting = false;
    }

    public IEnumerator LoadTextOneByOne(string inputTextString, Text inputTextUI, float eachTime = 0.1f, bool canClickSkip = true)
    {
        nowTexting = true;
        inputTextUI.gameObject.SetActive(true);
        SoundManager inst = SoundManager.inst;
        inst.conversationAudioSource.clip = inst.conversationEffect;
        inst.conversationAudioSource.Play();
        float miniTimer = 0f; 
        float currentTargetNumber = 0f; 
        int currentNumber = 0; 
        string displayedText = "";
        StringBuilder builder = new StringBuilder(displayedText);
        while (currentTargetNumber < inputTextString.Length)
        {
            while (currentNumber < currentTargetNumber)
            { 
                builder.Append(inputTextString.Substring(currentNumber, 1));
                currentNumber++;
            }
            inputTextUI.text = builder.ToString();
            yield return null;

            if(Input.GetMouseButtonDown(0))
            {

                inst.conversationAudioSource.Stop();
                break;
            }

            miniTimer += Time.deltaTime;
            currentTargetNumber = miniTimer / eachTime;
        }
        while (currentNumber < inputTextString.Length)
        {
            builder.Append(inputTextString.Substring(currentNumber, 1));
            currentNumber++;
        }
        inputTextUI.text = builder.ToString();
        yield return null;
        

        while(true)
        {
            yield return null;
            if(Input.GetMouseButtonDown(0))
            {
                nowTexting = false;
                break;
            }
        }
    }

    public IEnumerator LoadTexts(List<Text> texts, Text inputTextUI, int numOfTexts)
    {
        yield return null;
        for(int i = 0; i < numOfTexts; i++)
        {
            while(nowTexting)
            {
                yield return null;
            }
            for(int j = 0; j < numOfTexts; j++)
            {
                if(textOrder == j)
                {
                    StartCoroutine(LoadTextOneByOne(texts[j].text, inputTextUI));
                }
            }
            textOrder++;
        }
        textOrder = 0;
    }
}
