using UnityEngine.Events;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] int _regenAmount;
    [SerializeField] UnityEvent<GameObject> _onPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifiez si la collision est avec le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtenez le composant Health du joueur
            var health = collision.attachedRigidbody.gameObject.GetComponent<Health>();

            // Augmentez la sant� du joueur
            health.GiveLife(_regenAmount);

            // Appelez l'�v�nement _onPicked
            _onPicked.Invoke(gameObject);

            // D�truisez la pi�ce de monnaie
            //Destroy(gameObject);
        }
    }
}