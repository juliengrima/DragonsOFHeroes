using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private object Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject))

        {
            ScoreManager.Instance.AddScore(100);


        }

    }

}
