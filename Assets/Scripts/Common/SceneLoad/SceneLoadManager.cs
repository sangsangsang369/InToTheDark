using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance;

    [SerializeField] private CanvasGroup sceneLoaderCanvasGroup;
    [SerializeField] private Image backGround;
    [SerializeField] private GameObject gradation1;
    [SerializeField] private GameObject gradation2;
    private string loadSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    //씬 이동할 때 이 함수
    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        gradation1.SetActive(true);
        gradation2.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        loadSceneName = sceneName;

        StartCoroutine(Load(sceneName));  
    }

    //방 이동할 때 이 함수
    public void LoadRoom()
    {
        gameObject.SetActive(true);
        gradation1.SetActive(true);
        gradation2.SetActive(true);

        StartCoroutine(LoadRoomCoroutine());
    }

    private IEnumerator Load(string sceneName)
    {
        backGround.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;
        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;

            if (op.progress < 0.9f)
            {
                backGround.fillAmount = Mathf.Lerp(backGround.fillAmount, op.progress, timer);

                if (backGround.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                backGround.fillAmount = Mathf.Lerp(backGround.fillAmount, 1f, timer);

                if (backGround.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private IEnumerator LoadRoomCoroutine()
    {
        backGround.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));
        yield return StartCoroutine(Fade(false));
    }

    private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= LoadSceneEnd;
        }
    }


    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 2f;
            sceneLoaderCanvasGroup.alpha = Mathf.Lerp(isFadeIn ? 1 : 1, isFadeIn ? 1 : 0, timer);
        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }
}




