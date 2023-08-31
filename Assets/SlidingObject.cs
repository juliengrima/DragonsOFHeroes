using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObject : MonoBehaviour
{
    [SerializeField] private float slideSpeed = 1f;

    private bool isSliding = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSliding = true;
            StartCoroutine(Slide());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSliding = false;
        }
    }

    private IEnumerator Slide()
    {
        while (isSliding)
        {
            transform.Translate(Vector3.down * slideSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
