using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPopupController : MonoBehaviour
{
    public GameObject popupPanel;        // ResultPopupPanel
    public GameObject victoryImage;      // Victory 이미지
    public GameObject defeatImage;       // Defeat 이미지
    public Button confirmButton;         // OK 버튼

    void Awake()
    {
        popupPanel.SetActive(false);     // 팝업 패널 숨기기
        victoryImage.SetActive(false);   // Victory 이미지 숨기기
        defeatImage.SetActive(false);    // Defeat 이미지 숨기기
        confirmButton.onClick.AddListener(OnConfirm);
    }

    public void Show(bool isVictory)
    {
        if (gameObject == null) return;

        popupPanel.SetActive(true);
        
        // Victory/Defeat 이미지 중 하나만 보이게 하기
        victoryImage.SetActive(isVictory);
        defeatImage.SetActive(!isVictory);
    }

    void OnConfirm()
    {
        Debug.Log("OK 버튼이 눌렸습니다!"); // 이 줄 추가
        Time.timeScale = 1f;
        // SceneManager.LoadScene("Lobby");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }
    // {
    //     confirmButton.onClick.AddListener(OnConfirm);
    //     if (gameObject == null) return; // 이 오브젝트가 파괴되었으면 실행하지 않음

    //     popupPanel.SetActive(true);
    //     messageText.text = isVictory ? "Victory" : "Defeat";
    //     // 배경색 등도 필요하면 여기서 바꿀 수 있음
    // }

    // void OnConfirm()
    // {
    //     Time.timeScale = 1f; // 혹시 멈춰있으면 재개
    //     SceneManager.LoadScene("Lobby");
    // }
}
