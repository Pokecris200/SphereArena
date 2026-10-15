using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions controls;
    public float playerSpeed = 150f; // Adjust this value to control the player movement speed
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float powerupStrength = 15.0f; // Strength of the powerup effect
    [SerializeField] private bool hasPowerup = false;
    public GameObject powerupIndicator; 

    private void Awake()
    {
        controls = new InputSystem_Actions();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        float forwardInput = moveInput.y; 
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * Time.deltaTime * playerSpeed); // Move the player forward/backward
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0); // Position the powerup indicator below the player
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true); // Show the powerup indicator
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false); // Hide the powerup indicator
    }
}
