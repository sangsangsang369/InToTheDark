using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterNewsEnds : MonoBehaviour
{
    public GameObject KnifeEndingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextOn() // 엔딩텍스트재생 -> 분기선택에 따라 다르게 띄우기 + 텍스트랑 ui도 동시 재생
    {
        //sound.EndingPlay();
        KnifeEndingText.SetActive(true);
    }
}
