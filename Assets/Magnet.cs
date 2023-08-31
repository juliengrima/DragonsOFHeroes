using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // La zone d'effet de l'aimant
    public float radius = 10f;

    // La force de l'aimant
    public float force = 100f;

    // Le tag du joueur
    public string playerTag = "Player";

    // La r�f�rence au Rigidbody du joueur
    private Rigidbody2D playerRb;

    // La direction de la force � appliquer au joueur
    private Vector2 forceDirection;

    // Le joueur
    private GameObject player;

    void Start()
    {
        // Trouver le joueur par son tag
        player = GameObject.FindWithTag(playerTag);

        // V�rifier si le joueur existe
        if (player == null)
        {
            // Afficher un message d'erreur
            Debug.LogError("Player not found");
            return;
        }

        // R�cup�rer le composant Rigidbody du joueur
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // V�rifier si le joueur existe
        if (player == null)
        {
            // Afficher un message d'erreur
            Debug.LogError("Player not found");
            return;
        }


        // Appliquer la force au joueur
        playerRb.AddForce(forceDirection * force);

        // Faire pivoter le joueur vers la direction de la force
        playerRb.transform.up = forceDirection;
    }
}