using UnityEngine.Events;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] int _regenAmount;
    [SerializeField] UnityEvent<GameObject> _onPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifiez si la collision est avec le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtenez le composant Health du joueur
            var health = collision.attachedRigidbody.gameObject.GetComponent<Health>();

            // Augmentez la santé du joueur
            health.GiveLife(_regenAmount);

            // Appelez l'événement _onPicked
            _onPicked.Invoke(gameObject);

            // Détruisez la pièce de monnaie
            //Destroy(gameObject);
        }
    }
}