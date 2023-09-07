using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleConstraint : MonoBehaviour
{
    // Le GameObject à contraindre
    public GameObject target;

    // Le CircleCollider2D qui délimite la zone de contrainte
    public CircleCollider2D boundary;

    // La distance maximale entre le centre du target et le centre du boundary
    private float maxDistance;
    private Vector3 newPosition;

    void Start()
    {
        // On calcule la distance maximale en soustrayant le rayon du target du rayon du boundary
        maxDistance = boundary.radius - target.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        // On calcule la distance actuelle entre le centre du target et le centre du boundary
        float distance = Vector2.Distance(target.transform.position, boundary.transform.position);

        // Si la distance est supérieure à la distance maximale, on ramène le target à l'intérieur du boundary
        if (distance > maxDistance)
        {
            // On calcule le vecteur directionnel entre le centre du target et le centre du boundary
            Vector2 direction = (target.transform.position - boundary.transform.position).normalized;

            // On calcule la nouvelle position du target en multipliant le vecteur directionnel par la distance maximale et en l’ajoutant au centre du boundary Vector2 newPosition = Vector2.Scale(boundary.transform.position, direction) * maxDistance;

            // On assigne la nouvelle position au target
            target.transform.position = newPosition;
        }
    }
}