using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
    
    DataManager data;
    SaveDataClass saveData;

    //AudioSources
    public AudioSource bgmSource;
    public AudioSource effectSource;
    public AudioSource buttonSource;
    public AudioSource playerAudioSource;
    public AudioSource monsterAudioSource;
    public AudioSource conversationAudioSource;

    //BGM
    public AudioClip mainBGM;
    public AudioClip B12BGM;
    public AudioClip B34BGM;
    public AudioClip endingBGM;

    //Common Effect
    public AudioClip getItemEffect;
    public AudioClip playerWalkEffect;
    public AudioClip monsterWalkEffect;
    public AudioClip buttonOnStartScene;
    public AudioClip buttonEffect;
    public AudioClip conversationEffect;
    public AudioClip puzzleFailedEffect;
    public AudioClip doorOpenEffect;
    public AudioClip stairEffect;

    //B1 Effect
    public AudioClip bookSelectEffect;
    public AudioClip cardkeyDropEffect;
    public AudioClip letterDropEffect;
    public AudioClip turnPaperEffect;
    public AudioClip unlockEffect;
    public AudioClip unlockFailedEffect;
    public AudioClip doorUnlockEffect;
    public AudioClip lockNumberChangeEffect;

    //B2 Effect
    public AudioClip cabinetOpenLongEffect;
    public AudioClip cabinetOpenShortEffect;
    public AudioClip pocketwatchEffect;
    public AudioClip lockerOpenEffect;
    public AudioClip swipeStatueEffect;
    public AudioClip knifeEffect;
    public AudioClip moveClockEffect;

    //B3 Effect
    public AudioClip leavesShortEffect;
    public AudioClip monsterGrowlEffect;
    public AudioClip gooEffect;
    //Piano Effect
    public AudioClip doEffect;
    public AudioClip reEffect;
    public AudioClip miEffect;
    public AudioClip faEffect;
    public AudioClip solEffect;
    public AudioClip raEffect;
    public AudioClip siEffect;
    public AudioClip do_hEffect;
    public AudioClip re_hEffect;
    public AudioClip mi_hEffect;
    public AudioClip fa_hEffect;
    public AudioClip sol_hEffect;
    public AudioClip ra_hEffect;
    public AudioClip si_hEffect;

    //B4 Effect
    public AudioClip consoleTouchEffect;
    public AudioClip capsuleBrokenEffect;

    //B5 Effect
    public AudioClip doorSlideEffect;
    public AudioClip playerScreamEffect;
    public AudioClip priestWalkEffect;

    // Start is called before the first frame update
    void Start()
    {
        data = DataManager.singleTon;
        saveData = data.saveData;
        bgmSource.volume = saveData.volume1;
        effectSource.volume = saveData.volume2;
        buttonSource.volume = saveData.volume2;
        playerAudioSource.volume = saveData.volume2;
        monsterAudioSource.volume = saveData.volume2;

        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        bgmSource.clip = mainBGM;
        bgmSource.Play();

    }

    //BGM
    public void BGMStop()
    {
        bgmSource.Stop();
    }

    public void BGMPlay()
    {
        bgmSource.Play();
    }

    public void MainBGMPlay()
    {
        if(bgmSource.clip == mainBGM)
        {
            return;
        }
        bgmSource.clip = mainBGM;
        bgmSource.Play();
    }

    public void B12BGMPlay()
    {
        if (bgmSource.clip == B12BGM)
        {
            return;
        }
        bgmSource.clip = B12BGM;
        bgmSource.Play();
    }

    //B2
    public void cabinetOpenLongEffectPlay() // 끼익
    {
        effectSource.clip = cabinetOpenLongEffect;
        effectSource.Play();
    }

    public void cabinetOpenShortEffectPlay() // 덜컹덜컹-끼익
    {
        effectSource.clip = cabinetOpenShortEffect;
        effectSource.Play();
    }

    public void pocketwatchEffectPlay()
    {
        effectSource.clip = pocketwatchEffect;
        effectSource.Play();
    }

    public void lockerOpenEffectPlay()
    {
        effectSource.clip = lockerOpenEffect;
        effectSource.Play();
    }

    public void swipeStatueEffectPlay()
    {
        effectSource.clip = swipeStatueEffect;
        effectSource.Play();
    }

    public void knifeEffectPlay()
    {
        effectSource.clip = knifeEffect;
        effectSource.Play();
    }
    public void moveClockEffectPlay()
    {
        effectSource.clip = moveClockEffect;
        effectSource.Play();
    }
/////////////////////////////////////////////////////////////////
    //B3
    public void PianoKeysPlay(AudioClip key)
    {
        effectSource.clip = key;
        effectSource.Play();
    }

    public void leavesEffectPlay()
    {
        effectSource.clip = leavesShortEffect;
        effectSource.Play();
    }
    public void monsterExtractEffectPlay()
    {
        effectSource.clip = gooEffect;
        effectSource.Play();
    }

    //B5
    public void doorSlideEffectPlay()
    {
        effectSource.clip = doorSlideEffect;
        effectSource.Play();
    }
    public void playerScreamEffectPlay()
    {
        effectSource.clip = playerScreamEffect;
        effectSource.Play();
    }
    public void priestWalkEffectPlay()
    {
        effectSource.clip = priestWalkEffect;
        effectSource.Play();
    }

    //Common
    public void playerWalkEffectPlay()
    {
        if (playerAudioSource.clip == playerWalkEffect)
        {
            return;
        }
        playerAudioSource.clip = playerWalkEffect;
        playerAudioSource.Play();
    }

    public void getItemEffectPlay()
    {
        effectSource.clip = getItemEffect;
        effectSource.Play();
    }

    public void ButtonEffectPlay()
    {
        effectSource.clip = buttonEffect;
        effectSource.Play();
    }

    public void EffectPlay(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }

    public void Mute(bool muteOnTrue)
    {
        bgmSource.mute = muteOnTrue;
    }

    public bool EffectPlaying()
    {
        return effectSource.isPlaying;
    }
}
