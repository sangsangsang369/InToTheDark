using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartBeat : MonoBehaviour
{
    SoundManager inst;
    [SerializeField] private AudioClip heartBeatClip;
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    float rayLength = 10f;

    void Start()
    {
        inst = SoundManager.inst;
    }

    // Update is called once per frame
    void Update()
    {
        CheckMonster();
        HeartBeating();
    }

    void CheckMonster()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Monster"));
        hit1 = Physics2D.Raycast(this.transform.position, Vector2.right, rayLength, layerMask);
        hit2 = Physics2D.Raycast(this.transform.position, Vector2.left, rayLength, layerMask);
    }

    void HeartBeating()
    {
        if(FindObjectOfType<Monster>() && FindObjectOfType<Monster>().areYouDied)
        {
            if(inst.playerHeartBeatSource.clip != inst.playerScreamEffect)
            {
                inst.playerHeartBeatSource.clip = inst.playerScreamEffect;
                inst.playerHeartBeatSource.loop = false;
                inst.playerHeartBeatSource.Play();
            }
        }
        else if(hit1.collider != null || hit2.collider != null)
        {
            if(inst.playerHeartBeatSource.clip == heartBeatClip)
            {
                return;
            }
            inst.playerHeartBeatSource.loop = true;
            inst.playerHeartBeatSource.clip = heartBeatClip;
            inst.playerHeartBeatSource.Play();
        }
        else if(hit1.collider == null && hit2.collider == null)
        {
            inst.playerHeartBeatSource.Stop();
            inst.playerHeartBeatSource.clip = null;
        }
    }
}
