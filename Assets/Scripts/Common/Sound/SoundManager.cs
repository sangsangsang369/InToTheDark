using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    public AudioSource bgmSource;
    public AudioSource effectSource;
    public AudioSource buttonSource;

    public AudioClip mainBGM;
    public AudioClip B12BGM;
    public AudioClip B34BGM;
    public AudioClip endingBGM;
    public AudioClip fishBGM;
    public AudioClip mineBGM;
    public AudioClip huntBGM;
    public AudioClip composeBGM;


    public AudioClip bookEffect;
    public AudioClip openPaperEffect;
    public AudioClip drawingEffect;
    public AudioClip stepEffect;
    public AudioClip storeEffect;
    public AudioClip deliveryEffect;
    public AudioClip crowdEffect;
    public AudioClip carEffect;
    public AudioClip myaoEffect;

    public AudioClip workEffect;
    public AudioClip houseEffect;
    public AudioClip cheerEffect;
    public AudioClip composeEffect;
    public AudioClip fanfareEffect;
    public AudioClip errorEffect;
    public AudioClip harvestEffect;
    public AudioClip plantEffect;
    public AudioClip expandEffect;
    public AudioClip coinEffect;

    public AudioClip succedEffect;
    public AudioClip failEffect;
    public AudioClip gangEffect;
    public AudioClip stoneEffect;
    public AudioClip grassEffect;
    public AudioClip deerfailEffect;
    public AudioClip deerhornEffect;
    public AudioClip deeroutEffect;
    public AudioClip shipEffectOne;
    public AudioClip shipEffectTwo;
    public AudioClip throwEffect;
    public AudioClip jjiEffect;
    public AudioClip rillEffect;
    public AudioClip mulEffect;

    //Common Effect
    public AudioClip getItemEffect;

    //B2 Effect
    public AudioClip cabinetOpenLongEffect;
    public AudioClip cabinetOpenShortEffect;
    public AudioClip pocketwatchEffect;
    public AudioClip lockerOpenEffect;
    public AudioClip swipeStatueEffect;
    public AudioClip knifeEffect;

    // Start is called before the first frame update
    void Start()
    {
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

    public void ComposeBGMPlay()
    {
        if (bgmSource.clip == composeBGM)
        {
            return;
        }
        bgmSource.clip = composeBGM;
        bgmSource.Play();
    }

    public void FishBGMPlay()
    {
        if (bgmSource.clip == fishBGM)
        {
            return;
        }
        bgmSource.clip = fishBGM;
        bgmSource.Play();
        WorkEffectPlay();
    }

    public void MineBGMPlay()
    {
        if (bgmSource.clip == mineBGM)
        {
            return;
        }
        bgmSource.clip = mineBGM;
        bgmSource.Play();
        WorkEffectPlay();
    }

    public void HuntBGMPlay()
    {
        if (bgmSource.clip == huntBGM)
        {
            return;
        }
        bgmSource.clip = huntBGM;
        bgmSource.Play();
        WorkEffectPlay();
    }


    public void cabinetOpenLongEffectPlay() // 끼익
    {
        if (effectSource.clip == cabinetOpenShortEffect)
        {
            return;
        }
        else if (effectSource.clip == lockerOpenEffect)
        {
            return;
        }
        effectSource.clip = cabinetOpenLongEffect;
        effectSource.Play();
    }

    public void cabinetOpenShortEffectPlay() // 덜컹덜컹
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

    public void getItemEffectPlay()
    {
        effectSource.clip = getItemEffect;
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
    void WorkEffectPlay()
    {
        effectSource.clip = workEffect;
        effectSource.Play();
    }

    public void BookEffectPlay()
    {
        effectSource.clip = bookEffect;
        effectSource.Play();
    }

    public void StoreEffectPlay()
    {
        effectSource.clip = storeEffect;
        effectSource.Play();
    }
    public void OpenPaperEffectPlay()
    {
        effectSource.clip = openPaperEffect;
        effectSource.Play();
    }

    public void DrawingEffectPlay()
    {
        effectSource.clip = drawingEffect;
        effectSource.Play();
    }

    public void StepEffectPlay()
    {
        effectSource.clip = stepEffect;
        effectSource.Play();
    }

    public void DeliveryEffectPlay()
    {
        effectSource.clip = deliveryEffect;
        effectSource.Play();
    }

    public void CrowdEffectPlay()
    {
        effectSource.clip = crowdEffect;
        effectSource.Play();
    }

    public void CarEffectPlay()
    {
        effectSource.clip = carEffect;
        effectSource.Play();
    }

    public void MyaoEffectPlay()
    {
        effectSource.clip = myaoEffect;
        effectSource.Play();
    }

    public void HouseEffectPlay()
    {
        if(effectSource.clip == fanfareEffect)
        {
            return;
        }
        effectSource.clip = houseEffect;
        effectSource.Play();
    }

    public void CheerEffectPlay()
    {
        effectSource.clip = cheerEffect;
        effectSource.Play();
    }

    public void ComposeEffectPlay()
    {
        effectSource.clip = composeEffect;
        effectSource.Play();
    }

    public void FanfareEffectPlay()
    {
        effectSource.clip = fanfareEffect;
        effectSource.Play();
    }

    public void ErrorEffectPlay()
    {
        effectSource.clip = errorEffect;
        effectSource.Play();
    }

    public void HarvestEffectPlay()
    {
        effectSource.clip = harvestEffect;
        effectSource.Play();
    }

    public void PlantEffectPlay()
    {
        effectSource.clip = plantEffect;
        effectSource.Play();
    }

    public void ExpandEffectPlay()
    {
        effectSource.clip = expandEffect;
        effectSource.Play();
    }

    public void CoinEffectPlay()
    {
        effectSource.clip = coinEffect;
        effectSource.Play();
    }

    public void ButtonEffectPlay()
    {
        buttonSource.Play();
    }

    public void Mute(bool muteOnTrue)
    {
        bgmSource.mute = muteOnTrue;
    }

    public void SuccedEffectPlay()  //일하기 성공
    {
        effectSource.clip = succedEffect;
        effectSource.Play();
    }

    public void FailEffectPlay()    //일하기 실패
    {
        effectSource.clip = failEffect;
        effectSource.Play();
    }

    public void GangEffectPlay()
    {
        effectSource.clip = gangEffect;
        effectSource.Play();
    }

    public void StoneEffectPlay()
    {
        effectSource.clip = stoneEffect;
        effectSource.Play();
    }

    public void GrassEffectPlay()
    {
        effectSource.clip = grassEffect;
        effectSource.Play();
    }

    public void DeerfailEffectPlay()
    {
        effectSource.clip = deerfailEffect;
        effectSource.Play();
    }

    public void DeerhornEffectPlay()
    {
        effectSource.clip = deerhornEffect;
        effectSource.Play();
    }

    public void DeeroutEffectPlay()
    {
        effectSource.clip = deeroutEffect;
        effectSource.Play();
    }

    public void ThrowEffectPlay()
    {
        effectSource.clip = throwEffect;
        effectSource.Play();
    }

    public void JjiEffectPlay()
    {
        effectSource.clip = jjiEffect;
        effectSource.Play();
    }

    public void RillEffectPlay()
    {
        effectSource.clip = rillEffect;
        effectSource.Play();
    }

    public void MulEffectPlay()
    {
        effectSource.clip = mulEffect;
        effectSource.Play();
    }

    public bool EffectPlaying()
    {
        return effectSource.isPlaying;
    }
}
