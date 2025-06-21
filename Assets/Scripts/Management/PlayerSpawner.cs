using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // [Header("Data")]
    // public SelectedPlayerData selectedPlayerData; // 이제 GameDataManager를 통해 접근합니다.

    [Header("Prefabs")]
    public GameObject warriorPrefab;
    public GameObject assassinPrefab;

    [Header("Spawn")]
    public Transform spawnPoint;

    void Start()
    {
        var selectedClass = GameDataManager.Instance.selectedPlayerData.selectedClass;
        Debug.Log($"[Scene1] 스포너 시작. 선택된 클래스: {selectedClass}");

        GameObject prefabToSpawn = null;
        switch (selectedClass)
        {
            case PlayerClass.Warrior:
                prefabToSpawn = warriorPrefab;
                break;
            case PlayerClass.Assassin:
                prefabToSpawn = assassinPrefab;
                break;
            default:
                Debug.LogWarning($"선택된 클래스가 '{selectedClass}'입니다. 기본 프리팹(Warrior)으로 스폰합니다.");
                // 기본값으로 Warrior를 스폰하여 게임이 멈추지 않도록 합니다.
                prefabToSpawn = warriorPrefab;
                break;
        }

        if (prefabToSpawn != null)
        {
            GameObject player = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            // 카메라가 새로 생성된 플레이어를 따라가도록 설정
            CameraController.Instance.SetPlayerCameraFollow();
        }
        else
        {
            // 이 경우는 warriorPrefab이 할당되지 않았을 때만 발생합니다.
            Debug.LogError("스폰할 플레이어 프리팹이 없습니다! Warrior 프리팹이 PlayerSpawner에 연결되었는지 확인하세요.");
        }
    }
}