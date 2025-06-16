using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("로그찍히는지확인!");
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