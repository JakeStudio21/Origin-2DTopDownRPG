using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요

public class LobbyUIController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text playerNameInfoText;
    public Button warriorButton;
    public Button assassinButton;
    public Button playButton; // Play 버튼 연결
    public Image warriorPanelImage;   // Warrior 패널의 배경 Image
    public Image assassinPanelImage;  // Assassin 패널의 배경 Image

    void Start()
    {
        // ScriptableObject의 값을 기반으로 초기 상태 설정
        OnClassSelected(GameDataManager.Instance.selectedPlayerData.selectedClass.ToString());

        // 버튼에 클릭 이벤트 연결
        warriorButton.onClick.AddListener(() => OnClassSelected("Warrior"));
        assassinButton.onClick.AddListener(() => OnClassSelected("Assassin"));
        playButton.onClick.AddListener(OnClickPlay); // Play 버튼 리스너 연결
    }

    public void OnClassSelected(string className)
    {
        // ScriptableObject에 선택 정보 저장
        if (className == "Warrior")
        {
            GameDataManager.Instance.selectedPlayerData.selectedClass = PlayerClass.Warrior;
        }
        else if (className == "Assassin")
        {
            GameDataManager.Instance.selectedPlayerData.selectedClass = PlayerClass.Assassin;
        }
        else
        {
            GameDataManager.Instance.selectedPlayerData.selectedClass = PlayerClass.None;
        }
        
        // UI 업데이트
        UpdateClassSelectionUI(className);
    }

    void UpdateClassSelectionUI(string className)
    {
        playerNameInfoText.text = className == "None" ? "Character Select" : className;

        SetPanelActive(warriorPanelImage, className == "Warrior");
        SetPanelActive(assassinPanelImage, className == "Assassin");
    }

    void SetPanelActive(Image panelImage, bool isActive)
    {
        panelImage.color = isActive ? Color.white : new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }
    
    public void OnClickPlay()
    {
        if (GameDataManager.Instance.selectedPlayerData.selectedClass == PlayerClass.None)
        {
            Debug.LogWarning("Character Select!!");
            // 여기에 사용자에게 피드백을 주는 UI 로직을 추가할 수 있습니다. (예: 텍스트 깜빡임)
            return;
        }
        
        Debug.Log($"[Lobby] 로비를 떠납니다. 선택된 클래스: {GameDataManager.Instance.selectedPlayerData.selectedClass}");
        
        // "Ingame_Loading" 씬을 통해 다음 씬(Scene1)으로 전환
        LoadingSceneController.LoadScene("Scene1", "Ingame_Loading");
    }

    public void OnPlayButton()
    {
        Debug.Log("Play 버튼 클릭! Scene1로 이동합니다.");
        SceneManager.LoadScene("Scene1");
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