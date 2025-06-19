using UnityEngine;
using Cinemachine; // 로비에서 캐릭터선택후 Scene1에 입장할때 카메라 연결이 끊기는 문제처리를 위한 추가

public class PlayerSpawner : MonoBehaviour
{
    public SelectedPlayerData selectedPlayerData; // ScriptableObject 연결
    public GameObject warriorPrefab;
    public GameObject assassinPrefab;
    public Transform spawnPoint;

    public CinemachineVirtualCamera virtualCamera; // Inspector에 연결

    void Start()
    {
        GameObject prefabToSpawn = null;
        switch (selectedPlayerData.selectedClass)
        {
            case PlayerClass.Warrior:
                prefabToSpawn = warriorPrefab;
                break;
            case PlayerClass.Assassin:
                prefabToSpawn = assassinPrefab;
                break;
        }
        if (prefabToSpawn != null)
        {
            GameObject player = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

            // ★ 카메라 Follow/LookAt 연결
            if (virtualCamera != null)
            {
                virtualCamera.Follow = player.transform;
                virtualCamera.LookAt = player.transform;
            }
        }
        else
        {
            Debug.LogError("선택된 캐릭터가 없습니다!");
        }

        // if (prefabToSpawn != null)
        // {
        //     Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        // }
        // else
        // {
        //     Debug.LogError("선택된 캐릭터가 없습니다!");
        // }
    }
}