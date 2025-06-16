using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyUIController : MonoBehaviour
{
    public TMP_Text playerNameInfoText;

    public Button warriorButton;
    public Button assassinButton;

    public Image warriorPanelImage;   // Warrior 패널의 배경 Image
    public Image assassinPanelImage;  // Assassin 패널의 배경 Image

    private string selectedClass = "";

    void Start()
    {
        // 초기 상태: 아무것도 선택 안 함
        UpdateClassSelection("");
        // 버튼에 클릭 이벤트 연결
        warriorButton.onClick.AddListener(() => OnClassSelected("Warrior"));
        assassinButton.onClick.AddListener(() => OnClassSelected("Assassin"));
    }

    public void OnClassSelected(string className)
    {
        selectedClass = className;
        playerNameInfoText.text = className;
        UpdateClassSelection(className);
    }

    void UpdateClassSelection(string className)
    {
        // Warrior 선택 시
        if (className == "Warrior")
        {
            SetPanelActive(warriorPanelImage, true);
            SetPanelActive(assassinPanelImage, false);
        }
        // Assassin 선택 시
        else if (className == "Assassin")
        {
            SetPanelActive(warriorPanelImage, false);
            SetPanelActive(assassinPanelImage, true);
        }
        // 아무것도 선택 안 했을 때
        else
        {
            SetPanelActive(warriorPanelImage, false);
            SetPanelActive(assassinPanelImage, false);
            playerNameInfoText.text = "";
        }
    }

    void SetPanelActive(Image panelImage, bool isActive)
    {
        if (isActive)
        {
            // 완전 불투명, 원래 색상
            panelImage.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            // 회색, 반투명
            panelImage.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }

    public void OnLogoutButton()
    {
        Debug.Log("로그아웃 버튼 클릭!");
    }

    public void OnCharacterSelectButton()
    {
        Debug.Log("캐릭터선택창 버튼 클릭!");
    }

    public void OnGameMapButton()
    {
        Debug.Log("게임맵 버튼 클릭!");
    }

    public void OnEnterBattleButton()
    {
        Debug.Log("전투입장 버튼 클릭!");
    }

    // 필요하다면 캐릭터 이미지 클릭도 추가 가능
    public void OnCharacterImageClick(string characterName)
    {
        Debug.Log(characterName + " 캐릭터 클릭!");
    }
}