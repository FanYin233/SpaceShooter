using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float moveSpeed = 3f;
    public float explosionDelay = 2f;

    private bool targetAcquired = false;
    private Transform targetEnemy;

    private void Start()
    {
        StartCoroutine(ActivateBomb());
    }

    IEnumerator ActivateBomb()
    {
        yield return new WaitForSeconds(explosionDelay);
        while (!targetAcquired)
        {
            CheckForEnemies();
            yield return null;
        }
    }

    private void CheckForEnemies()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                targetEnemy = collider.transform;
                targetAcquired = true;
                break;
            }
        }
    }

    private void Update()
    {
        if (targetAcquired && targetEnemy != null)
        {
            Vector3 direction = (targetEnemy.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetEnemy.position) < 0.1f)
            {
                Destroy(targetEnemy.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
