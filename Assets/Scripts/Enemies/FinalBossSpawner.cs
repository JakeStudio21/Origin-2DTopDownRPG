using UnityEngine;

public class FinalBossSpawner : MonoBehaviour
{
    public GameObject finalBossAPrefab;
    public GameObject finalBossBPrefab;
    public GameObject finalBossCPrefab;

    private GameObject currentBoss;

    void Start()
    {
        // Scene 시작 시 FinalBossA 스폰
        SpawnBoss(finalBossAPrefab, transform.position);
    }

    // 보스가 죽을 때마다 호출
    public void OnBossDeath(string bossId, Vector3 deathPosition)
    {
        if (bossId == "FinalBossA")
        {
            SpawnBoss(finalBossBPrefab, deathPosition + new Vector3(1, 0, 0)); // 약간 옆에 스폰
        }
        else if (bossId == "FinalBossB")
        {
            SpawnBoss(finalBossCPrefab, deathPosition + new Vector3(1, 0, 0));
        }
        else if (bossId == "FinalBossC")
        {
            // 마지막 보스 처치 후 연출(문 열기, 엔딩 등)
            Debug.Log("모든 보스 처치! 엔딩 연출 등");
        }
    }

    private void SpawnBoss(GameObject bossPrefab, Vector3 pos)
    {
        if (bossPrefab == null) return;
        currentBoss = Instantiate(bossPrefab, pos, Quaternion.identity);

        // EnemyHealth에 스포너 연결
        EnemyHealth eh = currentBoss.GetComponent<EnemyHealth>();
        if (eh != null)
        {
            eh.bossSpawner = this;
        }
    }
}