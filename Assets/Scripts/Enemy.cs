using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f; // Speed of the enemy
    private Rigidbody enemyRb; // Rigidbody component of the enemy
    private GameObject player; // Reference to the player object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the enemy
        player = GameObject.Find("Player"); // Find the player object in the scene
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // Calculate the direction to the player

        enemyRb.AddForce(lookDirection * speed ); // Move the enemy towards the player

        if (transform.position.y < -10) // Check if the enemy has fallen below a certain point
        {
            Destroy(gameObject); // Destroy the enemy object if it falls below the threshold
        }
    }
}
