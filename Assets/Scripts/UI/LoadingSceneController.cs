using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneController : MonoBehaviour
{
    public Slider progressBar;
    public Text loadingText;
    public GameObject tapToStartObj; // TapToStart 오브젝트

    public static string nextSceneName = "Lobby"; // 기본값: Lobby

    private bool isLoading = false;

    void Start()
    {
        // TapToStart 오브젝트 활성화, 프로그레스바 0으로 초기화
        if (tapToStartObj != null)
            tapToStartObj.SetActive(true);
        if (progressBar != null)
            progressBar.value = 0f;
        if (loadingText != null)
            loadingText.text = "Tap to Start!";
    }

    // TapToStart 오브젝트의 OnClick 이벤트에 이 함수 연결
    public void OnTapToStart()
    {
        if (!isLoading)
        {
            isLoading = true;
            if (tapToStartObj != null)
                tapToStartObj.SetActive(false); // 클릭 후 비활성화
            if (loadingText != null)
                loadingText.text = "Loading...";
            StartCoroutine(FakeLoadingAndLoadScene());
        }
    }

    IEnumerator FakeLoadingAndLoadScene()
    {
        // 1. 프로그레스바를 애니메이션처럼 채우기 (예: 1초 동안)
        float duration = 1.0f;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / duration);
            if (progressBar != null)
                progressBar.value = progress;
            yield return null;
        }
        if (progressBar != null)
            progressBar.value = 1f;

        // 2. 실제로 Lobby 씬 비동기 로드
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);
        // (선택) 로딩 중에 프로그레스바를 실제 진행도로 업데이트하려면 아래 코드 사용
        /*
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            if (progressBar != null)
                progressBar.value = Mathf.Clamp01(op.progress / 0.9f);
            if (op.progress >= 0.9f)
            {
                op.allowSceneActivation = true;
            }
            yield return null;
        }
        */
    }

    // 씬 이동을 요청할 때 사용하는 함수
    public static void LoadScene(string sceneName)
    {
        nextSceneName = sceneName;
        SceneManager.LoadScene("Loading");
    }
}