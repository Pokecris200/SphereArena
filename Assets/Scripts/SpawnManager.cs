using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public GameObject powerupPrefab; // Reference to the powerup prefab
    private float spawnRange = 9f;
    private int enemyCount; // Variable to keep track of the number of enemies
    private int waveNumber = 1; // Variable to keep track of the current wave number

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawn the first powerup
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length; // Count the number of enemies in the scene
        if (enemyCount == 0) // If there are no enemies left
        {
            waveNumber++; // Increment the wave number
            SpawnEnemyWave(waveNumber); // Spawn a new wave of enemies
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); // Spawn a new powerup
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); // Random X position within the spawn range
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // Random Z position within the spawn range
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ); // Create a new position vector for the enemy spawn
        return randomPos;
    }

    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++) // Spawn the specified number of enemies
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); // Instantiate the enemy prefab at a random position
        }
    }
}
