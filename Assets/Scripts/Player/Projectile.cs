using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;

    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
        Debug.Log("발사 위치: " + startPosition); // Projectile 생성 위치 디버깅
    }

    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    public void UpdateProjectileRange(float projectileRange){
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger && (enemyHealth || indestructible || player)) {


// 여기서 ------------------------------------------------------------------------------------
            if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile)) {
                if (player && isEnemyProjectile) {
                    player.TakeDamage(1, transform);
                }

                if (enemyHealth && !isEnemyProjectile) {
                    enemyHealth.TakeDamage(1);
                }
// 여기까지 -----------------------------------------------------------------------------------


// 원본 --------------------------------------------------------------------------------------
//          if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile)) {
//              player?.TakeDamage(1, transform);
// 원본 ---------------------------------------------------------------------------------------


                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            } else if (!other.isTrigger && indestructible) {
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
            
    }

    private void DetectFireDistance() {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange) {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {   
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}