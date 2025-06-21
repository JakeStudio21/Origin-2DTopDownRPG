using UnityEngine;

// 이 클래스는 게임의 중요한 데이터를 관리하고, 씬 전환 시에도 파괴되지 않습니다.
public class GameDataManager : Singleton<GameDataManager>
{
    // 이 곳에 게임 전체에서 공유해야 할 데이터를 보관합니다.
    public SelectedPlayerData selectedPlayerData;

    // Singleton 패턴의 Awake를 오버라이드하여 추가적인 초기화 작업을 할 수 있습니다.
    // protected override void Awake()
    // {
    //     base.Awake();
    //     // 추가 초기화 코드
    // }
} 