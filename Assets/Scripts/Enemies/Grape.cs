using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject grapeProjectilePrefab;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake() {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack() {
        myAnimator.SetTrigger(ATTACK_HASH);

        if (transform.position.x - PlayerController.Instance.transform.position.x < 0) {
            spriteRenderer.flipX = false;
        } else {
            spriteRenderer.flipX = true;
        }
    }

    public void SpawnProjectileAnimEvent() {
        Debug.Log("SpawnProjectileAnimEvent called");
//        Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
        if (grapeProjectilePrefab == null) {
            Debug.LogError("grapeProjectilePrefab is NULL!");
            return;
        }
        GameObject proj = Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
        Debug.Log("Projectile instantiated at " + transform.position);
    }
}
