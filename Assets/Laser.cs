using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private float laserSpeed = 1f;
    [SerializeField] private int maxCollisions = 3;

    private int collisionCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FireLaser());
        }
    }

    private IEnumerator FireLaser()
    {
        while (collisionCount < maxCollisions)
        {
            Vector3 direction = Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector3.up;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

            if (hit.collider != null)
            {
                Debug.Log($"Laser hit {hit.collider.name}");
                collisionCount++;
            }

            transform.Translate(direction * laserSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}