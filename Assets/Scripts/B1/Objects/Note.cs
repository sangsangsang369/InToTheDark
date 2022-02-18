using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    UIManager uiManager;

    public void NoteItem()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.noteUI.SetActive(true);
        StartCoroutine(uiManager.LoadTextOneByOne(uiManager.noteText.text, uiManager.inputTextUI));
    }
}
