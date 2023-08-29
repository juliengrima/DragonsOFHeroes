using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // The Rigidbody 2D component for the player.
    public Rigidbody2D rb;

    // The time at which the player was created.
    private float birthTime;

    // The duration of the player's life in seconds.
    private float lifeTime = 120f;

    // The UI TextMesh Pro component for the timer.
    public TextMeshProUGUI timer;

    // The serialize field for the time.
    public float time;

    private void Start()
    {
        birthTime = Time.time;
    }

    // The update function.
    void Update()
    {
        // If the player is still alive, move it based on the input.
        float t = Time.time - birthTime;
        if (t < lifeTime)
        {
        }
        else
        {
            // If the player is dead, destroy it.
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // Update the timer.
        if (timer is null) return;
        timer.text = ((int)t).ToString();
    }
}