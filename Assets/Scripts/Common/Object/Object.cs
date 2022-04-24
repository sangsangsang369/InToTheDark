using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    SceneLoadManager sceneLoader;
    public virtual void ObjectFunction()
    {
        Debug.Log("virtualFunction");
    }

    //B3 실험대 조합하는거 때문에 추가했습니다
    public virtual void ItemActive()
    {
        Debug.Log("ItemActive");
    }
    public virtual void ItemDeactive()
    {
        Debug.Log("ItemDeactive");
    }

    public void LoadScene(string sceneName)
    {
        SoundManager.inst.EffectPlay(SoundManager.inst.stairEffect);
        sceneLoader = SceneLoadManager.instance;
        sceneLoader.LoadScene(sceneName);
    }

    public void LoadRoom(string functionName, AudioClip clip)
    {
        SoundManager.inst.EffectPlay(clip);
        sceneLoader = SceneLoadManager.instance;
        sceneLoader.LoadRoom();
        Invoke(functionName, 0.5f);
    }
}
