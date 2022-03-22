using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance;

    [SerializeField] private CanvasGroup sceneLoaderCanvasGroup;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject myKoala;
    [SerializeField] private GameObject loadingBar;
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

    private void Start()
    {
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);

        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        myKoala.SetActive(true);
        loadingBar.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        loadSceneName = sceneName;

        StartCoroutine(Load(sceneName));
    }

    private IEnumerator Load(string sceneName)
    {
        progressBar.fillAmount = 0f;
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
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
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
            sceneLoaderCanvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }
}




