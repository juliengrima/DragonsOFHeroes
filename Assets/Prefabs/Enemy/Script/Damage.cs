using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null) //Si la collision est avec le joueur
        {
            // Inflige des d�g�ts au joueur
            collision.rigidbody.GetComponent<Health>().TakeDamage(damage);

            // D�truit le GameObject
            Destroy(collision.rigidbody.gameObject);

            // Cr�e un GameObject
            GameObject Enemy5 = new GameObject();

            // Attache le script DamageScript au GameObject
            Enemy5.AddComponent<DamageScript>();

            // D�finit la propri�t� damage
            Enemy5.GetComponent<DamageScript>().damage = 10;
        }
    }

}