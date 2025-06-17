using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // [SerializeField] private int startingHealth = 3; - 몬스터 체력을 시작할때 체력으로 세팅한 경우(이전버전)
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private int maxHealth = 100; // 초기체력을 MaxHealth로 변경



    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    public bool isBoss = false; // Inspector에서 체크

    public string bossId = ""; // Inspector에서 "BossA", "BossB" 등으로 설정
    public bool isMiniBoss = false;  // Inspector에서 "BossA", "BossB" 등으로 설정

    public bool isDead = false;


    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        // currentHealth = startingHealth; - 기존 코드 ( Health 체력 변경중 )
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());

        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        if (isBoss)
        {
            Debug.Log("보스처치완료");
        }
        // 죽는 연출, 파괴 등 추가
        // Destroy(gameObject); // 필요에 따라

      foreach (var col in GetComponentsInChildren<Collider2D>())
      {
          col.enabled = false;
      }
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath() {
        if (currentHealth <= 0) {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }
}